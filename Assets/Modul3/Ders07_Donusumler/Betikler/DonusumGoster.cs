using UnityEngine;

/// <summary>
/// Ebeveyne bağlı bir nesnenin yerel ve dünya konumunu yan yana gösterir.
/// Ebeveynin kendi eksenlerini de çizer. Ebeveyn döndüğünde bu eksenler onunla birlikte döner.
/// </summary>
public class DonusumGoster : MonoBehaviour
{
    string Metin()
    {
        // localPosition ebeveyne göre, position sahneye göre konumdur.
        return "yerel " + Cizim.Vektor(transform.localPosition) + "\n" + "dünya " + Cizim.Vektor(transform.position);
    }

    void OnDrawGizmos()
    {
        Transform ebeveyn = transform.parent;
        if (ebeveyn == null) return;

        // Ebeveynin yerel eksenleri. Sağ kırmızı, yukarı yeşil, ileri mavi.
        Vector3 o = ebeveyn.position;
        Cizim.Ok(o, o + ebeveyn.right * 1.5f, Color.red);
        Cizim.Ok(o, o + ebeveyn.up * 1.5f, Color.green);
        Cizim.Ok(o, o + ebeveyn.forward * 1.5f, Color.blue);

        Cizim.KesikliCizgi(o, transform.position, Color.white);
        Cizim.Yazi(transform.position + Vector3.up * 0.9f, Metin(), Color.white);
    }

    void OnGUI()
    {
        GUIStyle stil = new GUIStyle(GUI.skin.label);
        stil.fontSize = 22;
        GUI.Label(new Rect(20f, 20f, 900f, 70f), name + "\n" + Metin(), stil);
    }
}
