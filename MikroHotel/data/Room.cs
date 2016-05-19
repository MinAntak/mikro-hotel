using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroHotel.data
{
    public class Room : Data
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public string Vacant { get; set; }

        public Room()
        {
            
        }

        public Room(int roomnumber, int id, int people, string description)
        {
            this.ID = id;
            this.Number = roomnumber;
            this.Description = description;
            this.People = people;
            this.Vacant = "Wolny";
        }

        public void randomID()
        {
            Random rand = new Random();

            ID = rand.Next();
        }
    }
}
