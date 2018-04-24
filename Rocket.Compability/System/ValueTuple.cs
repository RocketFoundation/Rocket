using System.Collections;
using System.Runtime.CompilerServices;

namespace System
{
    public class ValueTuple : IEquatable<ValueTuple>, IStructuralEquatable, IStructuralComparable, IComparable, IComparable<ValueTuple>, ITuple
    {
        int IComparable.CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            if (!(obj is ValueTuple))
                throw new ArgumentException(nameof(obj));

            return 0;
        }

        int IComparable<ValueTuple>.CompareTo(ValueTuple other) => 0;

        bool IEquatable<ValueTuple>.Equals(ValueTuple other) => true;

        int IStructuralComparable.CompareTo(object other, IComparer comparer) => ((IComparable) this).CompareTo(other);

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer) => Equals(other);

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer) => GetHashCode();

        object ITuple.this[int index] => throw new IndexOutOfRangeException();

        int ITuple.Length => 0;
        internal static int CombineHashCodes(int h1, int h2) => (int) (((uint) ((h1 << 5) | (int) ((uint) h1 >> 27)) + (uint) h1) ^ (uint) h2);
        internal static int CombineHashCodes(int h1, int h2, int h3) => CombineHashCodes(CombineHashCodes(h1, h2), h3);
        internal static int CombineHashCodes(int h1, int h2, int h3, int h4) => CombineHashCodes(CombineHashCodes(h1, h2), CombineHashCodes(h3, h4));
        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5) => CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), h5);
        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6) => CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6));
        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6, int h7) => CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6, h7));
        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6, int h7, int h8) => CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6, h7, h8));

        public static ValueTuple<T1> Create<T1>(T1 item1) => new ValueTuple<T1>(item1);
        public static ValueTuple<T1, T2> Create<T1, T2>(T1 item1, T2 item2) => new ValueTuple<T1, T2>(item1, item2);
        public static ValueTuple<T1, T2, T3> Create<T1, T2, T3>(T1 item1, T2 item2, T3 item3) => new ValueTuple<T1, T2, T3>(item1, item2, item3);
        public static ValueTuple<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4) => new ValueTuple<T1, T2, T3, T4>(item1, item2, item3, item4);
        public static ValueTuple<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5) => new ValueTuple<T1, T2, T3, T4, T5>(item1, item2, item3, item4, item5);
        public static ValueTuple<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6) => new ValueTuple<T1, T2, T3, T4, T5, T6>(item1, item2, item3, item4, item5, item6);
        public static ValueTuple<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7) => new ValueTuple<T1, T2, T3, T4, T5, T6, T7>(item1, item2, item3, item4, item5, item6, item7);
        public static ValueTuple<T1, T2, T3, T4, T5, T6, T7, ValueTuple<T8>> Create<T1, T2, T3, T4, T5, T6, T7, T8>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8) => new ValueTuple<T1, T2, T3, T4, T5, T6, T7, ValueTuple<T8>>(item1, item2, item3, item4, item5, item6, item7, new ValueTuple<T8>(item8));

        public override bool Equals(object obj) => obj is ValueTuple;

        public override int GetHashCode() => 0;

        public override string ToString() => "()";
    }
}