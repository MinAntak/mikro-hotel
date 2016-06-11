using System;
using System.Windows;
using System.Windows.Controls;
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
                if(room.Vacant.ToString() == "Wolny") roomNumber.Items.Add(room.Number+" ("+room.People + "-osobowy)");
            }
            other.Text = "-";

            this.container = container;

        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Room room = new Room();
                foreach (Room roomek in container.RoomList)
                {
                    if (roomek.Number + " (" + roomek.People + "-osobowy)" == this.roomNumber.Text)
                    {
                        room = roomek;
                        room.RoomGuest.Surname = surname.Text;
                        room.RoomGuest.Name = nameg.Text;
                        room.RoomGuest.Phone = phone.Text;
                        room.RoomGuest.Description = other.Text;
                        room.RoomGuest.CheckIn = checkIn.Text;
                        room.RoomGuest.CheckOut = checkOut.Text;
                        room.Vacant = Room.status.Zajety;
                        container.GuestList.Add(room);
                        break;
                    }
                }
               
                container.SaveFile();
                list.Items.Refresh();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie podano poprawnie danych");
            }
            
        }
    }
}
