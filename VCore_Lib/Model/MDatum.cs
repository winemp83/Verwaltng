using System;
using System.Collections.Generic;
using System.Text;

namespace VCore_Lib.Model
{
    public class MDatum:MBase
    {
        private DateTime _Value;
        public string Value
        {
            get { return this.ToString(); }
            set
            {
                if (_Value != String_To_DateTime(value)) {
                    _Value = String_To_DateTime(value);
                    RaisePropertyChanged("Value");
                }
            }
        }

        public DateTime GetDateTime { 
            get { return _Value; }
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
        private string DateTime_To_String(DateTime value)
        {
            return value.ToString("dd.MM.yyyy HH:mm");
        }

        public override string ToString()
        {
            return DateTime_To_String(_Value);
        }
    }
}
