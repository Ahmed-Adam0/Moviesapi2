using Moviesapi2.model;

namespace Moviesapi2.dtos
{
    public class movieDTo
    {
        public string name {  get; set; }   
        public string title { get; set; }
        public int year { get; set; }
        public double rate { get; set; }
        [MaxLength(2500)]
        public string storeline { get; set; }
        public IFormFile?poster { get; set; }
        public byte generId { get; set; }
    }
}
