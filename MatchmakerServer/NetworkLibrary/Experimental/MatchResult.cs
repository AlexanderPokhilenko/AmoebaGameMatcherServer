﻿﻿using ZeroFormatter;

namespace Libraries.NetworkLibrary.Experimental
{
    //TODO говно
    [ZeroFormattable]
    public class MatchResult
    {
        [Index(0)] public virtual string SpaceshipPrefabName { get; set; }
        [Index(1)] public virtual int CurrentSpaceshipRating { get; set; }
        [Index(2)] public virtual int MatchRatingDelta { get; set; }
        [Index(3)] public virtual int RankingRewardTokens { get; set; }
        [Index(4)] public virtual bool DoubleTokens { get; set; }
    }
}