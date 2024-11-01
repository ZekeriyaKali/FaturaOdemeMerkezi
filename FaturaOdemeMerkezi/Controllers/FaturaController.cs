using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

public class FaturaController : Controller
{
    [HttpPost]
    public IActionResult Hesapla(string faturaTuru, string aboneTipi, float sonEndeks, float ilkEndeks)
    {
        // Hesaplama işlemleri
       
        float tuketimTutari = sonEndeks - ilkEndeks;
        float odemeTutari = 0;
        float komisyonTutari = 0;


        if (faturaTuru == "Su")
        {
            if (aboneTipi == "Ev")
            {
                if (tuketimTutari <= 20)
                    odemeTutari = 2;
                else
                    odemeTutari = 3;
            }
            else if (aboneTipi == "Isyeri")
            {
                if (tuketimTutari <= 100)
                    odemeTutari = 3;
                else if (tuketimTutari > 100)
                    odemeTutari = 4;
            }

            komisyonTutari = odemeTutari * 0.005f;
        }
        else if (faturaTuru == "Elektrik")
        {
            if (aboneTipi == "Ev")
            {
                if (tuketimTutari < 150)
                    odemeTutari = 1;
                else
                    odemeTutari = 2;
            }
            else if (aboneTipi == "Isyeri")
            {
                if (tuketimTutari < 500)
                    odemeTutari = 2;
                else
                    odemeTutari = 3;
            }

            komisyonTutari = odemeTutari * 0.003f;
        }
        else if (faturaTuru == "Doğalgaz")
        {
            if (aboneTipi == "Ev")
            {
                if (tuketimTutari <= 100)
                    odemeTutari = 3;
                else
                    odemeTutari = 4;
            }
            else if (aboneTipi == "Isyeri")
            {
                if (tuketimTutari <= 500)
                    odemeTutari = 4;
                else
                    odemeTutari = 5;
            }

            komisyonTutari = odemeTutari * 0.002f;
        }

        var result = new
        {
            OdemeTutari = odemeTutari*tuketimTutari,
            KomisyonTutari = komisyonTutari
        };

        return Json(result);
    }
}
