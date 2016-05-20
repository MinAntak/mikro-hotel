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
    /// Interaction logic for RoomStatus.xaml
    /// </summary>
    public partial class RoomStatus : Window
    {
        private Room room;
        private ListView list;
        private Container container;
        public RoomStatus()
        {
            InitializeComponent();
            
        }

        public RoomStatus(Room room, ListView listview, Container container)
        {
            InitializeComponent();
            this.StatusRoomBox.ItemsSource = Enum.GetValues(typeof (Room.status));
            this.StatusRoomBox.Text = room.Vacant.ToString();
            this.room = room;
            this.container = container;
            list = listview;

        }

        private void Button1_OnClick(object sender, RoutedEventArgs e)
        {
            room.Vacant = (Room.status)Enum.Parse(typeof (Room.status), this.StatusRoomBox.Text);
            container.SaveFile();
            this.list.Items.Refresh();
            this.Close();

        }
    }
}
