using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroHotel.data
{
    class Guest : Data, IGuestData
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Phone { get; set; }
        

        public void addGuest()
        {
            
        }
    }
}
