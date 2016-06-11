using System;
using System.Windows;
using System.Windows.Controls;
using MikroHotel.data;

namespace MikroHotel.guest
{
    /// <summary>
    /// Interaction logic for EditGuest.xaml
    /// </summary>
    public partial class EditGuest : Window
    {
        private Room room;
        private Container container;
        private ListView list;
        public EditGuest(Room room, ListView listview, Container container)
        {
            InitializeComponent();
            this.room = room;
            this.container = container;
            nameG.Text = room.RoomGuest.Name;
            surname.Text = room.RoomGuest.Surname;
            checkIn.Text = room.RoomGuest.CheckIn;
            checkOut.Text = room.RoomGuest.CheckOut;
            phone.Text = room.RoomGuest.Phone;
            other.Text = room.RoomGuest.Description;
            list = listview;
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                room.RoomGuest.Surname = surname.Text;
                room.RoomGuest.Name = nameG.Text;
                room.RoomGuest.Phone = phone.Text;
                room.RoomGuest.Description = other.Text;
                room.RoomGuest.CheckIn = checkIn.Text;
                room.RoomGuest.CheckOut = checkOut.Text;        
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
