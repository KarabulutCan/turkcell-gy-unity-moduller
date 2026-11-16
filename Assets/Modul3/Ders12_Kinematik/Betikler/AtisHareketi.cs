using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Verilen açı ve süratle mermi atar ve merminin izleyeceği yolu önceden çizer.
/// Sarı çizgi Euler entegrasyonuyla, gri çizgi formülle hesaplanan yoldur.
/// Adım değeri büyüdükçe iki çizgi birbirinden ayrılır.
/// Boşluk tuşu mermiyi atar.
/// </summary>
public class AtisHareketi : MonoBehaviour
{
    [SerializeField, Range(0f, 90f)] float aci = 45f;
    [SerializeField] float surat = 10f;
    [SerializeField] Vector3 yercekimi = new Vector3(0f, -9.81f, 0f);
    [SerializeField] float adim = 0.02f;

    // İlk hız vektörü. Açının kosinüsü ileri, sinüsü yukarı bileşeni verir.
    Vector3 IlkHiz()
    {
        float radyan = aci * Mathf.Deg2Rad;
        Vector3 yon = transform.forward * Mathf.Cos(radyan) + Vector3.up * Mathf.Sin(radyan);
        return yon * surat;
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame) Ates();
    }

    void Ates()
    {
        GameObject kure = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        kure.name = "Mermi";
        kure.transform.position = transform.position;
        kure.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        Mermi mermi = kure.AddComponent<Mermi>();
        mermi.hiz = IlkHiz();
        mermi.ivme = yercekimi;
        mermi.zeminY = transform.position.y;

        Destroy(kure, 10f);
    }

    void OnDrawGizmos()
    {
        Vector3 baslangic = transform.position;
        Vector3 ilkHiz = IlkHiz();
        float g = -yercekimi.y;

        Cizim.Ok(baslangic, baslangic + ilkHiz.normalized * 2f, Color.red);

        // Sarı çizgi. Merminin yaptığı hesabın aynısı, seçilen adımla art arda uygulanır.
        Vector3 konum = baslangic;
        Vector3 hiz = ilkHiz;
        float guvenliAdim = Mathf.Max(adim, 0.005f);
        Gizmos.color = Color.yellow;
        for (int i = 0; i < 2000; i++)
        {
            hiz += yercekimi * guvenliAdim;
            Vector3 yeni = konum + hiz * guvenliAdim;
            Gizmos.DrawLine(konum, yeni);
            konum = yeni;
            if (konum.y < baslangic.y) break;
        }

        if (g <= 0f) return;

        // Formülle hesaplanan uçuş süresi, menzil ve tepe yüksekliği.
        float dikeyHiz = ilkHiz.y;
        float yatayHiz = new Vector3(ilkHiz.x, 0f, ilkHiz.z).magnitude;
        float ucusSuresi = 2f * dikeyHiz / g;
        float menzil = yatayHiz * ucusSuresi;
        float tepe = dikeyHiz * dikeyHiz / (2f * g);

        // Gri çizgi. Konum her an için doğrudan formülden bulunur.
        Gizmos.color = Color.gray;
        Vector3 onceki = baslangic;
        for (int i = 1; i <= 60; i++)
        {
            float t = ucusSuresi * i / 60f;
            Vector3 nokta = baslangic + ilkHiz * t + 0.5f * yercekimi * t * t;
            Gizmos.DrawLine(onceki, nokta);
            onceki = nokta;
        }

        string metin = "açı " + Cizim.Sayi(aci) + "  sürat " + Cizim.Sayi(surat) + "\n"
            + "menzil " + Cizim.Sayi(menzil) + "  tepe " + Cizim.Sayi(tepe) + "  süre " + Cizim.Sayi(ucusSuresi);
        Cizim.Yazi(baslangic + Vector3.up * (tepe + 1.5f), metin, Color.white);
    }
}
