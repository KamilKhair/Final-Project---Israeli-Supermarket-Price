using System;
using System.Drawing;
using System.IO;

namespace IsraeliSuperMarketManager.Extensions
{
    internal static class ManagerExtensions
    {
        public static Bitmap Base64StringToBitmap(this string base64String)
        {
            var byteBuffer = Convert.FromBase64String(base64String);
            using (var memoryStream = new MemoryStream(byteBuffer) {Position = 0})
            {
                var bmpReturn = (Bitmap) Image.FromStream(memoryStream);
                memoryStream.Close();
                return bmpReturn;
            }
        }
    }
}
