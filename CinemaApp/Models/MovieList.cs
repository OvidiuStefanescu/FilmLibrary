using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Models
{
    public class MovieList
    {
        [Key]
        public int MovieID { get; set; }
        [Required(ErrorMessage = "Movie name is required")]
        public string MovieName { get; set; }
        [Required(ErrorMessage = "Director name is required")]
        public string DirectorName { get; set; }
        [Required(ErrorMessage = "Genre is required")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Release date is required")]
        public DateTime ReleaseDate { get; set; }
        public float Duration { get; set; }
        public string IMDB { get; set; }
    }
}