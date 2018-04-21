namespace System
{
    public static class Tuple
    {
        public static Tuple<T1> Create<T1>(T1 item1) => new Tuple<T1>(item1);
        public static Tuple<T1, T2> Create<T1, T2>(T1 item1, T2 item2) => new Tuple<T1, T2>(item1, item2);
        public static Tuple<T1, T2, T3> Create<T1, T2, T3>(T1 item1, T2 item2, T3 item3) => new Tuple<T1, T2, T3>(item1, item2, item3);
        public static Tuple<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4) => new Tuple<T1, T2, T3, T4>(item1, item2, item3, item4);
        public static Tuple<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5) => new Tuple<T1, T2, T3, T4, T5>(item1, item2, item3, item4, item5);
        public static Tuple<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6) => new Tuple<T1, T2, T3, T4, T5, T6>(item1, item2, item3, item4, item5, item6);
        public static Tuple<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7) => new Tuple<T1, T2, T3, T4, T5, T6, T7>(item1, item2, item3, item4, item5, item6, item7);
        public static Tuple<T1, T2, T3, T4, T5, T6, T7, Tuple<T8>> Create<T1, T2, T3, T4, T5, T6, T7, T8>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8) => new Tuple<T1, T2, T3, T4, T5, T6, T7, Tuple<T8>>(item1, item2, item3, item4, item5, item6, item7, new Tuple<T8>(item8));
        
        internal static int CombineHashCodes(int h1, int h2) => (h1 << 5) + h1 ^ h2;
        internal static int CombineHashCodes(int h1, int h2, int h3) => CombineHashCodes(CombineHashCodes(h1, h2), h3);
        internal static int CombineHashCodes(int h1, int h2, int h3, int h4) => CombineHashCodes(CombineHashCodes(h1, h2), CombineHashCodes(h3, h4));
        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5) => CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), h5);
        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6) => CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6));
        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6, int h7) => CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6, h7));
        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6, int h7, int h8) => CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6, h7, h8));
    }
}