using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace VCore_Lib.Model
{
    internal interface IMBase
    {
        string Id { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        bool Equals([AllowNull] MBase other);
        bool Equals(object obj);
        int GetHashCode();
        void RaisePropertyChanged(string Property);
        string ToString();
    }
}