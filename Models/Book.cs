using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CSO_LF089.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The {0} required")]
        [Display(Name = "Book Name")]
        public string BookName { get; set; }
        [Display(Name = "Subject")]
        public string BookSubject { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        [Display(Name = "Status")]
        public string ReadingStatus { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Image Name")]
        public string ImageName { get; set; }

        [NotMapped]
        [Display(Name = "Upload File")]
        public IFormFile ImageFile { get; set; }
    }
}
