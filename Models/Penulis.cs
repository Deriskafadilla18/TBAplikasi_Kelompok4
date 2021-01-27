using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AplikasiPerpustakaan.Models
{
    public class Author
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Author { get; set; }

        [Display(Name = "Nama penulis")]
        [StringLength(40)]
        [Required(ErrorMessage = "{0} Harus Ada.")]
        public string penulis { get; set; }

        [Display(Name = "Umur Penulis")]
        [Required(ErrorMessage = "{0} Harus Ada.")]
        public int umur { get; set; }

        [Display(Name = "Asal Penulis")]
        [StringLength(50)]
        public string asal { get; set; }

        [Display(Name = "Nama Pena")]
        [StringLength(50)]
        public string pena { get; set; }

        [Display(Name = "Hobi Penulis")]
        [StringLength(50)]
        public string hobi { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }

}