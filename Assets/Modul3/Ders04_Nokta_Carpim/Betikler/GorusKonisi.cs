using UnityEngine;

/// <summary>
/// Düşmanın görüş konisi.
/// Hedef hem menzilin içinde hem görüş açısının içindeyse düşman hedefi görür.
/// Açı denetimi nokta çarpımla yapılır.
/// </summary>
public class GorusKonisi : MonoBehaviour
{
    [SerializeField] Transform hedef;
    [SerializeField] float gorusAcisi = 90f;
    [SerializeField] float menzil = 6f;

    float noktaCarpim;
    float aci;
    float uzaklik;
    bool goruyor;
    Renderer gorunum;

    void Start()
    {
        gorunum = GetComponent<Renderer>();
    }

    void Update()
    {
        if (hedef == null) return;

        Hesapla();

        // Gören düşman kırmızıya, görmeyen düşman griye boyanır.
        gorunum.material.color = goruyor ? Color.red : Color.gray;
    }

    void Hesapla()
    {
        // Düşmandan hedefe giden vektör. Uzunluğu aradaki uzaklıktır.
        Vector3 fark = hedef.position - transform.position;
        uzaklik = fark.magnitude;

        // İki birim vektörün nokta çarpımı, aralarındaki açının kosinüsüdür.
        noktaCarpim = Vector3.Dot(transform.forward, fark.normalized);

        // Açının kendisi yalnızca ekrana yazmak için hesaplanır.
        aci = Mathf.Acos(Mathf.Clamp(noktaCarpim, -1f, 1f)) * Mathf.Rad2Deg;

        // Eşik, görüş açısının yarısının kosinüsüdür.
        float esik = Mathf.Cos(gorusAcisi * 0.5f * Mathf.Deg2Rad);

        // Hedef hem menzilin hem koninin içindeyse görülür.
        goruyor = uzaklik <= menzil && noktaCarpim >= esik;
    }

    string Metin()
    {
        string taraf = noktaCarpim >= 0f ? "önde" : "arkada";
        string sonuc = goruyor ? "GÖRÜYOR" : "görmüyor";
        return "nokta çarpım " + Cizim.Sayi(noktaCarpim) + "  açı " + Mathf.RoundToInt(aci) + "  uzaklık " + Cizim.Sayi(uzaklik) + "\n" + taraf + "  " + sonuc;
    }

    void OnDrawGizmos()
    {
        if (hedef == null) return;
        Hesapla();

        Color renk = goruyor ? Color.red : Color.yellow;
        Vector3 o = transform.position;
        float yarim = gorusAcisi * 0.5f;

        // Koninin iki kenarı. İleri yön, yukarı eksen etrafında yarım açı kadar iki yana döndürülür.
        Vector3 sol = Quaternion.AngleAxis(-yarim, Vector3.up) * transform.forward;
        Vector3 sag = Quaternion.AngleAxis(yarim, Vector3.up) * transform.forward;
        Gizmos.color = renk;
        Gizmos.DrawLine(o, o + sol * menzil);
        Gizmos.DrawLine(o, o + sag * menzil);

        // Koninin yayı kısa çizgilerle çizilir.
        Vector3 onceki = o + sol * menzil;
        for (int i = 1; i <= 24; i++)
        {
            float a = -yarim + gorusAcisi * i / 24f;
            Vector3 yayNoktasi = o + Quaternion.AngleAxis(a, Vector3.up) * transform.forward * menzil;
            Gizmos.DrawLine(onceki, yayNoktasi);
            onceki = yayNoktasi;
        }

        Cizim.Ok(o, o + transform.forward * 2f, Color.blue);
        Cizim.KesikliCizgi(o, hedef.position, Color.white);
        Cizim.Yazi(o + Vector3.up * 1.8f, Metin(), renk);
    }

    void OnGUI()
    {
        if (hedef == null) return;
        GUIStyle stil = new GUIStyle(GUI.skin.label);
        stil.fontSize = 22;
        GUI.Label(new Rect(20f, 20f, 900f, 70f), Metin(), stil);
    }
}
