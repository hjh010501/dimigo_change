using System;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.IO;

namespace dimigopositionchange
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 
    static class RandomExtensions
    {
        public static void Shuffle<T>(this Random rng, T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string[] memberall = { };

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            string[] textfile = { };

          
           OpenFileDialog dlg = new OpenFileDialog();

  
            dlg.DefaultExt = ".txt";
            dlg.Filter = "텍스트 파일 (*.txt)|*.txt";


            bool? result = dlg.ShowDialog();


            if (result == true)
            {

                memberall = System.IO.File.ReadAllLines(dlg.FileName, Encoding.Default);
   
            }

        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (memberall.Length == 0)
            {
                MessageBox.Show("귀찮으시더라두 학생 명단 불러와 주세용....", "에러");
            }
            else
            {


                new Random().Shuffle(memberall);

                a1.Text = memberall[0];
                a2.Text = memberall[1];
                a3.Text = memberall[2];
                a4.Text = memberall[3];
                a5.Text = memberall[4];
                a6.Text = memberall[5];

                b1.Text = memberall[6];
                b2.Text = memberall[7];
                b3.Text = memberall[8];
                b4.Text = memberall[9];
                b5.Text = memberall[10];
                b6.Text = memberall[11];

                c1.Text = memberall[12];
                c2.Text = memberall[13];
                c3.Text = memberall[14];
                c4.Text = memberall[15];
                c5.Text = memberall[16];
                c6.Text = memberall[17];

                d1.Text = memberall[18];
                d2.Text = memberall[19];
                d3.Text = memberall[20];
                d4.Text = memberall[21];
                d5.Text = memberall[22];
                d6.Text = memberall[23];

                e1.Text = memberall[24];
                e2.Text = memberall[25];
                e3.Text = memberall[26];
                e4.Text = memberall[27];
                e5.Text = memberall[28];
                e6.Text = memberall[29];

                f1.Text = memberall[30];
                f2.Text = memberall[31];
                f3.Text = memberall[32];
                f4.Text = memberall[33];
                f5.Text = memberall[34];
                f6.Text = memberall[35];
              

            }


        }


        public static void CreateBitmapFromVisual(Visual target, string fileName)
        {
            if (target == null || string.IsNullOrEmpty(fileName))
            {
                return;
            }

            Rect bounds = VisualTreeHelper.GetDescendantBounds(target);

            RenderTargetBitmap renderTarget = new RenderTargetBitmap((Int32)bounds.Width, (Int32)bounds.Height, 96, 96, PixelFormats.Pbgra32);

            DrawingVisual visual = new DrawingVisual();

            using (DrawingContext context = visual.RenderOpen())
            {
                VisualBrush visualBrush = new VisualBrush(target);
                context.DrawRectangle(visualBrush, null, new Rect(new Point(), bounds.Size));
            }

            renderTarget.Render(visual);
            PngBitmapEncoder bitmapEncoder = new PngBitmapEncoder();
            bitmapEncoder.Frames.Add(BitmapFrame.Create(renderTarget));
            using (Stream stm = File.Create(fileName))
            {
                bitmapEncoder.Save(stm);
            }
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".jpg";
            sfd.Filter = "이미지 파일 (*.jpg)|*.jpg";

            bool? result = sfd.ShowDialog();


            if (result == true)
            {
                CreateBitmapFromVisual(this, sfd.FileName);
            }

        }


    }
}
