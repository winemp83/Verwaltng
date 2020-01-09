using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Xml;
using VCore_Lib.Model;

namespace VCore_Lib.Database.Xml
{
    public class DBPerson : IDBPerson
    {
        private readonly string _MainName = "PersonDetail";
        private readonly string _SubName = "Person";
        private readonly string _SubStunden = "Stunden";

        private string _FileName;
        private string _FilePath;
        private XmlTextWriter _Xml;
        private XmlDocument _XDoc;
        private FileStream _Stream;

        public string FileName
        {
            get { return _FileName; }
            set
            {
                _FileName = value;
                _FilePath = $@"{Directory.GetCurrentDirectory()}\{_FileName}.xml";
            }
        }

        public DBPerson(string filename = "xdb")
        {
            FileName = filename;
            if (!File.Exists(_FilePath))
                Create();
        }

        private void Create()
        {
            _Xml = new XmlTextWriter(_FilePath, Encoding.UTF8);
            _Xml.WriteStartDocument();
            _Xml.WriteStartElement(_MainName);
            _Xml.WriteEndElement();
            _Xml.Close();
        }

        public void AddStunden(MStunden stunden, MPerson person)
        {
            _XDoc = new XmlDocument();
            _Stream = new FileStream(_FilePath, FileMode.Open);
            _XDoc.Load(_Stream);
            XmlNodeList list = _XDoc.GetElementsByTagName(_SubName);
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement cl = (XmlElement)_XDoc.GetElementsByTagName(_SubName)[i];
                if (person.Id.Equals(cl.GetAttribute("Id")))
                {
                    XmlElement ca = _XDoc.CreateElement(_SubStunden);
                    ca.SetAttribute("Id", stunden.Id);
                    ca.SetAttribute("Start", stunden.Start);
                    ca.SetAttribute("Ende", stunden.Ende);
                    ca.SetAttribute("Pause", stunden.Pause);
                    cl.AppendChild(ca);
                    break;
                }
            }
            _Stream.Close();
            _XDoc.Save(_FilePath);
        }
        public void UpdateStunden(MStunden stunden)
        {
            _XDoc = new XmlDocument();
            _Stream = new FileStream(_FilePath, FileMode.Open);
            _XDoc.Load(_Stream);
            XmlNodeList list = _XDoc.GetElementsByTagName(_SubStunden);
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement cl = (XmlElement)_XDoc.GetElementsByTagName(_SubStunden)[i];
                if (stunden.Id.Equals(cl.GetAttribute("Id")))
                {
                    cl.SetAttribute("Start", stunden.Start);
                    cl.SetAttribute("Ende", stunden.Ende);
                    cl.SetAttribute("Pause", stunden.Pause);
                    break;
                }
            }
            _Stream.Close();
            _XDoc.Save(_FilePath);
        }
        public void DeleteStunden(MStunden value)
        {
            _XDoc = new XmlDocument();
            _Stream = new FileStream(_FilePath, FileMode.Open);
            _XDoc.Load(_Stream);
            XmlNodeList list = _XDoc.GetElementsByTagName(_SubName);
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement cl = (XmlElement)_XDoc.GetElementsByTagName(_SubName)[i];
                XmlNodeList l = cl.GetElementsByTagName(_SubStunden);
                for (int j = 0; j < l.Count; j++)
                {
                    XmlElement c = (XmlElement)cl.GetElementsByTagName(_SubStunden)[j];
                    if (value.Id.Equals(c.GetAttribute("Id")))
                    {
                        cl.RemoveChild(c);
                        break;
                    }
                }
            }
            _Stream.Close();
            _XDoc.Save(_FilePath);
        }
        public ObservableCollection<MStunden> LoadStunden(MPerson value)
        {
            ObservableCollection<MStunden> result = new ObservableCollection<MStunden>();
            _XDoc = new XmlDocument();
            FileStream Stream = new FileStream(_FilePath, FileMode.Open);
            _XDoc.Load(Stream);
            XmlNodeList list = _XDoc.GetElementsByTagName(_SubName);
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement cl = (XmlElement)_XDoc.GetElementsByTagName(_SubName)[i];
                if (cl.GetAttribute("Id").Equals(value.Id))
                {
                    XmlNodeList l = cl.ChildNodes;
                    for (int j = 0; j < l.Count; j++)
                    {
                        XmlElement ca = (XmlElement)cl.GetElementsByTagName(_SubStunden)[i];
                        result.Add(new MStunden()
                        {
                            Id = ca.GetAttribute("Id"),
                            Start = ca.GetAttribute("Start"),
                            Ende = ca.GetAttribute("Ende"),
                            Pause = ca.GetAttribute("Pause")
                        });
                    }
                }
            }
            Stream.Close();
            return result;
        }
        public void Add(MPerson value)
        {
            _XDoc = new XmlDocument();
            _Stream = new FileStream(_FilePath, FileMode.Open);
            _XDoc.Load(_Stream);
            XmlElement cl = _XDoc.CreateElement(_SubName);
            cl.SetAttribute("Id", value.Id);
            cl.SetAttribute("VName", value.VName);
            cl.SetAttribute("NName", value.NName);
            cl.SetAttribute("Mid", value.Mid);
            cl.SetAttribute("TaughtNr", value.TaughtNr);
            _XDoc.DocumentElement.AppendChild(cl);
            _Stream.Close();
            _XDoc.Save(_FilePath);
        }
        public ObservableCollection<MPerson> Load()
        {
            ObservableCollection<MPerson> result = new ObservableCollection<MPerson>();
            _XDoc = new XmlDocument();
            _Stream = new FileStream(_FilePath, FileMode.Open);
            _XDoc.Load(_Stream);
            XmlNodeList list = _XDoc.GetElementsByTagName(_SubName);
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement cl = (XmlElement)_XDoc.GetElementsByTagName(_SubName)[i];
                MPerson r = new MPerson()
                {
                    Id = cl.GetAttribute("Id"),
                    VName = cl.GetAttribute("VName"),
                    NName = cl.GetAttribute("NName"),
                    Mid = cl.GetAttribute("Mid"),
                    TaughtNr = cl.GetAttribute("TaughtNr"),
                    Stunden = new ObservableCollection<MStunden>()
                };
                for (int j = 0; j < cl.ChildNodes.Count; j++)
                {
                    XmlElement ca = (XmlElement)cl.ChildNodes[j];
                    r.Stunden.Add(new MStunden()
                    {
                        Id = ca.GetAttribute("Id"),
                        Start = ca.GetAttribute("Start"),
                        Ende = ca.GetAttribute("Ende"),
                        Pause = ca.GetAttribute("Pause")
                    });
                }
                result.Add(r);
            }
            _Stream.Close();
            return result;
        }
        public void Update(MPerson value)
        {
            _XDoc = new XmlDocument();
            _Stream = new FileStream(_FilePath, FileMode.Open);
            _XDoc.Load(_Stream);
            XmlNodeList list = _XDoc.GetElementsByTagName(_SubName);
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement cl = (XmlElement)_XDoc.GetElementsByTagName(_SubName)[i];
                if (value.Id.Equals(cl.GetAttribute("Id")))
                {
                    cl.SetAttribute("VName", value.VName);
                    cl.SetAttribute("NName", value.NName);
                    cl.SetAttribute("Mid", value.Mid);
                    cl.SetAttribute("TaughtNr", value.TaughtNr);
                    break;
                }
            }
            _Stream.Close();
            _XDoc.Save(_FilePath);
        }
        public void Delete(MPerson value)
        {
            _XDoc = new XmlDocument();
            _Stream = new FileStream(_FilePath, FileMode.Open);
            _XDoc.Load(_Stream);
            XmlNodeList list = _XDoc.GetElementsByTagName(_SubName);
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement cl = (XmlElement)_XDoc.GetElementsByTagName(_SubName)[i];
                if (value.Id.Equals(cl.GetAttribute("Id")))
                {
                    _XDoc.DocumentElement.RemoveChild(cl);
                    break;
                }
            }
            _Stream.Close();
            _XDoc.Save(_FilePath);
        }
    }
}
