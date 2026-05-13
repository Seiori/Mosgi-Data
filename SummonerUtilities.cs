using System.IO.Hashing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Mosgi_Data;

public static class SummonerUtilities
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long HashPuuid(
        string puuid
    )
    {
        return (long)XxHash3.HashToUInt64(
            MemoryMarshal.AsBytes(
                puuid.AsSpan()
            )
        );
    }
}