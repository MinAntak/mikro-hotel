using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;
using MikroHotel.data;

namespace MikroHotel.room
{
    /// <summary>
    /// Interaction logic for AddRoom.xaml
    /// </summary>
    public partial class AddRoom : Window
    {
        public ObservableCollection<Room> RoomList { get; set; }
        public AddRoom(ObservableCollection<Room> RoomList)
        {
            InitializeComponent();
            this.RoomList = RoomList;
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            int id = randomID();
            int howRooms = int.Parse(this.Ilepokoi.Text);
            int firstRoom = int.Parse(this.Numerpierwszego.Text);
            int howPeople = int.Parse(this.Ileosobowy.Text);
            string description = this.Opis.Text;

            for (int i = firstRoom; i <= firstRoom+howRooms; i++)
            {
                RoomList.Add(new Room(i, id, howPeople, description));
            }
            SaveFile();
            MessageBox.Show(@"Zakończono dodawanie "+howRooms+" Pokoi");
        }
        public int randomID()
        {
            Random rand = new Random();

            return(rand.Next());
        }

        private void SaveFile()
        {
            using (var sw = new StreamWriter("listapokoi.xml"))
            {
                var serializer = new XmlSerializer(typeof(ObservableCollection<Room>));
                serializer.Serialize(sw, RoomList);
            }
        }
    }
}
