using System;
using System.IO;

public static class ImageHelper
{
    public static byte[] LoadImageAsByteArray(string imagePath)
    {
        try
        {
            // Check if the image file exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine($"Image file '{imagePath}' does not exist.");
                return null;
            }

            // Read the image file into a byte array
            byte[] imageData;
            using (FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader binaryReader = new BinaryReader(fileStream))
                {
                    imageData = binaryReader.ReadBytes((int)fileStream.Length);
                }
            }

            return imageData;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading the image: {ex.Message}");
            return null;
        }
    }
}