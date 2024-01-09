using System.Text;
using MurmurHash.Net;

namespace Core.Extensions;

public static class StringHashingExtenstion
{
    public static uint Hash(this string str)
    {
        return MurmurHash3.Hash32(bytes: Encoding.UTF8.GetBytes(str), seed: 123456U);
    }
}