namespace Gamechanger
{
    public class AuthToken
    {
        public string type { get; set; }    
        public Token access { get; set; }    
        public Token refresh { get; set; }    
    }

    public class Token
    {
        public string data { get; set; }
        public int expires { get; set; }

    }
}
