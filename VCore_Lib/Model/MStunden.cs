using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace VCore_Lib.Model
{
    public class MStunden : MBase, IMBase
    {
        private DateTime _Start;
        private DateTime _Ende;
        private double _Pause;

        public string Start { get { return DateTime_To_String(_Start); } set { if (_Start != String_To_DateTime(value)) { _Start = String_To_DateTime(value); RaisePropertyChanged("Start"); RaisePropertyChanged("Arbeitszeit"); } } }
        public string Ende { get { return DateTime_To_String(_Ende); } set { if (_Ende != String_To_DateTime(value)) { _Ende = String_To_DateTime(value); RaisePropertyChanged("Ende"); RaisePropertyChanged("Arbeitszeit"); } } }
        public string Pause { get { return Double_To_String(_Pause); } set { if (_Pause != String_To_Double(value)) { _Pause = String_To_Double(value); RaisePropertyChanged("Pause"); RaisePropertyChanged("Arbeitszeit"); } } }
        public string Arbeitszeit { get { if (_Start != null || _Ende != null) { return Double_To_String((_Ende - _Start).TotalHours - _Pause); } return "0.00"; } }
                                                                                                                  
        private double String_To_Double(string value)
        {
            value = value.Replace(".", ",");
            if (double.TryParse(value, out double result))
                return result;
            return 0.0f;
        }
        private string Double_To_String(double value) {
            return value.ToString("0.00");
        }
        private DateTime String_To_DateTime(string value)
        {
            try
            {
                if (DateTime.TryParseExact(value, "dd.MM.yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime result))
                {
                    return result;
                }
                else
                {
                    return DateTime.Now;
                }
            }
            catch { return DateTime.Now; }
        }
        private string DateTime_To_String(DateTime value) {
            return value.ToString("dd.MM.yyyy HH:mm");
        }
    }
}
