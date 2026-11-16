using UnityEngine;

/// <summary>
/// İki vektörün toplamını çizer.
/// B vektörü A vektörünün ucuna taşınarak kesikli çizilir. Toplam, merkezden bu yeni uca uzanan oktur.
/// </summary>
public class VektorToplam : MonoBehaviour
{
    [SerializeField] VektorGoster a;
    [SerializeField] VektorGoster b;

    void OnDrawGizmos()
    {
        if (a == null || b == null) return;

        // Vektörler bileşen bileşen toplanır.
        Vector3 toplam = a.Vektor + b.Vektor;

        // Uç uca ekleme. B vektörü A vektörünün bittiği yerden başlatılır.
        Cizim.KesikliCizgi(a.Vektor, toplam, Color.gray);
        Cizim.Ok(Vector3.zero, toplam, Color.white);
        Cizim.Yazi(toplam + Vector3.up * 0.35f, "A + B " + Cizim.Vektor(toplam) + "  uzunluk " + Cizim.Sayi(toplam.magnitude), Color.white);
    }
}
