using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SoftUni_Blog.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Title { get; set; }

        public string Content { get; set; }

        [ForeignKey("Author")]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}