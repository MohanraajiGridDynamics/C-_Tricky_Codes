// See https://aka.ms/new-console-template for more information

using System;
using System.IO;

class Program
{
    static void Main()
    {
        
        string inputFile = "/Users/mmohanraaji/Documents/E/C_Sharp_Tips_and_Tricks/BinaryReadWriteFiles/BinaryReaderandWriter/BinaryReadAndWriteData/BinaryReadAndWriteData/InputFile.txt";
        string outputFile = "/Users/mmohanraaji/Documents/E/C_Sharp_Tips_and_Tricks/BinaryReadWriteFiles/BinaryReaderandWriter/BinaryReadAndWriteData/BinaryReadAndWriteData/OutputFile.txt";

        if (File.Exists(inputFile))
        {
            try
            {
                using(BinaryReader reader = new BinaryReader(File.Open(inputFile, FileMode.Open)))
                using (BinaryWriter writer = new BinaryWriter(File.Open(outputFile, FileMode.Create)))
                {
                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        byte byteData = reader.ReadByte();
                        
                        writer.Write(byteData);
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
}