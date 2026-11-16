using UnityEngine;

/// <summary>
/// Bir vektörün sayıyla çarpımını çizer.
/// Çarpan birden büyükse vektör uzar, sıfır ile bir arasındaysa kısalır, eksi ise yönü tersine döner.
/// </summary>
public class VektorOlcek : MonoBehaviour
{
    [SerializeField] VektorGoster a;
    [SerializeField] float carpan = 2f;

    void OnDrawGizmos()
    {
        if (a == null) return;

        // Sayıyla çarpım her bileşeni aynı sayıyla çarpar. Yön değişmez, uzunluk değişir.
        Vector3 sonuc = a.Vektor * carpan;

        // Ok, asıl vektörle üst üste binmesin diye biraz aşağıdan çizilir.
        Vector3 kaydir = Vector3.down * 0.25f;
        Cizim.Ok(kaydir, sonuc + kaydir, Color.cyan);
        Cizim.Yazi(sonuc + kaydir + Vector3.down * 0.35f, Cizim.Sayi(carpan) + " x A " + Cizim.Vektor(sonuc) + "  uzunluk " + Cizim.Sayi(sonuc.magnitude), Color.cyan);
    }
}
