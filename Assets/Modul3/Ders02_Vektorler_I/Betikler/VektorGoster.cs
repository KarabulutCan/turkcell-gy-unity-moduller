using UnityEngine;

/// <summary>
/// Başlangıç noktasından bu nesneye uzanan vektörü ok olarak çizer.
/// Başlangıç boş bırakılırsa vektör sahnenin merkezinden başlar.
/// Okun yanında vektörün bileşenleri ve uzunluğu yazar.
/// </summary>
public class VektorGoster : MonoBehaviour
{
    [SerializeField] Transform baslangic;
    [SerializeField] Color renk = Color.yellow;
    [SerializeField] string ad = "A";

    Vector3 Baslangic
    {
        get { return baslangic != null ? baslangic.position : Vector3.zero; }
    }

    // Vektör, uç noktadan başlangıç noktasının çıkarılmasıyla bulunur.
    public Vector3 Vektor
    {
        get { return transform.position - Baslangic; }
    }

    void OnDrawGizmos()
    {
        Vector3 v = Vektor;
        Cizim.Ok(Baslangic, transform.position, renk);

        // magnitude vektörün uzunluğunu verir.
        string metin = ad + " " + Cizim.Vektor(v) + "  uzunluk " + Cizim.Sayi(v.magnitude);
        Cizim.Yazi(transform.position + Vector3.up * 0.35f, metin, renk);
    }
}
