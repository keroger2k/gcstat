using System.Collections;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;


namespace Gamechanger
{
    public class GCAuthorization
    {
        private const string EDEN_AUTH_KEY = "OOjBrLaXKiW1RuLiyvydwEvzDP6K7V1dQhAozDF/4qA=";
        private const string API_URL = "https://api.team-manager.gc.com";
        private const string AUTH_ENDPOINT = "/auth";

        public HttpResponseMessage MakePostRequest(GCContext context, string payload, string signature, string token = "")
        {
            var http = new HttpClient();
            http.BaseAddress = new Uri(API_URL);
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            http.DefaultRequestHeaders.Add("Gc-Signature", context.nonce + "." + signature);
            http.DefaultRequestHeaders.Add("Gc-Timestamp", context.timestamp.ToString());
            if (!string.IsNullOrEmpty(token))
            {
                http.DefaultRequestHeaders.Add("Gc-Token", token);
            }
            var clientRequestContent = new StringContent(payload, Encoding.UTF8, "application/json");
            return http.PostAsync(AUTH_ENDPOINT, clientRequestContent).Result;
        }

        public GCContext GetNewContext(string? previousSignature = "")
        {
            return new GCContext { nonce = Base64Encode(RandomString(32)), timestamp = GetTimestamp(), previousSignature = previousSignature };
        }

        public string SignPayload(GCContext context, object payload)
        {
            using (IncrementalHash hmacsha256 = IncrementalHash.CreateHMAC(HashAlgorithmName.SHA256, Convert.FromBase64String(EDEN_AUTH_KEY)))
            {
                var values = ValuesForSigner(payload, 0);
                var valstring = string.Join('|', values);
                hmacsha256.AppendData(Encoding.UTF8.GetBytes(context.timestamp.ToString() + "|"));
                hmacsha256.AppendData(Convert.FromBase64String(context.nonce));
                hmacsha256.AppendData(Encoding.UTF8.GetBytes("|"));
                hmacsha256.AppendData(Encoding.UTF8.GetBytes(valstring));
                if (!string.IsNullOrEmpty(context.previousSignature))
                {
                    hmacsha256.AppendData(Encoding.UTF8.GetBytes("|"));
                    hmacsha256.AppendData(Convert.FromBase64String(context.previousSignature));
                }
                var hash = hmacsha256.GetHashAndReset();
                return Convert.ToBase64String(hash);
            }
        }

        public string[] ValuesForSigner(object obj, int indent)
        {
            var propertyArray = new List<string>();
            if (obj == null)
            {
                return new string[] { };
            }
            string indentString = new string(' ', indent);
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties().OrderBy(c => c.Name).ToArray();
            foreach (PropertyInfo property in properties)
            {
                object propValue = property.GetValue(obj, null);
                var elems = propValue as IList;
                if (elems != null)
                {
                    foreach (var item in elems)
                    {
                        ValuesForSigner(item, indent + 3);
                    }
                }
                else
                {
                    // This will not cut-off System.Collections because of the first check
                    if (property.PropertyType.Assembly == objType.Assembly)
                    {
                        ValuesForSigner(propValue, indent + 2);
                    }
                    else
                    {
                        if (propValue != null)
                            propertyArray.Add(propValue.ToString());
                    }
                }
            }
            return propertyArray.ToArray();
        }

        public string GetPasswordHash(string password, string password_salt, string challenge_salt)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, password_salt);
            hashedPassword = BCrypt.Net.BCrypt.HashPassword(hashedPassword, challenge_salt);
            return hashedPassword;
        }

        public string RandomString(int length)
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public int GetTimestamp()
        {
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            return (int)t.TotalSeconds;
        }
    }
}
