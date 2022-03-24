using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public int Id { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}