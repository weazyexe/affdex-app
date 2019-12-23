using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using Affdex;

namespace AffdexApp
{
    public partial class MainForm : Form, ImageListener
    {
        private PhotoDetector detector;
        private Image image;
        private Graphics graphics;
        private Stopwatch stopwatch;
        private const string AffdexApp = "Affdex App - ";

        public MainForm()
        {
            InitializeComponent();
            detector = new PhotoDetector(3, FaceDetectorMode.SMALL_FACES);

            var classifierPath = @"D:\dev\AffdexSDK\data";
            detector.setClassifierPath(classifierPath);

            detector.setDetectAllExpressions(true);
            detector.setDetectAllEmotions(true);
            detector.setDetectAllEmojis(true);
            detector.setDetectAllAppearances(true);

            detector.setImageListener(this);

            stopwatch = new Stopwatch();
        }

        public void onImageResults(Dictionary<int, Face> faces, Frame frame)
        {
            stopwatch.Stop();
            Text = AffdexApp + "Done";

            var result = new StringBuilder();
            result.Append($"Total processing time: {stopwatch.Elapsed.TotalMilliseconds / 1000}s\n\n");

            foreach (var face in faces.Values)
            {
                result.Append(GetFaceEmotionsInfo(face));
                DrawFeaturePoints(face.FeaturePoints);
            }

            if (faces.Values.Count == 0)
            {
                result.Append("Faces not found or image is invalid");
            }

            ResultTextBox.Lines = result.ToString().Split('\n');
            stopwatch.Reset();
        }

        public void onImageCapture(Frame frame)
        {
            Text = AffdexApp + "Captured. Find faces...";
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Open image";
                ofd.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    image = Image.FromFile(ofd.FileName);
                    ImagePicBox.Image = image;
                    graphics = ImagePicBox.CreateGraphics();
                    Text = AffdexApp + "Ok, now find some emotions";
                }
            }
        }

        private void ProcessButton_Click(object sender, EventArgs e)
        {
            var frame = ImageToFrame(image);
            Log("Frame created");
            Text = AffdexApp + "Capturing...";

            stopwatch.Start();
            detector.start();
            Log("Detector started. Processing...");

            try
            {
                detector.process(frame);
                Log("Done");
            }
            catch (AffdexException ex)
            {
                ResultTextBox.Text = $"Affdex error: {ex.Message}";
                Log("Processing ends with error");
            }
            
            
            detector.stop();
        }

        private Frame ImageToFrame(Image image)
        {

            Bitmap bitmap = (Bitmap) image;

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

        private void Log(string message)
        {
            LogListView.Items.Add(message);
        }

        private string GetFaceEmotionsInfo(Face face)
        {
            var result = new StringBuilder();

            result.Append($"Emotions (face_id={face.Id}):\n");
            result.Append($"Anger: {face.Emotions.Anger}\n");
            result.Append($"Disgust: {face.Emotions.Disgust}\n");
            result.Append($"Fear: {face.Emotions.Fear}\n");
            result.Append($"Sadness: {face.Emotions.Sadness}\n");
            result.Append($"Joy: {face.Emotions.Joy}\n");
            result.Append($"Surprise: {face.Emotions.Surprise}\n");
            result.Append($"Contempt: {face.Emotions.Contempt}\n");
            result.Append($"Engagement: {face.Emotions.Engagement}\n");
            result.Append($"Valence: {face.Emotions.Valence}\n");
            result.Append($"Fear: {face.Emotions.Fear}\n\n");

            return result.ToString();
        }

        private void DrawFeaturePoints(FeaturePoint[] featurePoints)
        {
            var pen = new Pen(Color.Red, 2);

            var ratioX = ImagePicBox.Width / (float)image.Width;
            var ratioY = ImagePicBox.Height / (float)image.Height;

            foreach (var featurePoint in featurePoints)
            {
                graphics.DrawEllipse(pen, featurePoint.X * ratioX, featurePoint.Y * ratioY, 2, 2);
            }
        }
    }
}
