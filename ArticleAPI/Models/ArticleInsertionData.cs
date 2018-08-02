using System;
using System.ComponentModel.DataAnnotations;

namespace ArticleAPI.Models
{
    public class ArticleInsertionData
    {
        [Required]  public string Author { get; set; }
        [Required]  public string Title { get; set; }
        [Required]  public string Body { get; set; }
        [Required]  public string Summary { get; set; }
        [Required]  public int Views { get; set; }
        [Required]  public DateTime PublicationDate { get; set; }
        [Required]  public bool IsPublished { get; internal set; }
        [Required]  public int CategoryID { get; set; }
    }
}