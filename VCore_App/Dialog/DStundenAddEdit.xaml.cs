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
using VCore_Lib.Model;

namespace VCore_App.Dialog
{

    /// <summary>
    /// Interaktionslogik für DStundenAddEdit.xaml
    /// </summary>
    public partial class DStundenAddEdit : Window
    {
        public MStunden Value { get; set; }
        public DStundenAddEdit(MStunden stunden = null)
        {
            InitializeComponent();
            this.WindowStyle = WindowStyle.None;
            if (stunden == null)
            {
                Value = new MStunden()
                {
                    Id = Guid.NewGuid().ToString(),
                    Start = "01.01.2020 00:00",
                    Ende = "01.01.2020 00:00",
                    Pause = "0,00"
                };
            }
            else
                Value = stunden;
            Start.Text = Value.Start;
            Ende.Text = Value.Ende;
            Pause.Text = Value.Pause;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            Value.Start = Start.Text;
            Value.Ende = Ende.Text;
            Value.Pause = Pause.Text;
            Close();
        }
    }
}
