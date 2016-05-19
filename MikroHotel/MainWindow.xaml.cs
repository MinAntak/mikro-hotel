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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using MikroHotel.about;
using MikroHotel.data;
using MikroHotel.room;


namespace MikroHotel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Room> RoomList { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            RoomList = new ObservableCollection<Room>();
            OpenFile();

        }


        private void Button4_OnClick(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            About_Window abtWindow = new About_Window();
            abtWindow.Show();
        }

        private void Button5_OnClick(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            this.Close();
        }

        private void Button3_OnClick(object sender, RoutedEventArgs e)
        {
            AddRoom addRoomWindow = new AddRoom(RoomList);
            addRoomWindow.Show();
        }

        private void Button2_OnClick(object sender, RoutedEventArgs e)
        {
            RoomWindow roomWindow = new RoomWindow(RoomList);
            roomWindow.Show();
        }

        private void Button1_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OpenFile()
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
    }
    
}
