using UnityEngine;

/// <summary>
/// Ekrandaki düğmeye tıklandığında topa yukarı doğru ani bir itki verir.
/// Top bir şeye çarptığında çarptığı nesnenin adı ve çarpışma hızı ekranda ve Console'da görünür.
/// RequireComponent, bu bileşen eklendiğinde Rigidbody yoksa onu da ekler.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Sekme : MonoBehaviour
{
    [SerializeField] float itki = 8f;

    Rigidbody govde;
    bool ziplaIstegi;
    string sonCarpma = "henüz yok";

    void Awake() { govde = GetComponent<Rigidbody>(); }

    // Kuvvet FixedUpdate içinde uygulanır, çünkü fizik sabit zaman adımıyla çalışır.
    void FixedUpdate()
    {
        if (!ziplaIstegi) return;
        ziplaIstegi = false;
        govde.AddForce(Vector3.up * itki, ForceMode.Impulse);
    }

    // İki collider birbirine çarptığında fizik motoru bu fonksiyonu çağırır.
    void OnCollisionEnter(Collision c)
    {
        sonCarpma = c.gameObject.name + ", hız " + c.relativeVelocity.magnitude.ToString("0.0");
        Debug.Log("Carpti " + c.gameObject.name + " hiz " + c.relativeVelocity.magnitude.ToString("F1"));
    }

    void OnGUI()
    {
        EkranArayuzu.Basla();
        EkranArayuzu.PanelBasla(20f, 400f, 500f);
        EkranArayuzu.Baslik("Rigidbody ve çarpışma");

        // Düğme yalnızca isteği kaydeder. Kuvvet bir sonraki fizik adımında uygulanır.
        if (EkranArayuzu.Dugme("Topa yukarı itki ver")) ziplaIstegi = true;

        EkranArayuzu.Satir("Topun hızı " + govde.linearVelocity.magnitude.ToString("0.0") + " birim/sn");
        EkranArayuzu.Satir("Son çarpışma");
        EkranArayuzu.Vurgu(sonCarpma);
        EkranArayuzu.Aciklama("Physic Material'in Bounciness değeri topun ne kadar sekeceğini belirler.");
        EkranArayuzu.PanelBitir();

        EkranArayuzu.DunyaEtiketi(transform.position + Vector3.up * 0.9f, "Top", govde.linearVelocity.magnitude.ToString("0.0") + " birim/sn", 220f);
    }
}
