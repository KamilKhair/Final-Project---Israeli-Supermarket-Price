using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace IsraeliSuperMarketEngine.Extensions
{
    public static class EngineExtensions
    {
        public static string ToBase64String(this Bitmap bmp, ImageFormat imageFormat)
        {
            using (var memoryStream = new MemoryStream())
            {
                bmp.Save(memoryStream, imageFormat);
                memoryStream.Position = 0;
                var byteBuffer = memoryStream.ToArray();
                memoryStream.Close();
                var base64String = Convert.ToBase64String(byteBuffer);
                return base64String;
            }
        }
    }
}