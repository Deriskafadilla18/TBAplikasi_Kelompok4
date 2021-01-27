using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AplikasiPerpustakaan.Models
{
    public class Publisher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Publisher { get; set; }


        [Display(Name = "Nama penerbit")]
        [StringLength(50)]
        public string penerbit { get; set; }

        [Display(Name = "Alamat Penerbit")]
        [StringLength(50)]
        public string alamat { get; set; }

        [Display(Name = "Nama Pemimpin")]
        [StringLength(50)]
        public string pemimpin { get; set; }


        public virtual ICollection<Book> Book { get; set; }
    }

}
