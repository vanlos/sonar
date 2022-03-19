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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Journal> JC2;
        public MainWindow()
        {
            InitializeComponent();
            List<Journal> JC1 = new List<Journal>();
            JC1.Add(new Journal(1, "Продажа", "Козлов", "462873", "Белый", "112154"));
            JC1.Add(new Journal(2, "Продажа", "Коровина", "343535", "Иванов", "734343"));
            JC1.Add(new Journal(3, "Продажа", "Сидоров", "283732", "Егорова", "311123"));
            JC2 = new List<Journal>();
            for (int i = 0; i < JC1.Count; i++)
            {
                JC2.Add(new Journal(JC1[i].Id, shifr(JC1[i].Type), shifr(JC1[i].Person1), shifr(JC1[i].Account1),
                   shifr(JC1[i].Person2), shifr(JC1[i].Account2)));
            }
            JournalGrid.ItemsSource = JC2;
        }
        public string shifr(string s)
        {
            string alphavit = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789 ";
            string k = "12";
            int[] keys = k.Select(key => (int)Char.GetNumericValue(key)).ToArray();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                sb.Append(alphavit[(alphavit.IndexOf(s[i]) + keys[i % keys.Length]) % alphavit.Length]);
            }
            return sb.ToString();
        }
        public string rashifr(string s, string k)
        {
            int j = 0;
            string alphavit = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789 ";
            int[] keys = k.Select(key => (int)Char.GetNumericValue(key)).ToArray();
            StringBuilder sb = new StringBuilder();
            try
            {
                do
                {
                    sb.Append(alphavit[(alphavit.IndexOf(s[j]) - keys[j % keys.Length]) % alphavit.Length]);
                    j++;
                }
                while (j < s.Length);
            }
            catch (IndexOutOfRangeException e)
            {
            }
            return sb.ToString();
        }

      

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            KeyWindow kw = new KeyWindow();
            if (kw.ShowDialog() == true)
            {
                    for (int i = 0; i < JC2.Count; i++)
                    {
                        JC2[i] = new Journal(JC2[i].Id, rashifr(JC2[i].Type, kw.key), rashifr(JC2[i].Person1, kw.key), rashifr(JC2[i].Account1, kw.key),
                           rashifr(JC2[i].Person2, kw.key), rashifr(JC2[i].Account2, kw.key));
                    }
                
            }
            else 
            {
                MessageBox.Show("ХЗ чё");
            }
            
            JournalGrid.Items.Refresh();
        }
        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox4_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
