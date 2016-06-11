
using System.Windows;
using MikroHotel.about;
using MikroHotel.data;
using MikroHotel.guest;
using MikroHotel.room;


namespace MikroHotel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Container container;
        public MainWindow()
        {
            container = new Container();
            InitializeComponent();
        }


        private void Button4_OnClick(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            AboutWindow abtWindow = new AboutWindow();
            abtWindow.Show();
        }

        private void Button5_OnClick(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            this.Close();
        }

        private void Button3_OnClick(object sender, RoutedEventArgs e)
        {
            AddRoom addRoomWindow = new AddRoom(container);
            addRoomWindow.Show();
        }

        private void Button2_OnClick(object sender, RoutedEventArgs e)
        {
            RoomWindow roomWindow = new RoomWindow(container);
            roomWindow.Show();
        }

        private void Button1_OnClick(object sender, RoutedEventArgs e)
        {
            GuestWindow guestWindow = new GuestWindow(container);
            guestWindow.Show();
        }

        
    }
    
}
