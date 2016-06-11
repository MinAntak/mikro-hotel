using System;

using System.Windows;
using System.Windows.Controls;
using MikroHotel.data;

namespace MikroHotel.room
{
    /// <summary>
    /// Interaction logic for EditRoom.xaml
    /// </summary>
    public partial class EditRoom : Window
    {
        private Room room;
        private ListView list;
        private Container container;
        public EditRoom(Room room, ListView listview, Container container)
        {
            InitializeComponent();
            roomNumber.Text = room.Number.ToString();
            description.Text = room.Description;
            howManyPeople.Text = room.People.ToString();
            this.room = room;
            this.container = container;
            list = listview;
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                room.Number = int.Parse(roomNumber.Text);
                room.People = int.Parse(howManyPeople.Text);
                room.Description = description.Text;
                container.SaveFile();
                this.list.Items.Refresh();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie podano poprawnie danych");
            }
            
        }
    }
}
