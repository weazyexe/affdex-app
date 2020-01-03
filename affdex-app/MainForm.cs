using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Affdex;

namespace AffdexApp
{
    public partial class MainForm : Form, ImageListener
    {
        private EmotionRecognizer recognizer;
        private Image image;
        private Graphics graphics;
        private Stopwatch stopwatch;
        private const string AffdexApp = "Affdex App - ";
        private bool isRecognizerCreated = false;
        DateTime timer = new DateTime();

        private int mode = 0;
        private string file = "";
        private int dataset = 0;

        public MainForm()
        {
            InitializeComponent();
            stopwatch = new Stopwatch();
        }

        public void onImageResults(Dictionary<int, Face> faces, Frame frame)
        {
            stopwatch.Stop();
            var result = new StringBuilder();
            switch (mode)
            {
                case 0:
                    Func<int> func;

                    result.Append($"Total processing time: {stopwatch.Elapsed.TotalMilliseconds / 1000}s\n\n");

                    foreach (var face in faces.Values)
                    {
                        result.Append(GetFaceEmotionsInfo(face));
                        func = () =>
                        {
                            DrawFeaturePoints(face.FeaturePoints);
                            return 0;
                        }; 
                        
                        DoOnMainThread(func);
                    }

                    if (faces.Values.Count == 0)
                    {
                        result.Append("Faces not found or image is invalid");
                    }

                    func = () =>
                    {
                        Text = AffdexApp + "Done";
                        ResultTextBox.Lines = result.ToString().Split('\n');
                        timer1.Stop();
                        return 0;
                    };

                    DoOnMainThread(func);

                    break;
                case 1:
                    var findedFace = faces.Values.First();

                    var emotion = GetEmotion(findedFace);

                    result.Append($"{stopwatch.Elapsed.TotalMilliseconds / 1000}s /// {file} /// {emotion}");

                    var path = dataset == 0 ? "lfw_result.txt" : "celeba_result.txt";

                    using (var sw = File.AppendText(path))
                    {
                        sw.WriteLine(result);
                    }
                    break;
            }

            stopwatch.Reset();
        }

        public void onImageCapture(Frame frame)
        {
            
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

        private async void ProcessButton_Click(object sender, EventArgs e)
        {
            TimeLabel.Text = "00:00:00";
            timer = new DateTime();
            await StartProcess();
        }

        private void Log(string message)
        {
            LogListView.Items.Add(message);
            LogListView.SelectedIndex = LogListView.Items.Count - 1;
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            DatasetComboBox.SelectedItem = null;
            DatasetComboBox.SelectedIndex = 0;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            var dataset = DatasetComboBox.SelectedIndex;

            TimeLabel.Text = "00:00:00";
            timer = new DateTime();
            timer1.Start();

            switch (dataset)
            {
                case 0:
                    ProcessLFW();
                    break;
                case 1:
                    ProcessCeleba();
                    break;
            }
        }

        private async void ProcessLFW()
        {
            EnableDisableButtons();
            var path = @"C:\Users\weazy\Desktop\lfw";
            var directories = Directory.GetDirectories(path);

            var dirsProcessed = 0;
            foreach (var directory in directories)
            {
                var filesProcessed = 0;
                var files = Directory.GetFiles($"{directory}");

                foreach (var file in files)
                {
                    this.file = file.Split('\\').Last();
                    image = Image.FromFile($"{file}");
                    ImagePicBox.Image = image;
                    await StartProcess();
                    filesProcessed++;

                    Text =
                        $"{AffdexApp}{dirsProcessed}/{directories.Length} dirs, {filesProcessed}/{files.Length} files";
                }

                dirsProcessed++;
                Text =
                    $"{AffdexApp}{dirsProcessed}/{directories.Length} dirs, {filesProcessed}/{files.Length} files";
            }
            EnableDisableButtons();
            timer1.Stop();
        }

        private async void ProcessCeleba()
        {
            EnableDisableButtons();
            var path = @"C:\Users\weazy\Desktop\celeba";
            var filesProcessed = 0;
            var files = Directory.GetFiles($"{path}");

            foreach (var file in files)
            {
                this.file = file.Split('\\').Last();
                image = Image.FromFile($"{file}");
                ImagePicBox.Image = image;
                await StartProcess();
                filesProcessed++;

                Text =
                    $"{AffdexApp}{filesProcessed}/{files.Length} files";
            }
            EnableDisableButtons();
            timer1.Stop();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mode = tabControl1.SelectedIndex;
        }

        private async Task StartProcess()
        {
            SetStatusBar(true, "Processing");
            
            
            stopwatch.Start();

            try
            {
                await Task.Run(() =>
                {
                    recognizer.Recognize(image);
                }); 

                Log("Done");
            }
            catch (AffdexException ex)
            {
                ResultTextBox.Text = $"Affdex error: {ex.Message}";
                Log("Processing ends with error");
            }

            SetStatusBar(false, "I\'m done");
        }

        private void EnableDisableButtons()
        {
            StartButton.Enabled = !StartButton.Enabled;
            ProcessButton.Enabled = !ProcessButton.Enabled;
            LoadButton.Enabled = !LoadButton.Enabled;
            DatasetComboBox.Enabled = !DatasetComboBox.Enabled;
        }

        private void DatasetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataset = DatasetComboBox.SelectedIndex;
        }

