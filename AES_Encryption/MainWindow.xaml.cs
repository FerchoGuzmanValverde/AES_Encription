using System;
using System.Collections.Generic;
using System.Linq;
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
using System.IO;
using Microsoft.Win32;

namespace AES_Encryption
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OpenFileDialog ofd;
        string file;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            loadFile("Text files (*.txt)|*.txt");
            string encrypt = "";

            if (ofd.ShowDialog() == true)
            {
                file = ofd.FileName;
                lblMsg.Content = "The file is: " + file;
                encrypt = File.ReadAllText(file);
                byte[] encrypted = AES.Encriptar(encrypt);
                File.WriteAllBytes(file.Replace(".txt", "_Encript.data"), encrypted);
                lblMsg.Content = "The process has finished...";
            }
        }

        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            loadFile("Data files (*.data)|*.data");
            string decrypted = "";
            if (ofd.ShowDialog() == true)
            {
                file = ofd.FileName;

                lblMsg.Content = "Current file: " + file;
                byte[] decrypt = File.ReadAllBytes(file);
                decrypted = AES.Desencripta(decrypt);
                File.WriteAllText(file.Replace("_Encript.data", "_Decript.txt"), decrypted);
                lblMsg.Content = "The process has finished...";
            }
        }

        private void loadFile(string filter)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = filter;
        }
    }
}
