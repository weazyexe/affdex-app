using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Affdex;

namespace AffdexApp
{
    class EmotionRecognizer
    {
        private PhotoDetector detector;
        private ImageListener listener;

        public EmotionRecognizer(ImageListener listener)
        {
            detector = new PhotoDetector(3, FaceDetectorMode.SMALL_FACES);
            var classifierPath = @"D:\dev\AffdexSDK\data";
            detector.setClassifierPath(classifierPath);
            detector.setDetectAllEmotions(true);

            detector.setImageListener(listener);

            detector.start();
        }

        public void Recognize(Image image)
        {
            try
            {
                var frame = ImageToFrame(image);
                detector.process(frame);
            }
            catch
            {
                
            }
        }

        private Frame ImageToFrame(Image image)
        {
            Bitmap bitmap = (Bitmap)image;

            // Lock the bitmap's bits.
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmpData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap. 
            int numBytes = bitmap.Width * bitmap.Height * 3;
            byte[] rgbValues = new byte[numBytes];

            int data_x = 0;
            int ptr_x = 0;
            int row_bytes = bitmap.Width * 3;      //3 bytes per pixel

            // The bitmap requires bitmap data to be byte aligned.

            for (int y = 0; y < bitmap.Height; y++)
            {
                Marshal.Copy(ptr + ptr_x, rgbValues, data_x, row_bytes);//(pixels, data_x, ptr + ptr_x, row_bytes);
                data_x += row_bytes;
                ptr_x += bmpData.Stride;
            }

            bitmap.UnlockBits(bmpData);

            return new Frame(bitmap.Width, bitmap.Height, rgbValues, Affdex.Frame.COLOR_FORMAT.RGB);
        }
    }
}
