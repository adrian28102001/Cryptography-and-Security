namespace Lab1.BlockCipher.DSE;

public static class BitArray
{
    public static int[] ToBits(int decimalNumber, int numberOfBits)  
    {  
        var bitarray = new int[numberOfBits];  
        var k = numberOfBits-1;  
        var bd = Convert.ToString(decimalNumber, 2).ToCharArray();  
  
        for (var i = bd.Length - 1; i >= 0; --i,--k)  
        {  
            if (bd[i] == '1')  
                bitarray[k] = 1;  
            else  
                bitarray[k] = 0;  
        }  
  
        while(k >= 0)  
        {  
            bitarray[k] = 0;  
            --k;  
        }  
  
        return bitarray;  
    }  
  
    public static int ToDecimal(int[] bitsArray)  
    {  
        var stringValue = bitsArray.Aggregate("", (current, t) => current + t.ToString());
        var DecimalValue = Convert.ToInt32(stringValue, 2);  
  
        return DecimalValue;  
    }  
}