        private string GetEmotion(Face face)
        {
            var currentEmotionValue = face.Emotions.Anger;
            var currentEmotionDesc = "Anger";

            if (face.Emotions.Contempt > currentEmotionValue)
            {
                currentEmotionValue = face.Emotions.Contempt;
                currentEmotionDesc = "Contempt";
            }

            if (face.Emotions.Disgust > currentEmotionValue)
            {
                currentEmotionValue = face.Emotions.Disgust;
                currentEmotionDesc = "Disgust";
            }

            if (face.Emotions.Engagement > currentEmotionValue)
            {
                currentEmotionValue = face.Emotions.Engagement;
                currentEmotionDesc = "Engagement";
            }

            if (face.Emotions.Fear > currentEmotionValue)
            {
                currentEmotionValue = face.Emotions.Fear;
                currentEmotionDesc = "Fear";
            }

            if (face.Emotions.Joy > currentEmotionValue)
            {
                currentEmotionValue = face.Emotions.Joy;
                currentEmotionDesc = "Joy";
            }

            if (face.Emotions.Sadness > currentEmotionValue)
            {
                currentEmotionValue = face.Emotions.Sadness;
                currentEmotionDesc = "Sadness";
            }

            if (face.Emotions.Surprise > currentEmotionValue)
            {
                currentEmotionValue = face.Emotions.Surprise;
                currentEmotionDesc = "Surprise";
            }

            if (face.Emotions.Valence > currentEmotionValue)
            {
                currentEmotionValue = face.Emotions.Valence;
                currentEmotionDesc = "Valence";
            }

            return currentEmotionDesc;
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

        private void MainForm_MouseHover(object sender, EventArgs e)
        {
            InitialLoad();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer = timer.AddSeconds(1);
            TimeLabel.Text = (timer.Hour >= 10 ? timer.Hour.ToString() : "0" + timer.Hour) + ":" + (timer.Minute >= 10 ? timer.Minute.ToString() : "0" + timer.Minute) + ":" + (timer.Second >= 10 ? timer.Second.ToString() : "0" + timer.Second);
        }

        private void SetStatusBar(bool isRun, string label)
        {
            StatusLabel.Text = label;
            LoadingProgressBar.Style = isRun ? ProgressBarStyle.Marquee : ProgressBarStyle.Blocks;
        }

        private async void InitialLoad()
        {
            if (!isRecognizerCreated)
            {
                SetStatusBar(true, "Loading");
                EnableDisableButtons();
                isRecognizerCreated = true;
                await Task.Run(() =>
                {
                    recognizer = new EmotionRecognizer(this);
                });
                EnableDisableButtons();
                SetStatusBar(false, "Done. Make your stuff");
            }
        }

        private void ImagePicBox_MouseMove(object sender, MouseEventArgs e)
        {
            InitialLoad();
        }

        private void tabControl1_MouseMove(object sender, MouseEventArgs e)
        {
            InitialLoad();
        }

        private void DoOnMainThread(Func<int> func)
        {
            try
            {
                Invoke((MethodInvoker)delegate {
                    func();
                });
            }
            catch
            {

            }
        }
    }
}
