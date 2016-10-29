using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace Base64Converter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FromFileToBase64(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            SaveFileDialog saveFile = new SaveFileDialog();

            if (openFile.ShowDialog() == true)
            {
                try
                {
                    var parseTo64 = Convert.ToBase64String(File.ReadAllBytes(openFile.FileName));
                    if (saveFile.ShowDialog() == true)
                    {
                        StreamWriter file = new StreamWriter(saveFile.FileName);
                        file.WriteLine(parseTo64);
                        file.Close();
                    }

                    MessageBox.Show("Encoding was successful");
                }
                catch (FileLoadException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void FromBase64ToFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            SaveFileDialog saveFile = new SaveFileDialog();

            if (openFile.ShowDialog() == true)
            {
                try
                {
                    //To decode file to prevorious state, it is needed to keep somewhere filename(here that is not implemented)
                    var parseToFile = Convert.FromBase64String(File.ReadAllText(openFile.FileName));
                    if (saveFile.ShowDialog() == true)
                    {
                        File.WriteAllBytes(saveFile.FileName, parseToFile);
                    }

                    MessageBox.Show("Decoding was successful");
                }
                catch (FileLoadException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}