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
        public ObservableCollection<Room> RoomList { get; set; }
        

        public RoomWindow(ObservableCollection<Room> RoomList)
        {
            InitializeComponent();
            this.RoomList = RoomList;
            this.ListView1.ItemsSource = this.RoomList;
            
        }

        private void ListView1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            
        }

        private void Button1_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                this.RoomList.RemoveAt(this.ListView1.SelectedIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie zaznaczono pokoju");
            }
        }
    }


}
