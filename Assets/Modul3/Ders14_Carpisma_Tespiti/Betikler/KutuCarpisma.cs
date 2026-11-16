using UnityEngine;

/// <summary>
/// İki nesnenin eksen hizalı sınır kutularının kesişip kesişmediğini denetler.
/// Kutular üç eksenin üçünde de örtüşüyorsa kesişiyordur.
/// Nesne döndürüldüğünde sınır kutusu nesneyi içine alacak biçimde büyür.
/// </summary>
public class KutuCarpisma : MonoBehaviour
{
    [SerializeField] Transform diger;

    void OnDrawGizmos()
    {
        if (diger == null) return;

        // Renderer bileşeni nesneyi saran eksen hizalı kutuyu verir.
        Bounds a = GetComponent<Renderer>().bounds;
        Bounds b = diger.GetComponent<Renderer>().bounds;

        // Her eksende iki aralığın örtüşüp örtüşmediğine bakılır.
        bool x = a.min.x <= b.max.x && a.max.x >= b.min.x;
        bool y = a.min.y <= b.max.y && a.max.y >= b.min.y;
        bool z = a.min.z <= b.max.z && a.max.z >= b.min.z;

        // Üç eksenin üçünde de örtüşme varsa kutular kesişir.
        bool kesisiyor = x && y && z;

        Color renk = kesisiyor ? Color.red : Color.green;
        Gizmos.color = renk;
        Gizmos.DrawWireCube(a.center, a.size);
        Gizmos.DrawWireCube(b.center, b.size);

        string metin = "X " + (x ? "örtüşüyor" : "ayrı") + "  Y " + (y ? "örtüşüyor" : "ayrı") + "  Z " + (z ? "örtüşüyor" : "ayrı") + "\n" + (kesisiyor ? "KESİŞİYOR" : "kesişmiyor");
        Cizim.Yazi(a.center + Vector3.up * (a.extents.y + 1.2f), metin, renk);
    }
}
