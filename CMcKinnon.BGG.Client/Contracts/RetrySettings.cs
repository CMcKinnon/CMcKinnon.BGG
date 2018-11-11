namespace CMcKinnon.BGG.Client.Contracts
{
    public class RetrySettings
    {
        public bool Retry { get; set; }
        public int RetryCount { get; set; }
        public int WaitSeconds { get; set; }
    }
}
