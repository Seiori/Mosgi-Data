using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Statikk_Data.Enums;

namespace Mosgi_Data;

public static class MatchUtilities
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (PlatformRoute PlatformRoute, long GameId) ParseMatchId(
        ReadOnlySpan<char> matchId
    )
    {
        var index = matchId.IndexOf('_');
        
        if (PlatformRouteExtensions.TryParse(matchId[..index], out var platformRoute))
        {
            var gameIdSpan = matchId[(index + 1)..];
            
            ref var searchSpace = ref MemoryMarshal.GetReference(gameIdSpan);
            var gameId = 0L;
            
            for (var i = 0; i < gameIdSpan.Length; i++)
            {
                var c = Unsafe.Add(ref searchSpace, i);
                gameId = (gameId << 3) + (gameId << 1) + (c - 48);
            }
            
            return (platformRoute, gameId);
        }
        
        throw new FormatException($"Invalid match ID: {matchId.ToString()}");
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short ParsePatchId(
        ReadOnlySpan<char> patchVersion
    )
    {
        ref var searchSpace = ref MemoryMarshal.GetReference(patchVersion);
        var result = 0;
        var dots = 0;

        for (var i = 0; i < patchVersion.Length; i++)
        {
            var c = Unsafe.Add(ref searchSpace, i);

            if (c is '.')
            {
                if (++dots is 2)
                {
                    break;
                }
                
                continue;
            }

            result = (result << 3) + (result << 1) + (c - 48);
        }

        return (short)result;
    }
}