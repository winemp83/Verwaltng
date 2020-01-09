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
        private MStunden _SelectedStunde;
        private ObservableCollection<MPerson> _Value;
        private ObservableCollection<MStunden> _ValueStunde;
        private readonly DBPerson _DB;

        public MPerson Selected { get { return _Selected; } set { _Selected = value; ValueStunden.Clear(); LoadStunden(_Selected); DeleteCommand.RaiseCanExecuteChanged(); EditCommand.RaiseCanExecuteChanged(); } }
        public MStunden SelectedStunden { get { return _SelectedStunde; } set { _SelectedStunde = value; DeleteStundenCommand.RaiseCanExecuteChanged(); EditStundenCommand.RaiseCanExecuteChanged(); } }
        public ObservableCollection<MPerson> Value { get { return _Value; } set { _Value = value; } }
        public ObservableCollection<MStunden> ValueStunden { get { return _ValueStunde; } set { _ValueStunde = value; } }

        public MyICommand DeleteCommand { get; set; }
        public MyICommand EditCommand { get; set; }
        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteStundenCommand { get; set; }
        public MyICommand EditStundenCommand { get; set; }
        public MyICommand AddStundenCommand { get; set; }

        public VMPerson()
        {
            DeleteStundenCommand = new MyICommand(DeleteStundenCommand_Click, CanStundenDelete);
            EditStundenCommand = new MyICommand(EditStundenCommand_Click, CanStundenEdit);
            AddStundenCommand = new MyICommand(AddStundenCommand_Click);
            DeleteCommand = new MyICommand(DeleteCommand_Click, CanDelete);
            EditCommand = new MyICommand(EditCommand_Click, CanEdit);
            AddCommand = new MyICommand(AddCommand_Click);
            Value = new ObservableCollection<MPerson>();
            ValueStunden = new ObservableCollection<MStunden>();
            Selected = null;
            SelectedStunden = null;
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
        private bool CanStundenDelete()
        {
            return SelectedStunden != null;
        }
        private bool CanStundenEdit()
        {
            return SelectedStunden != null;
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
                    TaughtNr = "",
                    Stunden = new ObservableCollection<MStunden>()
                }) ;
                _DB.Add(new MPerson()
                {
                    Id = Guid.NewGuid().ToString(),
                    VName = "Maria",
                    NName = "Mustermann",
                    Mid = "002",
                    TaughtNr = "",
                    Stunden = new ObservableCollection<MStunden>()
                });
                _DB.Add(new MPerson()
                {
                    Id = Guid.NewGuid().ToString(),
                    VName = "Nino",
                    NName = "Mustermann",
                    Mid = "003",
                    TaughtNr = "001",
                    Stunden = new ObservableCollection<MStunden>()
                });
                _DB.Add(new MPerson()
                {
                    Id = Guid.NewGuid().ToString(),
                    VName = "Nena",
                    NName = "Mustermann",
                    Mid = "004",
                    TaughtNr = "002",
                    Stunden = new ObservableCollection<MStunden>()
                });
                ObservableCollection < MPerson > mp = _DB.Load();
                foreach(MPerson p in mp) {
                    _DB.AddStunden(new MStunden() { Id = Guid.NewGuid().ToString(), Start = "01.01.2020 08:00", Ende = "01.01.2020 17:00", Pause = "1,0" }, p);
                }
            }
            Value.Clear();
            ValueStunden.Clear();
            foreach (MPerson p in _DB.Load()) {
                Value.Add(p);
                LoadStunden(p);
            }
        }
        public void LoadStunden(MPerson value = null)
        {
            if(value != null)
                foreach (MStunden std in value.Stunden){
                    ValueStunden.Add(std);
                }
        }
        public void AddStundenCommand_Click()
        {

        }
        public void AddCommand_Click() {
            Dialog.DPersonAddEdit AddPerson = new Dialog.DPersonAddEdit();
            if (AddPerson.ShowDialog() == true)
                _DB.Add(AddPerson.Value);
            Load();
        }
        public void EditStundenCommand_Click()
        {

        }
        public void EditCommand_Click() {
            Dialog.DPersonAddEdit EditPerson = new Dialog.DPersonAddEdit(Selected);
            if (EditPerson.ShowDialog() == true)
            {
                _DB.Update(EditPerson.Value);
                Load();
            }
        }
        public void DeleteStundenCommand_Click() {
            _DB.DeleteStunden(SelectedStunden);
            Load();
        }
        public void DeleteCommand_Click()
        {
            _DB.Delete(Selected);
            Load();
        }
    }
}
