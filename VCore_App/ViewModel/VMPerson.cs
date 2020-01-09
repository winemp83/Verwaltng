using VCore_Lib.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace VCore_App.ViewModel
{
    public class VMPerson : IVMPerson
    {
        private MPerson _Selected;
        private ObservableCollection<MPerson> _Value;

        public MPerson Selected { get { return _Selected; } set { _Selected = value; } }
        public ObservableCollection<MPerson> Value { get { return _Value; } set { _Value = value; } }

        public MyICommand DeleteCommand { get; set; }
        public MyICommand EditCommand { get; set; }
        public MyICommand AddCommand { get; set; }

        public VMPerson()
        {
            Value = new ObservableCollection<MPerson>();
            Selected = null;
            DeleteCommand = new MyICommand(DeleteCommand_Click, CanDelete);
            EditCommand = new MyICommand(EditCommand_Click, CanEdit);
            AddCommand = new MyICommand(AddCommand_Click);
        }

        private bool CanDelete()
        {
            return Selected != null;
        }
        private bool CanEdit()
        {
            return Selected != null;
        }

        public void Load(bool IsDebug = true)
        {
            if (IsDebug)
            {
                Value.Add(new MPerson()
                {
                    Id = Guid.NewGuid().ToString(),
                    VName = "Max",
                    NName = "Mustermann",
                    Mid = "001",
                    TaughtNr = ""
                });
                Value.Add(new MPerson()
                {
                    Id = Guid.NewGuid().ToString(),
                    VName = "Maria",
                    NName = "Mustermann",
                    Mid = "002",
                    TaughtNr = ""
                });
                Value.Add(new MPerson()
                {
                    Id = Guid.NewGuid().ToString(),
                    VName = "Nino",
                    NName = "Mustermann",
                    Mid = "003",
                    TaughtNr = "001"
                });
                Value.Add(new MPerson()
                {
                    Id = Guid.NewGuid().ToString(),
                    VName = "Nena",
                    NName = "Mustermann",
                    Mid = "004",
                    TaughtNr = "002"
                });
            }
            else
            {

            }
        }
        public void AddCommand_Click() { }
        public void EditCommand_Click() { }
        public void DeleteCommand_Click()
        {
            Value.Remove(Selected);
            Selected = null;
        }
    }
}
