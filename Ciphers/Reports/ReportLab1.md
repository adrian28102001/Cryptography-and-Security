# Intro to Cryptography. Classical ciphers. Caesar cipher.

## Course: Cryptography & Security

## Author: Gherman Adrian

# Theory

The study and application of methods for safe communication in the presence of malicious outside parties is known as
cryptography.
In other words, it involves developing and studying methods of communication that make it impossible for outside parties
to view private messages.

Encryption refers to the process of changing ordinary text (plaintext) into unintelligible text (ciphertext).
A cipher is the algorithm used to encrypt and decrypt. The operation of most good ciphers is controlled both by the
algorithm and a parameter called a key. Usually, a key that both the sender and the recipient agree upon is used.
The ciphertext is produced using an encryption key, and the original message is recovered using a decryption key.
Cipher keys come in two varieties: symmetric/private keys and asymmetric/public keys.

While the sender and recipient are aware of the key in symmetric key systems, it is computationally impossible to figure
out the decryption
key in public key systems if it is not already known. There are more options and older symmetric key schemes.
The substitution cipher was the first significant symmetric key system.

- The Caesar shift cipher, used by Julius Caesar, was one of the first substitution ciphers.
  Caesar would substitute the letters three letters below in the alphabet for the original letters in the message. The
  next major type
  of cipher that is analyzed is the polyalphabetic cipher.

- A polyalphabetic(Vigenere Cipher) cipher would have two or more rows
  of shifted or rearranged letters depending on the key.

- Next one is the Affine cipher,
  which maps each letter of the alphabet to its numerical counterpart,
  encrypts it using a straightforward mathematical formula, and then
  converts it back to the original letter.

- The last one is Playfair cipher.
  It is the same as a traditional cipher. The only difference is that it
  encrypts a digraph (a pair of two letters) instead of a single letter.
  It initially creates a key-table of 5*5 matrix.

# Objectives:

1. Get familiar with the basics of cryptography and classical ciphers.
2. Implement 4 types of the classical ciphers:

- Caesar cipher with one key used for substitution (as explained above),
- Caesar cipher with one key used for substitution, and a permutation of the alphabet,
- Vigenere cipher,
- Playfair cipher.

3. Structure the project in methods/classes/packages as needed.
   The last one is Playfair cipher.
   It is the same as a traditional cipher. The only difference is that it
   encrypts a digraph (a pair of two letters) instead of a single letter.
   It initially creates a key-table of 5*5 matrix.

# Implementation description

### Caesar Cipher Implementation

There is an interface with 2 methods, encrypt and decrypt. They make sure to do the logic
of and encrypt and decrypt.
In order to encrypt a plaintext letter, the sender positions the sliding ruler underneath the first set of plaintext
letters and slides it to LEFT by the number of positions of the secret shift.

The plaintext letter is then encrypted to the ciphertext letter on the sliding ruler underneath. The result of this
process is depicted in the following illustration for an agreed shift of three positions. In this case, the plaintext
‘Adrian’ is encrypted to the ciphertext ‘Ehvmer’. Here is the ciphertext alphabet for a Shift of 3 −
On receiving the ciphertext, the receiver who also knows the secret shift, positions his sliding ruler underneath the
ciphertext alphabet and slides it to RIGHT by the agreed shift number, 3 in this case.

He then replaces the ciphertext letter by the plaintext letter on the sliding ruler underneath. Hence the ciphertext
‘Ehvmer’ is decrypted to ‘Adrian’. To decrypt a message encoded with a Shift of 3, generate the plaintext alphabet
using a shift of ‘-3’ as shown below −

```csharp
  public string Encrypt(string input, int key)
    {
        var output = string.Empty;

        foreach (var ch in input)
        {
            output += Cipher(ch, key);
        }

        return output;
    }
````

```csharp
    public string Decrypt(string input, int key)
    {
        return Encrypt(input, 26 - key);
    }
````

Output

