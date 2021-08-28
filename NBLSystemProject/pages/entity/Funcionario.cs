using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NBLSystemProject.pages.entity
{
    [Table("USUARIO")]
    public class Funcionario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int id { set; get; }

        [Required]
        [StringLength(100)]
        [Key, Column(Order = 1)]
        public string nome { set; get; }

        [Required]
        [StringLength(20)]
        [Key, Column(Order = 2)]
        public string login { set; get; }

        [Required]
        [StringLength(50)]
        [Key, Column(Order = 3)]
        public string senha { set; get; }

    }
}
