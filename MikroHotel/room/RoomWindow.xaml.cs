using System;
using System.Windows;
using Container = MikroHotel.data.Container;

namespace MikroHotel.room
{
    /// <summary>
    /// Interaction logic for RoomWindow.xaml
    /// </summary>
    public partial class RoomWindow : Window
    {
        private Container container;

        public RoomWindow(Container container)
        {
            InitializeComponent();
            this.container = container;
            this.ListView1.ItemsSource = this.container.RoomList;
        }
        private void Button1_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                //Remove the room from container and XML file
                this.container.RoomList.RemoveAt(this.ListView1.SelectedIndex);
                container.SaveFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie zaznaczono pokoju");
            }
        }

        private void Button2_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                RoomStatus status = new RoomStatus(container.RoomList[ListView1.SelectedIndex], ListView1, container);
                status.Show();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie zaznaczono pokoju");
            }
        }

        private void Button3_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                EditRoom edit = new EditRoom(container.RoomList[ListView1.SelectedIndex], ListView1, container);
                edit.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie zaznaczono pokoju");
            }
        }
    }


}