```
Initial text: Adrian
Key: 4
Text encrypted for Caesar cipher: Ehvmer
Text decrypted for Caesar cipher: Adrian
````

### Affine Cipher Implementation

There is an interface with 2 methods, encrypt and decrypt. They make sure to do the logic
of and encrypt and decrypt.The Affine cipher is a type of monoalphabetic substitution cipher, wherein each letter in an
alphabet is mapped to its numeric equivalent, encrypted using a simple mathematical function, and converted back to a
letter. The formula used means that each letter encrypts to one other letter, and back again, meaning the cipher is
essentially a standard substitution cipher with a rule governing which letter goes to which.
The whole process relies on working modulo m (the length of the alphabet used). In the affine cipher, the letters of an
alphabet of size m are first mapped to the integers in the range 0 … m-1.

The ‘key’ for the Affine cipher consists of 2 numbers, we’ll call them a and b. The following discussion assumes the use
of a 26 character alphabet (m = 26). a should be chosen to be relatively prime to m (i.e. a should have no factors in
common with m).

It uses modular arithmetic to transform the integer that each plaintext letter corresponds to into another integer that
correspond to a ciphertext letter. The encryption function for a single letter is

````
E ( x ) = ( a x + b ) mod m 
modulus m: size of the alphabet
a and b: key of the cipher.
a must be chosen such that a and m are coprime.
````

In deciphering the ciphertext, we must perform the opposite (or inverse) functions on the ciphertext to retrieve the
plaintext. Once again, the first step is to convert each of the ciphertext letters into their integer values. The
decryption function is

````
D ( x ) = a^-1 ( x - b ) mod m
a^-1 : modular multiplicative inverse of a modulo m. i.e., it satisfies the equation
1 = a a^-1 mod m .
````

D ( x ) = a^-1 ( x - b ) mod m
a^-1 : modular multiplicative inverse of a modulo m. i.e., it satisfies the equation
1 = a a^-1 mod m .

````
[g,x,d] = gcd(a,m);    % we can ignore g and d, we dont need them
x = mod(x,m);
````

If you now multiply x and a and reduce the result (mod 26), you will get the answer 1. Remember, this is just the
definition of an inverse i.e. if a*x = 1 (mod 26), then x is an inverse of a (and a is an inverse of x)

```csharp
 public string Encrypt(string text, int a, int b)
    {
        var chars = text.ToUpper().ToCharArray();

        return chars.Select(c => Convert.ToInt32(c - 65)).Aggregate("", (current, x) => current + Convert.ToChar(((a * x + b) % 26) + 65));
    }
````

```csharp
    public string Decrypt(string text, int a, int b)
    {
        var plaintext = "";

        var aInvers = MultiplicativeInverse(a);

        var chars = text.ToUpper().ToCharArray();

        foreach(var c in chars)
        {
            var x = Convert.ToInt32(c - 65);
            if (x - b < 0)
            {
                x += Convert.ToInt32(x) + 26;
            }
            plaintext += Convert.ToChar(((aInvers * (x - b)) % 26) + 65);
        }
        return plaintext;
    }
````

```csharp
    private static int MultiplicativeInverse(int a)
    {
        for (var i = 1; i < 27; i++)
        {
            if ((a * i) % 26 == 1)
            {
                return i;
            }
        }
        throw new Exception("No Multiplicative Inverse Found");
    }

````

Output

```
Initial text: Adrian
Key: 3,1
Text encrypted for Affine cipher: BKAZBO
Text decrypted for Affine cipher: ADRIAN
````

### Playfair Cipher Implementation

Generate the key Square(5×5):
The key square is a 5×5 grid of alphabets that acts as the key for encrypting the plaintext. Each of the 25 alphabets
must be unique and one letter of the alphabet (usually J) is omitted from the table (as the table can hold only 25
alphabets). If the plaintext contains J, then it is replaced by I.

The initial alphabets in the key square are the unique alphabets of the key in the order in which they appear followed
by the remaining letters of the alphabet in order.

Algorithm to encrypt the plain text: The plaintext is split into pairs of two letters (digraphs). If there is an odd
number of letters, a Z is added to the last letter.
For example:

``PlainText: "instruments"
After Split: 'in' 'st' 'ru' 'me' 'nt' 'sz'
``

1. Pair cannot be made with same letter. Break the letter in single and add a bogus letter to the previous letter.
   Plain Text: “hello”
   After Split: ‘he’ ‘lx’ ‘lo’
   Here ‘x’ is the bogus letter.

2. If the letter is standing alone in the process of pairing, then add an extra bogus letter with the alone letter
   Plain Text: “helloe”
   AfterSplit: ‘he’ ‘lx’ ‘lo’ ‘ez’
   Here ‘z’ is the bogus letter.
   Rules for Encryption:

If both the letters are in the same column: Take the letter below each one (going back to the top if at the bottom).
For example:
``Diagraph: "me"
Encrypted Text: cl
Encryption:
m -> c
e -> l``

If both the letters are in the same row: Take the letter to the right of each one (going back to the leftmost if at the
rightmost position).
For example:

``Diagraph: "st"
Encrypted Text: tl
Encryption:
s -> t
t -> l``

If neither of the above rules is true: Form a rectangle with the two letters and take the letters on the horizontal
opposite corner of the rectangle.
For example:

``Diagraph: "nt"
Encrypted Text: rq
Encryption:
n -> r
t -> q``

``Plain Text: "instrumentsz"
Encrypted Text: gatlmzclrqtx
Encryption:
i -> g
n -> a
s -> t
t -> l
r -> m
u -> z
m -> c
e -> l
n -> r
t -> q
s -> t
z -> x``

```csharp
private static int Mod(int a, int b)
{
return (a % b + b) % b;
}
````

