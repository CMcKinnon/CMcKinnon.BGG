using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using CMcKinnon.BGG.Client.XmlContracts;
using CMcKinnon.BGG.Client.Contracts.Threads;

namespace CMcKinnon.BGG.Client.Extensions
{
    public static class ForumThreadContractConverters
    {
        public static ForumThread ConvertToForumThread(this _ForumThreadResult thread)
        {
            return new ForumThread
            {
                StatusCode = (int)HttpStatusCode.OK,
                Title = thread.Channel?.Title,
                Description = thread.Channel?.Description,
                Language = thread.Channel?.Language,
                LastBuildDate = (DateTime)thread.Channel?.LastBuildDate.GetSafeDateTime(),
                PublicationDate = (DateTime)thread.Channel?.PublicationDate.GetSafeDateTime(),
                Link = thread.Channel?.Link,
                Webmaster = thread.Channel?.Webmaster,
                Image = ConvertForumThreadImage(thread.Channel?.Image),
                Comments = ConvertForumThreadComments(thread.Channel?.Items)
            };
        }

        private static ForumThreadImage ConvertForumThreadImage(_ThreadImage image)
        {
            return new ForumThreadImage
            {
                Link = image?.Link,
                Title = image?.Title,
                Url = image?.Url
            };
        }

        private static List<ForumThreadComment> ConvertForumThreadComments(_ThreadItem[] items)
        {
            return items?.Select(i => new ForumThreadComment
            {
                Title = i.Title,
                CommentText = i.Description,
                Creator = i.Creator,
                Guid = i.Guid,
                Link = i.Link,
                PublicationDate = i.PublicationDate.GetSafeDateTime()
            }).OrderBy(c => c.PublicationDate).ToList() ?? new List<ForumThreadComment>();
        }
    }
}
