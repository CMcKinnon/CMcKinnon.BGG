using System;
using System.Collections.Generic;
using System.Linq;
using CMcKinnon.BGG.Client.XmlContracts;
using CMcKinnon.BGG.Contracts.Threads;

namespace CMcKinnon.BGG.Client.Extensions
{
    public static class ForumThreadContractConverters
    {
        public static ForumThread ConvertToForumThread(this _ForumThreadResult thread)
        {
            return new ForumThread
            {
                Title = thread.Channel?.Title,
                Description = thread.Channel?.Description,
                Language = thread.Channel?.Language,
                LastBuildDate = !string.IsNullOrEmpty(thread.Channel?.LastBuildDate) ? DateTime.Parse(thread.Channel?.LastBuildDate) : DateTime.MinValue,
                PublicationDate = !string.IsNullOrEmpty(thread.Channel?.PublicationDate) ? DateTime.Parse(thread.Channel?.PublicationDate) : DateTime.MinValue,
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
                PublicationDate = !string.IsNullOrEmpty(i.PublicationDate) ? DateTime.Parse(i.PublicationDate) : DateTime.MinValue
            }).OrderBy(c => c.PublicationDate).ToList() ?? new List<ForumThreadComment>();
        }
    }
}
