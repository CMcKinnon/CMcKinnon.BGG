﻿using CMcKinnon.BGG.Contracts.V2;
using System.Threading.Tasks;

namespace CMcKinnon.BGG.Client
{
    public interface IBGGClientV2
    {
        Task<SearchResult> SearchAsync(string query, ThingType? type = null, bool exact = false);
    }
}