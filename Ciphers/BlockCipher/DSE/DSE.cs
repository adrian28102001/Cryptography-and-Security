namespace Lab1.BlockCipher.DSE;

public class DSE : IDSE
{
    public void RunCipher()
    {
        Console.WriteLine("*************************************************");
        Console.WriteLine(" DSE Algorithm - Encryption and Decryption      |");
        Console.WriteLine("*************************************************");

        Console.WriteLine("Enter Key for Password:");
        var passwordKey = Console.ReadLine();

        Console.WriteLine("Enter Message to Encrypt:");
        var plainText = Console.ReadLine();

        if (string.IsNullOrEmpty(passwordKey) || string.IsNullOrEmpty(plainText))
            return;

        var encryptBytes = Encrypt(plainText, passwordKey);
        Console.WriteLine("DSE Encrypted Text: {0}", encryptBytes);
        var decryptedString = Decrypt(encryptBytes, passwordKey);
        Console.WriteLine("DSE Decrypted Text: {0}", decryptedString);
        Console.ReadLine();
    }

    //Initial Permutation Table  
    private readonly int[] ip =
    {
        58, 50, 42, 34, 26, 18, 10, 2, 60, 52, 44, 36, 28, 20, 12, 4,
        62, 54, 46, 38, 30, 22, 14, 6, 64, 56, 48, 40, 32, 24, 16, 8,
        57, 49, 41, 33, 25, 17, 9, 1, 59, 51, 43, 35, 27, 19, 11, 3,
        61, 53, 45, 37, 29, 21, 13, 5, 63, 55, 47, 39, 31, 23, 15, 7
    };

    //Circular Left shift Table (For Encryption)  
    private readonly int[] clst = {1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1};

    //Circular Right shift Table (For Decryption)  
    private readonly int[] crst = {1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1, 1};

    //Compression Permutation Table  
    private readonly int[] cpt =
    {
        14, 17, 11, 24, 1, 5, 3, 28, 15, 6, 21, 10,
        23, 19, 12, 4, 26, 8, 16, 7, 27, 20, 13, 2,
        41, 52, 31, 37, 47, 55, 30, 40, 51, 45, 33, 48,
        44, 49, 39, 56, 34, 53, 46, 42, 50, 36, 29, 32
    };

    //Expansion Permutation Table  
    private readonly int[] ept =
    {
        32, 1, 2, 3, 4, 5, 4, 5, 6, 7, 8, 9,
        8, 9, 10, 11, 12, 13, 12, 13, 14, 15, 16, 17,
        16, 17, 18, 19, 20, 21, 20, 21, 22, 23, 24, 25,
        24, 25, 26, 27, 28, 29, 28, 29, 30, 31, 32, 1
    };

    //S Box Tables ( Actual 2D S Box Tables have been converted to 1D S Box Tables for easier computation )  
    private readonly int[,] sbox = new int[8, 64]
    {
        {
            14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7,
            0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8,
            4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0,
            15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13
        },
        {
            15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10,
            3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5,
            0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15,
            13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9
        },
        {
            10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8,
            13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1,
            13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7,
            1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12
        },
        {
            7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15,
            13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9,
            10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4,
            3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14
        },
        {
            2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9,
            14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6,
            4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14,
            11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3
        },
        {
            12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11,
            10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8,
            9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6,
            4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13
        },
        {
            4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1,
            13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6,
            1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2,
            6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12
        },
        {
            13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7,
            1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2,
            7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8,
            2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11
        }
    };

    //P Box Table  
    private readonly int[] pbox =
    {
        16, 7, 20, 21, 29, 12, 28, 17, 1, 15, 23, 26, 5, 18, 31, 10,
        2, 8, 24, 14, 32, 27, 3, 9, 19, 13, 30, 6, 22, 11, 4, 25
    };

    //Final Permutation Table  
    private readonly int[] fp =
    {
        40, 8, 48, 16, 56, 24, 64, 32, 39, 7, 47, 15, 55, 23, 63, 31,
        38, 6, 46, 14, 54, 22, 62, 30, 37, 5, 45, 13, 53, 21, 61, 29,
        36, 4, 44, 12, 52, 20, 60, 28, 35, 3, 43, 11, 51, 19, 59, 27,
        34, 2, 42, 10, 50, 18, 58, 26, 33, 1, 41, 9, 49, 17, 57, 25
    };

