using System.Collections.ObjectModel;
using System.ComponentModel;
using VCore_Lib;
using VCore_Lib.Model;

namespace VCore_App.ViewModel
{
    public interface IVMPerson
    {
        MyICommand AddCommand { get; set; }
        MyICommand DeleteCommand { get; set; }
        MyICommand EditCommand { get; set; }
        MPerson Selected { get; set; }
        SortableBindingList<MPerson> Value { get; set; }

        void AddCommand_Click();
        void DeleteCommand_Click();
        void EditCommand_Click();
        void Load(bool IsDebug = true);
    }
}