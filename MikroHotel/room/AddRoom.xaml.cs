using System;
using System.Windows;
using MikroHotel.data;

namespace MikroHotel.room
{
    /// <summary>
    /// Interaction logic for AddRoom.xaml
    /// </summary>
    public partial class AddRoom : Window
    {
        private Container container;
        
        public AddRoom(Container container)
        {
            InitializeComponent();
            this.container = container;
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = randomID();
                int howRooms = int.Parse(this.howManyRooms.Text);
                int firstRoom = int.Parse(this.firstRoom.Text);
                int howPeople = int.Parse(this.howManyPeople.Text);
                string description = this.description.Text;

                for (int i = firstRoom; i < firstRoom + howRooms; i++)
                {
                    container.RoomList.Add(new Room(i, id, howPeople, description));
                }
                container.SaveFile();
                MessageBox.Show(@"Zakończono dodawanie " + howRooms + " Pokoi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie podano poprawnie danych");
            }
            
        }
        //set random ID for all rooms the same type
        public int randomID()
        {
            Random rand = new Random();

            return(rand.Next());
        }

        
    }
}
