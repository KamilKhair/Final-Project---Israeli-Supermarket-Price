using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsraeliSuperMarketManager.Extensions
{
    internal static class ManagerExtensions
    {
        public static Bitmap Base64StringToBitmap(this string base64String)
        {
            Bitmap bmpReturn = null;
            var byteBuffer = Convert.FromBase64String(base64String);
            var memoryStream = new MemoryStream(byteBuffer) {Position = 0};
            bmpReturn = (Bitmap)Image.FromStream(memoryStream);
            memoryStream.Close();
            memoryStream = null;
            byteBuffer = null;
            return bmpReturn;
        }
    }
}
