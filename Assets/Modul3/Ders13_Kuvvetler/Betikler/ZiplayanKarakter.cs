using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Kuvvetlerle hareket eden ve zıplayan basit bir karakter. Rigidbody kullanılmaz.
/// Her karede kuvvetler toplanır, ivme bulunur ve Euler entegrasyonu uygulanır.
/// A ve D tuşları yürütür, boşluk tuşu zıplatır.
/// Zıplamanın ilk hızı istenen yükseklikten hesaplanır.
/// </summary>
public class ZiplayanKarakter : MonoBehaviour
{
    [SerializeField] float ziplamaYuksekligi = 2f;
    [SerializeField] float yercekimi = 20f;
    [SerializeField] float kutle = 1f;
    [SerializeField] float yurumeKuvveti = 40f;
    [SerializeField] float surtunme = 6f;

    Vector3 hiz;
    float zemin;
    float enYuksek;
    bool yerde = true;

    void Start()
    {
        // Karakterin başladığı yükseklik zemin kabul edilir.
        zemin = transform.position.y;
    }

    void Update()
    {
        float dt = Time.deltaTime;
        Keyboard klavye = Keyboard.current;

        // Girdi. D tuşu sağa, A tuşu sola yürütür.
        float yon = 0f;
        if (klavye != null && klavye.dKey.isPressed) yon += 1f;
        if (klavye != null && klavye.aKey.isPressed) yon -= 1f;

        // Kuvvetler toplanır. Yürüme kuvveti, hıza ters yönlü sürtünme ve ağırlık.
        Vector3 kuvvet = Vector3.zero;
        kuvvet += Vector3.right * yon * yurumeKuvveti;
        kuvvet += Vector3.left * hiz.x * surtunme * kutle;
        kuvvet += Vector3.down * yercekimi * kutle;

        // Newton'un ikinci yasası. İvme, net kuvvetin kütleye bölümüdür.
        Vector3 ivme = kuvvet / kutle;

        // Zıplama bir itkidir. Dikey hız bir anda değişir.
        if (yerde && klavye != null && klavye.spaceKey.wasPressedThisFrame)
        {
            hiz.y = Mathf.Sqrt(2f * yercekimi * ziplamaYuksekligi);
            yerde = false;
            enYuksek = 0f;
        }

        // Euler entegrasyonu. Önce hız, sonra konum.
        hiz += ivme * dt;
        transform.position += hiz * dt;

        // Zemin karakteri durdurur.
        if (transform.position.y <= zemin)
        {
            Vector3 konum = transform.position;
            konum.y = zemin;
            transform.position = konum;
            hiz.y = 0f;
            yerde = true;
        }

        enYuksek = Mathf.Max(enYuksek, transform.position.y - zemin);
    }

    string Metin()
    {
        float ziplamaHizi = Mathf.Sqrt(2f * yercekimi * ziplamaYuksekligi);
        return "zıplama hızı " + Cizim.Sayi(ziplamaHizi) + "  ulaşılan yükseklik " + Cizim.Sayi(enYuksek) + "\n"
            + "hız " + Cizim.Vektor(hiz) + "  kütle " + Cizim.Sayi(kutle);
    }

    void OnDrawGizmos()
    {
        // İstenen zıplama yüksekliği sarı çizgiyle gösterilir.
        float taban = Application.isPlaying ? zemin : transform.position.y;
        Vector3 orta = new Vector3(transform.position.x, taban + ziplamaYuksekligi, transform.position.z);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(orta - Vector3.right * 1.5f, orta + Vector3.right * 1.5f);
        Cizim.Yazi(orta + Vector3.up * 0.9f, Metin(), Color.white);
    }

    void OnGUI()
    {
        GUIStyle stil = new GUIStyle(GUI.skin.label);
        stil.fontSize = 22;
        GUI.Label(new Rect(20f, 20f, 900f, 70f), Metin(), stil);
    }
}
