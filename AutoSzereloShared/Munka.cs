using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoSzerelo.Shared
{
    public class Munka
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MunkaId { get; set; }

        [Required]
        [ForeignKey("Kliens")]
        public Guid KliensId { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{3}-[0-9]{3}$")]
        public string? Rendszam { get; set; }

        [Required]
        [DatumTartomany]
        public DateTime GyartasiEv { get; set; }

        [Required]
        [MaxLength(1000)]
        public string? Leiras { get; set; }

        [Required]
        [Range(1, 10)]
        public int HibaSulyossaga { get; set; }

        public enum MunkaAllapot
        {
            FelvettMunka,
            ElvegzesAlatt,
            Befejezett
        }

        [Required]
        [EnumDataType(typeof(MunkaAllapot))]
        public MunkaAllapot Allapot { get; set; }

        public enum MunkaKategoria
        {
            Karosszeria,
            Motor,
            Futomu,
            Fekberendezes
        }

        [Required]
        [EnumDataType(typeof(MunkaKategoria))]
        public MunkaKategoria MKategoria { get; set; }

        double Kategoria()
        {
            switch (this.MKategoria)
            {
                case MunkaKategoria.Karosszeria: return 3;
                case MunkaKategoria.Motor: return 8;
                case MunkaKategoria.Futomu: return 6;
                case MunkaKategoria.Fekberendezes: return 4;
                default: return 0;
            }
        }

        double Ev()
        {
            int yearDifference = (DateTime.Now.Date - this.GyartasiEv).Days / 365;

            if (yearDifference < 5) return 0.5;
            if (yearDifference < 10) return 1;
            if (yearDifference < 20) return 1.5;
            return 2;
        }

        double Sulyossag()
        {
            if (this.HibaSulyossaga < 3) return 0.2;
            if (this.HibaSulyossaga < 5) return 0.4;
            if (this.HibaSulyossaga < 8) return 0.6;
            if (this.HibaSulyossaga < 10) return 0.8;
            return 1;
        }

        public double MunkaoraEsztimacio()
        {
            double kategoria = Kategoria();
            double kor = Ev();
            double hibasulyossag = Sulyossag();

            return kategoria * kor * hibasulyossag;
        }
        public MunkaAllapot AktualisAllapot()
        {
            return Allapot;
        }
    }
}
