namespace Moviesapi2.dtos
{
    public class generDTO
    {
        [MaxLength(100)]
        public string name { get; set; }
        public string Description { get; set; }

    }
}
