using CMcKinnon.BGG.Contracts.Search;
using CMcKinnon.BGG.Client.XmlContracts;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CMcKinnon.BGG.Client.Extensions
{
    public static class ContractConverters
    {
        public static IList<BoardgameResult> ConvertToBoardgameResultList(this BoardgameSearchResult boardgames)
        {
            return boardgames.Boardgames?.Select(b => new BoardgameResult
            {
                Name = b.names.FirstOrDefault()?.Value ?? "(no primary name)",
                ObjectId = b.ObjectId,
                YearPublished = b.YearPublished
            })
            .ToList() ?? new List<BoardgameResult>();
        }

        public static IList<Boardgame> ConvertToBoardgameList(this BoardgameSearchResult boardgames)
        {
            return boardgames.Boardgames?.Select(b => new Boardgame
            {
                PrimaryName = b.names.FirstOrDefault(n => n.IsPrimaryName)?.Value ?? "(no primary name)",
                OtherNames = b.names.Where(n => !n.IsPrimaryName).Select(p => p.Value).ToList(),
                ObjectId = b.ObjectId,
                YearPublished = b.YearPublished,
                Age = b.Age,
                Description = b.Description,
                Image = b.Image,
                MaxPlayers = b.MaxPlayers,
                MaxPlayTime = b.MaxPlayTime,
                MinPlayers = b.MinPlayers,
                MinPlayTime = b.MinPlayTime,
                PlayingTime = b.PlayingTime,
                Thumbnail = b.Thumbnail,
                Publishers = b.Publishers?.Select(p => new LinkedObject { ObjectId = p.ObjectId, Value = p.Value}).ToList() ?? new List<LinkedObject>(),
                Artists = b.Artists?.Select(p => new LinkedObject { ObjectId = p.ObjectId, Value = p.Value }).ToList() ?? new List<LinkedObject>(),
                Designers = b.Designers?.Select(p => new LinkedObject { ObjectId = p.ObjectId, Value = p.Value }).ToList() ?? new List<LinkedObject>(),
                Families = b.Families?.Select(p => new LinkedObject { ObjectId = p.ObjectId, Value = p.Value }).ToList() ?? new List<LinkedObject>(),
                Honors = b.Honors?.Select(p => new LinkedObject { ObjectId = p.ObjectId, Value = p.Value }).ToList() ?? new List<LinkedObject>(),
                Implementations = b.Implementations?.Select(p => new LinkedObject { ObjectId = p.ObjectId, Value = p.Value }).ToList() ?? new List<LinkedObject>(),
                Mechanics = b.Mechanics?.Select(p => new LinkedObject { ObjectId = p.ObjectId, Value = p.Value }).ToList() ?? new List<LinkedObject>(),
                PodcastEpisodes = b.PodcastEpisodes?.Select(p => new LinkedObject { ObjectId = p.ObjectId, Value = p.Value }).ToList() ?? new List<LinkedObject>(),
                Subdomains = b.Subdomains?.Select(p => new LinkedObject { ObjectId = p.ObjectId, Value = p.Value }).ToList() ?? new List<LinkedObject>(),
                Versions = b.Versions?.Select(p => new LinkedObject { ObjectId = p.ObjectId, Value = p.Value }).ToList() ?? new List<LinkedObject>(),
                SuggestedPlayerCountPoll = ConvertPlayerCountPoll(b.Polls),
                LanguageDependencePoll = ConvertLanguageDependence(b.Polls),
                PlayerAgePoll = ConvertPlayerAgePoll(b.Polls)
            })
            .ToList() ?? new List<Boardgame>();
        }

        private static SuggestedPlayerCountPoll ConvertPlayerCountPoll(Poll[] polls)
        {
            Poll poll = polls.FirstOrDefault(p => p.Name == "suggested_numplayers");
            if (poll == null)
            {
                return null;
            }

            return new SuggestedPlayerCountPoll
            {
                TotalVotes = poll.TotalVotes,
                Results = poll.Results.Select(r => new SuggestedPlayerCountResult
                {
                    NumberOfPlayers = r.NumberOfPlayers,
                    BestVotes = r.Results.FirstOrDefault(rr => rr.Value == "Best")?.NumberOfVotes ?? 0,
                    RecommendedVotes = r.Results.FirstOrDefault(rr => rr.Value == "Recommended")?.NumberOfVotes ?? 0,
                    NotRecommendedVotes = r.Results.FirstOrDefault(rr => rr.Value == "Not Recommended")?.NumberOfVotes ?? 0
                }).ToList()
            };
        }

        private static LanguageDependencePoll ConvertLanguageDependence(Poll[] polls)
        {
            Poll poll = polls.FirstOrDefault(p => p.Name == "language_dependence");
            if (poll == null)
            {
                return null;
            }

            PollResults result = poll.Results.FirstOrDefault();
            if (result == null)
            {
                return null;
            }
            return new LanguageDependencePoll
            {
                TotalVotes = poll.TotalVotes,
                NoNecessaryInGameTextVotes = result.Results.FirstOrDefault(rr => rr.Level == 1)?.NumberOfVotes ?? 0,
                SomeNecessaryInGameTextVotes = result.Results.FirstOrDefault(rr => rr.Level == 2)?.NumberOfVotes ?? 0,
                ModerateInGameTextVotes = result.Results.FirstOrDefault(rr => rr.Level == 3)?.NumberOfVotes ?? 0,
                ExtensiveInGameTextVotes = result.Results.FirstOrDefault(rr => rr.Level == 4)?.NumberOfVotes ?? 0,
                UnplayableInAnotherLanguageVotes = result.Results.FirstOrDefault(rr => rr.Level ==5)?.NumberOfVotes ?? 0
            };
        }

        private static PlayerAgePoll ConvertPlayerAgePoll(Poll[] polls)
        {
            Poll poll = polls.FirstOrDefault(p => p.Name == "suggested_playerage");
            if (poll == null)
            {
                return null;
            }

            PollResults result = poll.Results.FirstOrDefault();
            if (result == null)
            {
                return null;
            }
            return new PlayerAgePoll
            {
                TotalVotes = poll.TotalVotes,
                Age2Votes = result.Results.FirstOrDefault(rr => rr.Value == "2")?.NumberOfVotes ?? 0,
                Age3Votes = result.Results.FirstOrDefault(rr => rr.Value == "3")?.NumberOfVotes ?? 0,
                Age4Votes = result.Results.FirstOrDefault(rr => rr.Value == "4")?.NumberOfVotes ?? 0,
                Age5Votes = result.Results.FirstOrDefault(rr => rr.Value == "5")?.NumberOfVotes ?? 0,
                Age6Votes = result.Results.FirstOrDefault(rr => rr.Value == "6")?.NumberOfVotes ?? 0,
                Age8Votes = result.Results.FirstOrDefault(rr => rr.Value == "8")?.NumberOfVotes ?? 0,
                Age10Votes = result.Results.FirstOrDefault(rr => rr.Value == "10")?.NumberOfVotes ?? 0,
                Age12Votes = result.Results.FirstOrDefault(rr => rr.Value == "12")?.NumberOfVotes ?? 0,
                Age14Votes = result.Results.FirstOrDefault(rr => rr.Value == "14")?.NumberOfVotes ?? 0,
                Age16Votes = result.Results.FirstOrDefault(rr => rr.Value == "16")?.NumberOfVotes ?? 0,
                Age18Votes = result.Results.FirstOrDefault(rr => rr.Value == "18")?.NumberOfVotes ?? 0,
                Age21AndUpVotes = result.Results.FirstOrDefault(rr => rr.Value == "21 and up")?.NumberOfVotes ?? 0
            };
        }
    }
}
