using VCore_Lib.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using VCore_Lib.Database.Xml;

namespace VCore_App.ViewModel
{
    public class VMPerson : IVMPerson
    {
        private MPerson _Selected;
        private ObservableCollection<MPerson> _Value;
        private DBPerson _DB;

        public MPerson Selected { get { return _Selected; } set { _Selected = value; DeleteCommand.RaiseCanExecuteChanged(); EditCommand.RaiseCanExecuteChanged(); } }
        public ObservableCollection<MPerson> Value { get { return _Value; } set { _Value = value; } }

        public MyICommand DeleteCommand { get; set; }
        public MyICommand EditCommand { get; set; }
        public MyICommand AddCommand { get; set; }

        public VMPerson()
        {
            DeleteCommand = new MyICommand(DeleteCommand_Click, CanDelete);
            EditCommand = new MyICommand(EditCommand_Click, CanEdit);
            AddCommand = new MyICommand(AddCommand_Click);
            Value = new ObservableCollection<MPerson>();
            Selected = null;
            _DB = new DBPerson();
            Load();
        }

        private bool CanDelete()
        {
            return Selected != null;
        }
        private bool CanEdit()
        {
            return Selected != null;
        }

        public void Load(bool IsFirstStart = false)
        {
            if (IsFirstStart)
            {
                _DB.Add(new MPerson()
                {
                    Id = Guid.NewGuid().ToString(),
                    VName = "Max",
                    NName = "Mustermann",
                    Mid = "001",
                    TaughtNr = ""
                });
                _DB.Add(new MPerson()
                {
                    Id = Guid.NewGuid().ToString(),
                    VName = "Maria",
                    NName = "Mustermann",
                    Mid = "002",
                    TaughtNr = ""
                });
                _DB.Add(new MPerson()
                {
                    Id = Guid.NewGuid().ToString(),
                    VName = "Nino",
                    NName = "Mustermann",
                    Mid = "003",
                    TaughtNr = "001"
                });
                _DB.Add(new MPerson()
                {
                    Id = Guid.NewGuid().ToString(),
                    VName = "Nena",
                    NName = "Mustermann",
                    Mid = "004",
                    TaughtNr = "002"
                });
            }
            Value.Clear();
            foreach (MPerson p in _DB.Load()) {
                Value.Add(p);
            }
        }
        public void AddCommand_Click() {
            Dialog.DPersonAddEdit AddPerson = new Dialog.DPersonAddEdit();
            if (AddPerson.ShowDialog() == true)
                _DB.Add(AddPerson.Value);
            Load();
        }
        public void EditCommand_Click() {
            Dialog.DPersonAddEdit EditPerson = new Dialog.DPersonAddEdit(Selected);
            if (EditPerson.ShowDialog() == true)
            {
                _DB.Update(EditPerson.Value);
                Load();
            }
        }
        public void DeleteCommand_Click()
        {
            _DB.Delete(Selected);
            Load();
        }
    }
}
