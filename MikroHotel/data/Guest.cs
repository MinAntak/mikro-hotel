namespace MikroHotel.data
{
    public class Guest : Data
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }

        public Guest()
        {
            Name = null;
            Surname = null;
            Phone = null;
            CheckIn = null;
            CheckOut = null;
        }
    }
}
