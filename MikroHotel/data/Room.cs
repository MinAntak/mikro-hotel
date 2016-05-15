using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroHotel.data
{
    public class Room : Data
    {
        private int id;
        private int number;

        public Room()
        {
            
        }

        public void randomID()
        {
            Random rand = new Random();

            id = rand.Next();
        }
    }
}
