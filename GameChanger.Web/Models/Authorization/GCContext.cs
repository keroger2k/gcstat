namespace Gamechanger
{
    public class GCContext
    {
        public string nonce { get; set; }
        public int timestamp { get; set; }
        public string? previousSignature { get; set; }   

        public GCContext()
        {
        }

        public GCContext(string previousSignature)
        {
            this.previousSignature = previousSignature;
        }
    }
}