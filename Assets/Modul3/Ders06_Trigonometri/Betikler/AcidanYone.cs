using UnityEngine;

/// <summary>
/// Bir açıyı yön vektörüne çevirir ve birim çember üzerinde gösterir.
/// Kosinüs yatay, sinüs dikey bileşeni verir.
/// Açı Inspector'daki sürgüyle değiştirilir.
/// </summary>
public class AcidanYone : MonoBehaviour
{
    [SerializeField, Range(0f, 360f)] float aciDerece = 30f;
    [SerializeField] float yaricap = 3f;

    void OnDrawGizmos()
    {
        Vector3 o = transform.position;

        // Mathf.Cos ve Mathf.Sin radyan ister. Derece önce radyana çevrilir.
        float radyan = aciDerece * Mathf.Deg2Rad;
        float kosinus = Mathf.Cos(radyan);
        float sinus = Mathf.Sin(radyan);

        // Açıdan yöne dönüşüm. Bu vektörün uzunluğu her zaman birdir.
        Vector3 yon = new Vector3(kosinus, sinus, 0f);
        Vector3 uc = o + yon * yaricap;

        // Çember ve iki eksen.
        Gizmos.color = Color.gray;
        Vector3 onceki = o + Vector3.right * yaricap;
        for (int i = 1; i <= 48; i++)
        {
            float a = i * 360f / 48f * Mathf.Deg2Rad;
            Vector3 nokta = o + new Vector3(Mathf.Cos(a), Mathf.Sin(a), 0f) * yaricap;
            Gizmos.DrawLine(onceki, nokta);
            onceki = nokta;
        }
        Gizmos.DrawLine(o - Vector3.right * yaricap, o + Vector3.right * yaricap);
        Gizmos.DrawLine(o - Vector3.up * yaricap, o + Vector3.up * yaricap);

        // Sarı ok yönü gösterir. Kırmızı çizgi kosinüs, yeşil çizgi sinüstür.
        Cizim.Ok(o, uc, Color.yellow);
        Vector3 ayak = o + Vector3.right * kosinus * yaricap;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(o, ayak);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(ayak, uc);

        string metin = "açı " + Cizim.Sayi(aciDerece) + "  cos " + Cizim.Sayi(kosinus) + "  sin " + Cizim.Sayi(sinus) + "\n" + "yön " + Cizim.Vektor(yon);
        Cizim.Yazi(o + Vector3.up * (yaricap + 1f) - Vector3.right * yaricap, metin, Color.white);
    }
}
