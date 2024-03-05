using System.ComponentModel.DataAnnotations;
using MvcMovie.Models;

namespace MvcMovie.Models;

public class Movie
{
    public int Id { get; set; }
    public string? Title { get; set; }

    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    public string? Genre { get; set; }
    public decimal Price { get; set; }
    public int StudioId { get; set; }
    public Studio? Studio { get; set; }
    public ICollection<Artist> Artists { get; set; } = new List<Artist>();
}
