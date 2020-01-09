using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace VCore_Lib.Model
{
    public class MPerson : MBase, IMBase
    {
        private string _VName;
        private string _NName;
        private string _Mid;
        private string _TaughtNr;
        
        public string VName
        {
            get { return _VName; }
            set { if (_VName != value) { _VName = value; RaisePropertyChanged("VName"); } }
        }
        public string NName
        {
            get { return _NName; }
            set { if (_NName != value) { _NName = value; RaisePropertyChanged("NName"); } }
        }

    }
}
