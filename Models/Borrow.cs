using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AplikasiPerpustakaan.Models
{
    public class Borrow
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Borrow { get; set; }

        [Display(Name = "Nama Peminjam")]
        [StringLength(20)]
        [Required(ErrorMessage = "{0} Harus Ada.")]
        public string nama_peminjam { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Tanggal Pinjam")]
        public DateTime tanggal_pinjam { get; set; }

        [Display(Name = "Nama Penerbit")]
        public int? Id_Book { get; set; }

        [Display(Name = "Lama Pinjam (Hari)")]
        public int lama_pinjam { get; set; }


        public virtual Book Book { get; set; }

    }

}