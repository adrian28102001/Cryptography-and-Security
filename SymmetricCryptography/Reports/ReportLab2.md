# Symmetric Ciphers. Stream Ciphers. Block Ciphers.
## Course: Cryptography & Security
## Author: Gherman Adrian

# Theory
Synchronized key is a type of encryption scheme, where a single key is used to both encrypt and decrypt messages. A lot of governments and military have employed this method of data encoding to aid covert communication in the past.

The names shared-key, secret-key, one-key, and eventually private-key cryptography are all used to describe symmetric-key encryption. With this type of encryption, it is obvious that both the sender and the recipient must be aware of the shared key. The distribution of the key is where this method's intricacy lies.

Stream ciphers and block ciphers are two common categories for symmetric key cryptography techniques. Stream ciphers employ some kind of feedback mechanism to execute on a single bit (or byte or computer word) at a time, causing the key to change repeatedly.

A block cipher gets its name from the fact that it uses the same key on each block to encrypt one block of data at a time. In a block cipher, the same plaintext block will typically continue to encrypt to the same ciphertext while using the same key, however in a stream cipher, the same plaintext will encrypt to several ciphertexts.

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
16 round Feistel structures are used. Blocks are 64 bits in size. DES has an effective key length of 56 bits despite having a key length of 64 bits since the encryption algorithm only uses 8 of the key's 64 bits (function as check bits only).

The following steps comprise the algorithmic process:
The 64-bit plain text block is first given to an initial permutation (IP) function to start the process.
The initial permutation (IP) is then performed on the plain text.
Next, the initial permutation (IP) creates two halves of the permuted block, referred to as Left Plain Text (LPT) and Right Plain Text (RPT).
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

