using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public int StockLevel { get; set; }

        [Required]
        public Genre Genre { get; set; }
        public int GenreId { get; set; }

        //Adding constructor so that the date is automatically populated
        public Movie()
        {
            DateAdded = DateTime.Now;
        }
    }
}