using System;
using System.Windows;
using System.Windows.Controls;
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
            room.Vacant = (Room.status)Enum.Parse(typeof (Room.status), StatusRoomBox.Text);
            container.SaveFile();
            list.Items.Refresh();
            Close();

        }
    }
}
