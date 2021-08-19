using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NBLSystemProject.pages.entity
{
    [Table("MENSAGEM")]
    public partial class Mensagem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int id { set; get; }

        [Key, Column(Order = 1)]
        public int id_nome { set; get; }

        [Required]
        [StringLength(250)]
        [Key, Column(Order = 2)]
        public string mensagem { set; get; }
    }
}
