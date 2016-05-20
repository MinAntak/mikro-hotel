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
            try
            {
                this.container.GuestList[this.ListView1.SelectedIndex].RoomGuest.Surname = null;
                this.container.GuestList[this.ListView1.SelectedIndex].RoomGuest.Name = null;
                this.container.GuestList[this.ListView1.SelectedIndex].RoomGuest.Phone = null;
                this.container.GuestList[this.ListView1.SelectedIndex].RoomGuest.Description = null;
                this.container.GuestList[this.ListView1.SelectedIndex].RoomGuest.CheckOut = null;
                this.container.GuestList[this.ListView1.SelectedIndex].RoomGuest.CheckIn = null;
                this.container.GuestList[this.ListView1.SelectedIndex].Vacant = Room.status.Wolny;
                this.container.GuestList.RemoveAt(this.ListView1.SelectedIndex);
                container.SaveFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie zaznaczono pokoju");
            }

        }

        private void Button4_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.container.GuestList[this.ListView1.SelectedIndex].Vacant == Room.status.Zarezerwowany)
                {
                    this.container.GuestList[this.ListView1.SelectedIndex].Vacant = Room.status.Zajety;
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
    }
}
