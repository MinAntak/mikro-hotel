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
            this.Numerpokoju.Text = room.Number.ToString();
            this.Opis.Text = room.Description;
            this.Iloosobwy.Text = room.People.ToString();
            this.room = room;
            this.container = container;
            list = listview;
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                room.Number = int.Parse(this.Numerpokoju.Text);
                room.People = int.Parse(this.Iloosobwy.Text);
                room.Description = this.Opis.Text;
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
