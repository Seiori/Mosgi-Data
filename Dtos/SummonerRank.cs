using Statikk_Data.Enums;

namespace Mosgi_Data.Dtos;

public readonly record struct SummonerRank(
    long UpdatedAt,
    long SummonerId,
    PlatformRoute PlatformRoute,
    Rank Rank
);