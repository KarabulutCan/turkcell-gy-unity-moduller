using UnityEngine;

/// <summary>
/// Nesneyi bir merkezin çevresinde zemin düzleminde döndürür.
/// Açı zamanla artar. Kosinüs X, sinüs Z konumunu verir.
/// Nesnenin yüksekliğine dokunulmaz.
/// </summary>
public class DaireselHareket : MonoBehaviour
{
    [SerializeField] Transform merkez;
    [SerializeField] float yaricap = 3f;
    [SerializeField] float turHizi = 90f;

    float aci;

    void Update()
    {
        if (merkez == null) return;

        // Açı her karede hız çarpı geçen süre kadar artar. Hızın birimi derece bölü saniyedir.
        aci += turHizi * Time.deltaTime;
        float radyan = aci * Mathf.Deg2Rad;

        // Çember üzerindeki nokta. Merkeze yarıçap çarpı kosinüs ve yarıçap çarpı sinüs eklenir.
        Vector3 konum = transform.position;
        konum.x = merkez.position.x + Mathf.Cos(radyan) * yaricap;
        konum.z = merkez.position.z + Mathf.Sin(radyan) * yaricap;
        transform.position = konum;
    }

    void OnDrawGizmos()
    {
        if (merkez == null) return;

        // Yörünge çemberi.
        Vector3 m = merkez.position;
        Gizmos.color = Color.gray;
        Vector3 onceki = m + Vector3.right * yaricap;
        for (int i = 1; i <= 48; i++)
        {
            float a = i * 360f / 48f * Mathf.Deg2Rad;
            Vector3 nokta = m + new Vector3(Mathf.Cos(a), 0f, Mathf.Sin(a)) * yaricap;
            Gizmos.DrawLine(onceki, nokta);
            onceki = nokta;
        }

        Vector3 izdusum = new Vector3(transform.position.x, m.y, transform.position.z);
        Cizim.KesikliCizgi(m, izdusum, Color.yellow);
        Cizim.Yazi(transform.position + Vector3.up * 0.8f, "açı " + Mathf.RoundToInt(aci % 360f), Color.white);
    }
}
