namespace WebFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("POST")]
    public partial class POST
    {
        [Key]
        public int MaBai { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        public string Content { get; set; }

        public int? MaPostParent { get; set; }

        public virtual POST_PARENT POST_PARENT { get; set; }
    }
}