```csharp
    private static List<int> FindAllOccurrences(string str, char value)
    {
        var indexes = new List<int>();

        var index = 0;
        while ((index = str.IndexOf(value, index)) != -1)
            indexes.Add(index++);

        return indexes;
    }

````

```csharp

    private static string RemoveAllDuplicates(string str, List<int> indexes)
    {
        var retVal = str;

        for (var i = indexes.Count - 1; i >= 1; i--)
            retVal = retVal.Remove(indexes[i], 1);

        return retVal;
    }

````

```csharp
    private static char[,] GenerateKeySquare(string key)
    {
        var keySquare = new char[5, 5];
        const string defaultKeySquare = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
        var tempKey = string.IsNullOrEmpty(key) ? "CIPHER" : key.ToUpper();

        tempKey = tempKey.Replace("J", "");
        tempKey += defaultKeySquare;

        for (var i = 0; i < 25; ++i)
        {
            var indexes = FindAllOccurrences(tempKey, defaultKeySquare[i]);
            tempKey = RemoveAllDuplicates(tempKey, indexes);
        }

        tempKey = tempKey.Substring(0, 25);

        for (var i = 0; i < 25; ++i)
            keySquare[(i / 5), (i % 5)] = tempKey[i];

        return keySquare;
    }

````

```csharp

    private static void GetPosition(ref char[,] keySquare, char ch, ref int row, ref int col)
    {
        if (ch == 'J')
            GetPosition(ref keySquare, 'I', ref row, ref col);

        for (var i = 0; i < 5; ++i)
        for (var j = 0; j < 5; ++j)
            if (keySquare[i, j] == ch)
            {
                row = i;
                col = j;
            }
    }
````

```csharp
    private static char[] SameRow(ref char[,] keySquare, int row, int col1, int col2, int encipher)
    {
        return new[] {keySquare[row, Mod((col1 + encipher), 5)], keySquare[row, Mod((col2 + encipher), 5)]};
    }
````

```csharp
    private static char[] SameColumn(ref char[,] keySquare, int col, int row1, int row2, int encipher)
    {
        return new[] {keySquare[Mod((row1 + encipher), 5), col], keySquare[Mod((row2 + encipher), 5), col]};
    }
````

```csharp
    private static char[] SameRowColumn(ref char[,] keySquare, int row, int col, int encipher)
    {
        return new[]
        {
            keySquare[Mod((row + encipher), 5), Mod((col + encipher), 5)],
            keySquare[Mod((row + encipher), 5), Mod((col + encipher), 5)]
        };
    }
````

```csharp
    private static char[] DifferentRowColumn(ref char[,] keySquare, int row1, int col1, int row2, int col2)
    {
        return new[] {keySquare[row1, col2], keySquare[row2, col1]};
    }
````

```csharp
    private static string RemoveOtherChars(string input)
    {
        var output = input;

        for (var i = 0; i < output.Length; ++i)
            if (!char.IsLetter(output[i]))
                output = output.Remove(i, 1);

        return output;
    }
````

```csharp
    private static string AdjustOutput(string input, string output)
    {
        var retVal = new StringBuilder(output);

        for (var i = 0; i < input.Length; ++i)
        {
            if (!char.IsLetter(input[i]))
                retVal = retVal.Insert(i, input[i].ToString());

            if (char.IsLower(input[i]))
                retVal[i] = char.ToLower(retVal[i]);
        }

        return retVal.ToString();
    }
````

