using UnityEngine;

/// <summary>
/// Bir noktadan diğerine giden vektörü çizer.
/// A noktasından B noktasına giden vektör, B konumundan A konumu çıkarılarak bulunur.
/// </summary>
public class VektorFark : MonoBehaviour
{
    [SerializeField] VektorGoster a;
    [SerializeField] VektorGoster b;

    void OnDrawGizmos()
    {
        if (a == null || b == null) return;

        // Hedef eksi başlangıç. Oyunlarda en sık kullanılan vektör işlemidir.
        Vector3 fark = b.Vektor - a.Vektor;

        Cizim.Ok(a.Vektor, b.Vektor, Color.green);
        Vector3 orta = (a.Vektor + b.Vektor) * 0.5f;
        Cizim.Yazi(orta + Vector3.up * 0.35f, "B eksi A " + Cizim.Vektor(fark) + "  uzunluk " + Cizim.Sayi(fark.magnitude), Color.green);
    }
}
