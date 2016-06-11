using System;

namespace MikroHotel.data
{
    public class Room : Data
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public status Vacant { get; set; }
        public Guest RoomGuest { get; set; }


        public enum status
        {
            Wolny, Zajety, Zarezerwowany, Niedostepny
        }

        public Room()
        {   
        }

        public Room(int roomnumber, int id, int people, string description)
        {
            this.ID = id;
            this.Number = roomnumber;
            this.Description = description;
            this.People = people;
            this.Vacant = status.Wolny;
            this.RoomGuest = new Guest();
        }

        public override void randomID()
        {
            Random rand = new Random();

            ID = rand.Next();
        }
      }
}
