using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AplikasiPerpustakaan.Models
{
    public class Return
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Return { get; set; }

        [Display(Name = "Nama Pengembali")]
        [StringLength(20)]
        [Required(ErrorMessage = "{0} Harus Ada.")]
        public string nama_pengembali { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Tanggal Pengembalian")]
        public DateTime tanggal_pengembalian { get; set; }

        [Display(Name = "Tanggal Pinjam")]
        public int? Id_Borrow { get; set; }

        [Display(Name = "Keterangan")]
        public string ket { get; set; }
    

        public virtual Borrow Borrow { get; set; }

    }

}