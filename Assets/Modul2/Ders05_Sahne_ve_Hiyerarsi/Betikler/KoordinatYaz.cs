using UnityEngine;

/// <summary>
/// Nesnenin yerel ve dünya konumunu Game penceresinde gösterir ve Console penceresine yazar.
/// localPosition ebeveyne göre konumdur. position sahnenin merkezine göre konumdur.
/// </summary>
public class KoordinatYaz : MonoBehaviour
{
    void Update()
    {
        Debug.Log(name + " yerel " + transform.localPosition + " dunya " + transform.position);
    }

    void OnGUI()
    {
        EkranArayuzu.Basla();
        string ebeveyn = transform.parent != null ? transform.parent.name : "yok";

        EkranArayuzu.PanelBasla(20f, 20f, 520f);
        EkranArayuzu.Baslik(name + " nesnesinin konumu");
        EkranArayuzu.Satir("Yerel konum. Ebeveyni " + ebeveyn + " nesnesine göre");
        EkranArayuzu.Vurgu(Yaz(transform.localPosition));
        EkranArayuzu.Satir("Dünya konumu. Sahnenin merkezine göre");
        EkranArayuzu.Vurgu(Yaz(transform.position));
        EkranArayuzu.Aciklama("Yerel konum hiç değişmez. Ebeveynler döndükçe nesne onlarla birlikte taşınır ve yalnızca dünya konumu değişir.");
        EkranArayuzu.PanelBitir();

        EkranArayuzu.DunyaEtiketi(transform.position + Vector3.up * 0.8f, name, "", 160f);
    }

    static string Yaz(Vector3 v)
    {
        return "(" + v.x.ToString("0.0") + "   " + v.y.ToString("0.0") + "   " + v.z.ToString("0.0") + ")";
    }
}
