namespace Gamechanger
{
    /// <summary>
    /// Properties appear to have order significance for API. Sort of annoying.
    /// </summary>
    public class PasswordChallengeRequest
    {
        /// <summary>
        /// Options;
        ///     user-auth
        ///     login-token
        /// </summary>
        public virtual string type { get { return "user-auth"; } }

        /// <summary>
        /// 
        /// </summary>
        public string email { get; set; } 
    }

    public class WebPasswordChallengeRequest : PasswordChallengeRequest
    {
        public override string type { get { return "login-token"; } }
        /// <summary>
        ///  Options:
        ///     email
        /// </summary>
        public string deliver { get { return "email"; } }

        /// <summary>
        ///  Options:
        ///     required_login
        /// </summary>
        public string reason { get { return "required_login"; } }

    }
}
