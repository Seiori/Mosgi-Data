using System.Runtime.InteropServices;
using Statikk_Data.Enums;

namespace Mosgi_Data.Dtos;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct Rank(
    Tier Tier,
    Division Division,
    short LeaguePoints,
    short Wins,
    short Losses
);