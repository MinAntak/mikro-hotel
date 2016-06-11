/*
Base class for data about guests and rooms.
*/
namespace MikroHotel.data
{
    public class Data
    {
        public int People { get; set; }
        public string Description { get; set; }

        public Data()
        {
            
        }

        public virtual void randomID()
        {
            throw new System.NotImplementedException();
        }
    }
}