    readonly int[] plaintextbin = new int[5000];
    char[] ptca;
    readonly int[] ciphertextbin = new int[5000];
    char[] ctca;
    readonly int[] keybin = new int[64];
    char[] kca;
    readonly int[] ptextbitslice = new int[64];
    readonly int[] ctextbitslice = new int[64];
    readonly int[] ippt = new int[64];
    readonly int[] ipct = new int[64];
    readonly int[] ptLPT = new int[32];
    readonly int[] ptRPT = new int[32];
    readonly int[] ctLPT = new int[32];
    readonly int[] ctRPT = new int[32];
    readonly int[] changedkey = new int[56];
    readonly int[] shiftedkey = new int[56];
    readonly int[] tempRPT = new int[32];
    readonly int[] tempLPT = new int[32];
    readonly int[] CKey = new int[28];
    readonly int[] DKey = new int[28];
    readonly int[] compressedkey = new int[48];
    readonly int[] ctExpandedLPT = new int[48];
    readonly int[] ptExpandedRPT = new int[48];
    readonly int[] XoredRPT = new int[48];
    readonly int[] XoredLPT = new int[48];
    readonly int[] row = new int[2];
    int rowindex;
    readonly int[] column = new int[4];
    int columnindex;
    int sboxvalue;
    int[] tempsboxarray = new int[4];
    readonly int[] ptSBoxRPT = new int[32];
    readonly int[] ctSBoxLPT = new int[32];
    readonly int[] ctPBoxLPT = new int[32];
    readonly int[] ptPBoxRPT = new int[32];
    readonly int[] attachedpt = new int[64];
    readonly int[] attachedct = new int[64];
    readonly int[] fppt = new int[64];
    readonly int[] fpct = new int[64];

    private int GetASCII(char ch)
    {
        int n = ch;
        return n;
    }

    private int ConvertTextToBits(char[] chararray, int[] savedarray)
    {
        var j = 0;
        for (var i = 0; i < chararray.Length; ++i)
        {
            var ba = BitArray.ToBits(GetASCII(chararray[i]), 8);
            j = i * 8;
            AssignArray1ToArray2b(ba, savedarray, j);
        }

        return (j + 8);
    }
    
    public string Encrypt(string plaintext, string key)
    {
        string ciphertext = null;

        ptca = plaintext.ToCharArray();
        kca = key.ToCharArray();
        int j, k;

        var st = ConvertTextToBits(ptca, plaintextbin);

        var fst = AppendZeroes(plaintextbin, st);

        var sk = ConvertTextToBits(kca, keybin);

        var fsk = AppendZeroes(keybin, sk);

        Discard8thBitsFromKey();

        for (var i = 0; i < fst; i += 64)
        {
            for (k = 0, j = i; j < (i + 64); ++j, ++k)
            {
                ptextbitslice[k] = plaintextbin[j];
            }

            StartEncryption();

            for (k = 0, j = i; j < (i + 64); ++j, ++k)
            {
                ciphertextbin[j] = fppt[k];
            }
        }

        ciphertext = ConvertBitsToText(ciphertextbin, fst);

        return ciphertext;
    }

    public string Decrypt(string ciphertext, string key)
    {
        string plaintext = null;

        ctca = ciphertext.ToCharArray();
        kca = key.ToCharArray();
        int j, k;

        var st = ConvertTextToBits(ctca, ciphertextbin);

        var fst = AppendZeroes(ciphertextbin, st);

        var sk = ConvertTextToBits(kca, keybin);

        var fsk = AppendZeroes(keybin, sk);

        Discard8thBitsFromKey();

        for (var i = 0; i < fst; i += 64)
        {
            for (k = 0, j = i; j < (i + 64); ++j, ++k)
            {
                ctextbitslice[k] = ciphertextbin[j];
            }

            StartDecryption();

            for (k = 0, j = i; j < (i + 64); ++j, ++k)
            {
                plaintextbin[j] = fpct[k];
            }
        }

        plaintext = ConvertBitsToText(plaintextbin, fst);

        return plaintext;
    }

    private void AssignArray1ToArray2b(int[] array1, int[] array2, int fromIndex)
    {
        int x, y;
        for (x = 0, y = fromIndex; x < array1.Length; ++x, ++y)
            array2[y] = array1[x];
    }