```csharp
    private static string Cipher(string input, string key, bool encipher)
    {
        var retVal = string.Empty;
        var keySquare = GenerateKeySquare(key);
        var tempInput = RemoveOtherChars(input);
        var e = encipher ? 1 : -1;

        if (tempInput.Length % 2 != 0)
            tempInput += "X";

        for (var i = 0; i < tempInput.Length; i += 2)
        {
            var row1 = 0;
            var col1 = 0;
            var row2 = 0;
            var col2 = 0;

            GetPosition(ref keySquare, char.ToUpper(tempInput[i]), ref row1, ref col1);
            GetPosition(ref keySquare, char.ToUpper(tempInput[i + 1]), ref row2, ref col2);

            if (row1 == row2 && col1 == col2)
            {
                retVal += new string(SameRowColumn(ref keySquare, row1, col1, e));
            }
            else if (row1 == row2)
            {
                retVal += new string(SameRow(ref keySquare, row1, col1, col2, e));
            }
            else if (col1 == col2)
            {
                retVal += new string(SameColumn(ref keySquare, col1, row1, row2, e));
            }
            else
            {
                retVal += new string(DifferentRowColumn(ref keySquare, row1, col1, row2, col2));
            }
        }

        retVal = AdjustOutput(input, retVal);

        return retVal;
    }
````

```csharp
  public string Encrypt(string input, string key)
    {
        return Cipher(input, key, true);
    }
````

```csharp
    public string Decrypt(string input, string key)
    {
        return Cipher(input, key, false);
    }
````

Output

````
Key: cipher
Text encrypted for Playfair Cypher: Bfacfk
Text decrypted for Playfair Cypher: Adrian
````

### Vigenere Cipher Implementation

Encryption:

The first letter of the plaintext, G is paired with A, the first letter of the key. So use row G and column A of the
Vigenère square, namely G. Similarly, for the second letter of the plaintext, the second letter of the key is used, the
letter at row E, and column Y is C. The rest of the plaintext is enciphered in a similar fashion.
Decryption:
Decryption is performed by going to the row in the table corresponding to the key, finding the position of the
ciphertext letter in this row, and then using the column’s label as the plaintext. For example, in row A (from AYUSH),
the ciphertext G appears in column G, which is the first plaintext letter. Next, we go to row Y (from AYUSH), locate the
ciphertext C which is found in column E, thus E is the second plaintext letter.

A more easy implementation could be to visualize Vigenère algebraically by converting [A-Z] into numbers [0–25].

````
Encryption
The plaintext(P) and key(K) are added modulo 26.
Ei = (Pi + Ki) mod 26

Decryption
Di = (Ei - Ki + 26) mod 26
````

Note: Di denotes the offset of the i-th character of the plaintext. Like offset of A is 0 and of B is 1 and so on.

```csharp
private static int Mod(int a, int b)
{
return (a % b + b) % b;
}
````

```csharp
    private static string Cipher(string input, string key, bool encipher)
    {
        if (key.Any(t => !char.IsLetter(t)))
        {
            return null;
        }

        var output = string.Empty;
        var nonAlphaCharCount = 0;

        for (var i = 0; i < input.Length; ++i)
        {
            if (char.IsLetter(input[i]))
            {
                var cIsUpper = char.IsUpper(input[i]);
                var offset = cIsUpper ? 'A' : 'a';
                var keyIndex = (i - nonAlphaCharCount) % key.Length;
                var k = (cIsUpper ? char.ToUpper(key[keyIndex]) : char.ToLower(key[keyIndex])) - offset;
                k = encipher ? k : -k;
                var ch = (char) ((Mod(((input[i] + k) - offset), 26)) + offset);
                output += ch;
            }
            else
            {
                output += input[i];
                ++nonAlphaCharCount;
            }
        }

        return output;
    }
````

```csharp
    public string CipherType()
    {
        return "Vigenere cipher";
    }
````

```csharp
    public string Encrypt(string input, string key)
    {
        return Cipher(input, key, true);
    }
````

```csharp
    public string Decrypt(string input, string key)
    {
        return Cipher(input, key, false);
    }
````

Output

````
Initial text: Adrian
Key: cipher
Text encrypted for Vigenere cipher: Clgpee
Text decrypted for Vigenere cipher: Adrian
````
Conclusion

To sum up, cryptography is a study and
practice of hiding information. In this laboratory work some famous classical substitution ciphers including Affine,
Caesar, Viginere, Playfair cipher have been implemented. Traditional cryptography is based on mathematics and relies on
how difficult it is to factor huge numbers computationally. The high level of complexity of the mathematical issue for
the huge number factorization is the foundation for the security of classical cryptography. By using a key-space
brute-force search, traditional ciphers can be cracked. Even so those ciphers can be broken using the brute-force
attack.