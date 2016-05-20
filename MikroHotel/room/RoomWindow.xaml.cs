using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private void ListView1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            
        }

        private void Button1_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
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
                RoomStatus status = new RoomStatus(container.RoomList[this.ListView1.SelectedIndex], ListView1, container);
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
                EditRoom edit = new EditRoom(container.RoomList[this.ListView1.SelectedIndex], ListView1, container);
                edit.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie zaznaczono pokoju");
            }
        }
    }


}
