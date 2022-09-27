# Intro to Cryptography. Classical ciphers. Caesar cipher.
## Course: Cryptography & Security
## Author: Gherman Adrian

# Theory

The study and application of methods for safe communication in the presence of malicious outside parties is known as cryptography.
In other words, it involves developing and studying methods of communication that make it impossible for outside parties to view private messages.

Encryption refers to the process of changing ordinary text (plaintext) into unintelligible text (ciphertext).
A cipher is the algorithm used to encrypt and decrypt. The operation of most good ciphers is controlled both by the
algorithm and a parameter called a key. Usually, a key that both the sender and the recipient agree upon is used.
The ciphertext is produced using an encryption key, and the original message is recovered using a decryption key.
Cipher keys come in two varieties: symmetric/private keys and asymmetric/public keys.

While the sender and recipient are aware of the key in symmetric key systems, it is computationally impossible to figure out the decryption
key in public key systems if it is not already known. There are more options and older symmetric key schemes.
The substitution cipher was the first significant symmetric key system.

The Caesar shift cipher, used by Julius Caesar, was one of the first substitution ciphers.
Caesar would substitute the letters three letters below in the alphabet for the original letters in the message. The next major type
of cipher that is analyzed is the polyalphabetic cipher. A polyalphabetic(Vigenere Cipher) cipher would have two or more rows
of shifted or rearranged letters depending on the key. There are also a lot other types of ciphers which implementation will be presented in this laboratory work.

# Objectives:

1. Get familiar with the basics of cryptography and classical ciphers.
2. Implement 4 types of the classical ciphers:

- Caesar cipher with one key used for substitution (as explained above),
- Caesar cipher with one key used for substitution, and a permutation of the alphabet,
- Vigenere cipher,
- Playfair cipher.

3. Structure the project in methods/classes/packages as neeeded.