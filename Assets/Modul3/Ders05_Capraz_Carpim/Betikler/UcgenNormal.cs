using UnityEngine;

/// <summary>
/// Üç köşesi verilen üçgenin yüzey normalini çizer.
/// Normal, üçgenin iki kenarının çapraz çarpımıyla bulunur.
/// </summary>
public class UcgenNormal : MonoBehaviour
{
    [SerializeField] Transform a;
    [SerializeField] Transform b;
    [SerializeField] Transform c;

    void OnDrawGizmos()
    {
        if (a == null || b == null || c == null) return;

        // A köşesinden çıkan iki kenar.
        Vector3 kenar1 = b.position - a.position;
        Vector3 kenar2 = c.position - a.position;

        // İki kenarın çapraz çarpımı yüzeye diktir. Normalize edilince yüzey normali olur.
        Vector3 normal = Vector3.Cross(kenar1, kenar2).normalized;

        Gizmos.color = Color.white;
        Gizmos.DrawLine(a.position, b.position);
        Gizmos.DrawLine(b.position, c.position);
        Gizmos.DrawLine(c.position, a.position);

        // Normal, üçgenin ağırlık merkezinden çizilir.
        Vector3 orta = (a.position + b.position + c.position) / 3f;
        Cizim.Ok(orta, orta + normal * 1.5f, Color.green);
        Cizim.Yazi(orta + normal * 1.8f, "normal " + Cizim.Vektor(normal), Color.green);
    }
}
