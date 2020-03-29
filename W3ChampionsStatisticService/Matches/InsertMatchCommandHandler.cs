﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using W3ChampionsStatisticService.MatchEvents;
using W3ChampionsStatisticService.Ports;

namespace W3ChampionsStatisticService.Matches
{
    public class PopulateMatchReadModelHandler : IReadModelHandler
    {
        private readonly IMatchRepository _matchRepository;

        public PopulateMatchReadModelHandler(
            IMatchRepository matchRepository
            )
        {
            _matchRepository = matchRepository;
        }

        public async Task<string> Update(List<MatchFinishedEvent> nextEvents)
        {
            var matchups = nextEvents.Select(e => new Matchup(e)).ToList();
            var lastVersion = await _matchRepository.Upsert(matchups);
            return lastVersion;
        }
    }
}