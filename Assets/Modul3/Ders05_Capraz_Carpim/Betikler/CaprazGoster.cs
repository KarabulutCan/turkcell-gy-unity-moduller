using UnityEngine;

/// <summary>
/// İki vektörün çapraz çarpımını çizer.
/// Sonuç iki vektöre de dik olan yeni bir vektördür.
/// Uzunluğu, iki vektörün oluşturduğu paralelkenarın alanına eşittir.
/// </summary>
public class CaprazGoster : MonoBehaviour
{
    [SerializeField] VektorGoster a;
    [SerializeField] VektorGoster b;

    void OnDrawGizmos()
    {
        if (a == null || b == null) return;

        // Çapraz çarpımda sıra önemlidir. Sıra değişirse sonuç ters yöne bakar.
        Vector3 capraz = Vector3.Cross(a.Vektor, b.Vektor);

        Cizim.Ok(Vector3.zero, capraz, Color.green);
        Cizim.Yazi(capraz + Vector3.right * 0.3f, "A x B " + Cizim.Vektor(capraz) + "  uzunluk " + Cizim.Sayi(capraz.magnitude), Color.green);

        // A ve B vektörlerinin oluşturduğu paralelkenarın diğer iki kenarı.
        Cizim.KesikliCizgi(a.Vektor, a.Vektor + b.Vektor, Color.gray);
        Cizim.KesikliCizgi(b.Vektor, a.Vektor + b.Vektor, Color.gray);
    }
}
