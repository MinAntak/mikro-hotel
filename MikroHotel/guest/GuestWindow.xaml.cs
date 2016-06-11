using System;
using System.Windows;
using MikroHotel.data;

namespace MikroHotel.guest
{
    /// <summary>
    /// Interaction logic for GuestWindow.xaml
    /// </summary>
    public partial class GuestWindow : Window
    {
        private Container container;

        public GuestWindow(Container container)
        {
            InitializeComponent();
            this.container = container;
            this.ListView1.ItemsSource = this.container.GuestList;
            InitializeComponent();
        }

        private void Button1_OnClick(object sender, RoutedEventArgs e)
        {
            AddGuest addGuest = new AddGuest(container, ListView1);
            addGuest.Show();
        }

        private void Button2_OnClick(object sender, RoutedEventArgs e)
        {
            AddReservation addRes = new AddReservation(container, ListView1);
            addRes.Show();
        }

        private void Button3_OnClick(object sender, RoutedEventArgs e)
        {
            //remove all values about guest from room
            try
            {
                container.GuestList[ListView1.SelectedIndex].RoomGuest.Surname = null;
                container.GuestList[ListView1.SelectedIndex].RoomGuest.Name = null;
                container.GuestList[ListView1.SelectedIndex].RoomGuest.Phone = null;
                container.GuestList[ListView1.SelectedIndex].RoomGuest.Description = null;
                container.GuestList[ListView1.SelectedIndex].RoomGuest.CheckOut = null;
                container.GuestList[ListView1.SelectedIndex].RoomGuest.CheckIn = null;
                container.GuestList[ListView1.SelectedIndex].Vacant = Room.status.Wolny;
                container.GuestList.RemoveAt(ListView1.SelectedIndex);
                container.SaveFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie zaznaczono pokoju");
            }

        }

        private void Button4_OnClick(object sender, RoutedEventArgs e)
        {
            //Change status from to confirm reservation
            try
            {
                if (this.container.GuestList[ListView1.SelectedIndex].Vacant == Room.status.Zarezerwowany)
                {
                    this.container.GuestList[ListView1.SelectedIndex].Vacant = Room.status.Zajety;
                    ListView1.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("Ten pokój nie był wcześniej rezerwowany.");

                }
                container.SaveFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie zaznaczono pokoju.");
            }
        }

        private void Button5_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                EditGuest editGuest = new EditGuest(container.GuestList[ListView1.SelectedIndex], ListView1, container);
                editGuest.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie zaznaczono pokoju.");
            }
        }
    }
}