    private int AppendZeroes(int[] appendedarray, int len)
    {
        int zeroes;
        if (len % 64 != 0)
        {
            zeroes = (64 - (len % 64));

            for (var i = 0; i < zeroes; ++i)
                appendedarray[len++] = 0;
        }

        return len;
    }

    private void Discard8thBitsFromKey()
    {
        for (int i = 0, j = 0; i < 64; i++)
        {
            if ((i + 1) % 8 == 0)
                continue;
            changedkey[j++] = keybin[i];
        }
    }

    private void AssignChangedKeyToShiftedKey()
    {
        for (var i = 0; i < 56; i++)
        {
            shiftedkey[i] = changedkey[i];
        }
    }

    private void InitialPermutation(int[] sentarray, int[] savedarray)
    {
        int tmp;
        for (var i = 0; i < 64; i++)
        {
            tmp = ip[i];
            savedarray[i] = sentarray[tmp - 1];
        }
    }

    private static void DivideIntoLPTAndRPT(int[] sentarray, int[] savedLPT, int[] savedRPT)
    {
        for (int i = 0, k = 0; i < 32; i++, ++k)
        {
            savedLPT[k] = sentarray[i];
        }

        for (int i = 32, k = 0; i < 64; i++, ++k)
        {
            savedRPT[k] = sentarray[i];
        }
    }

    private static void SaveTemporaryHPT(int[] fromHPT, int[] toHPT)
    {
        for (var i = 0; i < 32; i++)
        {
            toHPT[i] = fromHPT[i];
        }
    }

    private void DivideIntoCKeyAndDKey()
    {
        for (int i = 0, j = 0; i < 28; i++, ++j)
        {
            CKey[j] = shiftedkey[i];
        }

        for (int i = 28, j = 0; i < 56; i++, ++j)
        {
            DKey[j] = shiftedkey[i];
        }
    }

    private static void CircularLeftShift(int[] HKey)
    {
        int i, FirstBit = HKey[0];
        for (i = 0; i < 27; i++)
        {
            HKey[i] = HKey[i + 1];
        }

        HKey[i] = FirstBit;
    }

    private void AttachCKeyAndDKey()
    {
        var j = 0;
        for (var i = 0; i < 28; i++)
        {
            shiftedkey[j++] = CKey[i];
        }

        for (var i = 0; i < 28; i++)
        {
            shiftedkey[j++] = DKey[i];
        }
    }

    private void CompressionPermutation()
    {
        int temp;
        for (var i = 0; i < 48; i++)
        {
            temp = cpt[i];
            compressedkey[i] = shiftedkey[temp - 1];
        }
    }

    private void ExpansionPermutation(int[] HPT, int[] ExpandedHPT)
    {
        int temp;
        for (var i = 0; i < 48; i++)
        {
            temp = ept[i];
            ExpandedHPT[i] = HPT[temp - 1];
        }
    }

    private static void XOROperation(int[] array1, int[] array2, int[] array3, int SizeOfTheArray)
    {
        for (var i = 0; i < SizeOfTheArray; i++)
        {
            array3[i] = array1[i] ^ array2[i];
        }
    }

    private void AssignSBoxHpt(int[] temparray, int[] SBoxHPTArray, int fromIndex)
    {
        var j = fromIndex;
        for (var i = 0; i < 4; i++)
        {
            SBoxHPTArray[j++] = tempsboxarray[i];
        }
    }

    private void SBoxSubstitution(int[] XoredHPT, int[] SBoxHPT)
    {
        int r, t, j = 0, q = 0;
        for (var i = 0; i < 48; i += 6)
        {
            row[0] = XoredHPT[i];
            row[1] = XoredHPT[i + 5];
            rowindex = BitArray.ToDecimal(row);

            column[0] = XoredHPT[i + 1];
            column[1] = XoredHPT[i + 2];
            column[2] = XoredHPT[i + 3];
            column[3] = XoredHPT[i + 4];
            columnindex = BitArray.ToDecimal(column);

            t = ((16 * (rowindex)) + (columnindex));

            sboxvalue = sbox[j++, t];

            tempsboxarray = BitArray.ToBits(sboxvalue, 4);

            r = q * 4;

            AssignSBoxHpt(tempsboxarray, SBoxHPT, r);

            ++q;
        }
    }

