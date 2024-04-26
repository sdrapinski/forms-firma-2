using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace firma
{
    [Table(Name = "Faktury Sprzedaży")]
    internal class FakturaSprzedazy
    {
        [Column(Name = "Id", IsPrimaryKey = true, CanBeNull = false)] public int Id;
        [Column(CanBeNull = false)] public string Numer;
        [Column(CanBeNull = false)] public double Netto;
        [Column(CanBeNull = true)] public Nullable<double> Vat;
        [Column(CanBeNull = false)] public DateTime Data;
        [Column(CanBeNull = true)] public double? Zapłacono;
        [Column(CanBeNull = false)] public double Kontrahent_ID;
        [Column(CanBeNull = false)] public double Pracownik_ID;

    }
}
