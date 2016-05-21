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
            this.Imie.Text = room.RoomGuest.Name;
            this.Nazwisko.Text = room.RoomGuest.Surname;
            this.Przyjazd.Text = room.RoomGuest.CheckIn;
            this.Odjazd.Text = room.RoomGuest.CheckOut;
            this.Telefon.Text = room.RoomGuest.Phone;
            this.Inne.Text = room.RoomGuest.Description;
            list = listview;
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                room.RoomGuest.Surname = this.Nazwisko.Text;
                room.RoomGuest.Name = this.Imie.Text;
                room.RoomGuest.Phone = this.Telefon.Text;
                room.RoomGuest.Description = this.Inne.Text;
                room.RoomGuest.CheckIn = this.Przyjazd.Text;
                room.RoomGuest.CheckOut = this.Odjazd.Text;        
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
