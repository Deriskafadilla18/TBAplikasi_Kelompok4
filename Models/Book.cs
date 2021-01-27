using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AplikasiPerpustakaan.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Book { get; set; }

        [Display(Name = "Genre buku")]
        [StringLength(20)]
        [Required(ErrorMessage = "{0} Harus Ada.")]
        public string genre { get; set; }

        [Display(Name = "Jumlah buku")]
        [Required(ErrorMessage = "{0} Harus Ada.")]
        public int jumlah { get; set; }

        [Display(Name = "Judul buku")]
        [StringLength(50)]
        public string judul { get; set; }

        [Display(Name = "Nama Penulis")]
        public int? Id_Author { get; set; }


        [Display(Name = "Nama Penerbit")]
        public int? Id_Publisher { get; set; }

        public virtual Author Author { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<Borrow> Borrow { get; set; }

    }

}