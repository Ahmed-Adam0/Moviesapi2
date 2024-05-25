namespace Moviesapi2.model
{
    public class movie
    {
        
        public int Id { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public int year { get; set; }
        public double rate { get; set; }
        [MaxLength(2500)]
        public string storeline { get; set; }   
         public byte[] poster { get; set; }
        public byte generId { get; set; }
        public gener gener { get; set; }
    }
}
