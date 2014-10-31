namespace BitArrayI
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class BitArray
    {
        private IList<byte> elements;

        public BitArray()
            : this(100000)
        {
        }

        public BitArray(int capacity)
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

        public byte this[int index]
        {
            get
            {
                return this.elements[this.Capacity - 1 - index];
            }
            set
            {
                byte num;
                if(!byte.TryParse(value.ToString(), out num))
                {
                    throw new FormatException("You can assign only 0 and 1 as values.");
                }
                if(num != 1 && num != 0)
                {
                    throw new FormatException("You can assign only 0 and 1 as values.");
                }
                if (this.elements.Count - 1 - index < 0 || this.elements.Count - 1 - index > this.elements.Count)
                {
                    throw new IndexOutOfRangeException("The index must greater than or equal to zero and less than the collection`s size.");
                }
                this.elements[this.Capacity - 1 - index] = value;
            }
        }

        public override string ToString()
        {
            return DecToNum().ToString();
        }

        private BigInteger DecToNum()
        {
            BigInteger result = BigInteger.Zero;
            BigInteger mult = BigInteger.One;
            for (int i = 0; i < this.Capacity; i++)
            {
                if(this[i] == 1)
                {
                    result += mult;

                    int count = 0;
                    for (int j = i + 1; j < this.Capacity; j++)
                    {
                        if(this[j] == 1)
                        {
                            count += 1;
                        }
                    }
                    if(count == 0)
                    {
                        break;
                    }
                }
                mult += mult; // mult = mult * 2
            }
            return result;
        }
    }
}