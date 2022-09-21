using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ImageTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
           
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image(.jpg) | *.jpg|Image(.png) |*.png";
            string imageName = tbImageName.Text;

            if (openFile.ShowDialog() == true)
            {
                ImageBox.Source = new BitmapImage(new Uri(openFile.FileName));
                
                MessageBox.Show($"{openFile} WAS ADDED.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                if (openFile.CheckFileExists)
                {
                    //string directory = @"pack://application:,,,/"; 
                    //string pathImage = "Image";
                    //string path = directory + pathImage + "/" + imageName;
                    string path = $@"C:\Users\КАБОТИК\source\repos\ImageTest\ImageTest\Image\{imageName}.jpg";

                    System.IO.File.Copy(openFile.FileName, path);
                    MessageBox.Show($"{openFile} WAS SAVED TO FOLDER.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("FILE WASN'T ADDED.", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        
    }
}
