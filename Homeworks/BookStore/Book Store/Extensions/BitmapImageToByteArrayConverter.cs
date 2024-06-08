using System.IO;
using System.Windows.Media.Imaging;

namespace Book_Store.Extensions
{
    internal static class BitmapImageToByteArrayConverter
    {
        public static byte[] GetBytes(this BitmapImage image)
        {
            byte[] data;
            var encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (var ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }

            return data;
        }
    }
}