using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Models
{
    public class Converter
    {
        //Reference : https://www.fluxbytes.com/csharp/convert-string-to-binary-and-binary-to-string-in-c/
        public static string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();                //creates an empty builder named sb.

            foreach (char c in data.ToCharArray())                 //takes each character in data.TocharArray()
            {
                //Convert the char to base 2 and pad the output with 0
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();                                 //Returns the binary string to Program.cs
        }

        //Reference : https://www.fluxbytes.com/csharp/convert-string-to-binary-and-binary-to-string-in-c/
        public static string BinaryToString(string data)
        {
            List<Byte> byteList = new List<Byte>();               // Creates a new list named bytelist.

            for (int i = 0; i < data.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2)); //Converts the specified string representation of a number to an equivalent 8 - bit unsigned integer.
            }
            return Encoding.ASCII.GetString(byteList.ToArray());  //Decodes the bytes back to full name string and returns to Program.cs
        }


        //Reference: https://klasserom.azurewebsites.net/Lessons/Binder/2214#CourseStrand_3643
        public static string StringToHex(string data)
        {
            StringBuilder sb = new StringBuilder();               //Creates an empty builder named sb.

            foreach (char c in data.ToCharArray())               //Takes each character in the full name string.
            {
                //Convert the char to base 16 and pad the output with 0
                sb.Append(Convert.ToString(c, 16).PadLeft(2, '0'));
            }

            return sb.ToString().ToUpper();                       //Formats in the form of hex string and returns to program.cs
        }

        //Reference: https://klasserom.azurewebsites.net/Lessons/Binder/2214#CourseStrand_3643
        public static string ConvertHex(String hexString)
        {
            try                                                    //Using try and catch blocks.
            {
                string ascii = string.Empty;

                for (int i = 0; i < hexString.Length; i += 2)
                {
                    String hs = string.Empty;
                    //Logic for converting hexa decimal to a string.
                    hs = hexString.Substring(i, 2);
                    uint decval = System.Convert.ToUInt32(hs, 16);
                    char character = System.Convert.ToChar(decval);
                    ascii += character;

                }

                return ascii;                    //Returns the fullname string.
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return string.Empty;                  //If error occurs, returns empty string.
        }


        //Reference: https://docs.microsoft.com/en-us/dotnet/api/system.convert.tobase64string?view=netcore-3.1
        public static string StringToBase64(string data)
        {
            byte[] bytearray = Encoding.ASCII.GetBytes(data);         //Converts the data(full name) into sequence of bytes.

            return Convert.ToBase64String(bytearray);                 //Converts the bytes to Base64 and returns the data.
        }

        //Reference: https://docs.microsoft.com/en-us/dotnet/api/system.convert.tobase64string?view=netcore-3.1
        public static string Base64ToString(string data)
        {
            if (String.IsNullOrEmpty(data))
            {
                return String.Empty;
            }

            byte[] bytearray = Convert.FromBase64String(data);     //Converts the data(base 64) into sequence of bytes.

            return Encoding.ASCII.GetString(bytearray);            //Encodes the Base64 to ASCII string and returns them to program.cs
        }

        //Reference: https://klasserom.azurewebsites.net/CourseStrands/Binder/3894
        public static string DeepEncryptWithCipher(string originalText, int[] encryptionCipher, int encryptionDepth)
        {
            string result = originalText;

            //For demonstration
            //string[] encryptedValues = new string[encryptionDepth + 1];
            //encryptedValues[0] = result;

            //Encrypt result encryptionDepth times
            for (int depth = 0; depth < encryptionDepth; depth++)
            {
                //Apply Encryption Cipher on current value of result
                result = EncryptWithCipher(result, encryptionCipher);

                //Add new encrypted result to the encrypted array fro demonstration
                //encryptedValues[depth + 1] = result;
            }

            return result;
        }

        public static string EncryptWithCipher(string text, int[] encryptionCipher)
        {
            if (encryptionCipher == null || encryptionCipher.Length == 0)
            {
                return text;
            }

            //Store the original string converted to bytes
            //Convert the text data to Unicode byte in order to handle non ASCII value character
            byte[] bytearray = Encoding.Unicode.GetBytes(text);

            //Build byte array from the original byte array that will receive the encrypted values
            byte[] bytearrayresult = bytearray;

            int encryptionCipherIndex = 0;

            //Apply Encryption Cipher
            for (int i = 0; i < bytearray.Length; i++)
            {
                //Set the Cipher index
                encryptionCipherIndex = i;

                //We reset the current encryption position to 0 to restart at the beginning of the encryptionCipher
                if (encryptionCipherIndex >= encryptionCipher.Length)
                {
                    //Reset the cryper postion to zero and restart sequence
                    encryptionCipherIndex = 0;
                }

                //These lines are for demonstration to show values
                //byte bytecharacter = bytearray[i];
                //int CipherChar = encryptionCipher[encryptionCipherIndex];

                //Change the value of the current character by the values received from the encryptionCipher array
                //int newchar = bytearray[i] + encryptionCipher[encryptionCipherIndex];

                //Change the value of the current character by the values received from the encryptionCipher array
                if (bytearray[i] != 0)
                {
                    bytearrayresult[i] = (byte)(bytearray[i] + encryptionCipher[encryptionCipherIndex]);
                }
            }

            string newresult = Encoding.Unicode.GetString(bytearrayresult);

            return newresult;
        }

        //Reference: https://klasserom.azurewebsites.net/CourseStrands/Binder/3894
        public static string DeepDecryptWithCipher(string originalText, int[] encryptionCipher, int encryptionDepth)
        {
            string result = originalText;

            //For demonstration
            string[] encryptedValues = new string[encryptionDepth + 1];
            encryptedValues[0] = result;

            //Encrypt result encryptionDepth times
            for (int depth = 0; depth < encryptionDepth; depth++)
            {
                //Apply Encryption Cipher on current value of result
                result = DecryptWithCipher(result, encryptionCipher);

                //Add new encrypted result to the encrypted array fro demonstration
                encryptedValues[depth + 1] = result;
            }

            return result;
        }

        /// <summary>
        /// Decrypts a cipher encrypted string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="encryptionCipher"></param>
        /// <returns></returns>
        public static string DecryptWithCipher(string text, int[] encryptionCipher)
        {
            //Convert the text data to Unicode byte in order to handle non ASCII value character
            byte[] bytearray = Encoding.Unicode.GetBytes(text);
            //Build byte array from the original byte array that will receive the encrypted values
            byte[] bytearrayresult = bytearray;

            int encryptionCipherIndex = 0;

            for (int i = 0; i < bytearray.Length; i++)
            {
                //Set the Cipher index
                encryptionCipherIndex = i;

                //We reset the current encryption position to 0 to restart at the beginning of the encryptionCipher
                if (encryptionCipherIndex >= encryptionCipher.Length)
                {
                    //Reset the cryper postion to zero and restart sequence
                    encryptionCipherIndex = 0;
                }

                if (bytearray[i] != 0)
                {
                    bytearrayresult[i] = (byte)(bytearray[i] - encryptionCipher[encryptionCipherIndex]);
                }
            }

            string newresult = Encoding.Unicode.GetString(bytearrayresult);

            return newresult;
        }


    }
}