    private void PBoxPermutation(int[] SBoxHPT, int[] PBoxHPT)
    {
        for (var i = 0; i < 32; i++)
        {
            var temp = pbox[i];
            PBoxHPT[i] = SBoxHPT[temp - 1];
        }
    }

    private void Swap(int[] tempHPT, int[] HPT)
    {
        for (var i = 0; i < 32; i++)
        {
            HPT[i] = tempHPT[i];
        }
    }

    private void SixteenRounds()
    {
        int n;

        for (var i = 0; i < 16; i++)
        {
            SaveTemporaryHPT(ptRPT, tempRPT);

            n = clst[i];

            DivideIntoCKeyAndDKey();

            for (var j = 0; j < n; j++)
            {
                CircularLeftShift(CKey);
                CircularLeftShift(DKey);
            }

            AttachCKeyAndDKey();

            CompressionPermutation();

            ExpansionPermutation(ptRPT, ptExpandedRPT);

            XOROperation(compressedkey, ptExpandedRPT, XoredRPT, 48);

            SBoxSubstitution(XoredRPT, ptSBoxRPT);

            PBoxPermutation(ptSBoxRPT, ptPBoxRPT);

            XOROperation(ptPBoxRPT, ptLPT, ptRPT, 32);

            Swap(tempRPT, ptLPT);
        }
    }

    private static void AttachLptAndRpt(int[] savedLPT, int[] savedRPT, int[] AttachedPT)
    {
        var j = 0;
        for (var i = 0; i < 32; i++)
        {
            AttachedPT[j++] = savedLPT[i];
        }

        for (var i = 0; i < 32; i++)
        {
            AttachedPT[j++] = savedRPT[i];
        }
    }

    private void FinalPermutation(int[] fromPT, int[] toPT)
    {
        for (var i = 0; i < 64; i++)
        {
            var temp = fp[i];
            toPT[i] = fromPT[temp - 1];
        }
    }

    private void StartEncryption()
    {
        InitialPermutation(ptextbitslice, ippt);

        DivideIntoLPTAndRPT(ippt, ptLPT, ptRPT);

        AssignChangedKeyToShiftedKey();

        SixteenRounds();

        AttachLptAndRpt(ptLPT, ptRPT, attachedpt);

        FinalPermutation(attachedpt, fppt);
    }

    private string ConvertBitsToText(int[] sentarray, int len)
    {
        var finaltext = "";
        int j, k, decimalvalue;
        var tempbitarray = new int[8];

        for (var i = 0; i < len; i += 8)
        {
            for (k = 0, j = i; j < (i + 8); ++k, ++j)
            {
                tempbitarray[k] = sentarray[j];
            }

            decimalvalue = BitArray.ToDecimal(tempbitarray);

            if (decimalvalue == 0)
                break;

            finaltext += (char) decimalvalue;
        }

        return finaltext;
    }

    private void CircularRightShift(int[] HKey)
    {
        int i, LastBit = HKey[27];
        for (i = 27; i >= 1; --i)
        {
            HKey[i] = HKey[i - 1];
        }

        HKey[i] = LastBit;
    }

    private void ReversedSixteenRounds()
    {
        int n;

        for (var i = 0; i < 16; i++)
        {
            SaveTemporaryHPT(ctLPT, tempLPT);

            CompressionPermutation();

            ExpansionPermutation(ctLPT, ctExpandedLPT);

            XOROperation(compressedkey, ctExpandedLPT, XoredLPT, 48);

            SBoxSubstitution(XoredLPT, ctSBoxLPT);

            PBoxPermutation(ctSBoxLPT, ctPBoxLPT);

            XOROperation(ctPBoxLPT, ctRPT, ctLPT, 32);

            Swap(tempLPT, ctRPT);

            n = crst[i];

            DivideIntoCKeyAndDKey();

            for (var j = 0; j < n; j++)
            {
                CircularRightShift(CKey);
                CircularRightShift(DKey);
            }

            AttachCKeyAndDKey();
        }
    }

    private void StartDecryption()
    {
        InitialPermutation(ctextbitslice, ipct);

        DivideIntoLPTAndRPT(ipct, ctLPT, ctRPT);

        AssignChangedKeyToShiftedKey();

        ReversedSixteenRounds();

        AttachLptAndRpt(ctLPT, ctRPT, attachedct);

        FinalPermutation(attachedct, fpct);
    }
}