using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace System
{
    public struct ValueTuple<T1> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
    {
        public readonly T1 Item1;

        public ValueTuple(T1 item1)
        {
            Item1 = item1;
        }

        public override bool Equals(object obj) => ((IStructuralEquatable)this).Equals(obj, EqualityComparer<object>.Default);

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
                return false;

            return other is ValueTuple<T1> tuple && comparer.Equals(Item1, tuple.Item1);
        }

        int IComparable.CompareTo(object obj) => ((IStructuralComparable)this).CompareTo(obj, Comparer<object>.Default);

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
                return 1;

            if (!(other is ValueTuple<T1> tuple))
                throw new ArgumentException(nameof(other));

            return comparer.Compare(Item1, tuple.Item1);
        }

        public override int GetHashCode() => ((IStructuralEquatable)this).GetHashCode(EqualityComparer<object>.Default);

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer) => comparer.GetHashCode(Item1);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("(");
            sb.Append(Item1);
            sb.Append(")");

            return sb.ToString();
        }

        int ITuple.Length => 1;

        object ITuple.this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return Item1;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }
    }

    public struct ValueTuple<T1, T2> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
    {
        public readonly T1 Item1;
        public readonly T2 Item2;

        public ValueTuple(T1 item1, T2 item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        public override bool Equals(object obj) => ((IStructuralEquatable)this).Equals(obj, EqualityComparer<object>.Default);

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
                return false;

            return other is ValueTuple<T1, T2> tuple && comparer.Equals(Item1, tuple.Item1) && comparer.Equals(Item2, tuple.Item2);
        }

        int IComparable.CompareTo(object obj) => ((IStructuralComparable)this).CompareTo(obj, Comparer<object>.Default);

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
                return 1;

            if (!(other is ValueTuple<T1, T2> tuple))
                throw new ArgumentException(nameof(other));

            int num = comparer.Compare(Item1, tuple.Item1);

            return num != 0 ? num : comparer.Compare(Item2, tuple.Item2);
        }

        public override int GetHashCode() => ((IStructuralEquatable)this).GetHashCode(EqualityComparer<object>.Default);

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer) => ValueTuple.CombineHashCodes(comparer.GetHashCode(Item1), comparer.GetHashCode(Item2));

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("(");
            sb.Append(Item1);
            sb.Append(", ");
            sb.Append(Item2);
            sb.Append(")");

            return sb.ToString();
        }

        int ITuple.Length => 2;

        object ITuple.this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return Item1;
                    case 1: return Item2;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }
    }

    public struct ValueTuple<T1, T2, T3> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
    {
        public readonly T1 Item1;
        public readonly T2 Item2;
        public readonly T3 Item3;

        public ValueTuple(T1 item1, T2 item2, T3 item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }

        public override bool Equals(object obj) => ((IStructuralEquatable)this).Equals(obj, EqualityComparer<object>.Default);

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
                return false;

            return other is ValueTuple<T1, T2, T3> tuple && comparer.Equals(Item1, tuple.Item1) && comparer.Equals(Item2, tuple.Item2) && comparer.Equals(Item3, tuple.Item3);
        }

        int IComparable.CompareTo(object obj) => ((IStructuralComparable)this).CompareTo(obj, Comparer<object>.Default);

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
                return 1;

            if (!(other is ValueTuple<T1, T2, T3> tuple))
                throw new ArgumentException(nameof(other));

            int num1 = comparer.Compare(Item1, tuple.Item1);

            if (num1 != 0)
                return num1;

            int num2 = comparer.Compare(Item2, tuple.Item2);

            return num2 != 0 ? num2 : comparer.Compare(Item3, tuple.Item3);
        }

        public override int GetHashCode() => ((IStructuralEquatable)this).GetHashCode(EqualityComparer<object>.Default);

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer) => ValueTuple.CombineHashCodes(comparer.GetHashCode(Item1), comparer.GetHashCode(Item2), comparer.GetHashCode(Item3));

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("(");
            sb.Append(Item1);
            sb.Append(", ");
            sb.Append(Item2);
            sb.Append(", ");
            sb.Append(Item3);
            sb.Append(")");

            return sb.ToString();
        }

        int ITuple.Length => 3;

        object ITuple.this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return Item1;
                    case 1: return Item2;
                    case 2: return Item3;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }
    }

    public struct ValueTuple<T1, T2, T3, T4> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
    {
        public readonly T1 Item1;
        public readonly T2 Item2;
        public readonly T3 Item3;
        public readonly T4 Item4;

        public ValueTuple(T1 item1, T2 item2, T3 item3, T4 item4)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
            Item4 = item4;
        }

        public override bool Equals(object obj) => ((IStructuralEquatable)this).Equals(obj, EqualityComparer<object>.Default);

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
                return false;

            return other is ValueTuple<T1, T2, T3, T4> tuple
                && comparer.Equals(Item1, tuple.Item1)
                && comparer.Equals(Item2, tuple.Item2)
                && comparer.Equals(Item3, tuple.Item3)
                && comparer.Equals(Item4, tuple.Item4);
        }

        int IComparable.CompareTo(object obj) => ((IStructuralComparable)this).CompareTo(obj, Comparer<object>.Default);

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
                return 1;

            if (!(other is ValueTuple<T1, T2, T3, T4> tuple))
                throw new ArgumentException(nameof(other));

            int num1 = comparer.Compare(Item1, tuple.Item1);

            if (num1 != 0)
                return num1;

            int num2 = comparer.Compare(Item2, tuple.Item2);

            if (num2 != 0)
                return num2;

            int num3 = comparer.Compare(Item3, tuple.Item3);

            return num3 != 0 ? num3 : comparer.Compare(Item4, tuple.Item4);
        }

        public override int GetHashCode() => ((IStructuralEquatable)this).GetHashCode(EqualityComparer<object>.Default);

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer) => ValueTuple.CombineHashCodes(comparer.GetHashCode(Item1), comparer.GetHashCode(Item2), comparer.GetHashCode(Item3), comparer.GetHashCode(Item4));

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("(");
            sb.Append(Item1);
            sb.Append(", ");
            sb.Append(Item2);
            sb.Append(", ");
            sb.Append(Item3);
            sb.Append(", ");
            sb.Append(Item4);
            sb.Append(")");

            return sb.ToString();
        }

        int ITuple.Length => 4;

        object ITuple.this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return Item1;
                    case 1: return Item2;
                    case 2: return Item3;
                    case 3: return Item4;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }
    }

    public struct ValueTuple<T1, T2, T3, T4, T5> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
    {
        public readonly T1 Item1;
        public readonly T2 Item2;
        public readonly T3 Item3;
        public readonly T4 Item4;
        public readonly T5 Item5;

        public ValueTuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
            Item4 = item4;
            Item5 = item5;
        }

        public override bool Equals(object obj) => ((IStructuralEquatable)this).Equals(obj, EqualityComparer<object>.Default);

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
                return false;

            return other is ValueTuple<T1, T2, T3, T4, T5> tuple
                && comparer.Equals(Item1, tuple.Item1)
                && comparer.Equals(Item2, tuple.Item2)
                && comparer.Equals(Item3, tuple.Item3)
                && comparer.Equals(Item4, tuple.Item4)
                && comparer.Equals(Item5, tuple.Item5);
        }

        int IComparable.CompareTo(object obj) => ((IStructuralComparable)this).CompareTo(obj, Comparer<object>.Default);

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
                return 1;

            if (!(other is ValueTuple<T1, T2, T3, T4, T5> tuple))
                throw new ArgumentException(nameof(other));

            int num1 = comparer.Compare(Item1, tuple.Item1);

            if (num1 != 0)
                return num1;

            int num2 = comparer.Compare(Item2, tuple.Item2);

            if (num2 != 0)
                return num2;

            int num3 = comparer.Compare(Item3, tuple.Item3);

            if (num3 != 0)
                return num3;

            int num4 = comparer.Compare(Item4, tuple.Item4);

            return num4 != 0 ? num4 : comparer.Compare(Item5, tuple.Item5);
        }

        public override int GetHashCode() => ((IStructuralEquatable)this).GetHashCode(EqualityComparer<object>.Default);

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer) => ValueTuple.CombineHashCodes(comparer.GetHashCode(Item1), comparer.GetHashCode(Item2), comparer.GetHashCode(Item3), comparer.GetHashCode(Item4), comparer.GetHashCode(Item5));

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("(");
            sb.Append(Item1);
            sb.Append(", ");
            sb.Append(Item2);
            sb.Append(", ");
            sb.Append(Item3);
            sb.Append(", ");
            sb.Append(Item4);
            sb.Append(", ");
            sb.Append(Item5);
            sb.Append(")");

            return sb.ToString();
        }

        int ITuple.Length => 5;

        object ITuple.this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return Item1;
                    case 1: return Item2;
                    case 2: return Item3;
                    case 3: return Item4;
                    case 4: return Item5;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }
    }

    public struct ValueTuple<T1, T2, T3, T4, T5, T6> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
    {
        public readonly T1 Item1;
        public readonly T2 Item2;
        public readonly T3 Item3;
        public readonly T4 Item4;
        public readonly T5 Item5;
        public readonly T6 Item6;

        public ValueTuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
            Item4 = item4;
            Item5 = item5;
            Item6 = item6;
        }

        public override bool Equals(object obj) => ((IStructuralEquatable)this).Equals(obj, EqualityComparer<object>.Default);

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
                return false;

            return other is ValueTuple<T1, T2, T3, T4, T5, T6> tuple
                && comparer.Equals(Item1, tuple.Item1)
                && comparer.Equals(Item2, tuple.Item2)
                && comparer.Equals(Item3, tuple.Item3)
                && comparer.Equals(Item4, tuple.Item4)
                && comparer.Equals(Item5, tuple.Item5)
                && comparer.Equals(Item6, tuple.Item6);
        }

        int IComparable.CompareTo(object obj) => ((IStructuralComparable)this).CompareTo(obj, Comparer<object>.Default);

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
                return 1;

            if (!(other is ValueTuple<T1, T2, T3, T4, T5, T6> tuple))
                throw new ArgumentException(nameof(other));

            int num1 = comparer.Compare(Item1, tuple.Item1);

            if (num1 != 0)
                return num1;

            int num2 = comparer.Compare(Item2, tuple.Item2);

            if (num2 != 0)
                return num2;

            int num3 = comparer.Compare(Item3, tuple.Item3);

            if (num3 != 0)
                return num3;

            int num4 = comparer.Compare(Item4, tuple.Item4);

            if (num4 != 0)
                return num4;

            int num5 = comparer.Compare(Item5, tuple.Item5);

            return num5 != 0 ? num5 : comparer.Compare(Item6, tuple.Item6);
        }

        public override int GetHashCode() => ((IStructuralEquatable)this).GetHashCode(EqualityComparer<object>.Default);

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer) => ValueTuple.CombineHashCodes(
            comparer.GetHashCode(Item1),
            comparer.GetHashCode(Item2),
            comparer.GetHashCode(Item3),
            comparer.GetHashCode(Item4),
            comparer.GetHashCode(Item5),
            comparer.GetHashCode(Item6));

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("(");
            sb.Append(Item1);
            sb.Append(", ");
            sb.Append(Item2);
            sb.Append(", ");
            sb.Append(Item3);
            sb.Append(", ");
            sb.Append(Item4);
            sb.Append(", ");
            sb.Append(Item5);
            sb.Append(", ");
            sb.Append(Item6);
            sb.Append(")");

            return sb.ToString();
        }

        int ITuple.Length => 6;

        object ITuple.this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return Item1;
                    case 1: return Item2;
                    case 2: return Item3;
                    case 3: return Item4;
                    case 4: return Item5;
                    case 5: return Item6;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }
    }

    public struct ValueTuple<T1, T2, T3, T4, T5, T6, T7> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
    {
        public readonly T1 Item1;
        public readonly T2 Item2;
        public readonly T3 Item3;
        public readonly T4 Item4;
        public readonly T5 Item5;
        public readonly T6 Item6;
        public readonly T7 Item7;

        public ValueTuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
            Item4 = item4;
            Item5 = item5;
            Item6 = item6;
            Item7 = item7;
        }

        public override bool Equals(object obj) => ((IStructuralEquatable)this).Equals(obj, EqualityComparer<object>.Default);

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
                return false;

            return other is ValueTuple<T1, T2, T3, T4, T5, T6, T7> tuple
                && comparer.Equals(Item1, tuple.Item1)
                && comparer.Equals(Item2, tuple.Item2)
                && comparer.Equals(Item3, tuple.Item3)
                && comparer.Equals(Item4, tuple.Item4)
                && comparer.Equals(Item5, tuple.Item5)
                && comparer.Equals(Item6, tuple.Item6)
                && comparer.Equals(Item7, tuple.Item7);
        }

        int IComparable.CompareTo(object obj) => ((IStructuralComparable)this).CompareTo(obj, Comparer<object>.Default);

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
                return 1;

            if (!(other is ValueTuple<T1, T2, T3, T4, T5, T6, T7> tuple))
                throw new ArgumentException(nameof(other));

            int num1 = comparer.Compare(Item1, tuple.Item1);

            if (num1 != 0)
                return num1;

            int num2 = comparer.Compare(Item2, tuple.Item2);

            if (num2 != 0)
                return num2;

            int num3 = comparer.Compare(Item3, tuple.Item3);

            if (num3 != 0)
                return num3;

            int num4 = comparer.Compare(Item4, tuple.Item4);

            if (num4 != 0)
                return num4;

            int num5 = comparer.Compare(Item5, tuple.Item5);

            if (num5 != 0)
                return num5;

            int num6 = comparer.Compare(Item6, tuple.Item6);

            return num6 != 0 ? num6 : comparer.Compare(Item7, tuple.Item7);
        }

        public override int GetHashCode() => ((IStructuralEquatable)this).GetHashCode(EqualityComparer<object>.Default);

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer) => ValueTuple.CombineHashCodes(
            comparer.GetHashCode(Item1),
            comparer.GetHashCode(Item2),
            comparer.GetHashCode(Item3),
            comparer.GetHashCode(Item4),
            comparer.GetHashCode(Item5),
            comparer.GetHashCode(Item6),
            comparer.GetHashCode(Item7));

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("(");
            sb.Append(Item1);
            sb.Append(", ");
            sb.Append(Item2);
            sb.Append(", ");
            sb.Append(Item3);
            sb.Append(", ");
            sb.Append(Item4);
            sb.Append(", ");
            sb.Append(Item5);
            sb.Append(", ");
            sb.Append(Item6);
            sb.Append(", ");
            sb.Append(Item7);
            sb.Append(")");

            return sb.ToString();
        }

        int ITuple.Length => 7;

        object ITuple.this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return Item1;
                    case 1: return Item2;
                    case 2: return Item3;
                    case 3: return Item4;
                    case 4: return Item5;
                    case 5: return Item6;
                    case 6: return Item7;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }
    }

    public struct ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple where TRest : ITuple
    {
        public readonly T1 Item1;
        public readonly T2 Item2;
        public readonly T3 Item3;
        public readonly T4 Item4;
        public readonly T5 Item5;
        public readonly T6 Item6;
        public readonly T7 Item7;
        public readonly TRest Rest;

        public ValueTuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, TRest rest)
        {
            if (typeof(TRest).IsValueType)
                throw new ArgumentException(nameof(rest));

            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
            Item4 = item4;
            Item5 = item5;
            Item6 = item6;
            Item7 = item7;
            Rest = rest;
        }

        public override bool Equals(object obj) => ((IStructuralEquatable)this).Equals(obj, EqualityComparer<object>.Default);

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
                return false;

            return other is ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest> tuple
                && comparer.Equals(Item1, tuple.Item1)
                && comparer.Equals(Item2, tuple.Item2)
                && comparer.Equals(Item3, tuple.Item3)
                && comparer.Equals(Item4, tuple.Item4)
                && comparer.Equals(Item5, tuple.Item5)
                && comparer.Equals(Item6, tuple.Item6)
                && comparer.Equals(Item7, tuple.Item7)
                && Comparer.Equals(Rest, tuple.Rest);
        }

        int IComparable.CompareTo(object obj) => ((IStructuralComparable)this).CompareTo(obj, Comparer<object>.Default);

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
                return 1;

            if (!(other is ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest> tuple))
                throw new ArgumentException(nameof(other));

            int num = comparer.Compare(Item1, tuple.Item1);

            if (num != 0)
                return num;

            num = comparer.Compare(Item2, tuple.Item2);

            if (num != 0)
                return num;

            num = comparer.Compare(Item3, tuple.Item3);

            if (num != 0)
                return num;

            num = comparer.Compare(Item4, tuple.Item4);

            if (num != 0)
                return num;

            num = comparer.Compare(Item5, tuple.Item5);

            if (num != 0)
                return num;

            num = comparer.Compare(Item6, tuple.Item6);

            if (num != 0)
                return num;

            num = comparer.Compare(Item7, tuple.Item7);

            return num != 0 ? num : comparer.Compare(Rest, tuple.Rest);
        }

        public override int GetHashCode() => ((IStructuralEquatable)this).GetHashCode(EqualityComparer<object>.Default);

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            if (Rest.Length >= 8)
                return ((IStructuralEquatable)Rest).GetHashCode(comparer);

            switch (8 - Rest.Length)
            {
                case 1:
                    return ValueTuple.CombineHashCodes(comparer.GetHashCode(Item7), ((IStructuralEquatable)Rest).GetHashCode(comparer));
                case 2:
                    return ValueTuple.CombineHashCodes(comparer.GetHashCode(Item6), comparer.GetHashCode(Item7), ((IStructuralEquatable)Rest).GetHashCode(comparer));
                case 3:
                    return ValueTuple.CombineHashCodes(comparer.GetHashCode(Item5), comparer.GetHashCode(Item6), comparer.GetHashCode(Item7), ((IStructuralEquatable)Rest).GetHashCode(comparer));
                case 4:
                    return ValueTuple.CombineHashCodes(comparer.GetHashCode(Item4), comparer.GetHashCode(Item5), comparer.GetHashCode(Item6), comparer.GetHashCode(Item7), ((IStructuralEquatable)Rest).GetHashCode(comparer));
                case 5:
                    return ValueTuple.CombineHashCodes(comparer.GetHashCode(Item3), comparer.GetHashCode(Item4), comparer.GetHashCode(Item5), comparer.GetHashCode(Item6), comparer.GetHashCode(Item7), ((IStructuralEquatable)Rest).GetHashCode(comparer));
                case 6:
                    return ValueTuple.CombineHashCodes(comparer.GetHashCode(Item2), comparer.GetHashCode(Item3), comparer.GetHashCode(Item4), comparer.GetHashCode(Item5), comparer.GetHashCode(Item6), comparer.GetHashCode(Item7), ((IStructuralEquatable)Rest).GetHashCode(comparer));
                case 7:
                    return ValueTuple.CombineHashCodes(comparer.GetHashCode(Item1), comparer.GetHashCode(Item2), comparer.GetHashCode(Item3), comparer.GetHashCode(Item4), comparer.GetHashCode(Item5), comparer.GetHashCode(Item6), comparer.GetHashCode(Item7), ((IStructuralEquatable)Rest).GetHashCode(comparer));
                default:
                    return -1;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("(");
            sb.Append(Item1);
            sb.Append(", ");
            sb.Append(Item2);
            sb.Append(", ");
            sb.Append(Item3);
            sb.Append(", ");
            sb.Append(Item4);
            sb.Append(", ");
            sb.Append(Item5);
            sb.Append(", ");
            sb.Append(Item6);
            sb.Append(", ");
            sb.Append(Item7);
            sb.Append(", ");
            //TODO: Add a better workaround
            sb.Append(Rest.ToString().Replace("(", string.Empty).Replace(")", string.Empty));
            sb.Append(")");

            return sb.ToString();
        }

        int ITuple.Length => 7 + Rest.Length;

        object ITuple.this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return Item1;
                    case 1: return Item2;
                    case 2: return Item3;
                    case 3: return Item4;
                    case 4: return Item5;
                    case 5: return Item6;
                    case 6: return Item7;
                    default: return Rest[index - 7];
                }
            }
        }
    }
}
