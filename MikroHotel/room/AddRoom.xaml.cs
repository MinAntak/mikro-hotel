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
        private Container container;
        
        public AddRoom(Container container)
        {
            InitializeComponent();
            this.container = container;
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = randomID();
                int howRooms = int.Parse(this.Ilepokoi.Text);
                int firstRoom = int.Parse(this.Numerpierwszego.Text);
                int howPeople = int.Parse(this.Ileosobowy.Text);
                string description = this.Opis.Text;

                for (int i = firstRoom; i < firstRoom + howRooms; i++)
                {
                    container.RoomList.Add(new Room(i, id, howPeople, description));
                }
                container.SaveFile();
                MessageBox.Show(@"Zakończono dodawanie " + howRooms + " Pokoi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie podano poprawnie danych");
            }
            
        }
        public int randomID()
        {
            Random rand = new Random();

            return(rand.Next());
        }

        
    }
}
