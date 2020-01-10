using System;
using System.Collections.Generic;
using System.Text;

namespace VCore_Lib.Model
{
    public class MVeranstaltungsTag : MBase
    {
        private string _Name;
        private SortableBindingList<string> _ArbeitNehmerId;
        private SortableBindingList<string> _StundenId;
        private DateTime _Start;
        private DateTime _Ende;
        private double _WorkingTime;

        public string Name 
        { 
            get { return _Name; } 
            set { if(_Name != value) {
                    _Name = value;
                    RaisePropertyChanged("Name");
                } 
            }
        }
        public SortableBindingList<string> ArbeitNehmer { 
            get { return _ArbeitNehmerId; }
            set {
                if(_ArbeitNehmerId != value) {
                    _ArbeitNehmerId = value;
                    RaisePropertyChanged("ArbeitNehmer");
                }
            }
        }
        public SortableBindingList<string> Stunden { 
            get { return _StundenId; }
            set { if(_StundenId != value) {
                    _StundenId = value;
                    RaisePropertyChanged("Stunden");
                } 
            }
        }
        public string Start {
            get;
            set;
        }
        public string Ende {
            get;
            set;
        }
        public string Arbeitszeit { get; }
    }
}
