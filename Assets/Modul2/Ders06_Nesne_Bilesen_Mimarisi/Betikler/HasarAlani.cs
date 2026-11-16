using UnityEngine;

/// <summary>
/// Ekrandaki düğmeye her tıklandığında hedefteki Saglik bileşenine hasar verir.
/// Hedef Inspector'dan sürüklenerek atanır.
/// </summary>
public class HasarAlani : MonoBehaviour
{
    [SerializeField] int hasar = 30;

    // Hasar verilecek nesnenin Saglik bileşeni.
    [SerializeField] Saglik hedef;

    void OnGUI()
    {
        EkranArayuzu.Basla();
        EkranArayuzu.PanelBasla(20f, 20f, 560f);
        EkranArayuzu.Baslik("Bileşenler birlikte çalışıyor");

        if (hedef != null)
        {
            EkranArayuzu.Satir(name + " nesnesindeki HasarAlani bileşeni, " + hedef.name + " nesnesindeki Saglik bileşenine hasar verir.");
            EkranArayuzu.Vurgu(hedef.name + " canı " + Mathf.Max(hedef.Can, 0) + " / " + hedef.EnYuksekCan);

            // Düğmeye tıklanınca hedefin HasarAl fonksiyonu çağrılır.
            if (EkranArayuzu.Dugme("Hasar ver (" + hasar + ")")) hedef.HasarAl(hasar);

            EkranArayuzu.Aciklama("Can sıfıra inince Saglik bileşenindeki canBitti olayı tetiklenir. Olaya bağlı YokOl bileşeni nesneyi sahneden siler.");
        }
        else
        {
            // Hedef silindiğinde ya da atanmadığında Unity bu alanı boş sayar.
            EkranArayuzu.Vurgu("Hedef yok");
            EkranArayuzu.Aciklama("Hedef nesne silindi ya da Inspector'da Hedef alanı boş. canBitti olayı YokOl bileşenini çalıştırdı ve nesne sahneden kaldırıldı.");
        }
        EkranArayuzu.PanelBitir();
    }
}
