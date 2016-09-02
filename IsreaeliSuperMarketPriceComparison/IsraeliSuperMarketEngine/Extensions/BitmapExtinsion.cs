using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace IsraeliSuperMarketEngine.Extensions
{
    public static class ExtBitmap
    {
        public static string ToBase64String(this Bitmap bmp, ImageFormat imageFormat)
        {
            var memoryStream = new MemoryStream();
            bmp.Save(memoryStream, imageFormat);
            memoryStream.Position = 0;
            var byteBuffer = memoryStream.ToArray();
            memoryStream.Close();
            var base64String = Convert.ToBase64String(byteBuffer);
            return base64String;
        }

        public static Bitmap Base64StringToBitmap(this string base64String)
        {
            var byteBuffer = Convert.FromBase64String(base64String);
            var memoryStream = new MemoryStream(byteBuffer) {Position = 0};
            var bmpReturn = (Bitmap)Image.FromStream(memoryStream);
            memoryStream.Close();
            return bmpReturn;
        }
    }
}