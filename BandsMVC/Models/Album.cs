namespace BandsMVC.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public Band Band { get; set; }
        public int Year { get; set; }
        public Album()
        {
            Name = "New Album";
            Band = new Band();
        }
    }
}
