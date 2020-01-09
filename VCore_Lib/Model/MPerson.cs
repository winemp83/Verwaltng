﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace VCore_Lib.Model
{
    public class MPerson : MBase, IMBase, IEquatable<MPerson>
    {
        private string _VName;
        private string _NName;
        private string _Mid;
        private string _TaughtNr;
        
        public string VName
        {
            get { return _VName; }
            set { if (_VName != value) { _VName = value; RaisePropertyChanged("VName"); RaisePropertyChanged("FullName"); } }
        }
        public string NName
        {
            get { return _NName; }
            set { if (_NName != value) { _NName = value; RaisePropertyChanged("NName"); RaisePropertyChanged("FullName"); } }
        }
        public string Mid 
        { 
            get { return _Mid; }
            set { if (_Mid != value) { _Mid = value; RaisePropertyChanged("Mid"); } }
        }
        public string TaughtNr
        {
            get { return _TaughtNr; }
            set { if (_TaughtNr != value) { _TaughtNr = value; RaisePropertyChanged("TaughtNr"); } }
        }
        public string FullName { get { return $@"{NName}, {VName}"; } }

        public override bool Equals(object obj)
        {
            return Equals(obj as MPerson);
        }

        public bool Equals([AllowNull] MPerson other)
        {
            return other != null &&
                   base.Equals(other) &&
                   VName == other.VName &&
                   NName == other.NName &&
                   Mid == other.Mid &&
                   TaughtNr == other.TaughtNr;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), VName, NName, Mid, TaughtNr);
        }

        public static bool operator ==(MPerson left, MPerson right)
        {
            return EqualityComparer<MPerson>.Default.Equals(left, right);
        }

        public static bool operator !=(MPerson left, MPerson right)
        {
            return !(left == right);
        }
    }
}
