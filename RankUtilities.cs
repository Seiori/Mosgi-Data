using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Statikk_Data.Enums;

namespace Mosgi_Data;

public static class RankUtilities
{
    private const int BaseMultiplier = 100;
    private const int MasterMosgiScore = (int)Tier.Diamond * 400;

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static short CalculateMosgiScore(
        Tier tier, 
        Division division, 
        short leaguePoints
    )
    {
        var t = (int)tier;

        if (t < (int)Tier.Master)
        {
            unchecked 
            {
                return (short)(BaseMultiplier * ((t << 2) - (int)division) + leaguePoints);
            }
        }

        unchecked
        {
            return (short)(MasterMosgiScore + leaguePoints);
        }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte[] CreateRankCacheKey(
        long summonerId,
        PlatformRoute platformRoute
    )
    {
        var keyBuffer = GC.AllocateUninitializedArray<byte>(9);
    
        ref var start = ref MemoryMarshal.GetArrayDataReference(keyBuffer);
    
        start = platformRoute.GetUnderlyingValue();
        Unsafe.WriteUnaligned(ref Unsafe.Add(ref start, 1), summonerId);

        return keyBuffer;
    }
}