namespace CMcKinnon.BGG.Client.Contracts.Boardgames
{
    public class LanguageDependencePoll
    {
        public uint TotalVotes { get; set; }

        public uint NoNecessaryInGameTextVotes { get; set; }
        public uint SomeNecessaryInGameTextVotes { get; set; }
        public uint ModerateInGameTextVotes { get; set; }
        public uint ExtensiveInGameTextVotes { get; set; }
        public uint UnplayableInAnotherLanguageVotes { get; set; }
    }
}
