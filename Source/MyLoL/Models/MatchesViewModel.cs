using System;
using RiotSharp.Endpoints.MatchEndpoint;
using RiotSharp.Endpoints.StaticDataEndpoint.Champion;
using Humanizer;

namespace MyLoL.Models
{
    public class MatchesViewModel
    {
        public MatchReference MatchInformation { get; set; }
        public ChampionStatic Champion { get; set; }
        public string ChampionImage { get; set; }

        public string MatchDate => MatchInformation.Timestamp.Humanize();

        public MatchesViewModel(MatchReference item)
        {
            MatchInformation = item;
        }
    }
}