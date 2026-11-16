using UnityEngine;

/// <summary>
/// Toplanan puanı ve oyunun nasıl oynandığını ekranda gösterir.
/// Sahneye elle eklenmez, Toplanabilir betiği oyun başladığında oluşturur.
/// </summary>
public class PuanGostergesi : MonoBehaviour
{
    void OnGUI()
    {
        EkranArayuzu.Basla();
        EkranArayuzu.PanelBasla(20f, 20f, 440f);
        EkranArayuzu.Vurgu("Puan " + Toplanabilir.Puan + " / " + Toplanabilir.Toplam);
        if (Toplanabilir.Toplam > 0 && Toplanabilir.Puan >= Toplanabilir.Toplam)
            EkranArayuzu.Baslik("Tebrikler, hepsini topladınız");
        else
            EkranArayuzu.Satir("W A S D ile yürüyün, Boşluk ile zıplayın. Dönen küpleri toplayın.");
        EkranArayuzu.PanelBitir();
    }
}
