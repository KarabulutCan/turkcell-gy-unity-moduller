using UnityEngine;

/// <summary>
/// Nesnenin konumunu görünür kılar.
/// Noktadan zemine ve eksenlere kesikli çizgiler çizer, konumu sayı olarak yazar.
/// Play modunda konum Game penceresinin sol üst köşesinde de görünür.
/// </summary>
public class KonumGoster : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Vector3 p = transform.position;

        // Noktanın zemindeki izdüşümü. Y değeri sıfırlanır.
        Vector3 zemin = new Vector3(p.x, 0f, p.z);

        // Yeşil çizgi yüksekliği, mavi çizgi Z değerini, kırmızı çizgi X değerini gösterir.
        Cizim.KesikliCizgi(p, zemin, Color.green);
        Cizim.KesikliCizgi(zemin, new Vector3(p.x, 0f, 0f), Color.blue);
        Cizim.KesikliCizgi(zemin, new Vector3(0f, 0f, p.z), Color.red);

        Cizim.Yazi(p + Vector3.up * 0.4f, name + " " + Cizim.Vektor(p), Color.white);
    }

    void OnGUI()
    {
        GUIStyle stil = new GUIStyle(GUI.skin.label);
        stil.fontSize = 22;
        GUI.Label(new Rect(20f, 20f, 700f, 34f), name + " konumu " + Cizim.Vektor(transform.position), stil);
    }
}
