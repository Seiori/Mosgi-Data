using Statikk_Data.Enums;

namespace Mosgi_Data.Dtos;

public readonly record struct Summoner(
    long Id,
    long UpdatedAt,
    PlatformRoute PlatformRoute,
    short IconId,
    short Level,
    string Puuid,
    string GameName,
    string TagLine
);