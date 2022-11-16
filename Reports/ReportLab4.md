# Topic: Hash functions and Digital Signatures.

## Course: Cryptography & Security

## Author: Gherman Adrian

# Theory

Hashing is a technique used to compute a new representation of an existing value,
message or any piece of text. The new representation is also commonly called a
digest of the initial text, and it is a one way function meaning that it should
be impossible to retrieve the initial content from the digest.

Such a technique has the following usages:

1. Offering confidentiality when storing passwords,
2. Checking for integrity for some downloaded files or content,
3. Creation of digital signatures, which provides integrity and non-repudiation.
   In order to create digital signatures, the initial message or text needs to be hashed
   to get the digest. After that, the digest is to be encrypted using a public key encryption
   cipher. Having this, the obtained digital signature can be decrypted with the public key
   and the hash can be compared with an additional hash computed from the received message
   to check the integrity of it.

# Objectives:

1. Get familiar with the hashing techniques/algorithms.
2. Use an appropriate hashing algorithms to store passwords in a local DB.
3. Use an asymmetric cipher to implement a digital signature process for a user message.
    - Take the user input message.
    - Preprocess the message, if needed.
    - Get a digest of it via hashing.
    - Encrypt it with the chosen cipher.
    - Perform a digital signature check by comparing the hash of the message with the decrypted one.

# Implementation description

### DES

We have noted initial 64-bit key is transformed into a 56-bit key by discarding every 8th bit of the initial key. Thus,
for each a 56-bit key is available. From this 56-bit key, a different 48-bit Sub Key is generated during each round
using a process called key transformation. For this, the 56-bit key is divided into two halves, each of 28 bits. These
halves are circularly shifted left by one or two positions, depending on the round.
After an appropriate shift, 48 of the 56 bits are selected. for selecting 48 of the 56 bits the table is shown in the
figure given below. For instance, after the shift, bit number 14 moves to the first position, bit number 17 moves to the
second position, and so on. If we observe the table carefully, we will realize that it contains only 48-bit positions.
Bit number 18 is discarded (we will not find it in the table), like 7 others, to reduce a 56-bit key to a 48-bit key.
Since the key transformation process involves permutation as well as a selection of a 48-bit subset of the original
56-bit key it is called Compression Permutation.
Because of this compression permutation technique, a different subset of key bits is used in each round. That makes DES
not easy to crack.

Recall that after the initial permutation, we had two 32-bit plain text areas called Left Plain Text(LPT) and Right
Plain Text(RPT). During the expansion permutation, the RPT is expanded from 32 bits to 48 bits. Bits are permuted as
well hence called expansion permutation. This happens as the 32-bit RPT is divided into 8 blocks, with each block
consisting of 4 bits. Then, each 4-bit block of the previous step is then expanded to a corresponding 6-bit block, i.e.,
per 4-bit block, 2 more bits are added.his process results in expansion as well as a permutation of the input bit while
creating output. The key transformation process compresses the 56-bit key to 48 bits. Then the expansion permutation
process expands the 32-bit RPT to 48-bits. Now the 48-bit key is XOR with 48-bit RPT and the resulting output is given
to the next step, which is the S-Box substitution.

Important code

```csharp
public bool Verify(string password, string hashedPassword)
    {
        // Check hash
        if (!IsHashSupported(hashedPassword))
        {
            throw new NotSupportedException("The hashtype is not supported");
        }

        // Extract iteration and Base64 string
        var splittedHashString = hashedPassword.Replace("$MYHASH$V1$", "").Split('$');
        var iterations = int.Parse(splittedHashString[0]);
        var base64Hash = splittedHashString[1];

        // Get hash bytes
        var hashBytes = Convert.FromBase64String(base64Hash);

        // Get salt
        Array.Copy(hashBytes, 0, salt, 0, SaltSize);

        // Create hash with given salt
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
        byte[] hash = pbkdf2.GetBytes(HashSize);

        // Get result
        for (var i = 0; i < HashSize; i++)
        {
            if (hashBytes[i + SaltSize] != hash[i])
            {
                return false;
            }
        }

        return true;
    }
````

```csharp
public void Register(){}
public void Login(){}
public void SetDigitalSignature(User user){
VerifyDigitalSignature(user);
}
public void VerifyDigitalSignature(User user){}

    
````

# Output

````
Welcome to Digital Signatures and Password Hashing!

Enter a username to register: Adrian
Enter a password to register: 1234
Hashed: $MYHASH$V1$10000$N/GkuWLF5BlICcwFXqPR3wEEyvqYYJ/LNv53DTwxRQgf/Lzg
The password is:  valid
Registration successful, let's login
Enter a username to login: Adi
User with username Adi doesn't exists.
Enter a username to register: Adi
Enter a password to register: 1234
Hashed: $MYHASH$V1$10000$N/GkuWLF5BlICcwFXqPR3wEEyvqYYJ/LNv53DTwxRQgf/Lzg
The password is:  valid
Registration successful, let's login
Enter a username to login: Adi
Enter a password login: 1234
Hash: $MYHASH$V1$10000$N/GkuWLF5BlICcwFXqPR3wEEyvqYYJ/LNv53DTwxRQgf/Lzg
The password is:  valid
Authentication successful!
Enter a message: Vreau nota 10
Enter the message you have set already: Merit nota 5
'Û?BÙÐýIO¡♠õ;L*¤?¸OÇzÌG'¯înò§M▼(fåÛ1)óZû!▲▼
The message is: not valid
Digital signature check failed!
You have entered wrong message, try again
Enter the message you have set already: Vreau nota 10
'Û?BÙÐýIO¡♠õ;L*¤?¸OÇzÌG'¯înò§M▼(fåÛ1)óZû!▲▼
The message is:  valid
Digital signature check successful!

````

# Conclusion //////Adaptezi la algoritmul folosit de tine

To sum up, in this laboratory work we got familiar with the DSA hashing method
that is a cryptographic security algorithm. DES is a symmetric block cipher that can be used to encrypt 64-bits of
plaintext into 64-bits of ciphertext. The algorithm is the same for the process of encryption as well as decryption. The
only difference is that the decryption procedure is the opposite of the encryption procedure. The algorithm goes through
16 rounds and makes it stronger. Now, even though there are much stronger encryption algorithms available, learning
about DES is still important as it helped in the advancement of cryptography as we know it today.