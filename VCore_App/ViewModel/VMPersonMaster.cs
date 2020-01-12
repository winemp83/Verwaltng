using System;
using System.Collections.ObjectModel;
using VCore_Lib;
using VCore_Lib.Database.Xml;
using VCore_Lib.Model;

namespace VCore_App.ViewModel
{
    public class VMPersonMaster
    {
        private MPerson _Selected;
        private SortableBindingList<MPerson> _Value;
        private readonly DBPerson _DB;

        public MyICommand AddPersonCommand;
        public MyICommand EditPersonCommand;
        public MyICommand DeletePersonCommand;

        public MPerson SelectedPerson { get { return _Selected; } set { _Selected = value; } }
        public SortableBindingList<MPerson> ValuePerson { get { return _Value; } set { _Value = value; } }

        public VMPersonMaster() {
            AddPersonCommand = new MyICommand(AddPerson_Click);
            EditPersonCommand = new MyICommand(EditPerson_Click, CanDo);
            DeletePersonCommand = new MyICommand(DeletePerson_Click, CanDo);
            SelectedPerson = null;
            ValuePerson = new SortableBindingList<MPerson>();
            _DB = new DBPerson();
            #if DEBUG
            Load(true);
            #else
            Load();
            #endif
        }

        private bool CanDo()
        {
            return _Selected != null;
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
                });
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
                ObservableCollection<MPerson> mp = _DB.Load();
                foreach (MPerson p in mp)
                {
                    _DB.AddStunden(new MStunden() { Id = Guid.NewGuid().ToString(), Start = "01.01.2020 08:00", Ende = "01.01.2020 17:00", Pause = "1,0" }, p);
                }
            }
            ValuePerson.Clear();
            foreach (MPerson p in _DB.Load())
            {
                ValuePerson.Add(p);
            }
        }
        public void AddPerson_Click()
        {
            Dialog.DPersonAddEdit AddPerson = new Dialog.DPersonAddEdit();
            if (AddPerson.ShowDialog() == true)
                _DB.Add(AddPerson.Value);
            SelectedPerson = null;
            Load();
        }
        public void EditPerson_Click() {
            Dialog.DPersonAddEdit EditPerson = new Dialog.DPersonAddEdit(SelectedPerson);
            if (EditPerson.ShowDialog() == true)
            {
                _DB.Update(EditPerson.Value);
                Load();
            }
            SelectedPerson = null;
        }
        public void DeletePerson_Click() {
            _DB.Delete(SelectedPerson);
            Load();
            SelectedPerson = null;
        }
    }
}
