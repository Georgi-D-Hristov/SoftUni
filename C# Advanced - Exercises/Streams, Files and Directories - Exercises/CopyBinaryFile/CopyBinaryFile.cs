using System.IO;

namespace CopyBinaryFile
{
    using System;
    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (var inputStream = new FileStream(inputFilePath,FileMode.Open,FileAccess.Read))
            {
                using (var outputStream = new FileStream(outputFilePath,FileMode.Create,FileAccess.Write))
                {
                    var buffer = new byte[1024];
                    int bufferRead;

                    while ((bufferRead=inputStream.Read(buffer,0,buffer.Length))>0)
                    {
                        outputStream.Write(buffer,0,buffer.Length);
                    }
                }
            }
        }
    }
}
