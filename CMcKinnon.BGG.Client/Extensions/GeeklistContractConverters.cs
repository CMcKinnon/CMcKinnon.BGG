using CMcKinnon.BGG.Client.XmlContracts;
using CMcKinnon.BGG.Contracts.Geeklists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace CMcKinnon.BGG.Client.Extensions
{
    public static class GeeklistContractConverters
    {
        public static Geeklist ConvertToGeeklist(this _GeeklistResult geeklist)
        {
            return new Geeklist
            {
                StatusCode = (int)HttpStatusCode.OK,
                Id = geeklist.Id,
                Description = geeklist.Description,
                EditDate = !string.IsNullOrEmpty(geeklist.EditDate) ? DateTime.Parse(geeklist.EditDate) : DateTime.MinValue,
                EditDateTimestamp = geeklist.EditDateTimestamp,
                PostDate = !string.IsNullOrEmpty(geeklist.PostDate) ? DateTime.Parse(geeklist.PostDate) : DateTime.MinValue,
                PostDateTimestamp = geeklist.PostDateTimestamp,
                NumberOfItems = geeklist.NumberOfItems,
                Thumbs = geeklist.Thumbs,
                Title = geeklist.Title,
                Username = geeklist.Username,
                Items = ConvertGeeklistItems(geeklist.Items),
                Comments = ConvertGeeklistComments(geeklist.Comments)
            };
        }

        private static List<GeeklistItem> ConvertGeeklistItems(_GeeklistItem[] items)
        {
            return items?.Select(i => new GeeklistItem
            {
                Id = i.Id,
                Username = i.Username,
                ImageId = i.ImageId,
                ObjectType = i.ObjectType,
                ObjectName = i.ObjectName,
                ObjectId = i.ObjectId,
                SubType = i.SubType,
                Thumbs = i.Thumbs,
                Body = i.Body,
                EditDate = !string.IsNullOrEmpty(i.EditDate) ? DateTime.Parse(i.EditDate) : DateTime.MinValue,
                PostDate = !string.IsNullOrEmpty(i.PostDate) ? DateTime.Parse(i.PostDate) : DateTime.MinValue,
                Comments = ConvertGeeklistComments(i.Comments)
            }).ToList() ?? new List<GeeklistItem>();
        }

        private static List<GeeklistComment> ConvertGeeklistComments(_GeeklistComment[] comments)
        {
            return comments?.Select(c => new GeeklistComment
            {
                Username = c.Username,
                Thumbs = c.Thumbs,
                Body = c.Body,
                EditDate = !string.IsNullOrEmpty(c.EditDate) ? DateTime.Parse(c.EditDate) : DateTime.MinValue,
                PostDate = !string.IsNullOrEmpty(c.PostDate) ? DateTime.Parse(c.PostDate) : DateTime.MinValue,
                Date = !string.IsNullOrEmpty(c.Date) ? DateTime.Parse(c.EditDate) : DateTime.MinValue,
            }).ToList() ?? new List<GeeklistComment>();
        }
    }
}
