using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ratings.Models
{
    public class Article
    {

        [Key, ScaffoldColumn(false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Guid AutoId { get; set; } = Guid.NewGuid();
        public int AutoId { get; set; }
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public bool Active { get; set; }

    }
}