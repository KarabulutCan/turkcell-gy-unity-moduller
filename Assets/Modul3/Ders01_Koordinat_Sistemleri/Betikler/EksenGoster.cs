using UnityEngine;

/// <summary>
/// Bulunduğu noktadan başlayan X, Y ve Z eksenlerini çizer.
/// Unity'nin renk düzenine uyar. X kırmızı, Y yeşil, Z mavidir.
/// Her birimde küçük bir çentik bulunur.
/// </summary>
public class EksenGoster : MonoBehaviour
{
    [SerializeField] float uzunluk = 5f;

    void OnDrawGizmos()
    {
        Vector3 o = transform.position;

        // Vector3.right, up ve forward sırasıyla X, Y ve Z eksenlerinin artı yönleridir.
        EksenCiz(o, Vector3.right, Vector3.up, Color.red, "X");
        EksenCiz(o, Vector3.up, Vector3.right, Color.green, "Y");
        EksenCiz(o, Vector3.forward, Vector3.up, Color.blue, "Z");
    }

    void EksenCiz(Vector3 o, Vector3 yon, Vector3 centikYonu, Color renk, string ad)
    {
        Cizim.Ok(o, o + yon * uzunluk, renk);
        Cizim.Yazi(o + yon * (uzunluk + 0.3f), ad, renk);

        // Birim çentikleri. Her çentik bir birimi, yani bir metreyi gösterir.
        Gizmos.color = renk;
        for (int i = 1; i < uzunluk; i++)
        {
            Vector3 p = o + yon * i;
            Gizmos.DrawLine(p - centikYonu * 0.08f, p + centikYonu * 0.08f);
        }
    }
}
