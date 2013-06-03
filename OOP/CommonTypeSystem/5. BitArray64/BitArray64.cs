using System;
using System.Collections.Generic;

public class BitArray64 : IEnumerable<int>
{
    private ulong number;

    public ulong Number
    {
        get
        {
            return this.number;
        }
    }

    public BitArray64(ulong number)
    {
        this.number = number;
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 63; i >= 0; i--)
        {
            yield return this[i];
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public override bool Equals(object obj)
    {
        BitArray64 bitArray = obj as BitArray64;

        if (bitArray == null)
        {
            return false;
        }
        else if (this.Number.Equals(bitArray.Number))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override int GetHashCode()
    {
        return this.Number.GetHashCode();
    }

    public int this[int index]
    {
        get
        {
            if (index < 0 || index > 63)
            {
                throw new ArgumentOutOfRangeException("The index cannot be out of bounds [0..63]!");
            }
            return (int)((Number >> index) & 1);
        }
    }

    public static bool operator ==(BitArray64 bitArray1, BitArray64 bitArray2)
    {
        return BitArray64.Equals(bitArray1, bitArray2);
    }

    public static bool operator !=(BitArray64 bitArray1, BitArray64 bitArray2)
    {
        return !(BitArray64.Equals(bitArray1, bitArray2));
    }
}

