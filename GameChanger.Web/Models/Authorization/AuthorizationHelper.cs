using Gamechanger;
using System.Text.Json;

namespace GameChanger.Web.Authorization
{
    public class AuthorizationHelper
    {
        private static string _token;

        public static string GetAuthorizationToken(string username, string password)
        {
            if(string.IsNullOrEmpty(_token))
            {
                GCAuthorization gcAuth = new GCAuthorization();

                //Console.WriteLine("\nRequesting Client Token...");

                var clientRequestPayload = new ClientAuthorizationRequest { client_id = "11c584aa-1e12-4efc-986f-891ae0d40262", type = "client-auth" };
                var context1 = gcAuth.GetNewContext();
                var clientRequestSignature = gcAuth.SignPayload(context1, clientRequestPayload);

                var clientAuthorizationRequest = gcAuth.MakePostRequest(context1, JsonSerializer.Serialize(clientRequestPayload), clientRequestSignature);
                var clientRequestContentResult = clientAuthorizationRequest.Content.ReadAsStringAsync().Result;
                var p1Signature = clientAuthorizationRequest.Headers.First(c => c.Key == "gc-signature").Value.First().Split('.')[1]; ;
                var clientResponse = JsonSerializer.Deserialize<ClientAuthorizationResponse>(clientRequestContentResult);

                //Console.WriteLine("\nGot Client Token: \n" + clientResponse.token);
                //Console.WriteLine("\nRequesting Password Authentication...");

                var passwordRequestPayload = new PasswordChallengeRequest { email = username };
                var context2 = gcAuth.GetNewContext(p1Signature);
                var passwordRequestSignature = gcAuth.SignPayload(context2, passwordRequestPayload);

                var passwordAuthorizationRequest = gcAuth.MakePostRequest(context2, JsonSerializer.Serialize(passwordRequestPayload), passwordRequestSignature, clientResponse.token);
                var passwordRequestContentResults = passwordAuthorizationRequest.Content.ReadAsStringAsync().Result;
                var p2Signature = passwordAuthorizationRequest.Headers.First(c => c.Key == "gc-signature").Value.First().Split('.')[1]; ;
                var passwordResponse = JsonSerializer.Deserialize<PasswordChallengeResponse>(passwordRequestContentResults);

                //Console.WriteLine(string.Format("\nGot Password Challenge Info:\n\talg:{0}, challenge_salt: {1}, password_salt{2}", passwordResponse.password_params.alg, passwordResponse.challenge_params.salt, passwordResponse.password_params.salt));
                //Console.WriteLine("\nPerform authenication....");

                var encPassword = gcAuth.GetPasswordHash(password, passwordResponse.password_params.salt, passwordResponse.challenge_params.salt);
                var passwordConfirmationRequestPayload = new PasswordConfirmationRequest { password = encPassword };
                var context3 = gcAuth.GetNewContext(p2Signature);
                var passwordChallengeRequestSignature = gcAuth.SignPayload(context3, passwordConfirmationRequestPayload);
                var passwordChallengeRequest = gcAuth.MakePostRequest(context3, JsonSerializer.Serialize(passwordConfirmationRequestPayload), passwordChallengeRequestSignature, clientResponse.token);
                var passwordChallengeRequestcontentResults = passwordChallengeRequest.Content.ReadAsStringAsync().Result;
                var challengeResponse = JsonSerializer.Deserialize<AuthToken>(passwordChallengeRequestcontentResults);
                //Console.WriteLine("\nReceived new JWT Token:\n");
                //Console.WriteLine(challengeResponse.access.data);
                _token = challengeResponse.access.data;

            }
            return _token;
        }
    }
}
