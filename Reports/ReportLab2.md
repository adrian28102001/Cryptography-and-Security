# Symmetric Ciphers. Stream Ciphers. Block Ciphers.

## Course: Cryptography & Security

## Author: Gherman Adrian

# Theory

Synchronized key is a type of encryption scheme, where a single key is used to both encrypt and decrypt messages. A lot
of governments and military have employed this method of data encoding to aid covert communication in the past.

The names shared-key, secret-key, one-key, and eventually private-key cryptography are all used to describe
symmetric-key encryption. With this type of encryption, it is obvious that both the sender and the recipient must be
aware of the shared key. The distribution of the key is where this method's intricacy lies.

Stream ciphers and block ciphers are two common categories for symmetric key cryptography techniques. Stream ciphers
employ some kind of feedback mechanism to execute on a single bit (or byte or computer word) at a time, causing the key
to change repeatedly.

A block cipher gets its name from the fact that it uses the same key on each block to encrypt one block of data at a
time. In a block cipher, the same plaintext block will typically continue to encrypt to the same ciphertext while using
the same key, however in a stream cipher, the same plaintext will encrypt to several ciphertexts.

- Stream ciphers:

1. The encryption is done one byte at a time.
2. Stream ciphers use confusion to hide the plain text.
3. Make use of substitution techniques to modify the plain text.
4. The implementation is fairly complex.
5. The execution is fast.

- Block ciphers:

1. The encryption is done one block of plain text at a time.
2. Block ciphers use confusion and diffusion to hide the plain text.
3. Make use of transposition techniques to modify the plain text.
4. The implementation is simpler relative to the stream ciphers.
5. The execution is slow compared to the stream ciphers.

Examples of Stream Ciphers are Rivest Cipher (RC4), Salsa20, Software-optimized Encryption Algorithm (SEAL).
Examples of Block Ciphers are Data Encryption Standard (DES), Advanced Encryption Standard (AES), Twofish.
In this laboratory work, DES cipher and ...... were implemented.

DES is an implementation of a Feistel Cipher.
16 round Feistel structures are used. Blocks are 64 bits in size. DES has an effective key length of 56 bits despite
having a key length of 64 bits since the encryption algorithm only uses 8 of the key's 64 bits (function as check bits
only).

The following steps comprise the algorithmic process:
The 64-bit plain text block is first given to an initial permutation (IP) function to start the process.
The initial permutation (IP) is then performed on the plain text.
Next, the initial permutation (IP) creates two halves of the permuted block, referred to as Left Plain Text (LPT) and
Right Plain Text (RPT).
Each LPT and RPT goes through 16 rounds of the encryption process.
Finally, the LPT and RPT are rejoined, and a Final Permutation (FP) is performed on the newly combined block.
The result of this process produces the desired 64-bit ciphertext.
The step of the encryption process (step 4, above) is further divided into the following five stages:
Key transformation
Expansion permutation
S-Box permutation
P-Box permutation
XOR and swap
For decryption, we use the same algorithm, and we reverse the order of the 16 round keys.

# Objectives:

1. Get familiar with the symmetric cryptography, stream and block ciphers.
2. Implement an example of a stream cipher.
3. Implement an example of a block cipher.
4. The implementation should, ideally follow the abstraction/contract/interface used in the previous laboratory work.
5. Please use packages/directories to logically split the files that you will have.
6. As in the previous task, please use a client class or test classes to showcase the execution of your programs.

# Implementation description

Data encryption standard (DES) has been found vulnerable to very powerful attacks and therefore, the popularity of DES
has been found slightly on the decline. DES is a block cipher and encrypts data in blocks of size of 64 bits each, which
means 64 bits of plain text go as the input to DES, which produces 64 bits of ciphertext. The same algorithm and key are
used for encryption and decryption, with minor differences. The key length is 56 bits.
We have mentioned that DES uses a 56-bit key. Actually, the initial key consists of 64 bits. However, before the DES
process even starts, every 8th bit of the key is discarded to produce a 56-bit key. That is bit positions 8, 16, 24, 32,
40, 48, 56, and 64 are discarded.
Thus, the discarding of every 8th bit of the key produces a 56-bit key from the original 64-bit key.
DES is based on the two fundamental attributes of cryptography: substitution (also called confusion) and transposition (
also called diffusion). DES consists of 16 steps, each of which is called a round. Each round performs the steps of
substitution and transposition. Let us now discuss the broad-level steps in DES.

