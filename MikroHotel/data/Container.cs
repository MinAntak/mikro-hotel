using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
/*
Class keeping containers, which has rooms objects and guest objects
*/
namespace MikroHotel.data
{
    public class Container : Interf
    {
        public ObservableCollection<Room> RoomList { get; set; }
        public ObservableCollection<Room> GuestList { get; set; }

        public Container()
        {
            RoomList = new ObservableCollection<Room>();
            GuestList = new ObservableCollection<Room>();
            OpenFile();
            addGuestList();
        }

        public void OpenFile()
        {
            if (File.Exists("listapokoi.xml"))
            {
                using (var sr = new StreamReader("listapokoi.xml"))
                {
                    var deserializer = new XmlSerializer(typeof(ObservableCollection<Room>));
                    ObservableCollection<Room> tmpList = (ObservableCollection<Room>)deserializer.Deserialize(sr);
                    foreach (var item in tmpList)
                    {
                        RoomList.Add(item);
                    }
                }
            }
            else
            {
                MessageBox.Show(@"Nie istnieje plik listapokoi.xml. Utwórz plik dodając pokój w oknie Dodaj Pokój");
            }
        }
        public void SaveFile()
        {
            using (var sw = new StreamWriter("listapokoi.xml"))
            {
                var serializer = new XmlSerializer(typeof(ObservableCollection<Room>));
                serializer.Serialize(sw, RoomList);
            }
        }
        //Adding rooms which status is booked
        public void addGuestList()
        {
            foreach (Room roomek in RoomList)
            {
                if (roomek.RoomGuest.Name != null)
                {
                    GuestList.Add(roomek);
                }
            }
        }
    }
}
