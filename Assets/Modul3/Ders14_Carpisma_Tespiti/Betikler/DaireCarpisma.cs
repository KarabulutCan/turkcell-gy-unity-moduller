using UnityEngine;

/// <summary>
/// İki kürenin çarpışıp çarpışmadığını uzaklıkla denetler.
/// Merkezler arasındaki uzaklık yarıçapların toplamından küçükse küreler çarpışıyordur.
/// Karşılaştırma karekök almadan, uzaklığın karesiyle yapılır.
/// </summary>
public class DaireCarpisma : MonoBehaviour
{
    [SerializeField] Transform diger;

    // Kürenin yarıçapı ölçeğinin yarısıdır.
    float Yaricap(Transform kure)
    {
        return kure.localScale.x * 0.5f;
    }

    bool Carpisiyor()
    {
        Vector3 fark = diger.position - transform.position;
        float toplam = Yaricap(transform) + Yaricap(diger);

        // Uzaklığın karesi, yarıçaplar toplamının karesiyle karşılaştırılır.
        return fark.sqrMagnitude <= toplam * toplam;
    }

    void OnDrawGizmos()
    {
        if (diger == null) return;

        bool carpisiyor = Carpisiyor();
        Color renk = carpisiyor ? Color.red : Color.green;

        Cizim.Cember(transform.position, Vector3.up, Yaricap(transform), renk);
        Cizim.Cember(diger.position, Vector3.up, Yaricap(diger), renk);
        Cizim.KesikliCizgi(transform.position, diger.position, Color.white);

        float uzaklik = Vector3.Distance(transform.position, diger.position);
        float toplam = Yaricap(transform) + Yaricap(diger);
        string metin = "uzaklık " + Cizim.Sayi(uzaklik) + "  yarıçaplar toplamı " + Cizim.Sayi(toplam) + "\n" + (carpisiyor ? "ÇARPIŞIYOR" : "çarpışmıyor");
        Cizim.Yazi(transform.position + Vector3.up * 1.8f, metin, renk);
    }
}
