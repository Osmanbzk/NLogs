using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLog.Models
{
    public class Hatalar
    {
        public DateTime  Tarih { get; set; }
        public string Saat { get; set; }
        public string Hata { get; set; }
        public string Aciklama { get; set; }
    }
}