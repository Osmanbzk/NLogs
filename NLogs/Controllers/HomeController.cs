using NLog.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NLog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Hatalar> list = DosyaOku();

            return View(list.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        private static List<Hatalar> DosyaOku()
        {
            //Okuma işlemi yapılacak dosya yolu
            string dosyaYolu = @"D:\\SRC\\deneme.txt";
            char[] delimiterChars = { ' ' };
            string[] word;
            List<Hatalar> hatalar = new List<Hatalar>();
            try
            {
                //FileStream nesnesi
                FileStream fs = new FileStream(dosyaYolu, FileMode.Open, FileAccess.Read);

                //Okuma işlemi için StreamReader nesnesi
                StreamReader sr = new StreamReader(fs);

                string yazi = sr.ReadLine();
                string concatText;


                while (yazi != null)
                {
                    yazi = sr.ReadLine();
                    word = yazi.Split(delimiterChars);
                    concatText = string.Empty;
                    Hatalar hata = new Hatalar();

                    for (int i = 0; i < word.Length; i++)
                    {
                        if (i == 0)
                        {
                            hata.Tarih = Convert.ToDateTime(word[i]);
                        }
                        else if (i == 1)
                        {
                            hata.Saat = word[i].ToString();
                        }
                        else if (i == 2)
                        {
                            hata.Hata = word[i].ToString();
                        }
                        else
                        {
                            concatText = string.Concat(concatText + " ", word[i]);
                        }

                    }
                    hata.Aciklama = concatText;
                    hatalar.Add(hata);
                }

                //Son yazı okunduktan sonra kullandıgımız nesneleri iade ettik.
                sr.Close();
                fs.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return hatalar;
        }

    }
}