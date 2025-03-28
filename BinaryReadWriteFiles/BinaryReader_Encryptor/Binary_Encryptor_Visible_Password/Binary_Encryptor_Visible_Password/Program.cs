// See https://aka.ms/new-console-template for more information

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        
        //string inputFile = "/Users/mmohanraaji/Documents/E/Practise Programs/BinaryDemo_2/BinaryReaderEncrypt/BinaryReaderEncrypt/InputFile.txt";
        //string outputFile = "/Users/mmohanraaji/Documents/E/Practise Programs/BinaryDemo_2/BinaryReaderEncrypt/BinaryReaderEncrypt/OutputFile.txt";
        
        
        string inputFile = "/Users/mmohanraaji/Documents/E/Practise Programs/BinaryDemo_2/BinaryReaderEncrypt/BinaryReaderEncrypt/OutputFile.txt";
        string outputFile = "/Users/mmohanraaji/Documents/E/Practise Programs/BinaryDemo_2/BinaryReaderEncrypt/BinaryReaderEncrypt/InputFile.txt";
            
            
        Console.WriteLine("Enter the Password : ");
        string password = Console.ReadLine();

        if (string.IsNullOrEmpty(password))
        {
            Console.WriteLine("Please enter a password");
            password = Console.ReadLine();
        }
        
        

        if (File.Exists(inputFile))
        {
            try
            {
                byte[] key = GenerateKey(password);
                
                
                using(BinaryReader reader = new BinaryReader(File.Open(inputFile, FileMode.Open)))
                using (BinaryWriter writer = new BinaryWriter(File.Open(outputFile, FileMode.Create)))
                {
                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        byte byteData = reader.ReadByte();
                        byte encryptedByte = XOREncrypt(byteData, key);
                        writer.Write(encryptedByte);
                    }
                    
                    Console.WriteLine("Data copied successfully.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred : "+e.Message);
            }
        }
        else
        {
            {
                Console.WriteLine("Input file does not exist.");
            }
        }
    }

    static byte[] GenerateKey(string password)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        return passwordBytes;
    }

    static byte XOREncrypt(byte data, byte[] key)
    {
        int keyIndex = 0;
        byte encryptedByte = data;

        foreach (var keyByte in key)
        {
            encryptedByte ^= keyByte;
            keyIndex++;
            if (keyIndex >= key.Length)
            {
                keyIndex = 0;
            }
        }
        return encryptedByte;
    }
}