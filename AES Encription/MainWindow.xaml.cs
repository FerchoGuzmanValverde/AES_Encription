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

namespace AES_Encription
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AES aesObj;
        string decriptedMsg;
        byte[] encriptedCode;
        string encriptedMsg;

        public MainWindow()
        {
            InitializeComponent();
            aesObj = new AES();
        }

        private void btn_Encription_Click(object sender, RoutedEventArgs e)
        {
            decriptedMsg = txtEInput.Text.ToString();
            encriptedMsg = AES.encriptadoAES(decriptedMsg);
            encriptedCode = AES.Encriptar(decriptedMsg);
            txtResultE.Text = "Result: " + encriptedMsg;
        }

        private void btn_Decription_Click(object sender, RoutedEventArgs e)
        {
            decriptedMsg = AES.Desencripta(encriptedCode);
            txtResultD.Text = "Result: " + decriptedMsg;
        }

        private void btn_AllOne_Click(object sender, RoutedEventArgs e)
        {

        }

        private string ByteArrayToString(byte[] code)
        {
            string result = "";
            for (int i = 0; i < code.Length; i++)
            {
                if (i == code.Length - 1)
                {
                    result = result + code[i].ToString();
                }
                else
                {
                    result = result + code[i].ToString() + "-";
                }
            }
            return result;
        }

        private byte[] StringToByteArray(string msg)
        {
            List<string> codeS = new List<string>();
            string item = "";
            for (int i = 0; i < msg.Length; i++)
            {
                if(msg[i].ToString() != "-")
                {
                    item = item + msg[i].ToString();
                }
                else
                {
                    codeS.Add(item);
                    item = "";
                }
            }
            byte[] code = new byte[codeS.Count];
            for (int i = 0; i < code.Length; i++)
            {
                code[i] = byte.Parse(codeS.ElementAt(i));
            }
            return code;
        }
    }
}
