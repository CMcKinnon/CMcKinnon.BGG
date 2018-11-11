using CMcKinnon.BGG.Client.XmlContracts;
using CMcKinnon.BGG.Client.Contracts.Boardgames;
using CMcKinnon.BGG.Client.Contracts.Search;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace CMcKinnon.BGG.Client.Extensions
{
    public static class BoardgameContractConverters
    {
        public static IList<BoardgameResult> ConvertToBoardgameResultList(this _BoardgameSearchResult boardgames)
        {
            return boardgames.Boardgames?.Select(b => new BoardgameResult
            {
                StatusCode = (int)HttpStatusCode.OK,
                Name = b.names.FirstOrDefault()?.Value ?? "(no primary name)",
                ObjectId = b.ObjectId,
                YearPublished = b.YearPublished
            })
            .ToList() ?? new List<BoardgameResult>();
        }

        public static IList<Boardgame> ConvertToBoardgameList(this _BoardgameSearchResult boardgames)
        {
            return boardgames.Boardgames?.Select(b => new Boardgame
            {
                StatusCode = (int)HttpStatusCode.OK,
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
                Publishers = b.Publishers?.Select(p => new LinkedObject { ObjectId = p.ObjectId, Value = p.Value }).ToList() ?? new List<LinkedObject>(),
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
                PlayerAgePoll = ConvertPlayerAgePoll(b.Polls),
                Comments = b.Comments?.Select(c => new Comment { UserName = c.UserName, Rating = c.Rating, Text = c.Value }).ToList() ?? new List<Comment>(),
                Statistics = ConvertStatistics(b.Statistics)
            })
            .ToList() ?? new List<Boardgame>();
        }

        private static SuggestedPlayerCountPoll ConvertPlayerCountPoll(_Poll[] polls)
        {
            _Poll poll = polls.FirstOrDefault(p => p.Name == "suggested_numplayers");
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

        private static LanguageDependencePoll ConvertLanguageDependence(_Poll[] polls)
        {
            _Poll poll = polls.FirstOrDefault(p => p.Name == "language_dependence");
            if (poll == null)
            {
                return null;
            }

            _PollResults result = poll.Results.FirstOrDefault();
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
                UnplayableInAnotherLanguageVotes = result.Results.FirstOrDefault(rr => rr.Level == 5)?.NumberOfVotes ?? 0
            };
        }

        private static PlayerAgePoll ConvertPlayerAgePoll(_Poll[] polls)
        {
            _Poll poll = polls.FirstOrDefault(p => p.Name == "suggested_playerage");
            if (poll == null)
            {
                return null;
            }

            _PollResults result = poll.Results.FirstOrDefault();
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

        private static Statistics ConvertStatistics(_Statistics statistics)
        {
            if (statistics == null)
            {
                return null;
            }

            return new Statistics
            {
                Page = statistics.Page,
                NumberOfUserRatings = statistics.Ratings?.NumberOfUserRatings ?? 0,
                AverageRating = statistics.Ratings?.AverageRating ?? 0,
                BayesAverageRating = statistics.Ratings?.BayesAverageRating ?? 0,
                StandardDeviation = statistics.Ratings?.StandardDeviation ?? 0,
                Median = statistics?.Ratings.Median ?? 0,
                NumberOfUsersOwning = statistics.Ratings?.NumberOfUsersOwning ?? 0,
                NumberOfUsersWantingToTrade = statistics.Ratings?.NumberOfUsersWantingToTrade ?? 0,
                NumberOfUsersWantingInTrade = statistics.Ratings?.NumberOfUsersWantingInTrade ?? 0,
                NumberOfUsersWishing = statistics.Ratings?.NumberOfUsersWishing ?? 0,
                NumberOfComments = statistics.Ratings?.NumberOfComments ?? 0,
                NumberOfWeightVotes = statistics.Ratings?.NumberOfWeightVotes ?? 0,
                AverageWeight = statistics.Ratings?.AverageWeight ?? 0,
                Ranks = statistics.Ratings?.Ranks?.Ranks?.Select(r => new Rank
                {
                    Type = r.Type,
                    BayesAverage = r.BayesAverage,
                    FriendlyName = r.FriendlyName,
                    Id = r.Id,
                    Name = r.Name,
                    Value = r.Value
                }).ToList() ?? new List<Rank>()
            };
        }
    }
}
