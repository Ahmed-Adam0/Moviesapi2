namespace Moviesapi2.model
{
    public class gener
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }


    }
}