In the first step, the 64-bit plain text block is handed over to an initial Permutation (IP) function.
The initial permutation is performed on plain text.
Next, the initial permutation (IP) produces two halves of the permuted block; saying Left Plain Text (LPT) and Right
Plain Text (RPT).
Now each LPT and RPT go through 16 rounds of the encryption process.
In the end, LPT and RPT are rejoined and a Final Permutation (FP) is performed on the combined block
The result of this process produces 64-bit ciphertext.
As we have noted, the initial permutation (IP) happens only once and it happens before the first round. It suggests how
the transposition in IP should proceed, as shown in the figure. For example, it says that the IP replaces the first bit
of the original plain text block with the 58th bit of the original plain text, the second bit with the 50th bit of the
original plain text block, and so on.

This is nothing but jugglery of bit positions of the original plain text block. the same rule applies to all the other
bit positions shown in the figure.
As we have noted after IP is done, the resulting 64-bit permuted text block is divided into two half blocks. Each
half-block consists of 32 bits, and each of the 16 rounds, in turn, consists of the broad-level steps outlined in the
figure.
We have noted initial 64-bit key is transformed into a 56-bit key by discarding every 8th bit of the initial key. Thus,
for each a 56-bit key is available. From this 56-bit key, a different 48-bit Sub Key is generated during each round
using a process called key transformation. For this, the 56-bit key is divided into two halves, each of 28 bits. These
halves are circularly shifted left by one or two positions, depending on the round.

For example: if the round numbers 1, 2, 9, or 16 the shift is done by only one position for other rounds, the circular
shift is done by two positions. The number of key bits shifted per round is shown in the figure.
After an appropriate shift, 48 of the 56 bits are selected. for selecting 48 of the 56 bits the table is shown in the
figure given below. For instance, after the shift, bit number 14 moves to the first position, bit number 17 moves to the
second position, and so on. If we observe the table carefully, we will realize that it contains only 48-bit positions.
Bit number 18 is discarded (we will not find it in the table), like 7 others, to reduce a 56-bit key to a 48-bit key.
Since the key transformation process involves permutation as well as a selection of a 48-bit subset of the original
56-bit key it is called Compression Permutation.
Because of this compression permutation technique, a different subset of key bits is used in each round. That makes DES
not easy to crack.

Step-2: Expansion Permutation:
Recall that after the initial permutation, we had two 32-bit plain text areas called Left Plain Text(LPT) and Right
Plain Text(RPT). During the expansion permutation, the RPT is expanded from 32 bits to 48 bits. Bits are permuted as
well hence called expansion permutation. This happens as the 32-bit RPT is divided into 8 blocks, with each block
consisting of 4 bits. Then, each 4-bit block of the previous step is then expanded to a corresponding 6-bit block, i.e.,
per 4-bit block, 2 more bits are added.
This process results in expansion as well as a permutation of the input bit while creating output. The key
transformation process compresses the 56-bit key to 48 bits. Then the expansion permutation process expands the 32-bit
RPT to 48-bits. Now the 48-bit key is XOR with 48-bit RPT and the resulting output is given to the next step, which is
the S-Box substitution.

