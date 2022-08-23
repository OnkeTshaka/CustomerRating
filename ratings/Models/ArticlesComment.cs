using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ratings.Models
{
    public class ArticlesComment
    {

        [Key, ScaffoldColumn(false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CommentId { get; set; } = Guid.NewGuid();
        public string Comments { get; set; }
        public DateTime? ThisDateTime { get; set; }
        public int ArticleId { get; set; }
        public int? Rating { get; set; }
    }
}