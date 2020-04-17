﻿using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace W3ChampionsStatisticService.PadEvents
{
    [BsonIgnoreExtraElements]
    public class Mmr
    {
        public double rating { get; set; }
        public double rd { get; set; }
        public double vol { get; set; }
    }

    [BsonIgnoreExtraElements]
    [BsonNoId]
    public class PlayerMMrChange
    {
        [BsonElement("id")]
        public string id { get; set; }
        public string battleTag { get; set; }
        public int race { get; set; }

        public bool won { get; set; }
        public Mmr mmr { get; set; }
        public Mmr updatedMmr { get; set; }
        public Ranking ranking { get; set; }
        public Ranking updatedRanking { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Ranking
    {
        public double rp { get; set; }
        public int rank { get; set; }
        public int leagueId { get; set; }
        public int leagueOrder { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class PlayerBlizzard
    {
        public int id { get; set; }
        public int raceId { get; set; }
        public int gamePlayerId { get; set; }
        public int playerColor { get; set; }
        public int teamIndex { get; set; }
        public string toonName { get; set; }
        public bool won { get; set; }
        public bool isAi { get; set; }
        public string battleTag { get; set; }
        public string clanName { get; set; }
        public string avatarId { get; set; }
        public OverallScore overallScore { get; set; }
        public UnitScore unitScore { get; set; }
        public List<Hero> heroes { get; set; }
        public HeroScore heroScore { get; set; }
        public ResourceScore resourceScore { get; set; }
    }

    [BsonIgnoreExtraElements]
    [BsonNoId]
    public class Match
    {
        public int state { get; set; }
        public long startTime { get; set; }
        public int gameMode { get; set; }
        public int gateway { get; set; }
        public string host { get; set; }
        [BsonElement("id")]
        public string id { get; set; }
        public int mapId { get; set; }
        public string map { get; set; }
        public List<PlayerMMrChange> players { get; set; }
        public long endTime { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class OverallScore
    {
        public int UNIT_SCORE { get; set; }
        public int HERO_SCORE { get; set; }
        public int RESOURCE_SCORE { get; set; }
        public int TOTAL_SCORE { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class UnitScore
    {
        public int UNITS_PRODUCED { get; set; }
        public int UNITS_KILLED { get; set; }
        public int STRUCTURES_PRODUCED { get; set; }
        public int STRUCTURES_RAZED { get; set; }
        public int LARGEST_ARMY { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Hero
    {
        public string icon { get; set; }
        public int level { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class HeroScore
    {
        public int HEROES_KILLED { get; set; }
        public int ITEMS_OBTAINED { get; set; }
        public int MERCS_HIRED { get; set; }
        public int EXP_GAINED { get; set; }
        public int STRONGER_HEROES { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class ResourceScore
    {
        public int GOLD_COLLECTED { get; set; }
        public int LUMBER_COLLECTED { get; set; }
        public int RESOURCES_RECVD { get; set; }
        public int RESOURCES_SENT { get; set; }
        public int TECH_PERCENTAGE { get; set; }
        public int GOLD_UPKEEP_LOST { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class MapInfo
    {
        public int elapsedGameTimeTotalSeconds { get; set; }
        public int elapsedGameTimeTotalHours { get; set; }
        public int elapsedGameTimeMinutes { get; set; }
        public int elapsedGameTimeSeconds { get; set; }
        public string elapsedSec { get; set; }
        public string name { get; set; }
        public string mapFile { get; set; }
        public bool isReplay { get; set; }
        public string replayFile { get; set; }
        public int difficulty { get; set; }
        public int campaignIndex { get; set; }
        public int missionIndex { get; set; }
        public string gameType { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Result
    {
        public bool localPlayerWon { get; set; }
        public bool isHDModeEnabled { get; set; }
        public int localPlayerRace { get; set; }
        public string gameName { get; set; }
        public string gameId { get; set; }
        public List<PlayerBlizzard> players { get; set; }
        public MapInfo mapInfo { get; set; }
        public long id { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class MatchFinishedEvent : PadEvent
    {
        public Match match { get; set; }
        public Result result { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class MatchStartedEvent : PadEvent
    {
        public Match match { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class MatchCanceledEvent : PadEvent
    {
        public Match match { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class PadEvent
    {
        public ObjectId Id { get; set; }
    }
}