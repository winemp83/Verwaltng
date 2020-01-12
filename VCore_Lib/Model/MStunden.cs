namespace VCore_Lib.Model
{
    public class MStunden : MBase, IMBase
    {
        private MDatum _Start;
        private MDatum _Ende;
        private double _Pause;

        public MStunden() {
            _Start = new MDatum();
            _Ende = new MDatum();
        }

        public string Start { get { return _Start.ToString(); } set { if (_Start.ToString() != value) { _Start.Value = value; RaisePropertyChanged("Start"); RaisePropertyChanged("Arbeitszeit"); } } }
        public string Ende { get { return _Ende.ToString(); } set { if (_Ende.ToString() != value) { _Ende.Value = value; RaisePropertyChanged("Ende"); RaisePropertyChanged("Arbeitszeit"); } } }
        public string Pause { get { return Double_To_String(_Pause); } set { if (_Pause != String_To_Double(value)) { _Pause = String_To_Double(value); RaisePropertyChanged("Pause"); RaisePropertyChanged("Arbeitszeit"); } } }
        public string Arbeitszeit { get { if (_Start != null || _Ende != null) { return Double_To_String((_Ende.GetDateTime - _Start.GetDateTime).TotalHours - _Pause); } return "0.00"; } }
                                                                                                                  
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
        
    }
}
