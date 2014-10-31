namespace BitArrayI
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class BigInteger
    {
        private IList<byte> elements;

        public BigInteger()
            : this(4)
        {

        }

        public BigInteger(int capacity)
        {
            this.elements = new byte[capacity];
        }

        public int Capacity 
        {
            get
            {
                return this.elements.Count;
            }
        }

        public int Count
        {
            get
            {
                return this.ToString().Length;
            }
        }

        public byte this[int index]
        {
            get
            {
                return this.elements[this.Capacity - index];
            }
            set
            {
                this.elements[this.Capacity - index] = value;
            }
        }

        public static BigInteger Zero
        {
            get
            {
                BigInteger zero = new BigInteger();
                zero[1] = 0;

                return zero;
            }
        }

        public static BigInteger One
        {
            get
            {
                BigInteger one = new BigInteger();
                one[1] = 1;

                return one;
            }
        }

        public static bool operator >(BigInteger n1, BigInteger n2)
        {
            if (n1.Count > n2.Count)
            {
                return true;
            }
            if (n1.Count < n2.Count)
            {
                return false;
            }

            for (int i = n1.Count; i > 0; i--)
            {
                if (n1[i] < n2[i])
                {
                    return false;
                }
                if (n1[i] > n2[i])
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator <(BigInteger n1, BigInteger n2)
        {
            if (n1.Count < n2.Count)
            {
                return true;
            }
            if (n1.Count > n2.Count)
            {
                return false;
            }

            for (int i = n1.Count; i > 0; i--)
            {
                if (n1[i] > n2[i])
                {
                    return false;
                }
                if (n1[i] < n2[i])
                {
                    return true;
                }
            }

            return false;
        }

        public static BigInteger operator +(BigInteger n1, BigInteger n2)
        {
            BigInteger num = BigInteger.Zero;
            BigInteger max = n1 > n2 ? n1 : n2;
            BigInteger min = n1 < n2 ? n1 : n2;
            Dictionary<int, byte> adds = new Dictionary<int, byte>();

            for (int i = 1; i <= max.Count; i++)
            {
                if(i >= num.Capacity)
                {
                    num.EnsureCapacity();
                }

                if(i <= min.Count)
                {
                    byte add1 = min[i];
                    byte add2 = max[i];
                    int sum = add1 + add2;

                    if(sum >= 10)
                    {
                        byte remainder = (byte)(sum % 10);
                        byte upNum = (byte)(sum / 10);
                        adds.Add(i + 1, upNum);
                        num[i] = remainder;
                    }
                    else
                    {
                        num[i] = (byte)sum;
                    }
                }
                else
                {
                    num[i] = max[i];
                }
            }

            foreach (var add in adds)
            {
                int index = add.Key;
                byte value = add.Value;
                num.AddRemainder(index, value);
            }

            return num;
        }

        public static BigInteger operator ++(BigInteger n1)
        {
            BigInteger num = n1 + BigInteger.One;

            return num;
        }

        public static BigInteger operator *(BigInteger n1, BigInteger n2)
        {
            BigInteger num = BigInteger.Zero;
            for (BigInteger i = BigInteger.Zero; i < n2; i++)
            {
                num += n1;
            }
            return num;
        }

        private void AddRemainder(int index, byte value)
        {
            int sum = this[index] + value;
            byte remainder = (byte)(sum % 10);
            byte upNum = (byte)(sum / 10);

            if(sum >= 10)
            {
                this[index] = remainder;
                this.AddRemainder(index + 1, upNum);
            }
            else
            {
                this[index] = remainder;
            }
        }

        private void EnsureCapacity()
        {
            BigInteger num = new BigInteger(this.Capacity * 2);

            for (int i = 1; i <= this.Capacity; i++)
            {
                num[i] = this[i];
            }
            this.elements = num.elements;
        }

        public override string ToString()
        {
            StringBuilder numAsString = new StringBuilder();

            bool trailing = true;

            foreach(var el in this.elements)
            {
                if(el == 0 && trailing)
                {
                    continue;
                }
                numAsString.Append(el);
                trailing = false;
            }

            if(trailing)
            {
                numAsString.Append(0);
            }

            return numAsString.ToString();
        }
    }
}