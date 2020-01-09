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
    /// Interaktionslogik für DPersonAddEdit.xaml
    /// </summary>
    public partial class DPersonAddEdit : Window
    {
        public MPerson Value { get; set; }

        public DPersonAddEdit(MPerson person = null)
        {
            InitializeComponent();
            this.WindowStyle = WindowStyle.None;
            if (person == null)
            {
                Value = new MPerson()
                {
                    Id = Guid.NewGuid().ToString(),
                    VName = "Max",
                    NName = "Mustermann",
                    Mid = "000",
                    TaughtNr = ""
                };
            }
            else
                Value = person;
            VName.Text = Value.VName;
            NName.Text = Value.NName;
            Mid.Text = Value.Mid;
            TaughtNr.Text = Value.TaughtNr;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            Value.VName = VName.Text;
            Value.NName = NName.Text;
            Value.Mid = Mid.Text;
            Value.TaughtNr = TaughtNr.Text;
            Close();
        }
    }
}
