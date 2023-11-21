using CompressAndDecompressText;
using Microsoft.IO;
using System.IO.Compression;
using System.Text;

public class Program 
{
    public static void Main() 
    {
        // Original Text
        string originalText = "Hello, this is a simple example of compression and decompression text";

        //Compress text
        byte[] compressedData = CompressText(originalText);
        Console.WriteLine("Compressed Data: " + Convert.ToBase64String(compressedData));

        string decompressedText = DecompressText(compressedData);
        Console.WriteLine("Decompressed Text: " + decompressedText);

    }

    private static byte[] CompressText(string originalText)
    {
        using (MemoryStream ms = MemoryManager.GetStream())
        {
            // Use GZipStream to compress the data
            using (var gzipStream = new GZipStream(ms, CompressionMode.Compress, true))
            using (var writer = new StreamWriter(gzipStream))
            {
                writer.Write(originalText);
            }

            // Return the compressed data as a byte array
            return ms.ToArray();
        }
    }

    private static string DecompressText(byte[] compressedData)
    {
        // Create a MemoryStream from the compressed data
        using (var compressStream = MemoryManager.GetStream(compressedData))
        {
            // Use GZipStream to decompress the data
            using (var gZipStream = new GZipStream(compressStream, CompressionMode.Decompress))
            using (var reader = new StreamReader(gZipStream))
            {
                return reader.ReadToEnd();
            }
        }
        
    }
}