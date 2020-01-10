using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VCore_App.Dialog
{
    /// <summary>
    /// Interaktionslogik für DMonatsAuswahl.xaml
    /// </summary>
    public partial class DMonatsAuswahl : Window
    {
        public Dictionary<string, int> Monat;
        public string Month;
        public DMonatsAuswahl()
        {
            InitializeComponent();
            Monat = new Dictionary<string, int>();
            this.WindowStyle = WindowStyle.None;
            CreateMonat();
            listBox.ItemsSource = Monat;
        }

        private void CreateMonat()
        {
            Monat.Clear();
            Monat.Add("Januar", 1);
            Monat.Add("Februar", 2);
            Monat.Add("März", 3);
            Monat.Add("April", 4);
            Monat.Add("Mai", 5);
            Monat.Add("Juni", 6);
            Monat.Add("Juli", 7);
            Monat.Add("August", 8);
            Monat.Add("September", 9);
            Monat.Add("Oktober", 10);
            Monat.Add("November", 11);
            Monat.Add("Dezember", 12);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            string[] result = listBox.SelectedItem.ToString().Replace('[', ' ').Replace(']', ' ').TrimStart().TrimEnd().Split(',');
            Month = (result[1].TrimStart().Length == 1)? "0"+result[1].TrimStart(): result[1].TrimStart();
            Close();
        }
    }
}
