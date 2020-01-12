using System;
using System.Collections.Generic;
using System.Text;

namespace VCore_Lib.Model
{
    public class MEvent : MBase
    {
        private string _Name;
        private SortableBindingList<string> _ArbeitNehmerId;
        private SortableBindingList<string> _StundenId;
        private readonly MDatum _Start;
        private readonly MDatum _Ende;

        public MEvent() {
            _ArbeitNehmerId = new SortableBindingList<string>();
            _StundenId = new SortableBindingList<string>();
            _Start = new MDatum();
            _Ende = new MDatum();
        }
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
            get { return _Start.ToString(); }
            set { if (_Start.ToString() != value){ _Start.Value = value; RaisePropertyChanged("Start"); } }
        }
        public string Ende {
            get { return _Ende.ToString(); }
            set { if (_Ende.ToString() != value) { _Ende.Value = value; RaisePropertyChanged("Ende"); } }
        }
    }
}
