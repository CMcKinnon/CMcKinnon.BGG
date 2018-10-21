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
                EditDate = geeklist.EditDate.GetSafeDateTime(),
                EditDateTimestamp = geeklist.EditDateTimestamp,
                PostDate = geeklist.PostDate.GetSafeDateTime(),
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
                EditDate = i.EditDate.GetSafeDateTime(),
                PostDate = i.PostDate.GetSafeDateTime(),
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
                EditDate = c.EditDate.GetSafeDateTime(),
                PostDate = c.PostDate.GetSafeDateTime(),
                Date = c.Date.GetSafeDateTime(),
            }).ToList() ?? new List<GeeklistComment>();
        }
    }
}
