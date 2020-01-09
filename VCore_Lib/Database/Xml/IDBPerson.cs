using System.Collections.ObjectModel;
using VCore_Lib.Model;

namespace VCore_Lib.Database.Xml
{
    public interface IDBPerson
    {
        string FileName { get; set; }

        void Add(MPerson value);
        void AddStunden(MStunden stunden, MPerson person);
        void Delete(MPerson value);
        void DeleteStunden(MStunden value);
        ObservableCollection<MPerson> Load();
        ObservableCollection<MStunden> LoadStunden(MPerson value);
        void Update(MPerson value);
        void UpdateStunden(MStunden stunden);
    }
}