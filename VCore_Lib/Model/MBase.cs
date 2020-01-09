using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace VCore_Lib.Model
{
    public class MBase : INotifyPropertyChanged, IEquatable<MBase>, IMBase
    {
        private string _Id;

        public string Id
        {
            get { return _Id; }
            set
            {
                if (Id != value)
                {
                    _Id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override bool Equals(object obj)
        {
            return Equals(obj as MBase);
        }

        public bool Equals([AllowNull] MBase other)
        {
            return other != null &&
                   Id == other.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public void RaisePropertyChanged(string Property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(Property));
        }

        public override string ToString()
        {
            return _Id;
        }

        public static bool operator ==(MBase left, MBase right)
        {
            return EqualityComparer<MBase>.Default.Equals(left, right);
        }

        public static bool operator !=(MBase left, MBase right)
        {
            return !(left == right);
        }
    }
}
