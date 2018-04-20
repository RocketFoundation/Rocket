namespace Rocket.Compability.System
{
    public static class ValueTuple
    {
        internal static int CombineHashCodes(int h1, int h2)
        {
            uint num = (uint)(h1 << 5 | (int)((uint)h1 >> 27));
            return (int)(num + (uint)h1 ^ (uint)h2);
        }
        
        internal static int CombineHashCodes(int h1, int h2, int h3) => CombineHashCodes(CombineHashCodes(h1, h2), h3);
        internal static int CombineHashCodes(int h1, int h2, int h3, int h4) => CombineHashCodes(CombineHashCodes(h1, h2), CombineHashCodes(h3, h4));
        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5) => CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), h5);
        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6) => CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6));
        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6, int h7) => CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6, h7));
        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6, int h7, int h8) => CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6, h7, h8));
    }
}
