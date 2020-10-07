using System;
using System.Linq;
using System.Text;
using ConsoleApp2.Models;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 3 : Convertion of Full name string to binary.
            Console.WriteLine("(Q:2) Enter your full name");  //Displays the content on the prompt/output window
            string fullName = Console.ReadLine();       // Takes the input from the user
            string binary = Converter.StringToBinary(fullName);    //Calls for the StringToBinary method in Convertor.cs
            //Question 4
            Console.WriteLine("(Q:3,4) The binary equivalent of the full name is  " + binary);   //Displays the output
            Console.WriteLine(" ");


            //Question 5
            //Converting my name in binary back to ascii.
            Console.WriteLine("(Q:5) Enter your fullname in binary format");  //Displays the content on the prompt/output window
            string NameinBinary = Console.ReadLine();     //Takes the input from the user
            //Question 6
            string ascii = Converter.BinaryToString(NameinBinary);   //Calls for the BinaryToString method in Convertor.cs
            Console.WriteLine("(Q:6) The ASCII equivalent of binary input is " + ascii);      //Displays the result.
            Console.WriteLine(" ");


            //Question 7
            //Converting name into Hexadecimal.
            Console.WriteLine("(Q:7) Enter the ASCII text to be tranformed");
            string NameAscii = Console.ReadLine();
            string hex = Converter.StringToHex(NameAscii);      //Calls the StringToHex method in Converter.cs
            Console.WriteLine("(Q:7.3) The Hexadecimal equivalent of the ASCII text is  " + hex);
            //Converting Hexadecimal back to ASCII letters.
            string h_a = Converter.ConvertHex(hex);            //Calls the ConvertHex method in the Converter.cs
            Console.WriteLine("(Q:7.4) The ASCII equivalent of Hexa is  " + h_a);
            Console.WriteLine(" ");

            // Converting Ascii string to Base64.
            Console.WriteLine("Enter the name");
            string Name = Console.ReadLine();
            string Bse64Name = Converter.StringToBase64(Name);    //calls StringToBase64 method in the Converter.cs
            Console.WriteLine("(Q:7.5) The Base64 equivalent of ASCII text is  " + Bse64Name);
            //Converting Base64 to Name string.
            string orgName = Converter.Base64ToString(Bse64Name);  //calls Base64ToString method in the Converter.cs
            Console.WriteLine("(Q:7.6) Base64 back to ASCII  " + orgName);
            Console.WriteLine(" ");

            //Question 8
            //Converting fullName to byte array and displaying them.
            byte[] fullNamebytes = Encoding.ASCII.GetBytes(Name);
            Console.WriteLine("(Q:8) The byte array of fullName is");
            foreach (byte b in fullNamebytes)
            {
                Console.WriteLine(b);
            }


            //Question 9
            //Encrypting and Decrypting my name using DeepEncryptWithCipher using a sequence of intergers(from byte array) with depth of 20.
            string unicodeString = "Manoj Gottumukkala ";
            int[] cipher = new[] { 77,97,110,111,106,32,71,111,116,116,117,109,117,107,107,97,108,97 }; //Fibonacci Sequence
            string cipherasString = String.Join(",", cipher.Select(x => x.ToString())); //FOr display

            int encryptionDepth = 20;

            string nameDeepEncryptWithCipher = Converter.DeepEncryptWithCipher(unicodeString, cipher, encryptionDepth);
            Console.WriteLine($"(Q:9.1) Deep Encrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepEncryptWithCipher}");

            string nameDeepDecryptWithCipher = Converter.DeepDecryptWithCipher(nameDeepEncryptWithCipher, cipher, encryptionDepth);
            Console.WriteLine($"(Q:9.2)Deep Decrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepDecryptWithCipher}");



            Console.ReadKey();






        }

    }
}