```csharp
  public void RunCipher()
    {
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
````
# Output
````
Enter Key for Password:
Adrian
Enter Message to Encrypt:
HelloWorld
DSE Encrypted Text: ¤1=¢U7~Ú<¥
ùQÇl.
DSE Decrypted Text: HelloWorld

````
# Implementation description

RC4 is a stream cipher and variable-length key algorithm. This algorithm encrypts one byte at a time (or larger units at
a time).
A key input is pseudorandom bit generator that produces a stream 8-bit number that is unpredictable without knowledge of
input key, The output of the generator is called key-stream, is combined one byte at a time with the plaintext stream
cipher using X-OR operation.
Example:

````
RC4 Encryption 
10011000 ? 01010000 = 11001000    

RC4 Decryption 
11001000 ? 01010000 = 10011000
````

Key-Generation Algorithm –
A variable-length key from 1 to 256 bytes is used to initialize a 256-byte state vector S, with elements S[0] to S[255].
For encryption and decryption, a byte k is generated from S by selecting one of the 255 entries in a systematic fashion,
then the entries in S are permuted again.

Key-Scheduling Algorithm:
Initialization: The entries of S are set equal to the values from 0 to 255 in ascending order, a temporary vector T, is
created.
If the length of the key k is 256 bytes, then k is assigned to T. Otherwise, for a key with length(k-len) bytes, the
first k-len elements of T as copied from K, and then K is repeated as many times as necessary to fill T. The idea is
illustrated as follow:

````
for
    i = 0 to 255 do S[i] = i;
T[i] = K[i mod k - len];
````

we use T to produce the initial permutation of S. Starting with S[0] to S[255], and for each S[i] algorithm swap it with
another byte in S according to a scheme dictated by T[i], but S will still contain values from 0 to 255

````j = 0;
for
    i = 0 to 255 do
    {
        j = (j + S[i] + T[i])mod 256;
        Swap(S[i], S[j]);
    }
````

Pseudo random generation algorithm (Stream Generation):
Once the vector S is initialized, the input key will not be used. In this step, for each S[i] algorithm swap it with
another byte in S according to a scheme dictated by the current configuration of S. After reaching S[255] the process
continues, starting from S[0] again

````
i, j = 0;
while (true)
    i = (i + 1)mod 256;
j = (j + S[i])mod 256;
Swap(S[i], S[j]);
t = (S[i] + S[j])mod 256;
k = S[t];
````

```csharp
   public void RunCipher()
    {
        Console.WriteLine("Enter Key for Password:");
        var passwordKey = Console.ReadLine();

        Console.WriteLine("Enter Message to Encrypt:");
        var plainText = Console.ReadLine();

        if (string.IsNullOrEmpty(passwordKey) || string.IsNullOrEmpty(plainText))
            return;

        var asciiKeyBytes = Encoding.ASCII.GetBytes(passwordKey);
        var sBox = Enumerable.Range(0, 256).ToArray();

        var j = 0;
        for (var i = 0; i < 256; i++)
        {
            j = (j + sBox[i] + asciiKeyBytes[i % asciiKeyBytes.Length]) % 256;
            sBox[j] = sBox[i];
            sBox[i] = j;
        }

        var encryptBytes = PseudoRandomRc4(sBox, Encoding.ASCII.GetBytes(plainText));
        Console.WriteLine("RC4 Encrypted Text: {0}", Encoding.ASCII.GetString(encryptBytes));
        var decryptedString = PseudoRandomRc4(sBox, encryptBytes);
        Console.WriteLine("RC4 Decrypted Text: {0}", Encoding.ASCII.GetString(decryptedString));
        Console.ReadLine();
    }
    public byte[] PseudoRandomRc4(int[] sBox, byte[] messageBytes)
    {
        var i = 0;
        var j = 0;
        var cnt = 0;
        var tempBox = new int[sBox.Length];
        var result = new byte[messageBytes.Length];

        Array.Copy(sBox, tempBox, tempBox.Length);

        foreach (var textByte in messageBytes)
        {
            i = (i + 1) % 256;
            j = (j + tempBox[i]) % 256;
            (tempBox[i], tempBox[j]) = (tempBox[j], tempBox[i]);
            var t = (tempBox[i] + tempBox[j]) % 256;
            var k = tempBox[t];

            var ss = textByte ^ k;
            result[cnt] = (byte) ss;
            cnt++;
        }

        return result;
    }
````

# Output
````
Enter Key for Password:
Adrian
Enter Message to Encrypt:
HelloWorld
RC4 Encrypted Text: ?e??↔6?F?:
RC4 Decrypted Text: HelloWorld
````