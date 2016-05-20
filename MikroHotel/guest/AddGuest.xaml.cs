using System;
using System.Collections.Generic;
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
using MikroHotel.data;

namespace MikroHotel.guest
{
    /// <summary>
    /// Interaction logic for AddGuest.xaml
    /// </summary>
    public partial class AddGuest : Window
    {
        private ListView list;
        private Container container;
        public AddGuest(Container container, ListView listview)
        {
            InitializeComponent();
            list = listview;
            foreach (Room room in container.RoomList)
            {
                if(room.Vacant.ToString() == "Wolny")NumerPokoju.Items.Add(room.Number+" ("+room.People + "-osobowy)");
            }

            this.container = container;
            
           // this.NumerPokoju.Text = this.container.RoomList.ToString();

        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Room room = new Room();
                foreach (Room roomek in container.RoomList)
                {
                    if (roomek.Number + " (" + roomek.People + "-osobowy)" == this.NumerPokoju.Text)
                    {
                        room = roomek;
                        room.RoomGuest.Surname = this.Nazwisko.Text;
                        room.RoomGuest.Name = this.Imie.Text;
                        room.RoomGuest.Phone = this.Telefon.Text;
                        room.RoomGuest.Description = this.Inne.Text;
                        room.RoomGuest.CheckIn = this.Przyjazd.Text;
                        room.RoomGuest.CheckOut = this.Odjazd.Text;
                        room.Vacant = Room.status.Zajety;
                        container.GuestList.Add(room);
                        break;
                    }
                }
               
                container.SaveFile();
                list.Items.Refresh();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie podano poprawnie danych");
            }
            
        }
    }
}
