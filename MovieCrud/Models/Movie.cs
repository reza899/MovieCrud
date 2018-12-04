namespace MovieCrud.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        public Genre Genre { get; set; }
    }
}