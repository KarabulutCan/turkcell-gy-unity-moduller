using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Farenin sol tuşuyla Game penceresinde bir yere tıklandığında kameradan o noktaya doğru bir ışın gönderir.
/// Işın bir collider'a çarparsa nesnenin adı, uzaklığı ve çarpma noktası ekranda ve Console'da görünür.
/// Scene penceresinde ışın iki saniye boyunca kırmızı çizgi olarak görünür.
/// </summary>
public class IsinGonder : MonoBehaviour
{
    [SerializeField] Camera kamera;

    string sonVurulan = "henüz yok";
    float sonUzaklik;
    Vector3 sonNokta;
    bool vurdu;

    void Update()
    {
        var fare = Mouse.current;
        if (fare == null || !fare.leftButton.wasPressedThisFrame) return;

        // Ekrandaki fare konumundan sahneye doğru uzanan ışın.
        Ray isin = kamera.ScreenPointToRay(fare.position.ReadValue());

        // En fazla 100 birim uzaklığa kadar ilk çarpılan collider aranır.
        if (Physics.Raycast(isin, out RaycastHit vurus, 100f))
        {
            vurdu = true;
            sonVurulan = vurus.collider.name;
            sonUzaklik = vurus.distance;
            sonNokta = vurus.point;
            Debug.Log("Vuruldu " + vurus.collider.name + " uzaklik " + vurus.distance.ToString("F1"));
            Debug.DrawLine(isin.origin, vurus.point, Color.red, 2f);
        }
        else
        {
            vurdu = false;
            sonVurulan = "hiçbir şey";
        }
    }

    void OnGUI()
    {
        EkranArayuzu.Basla();
        EkranArayuzu.PanelBasla(20f, 20f, 500f);
        EkranArayuzu.Baslik("Işın gönderme (Raycast)");
        EkranArayuzu.Satir("Game penceresinde bir nesneye tıklayın.");
        EkranArayuzu.Satir("Son vurulan");
        EkranArayuzu.Vurgu(sonVurulan);
        if (vurdu) EkranArayuzu.Satir("Uzaklık " + sonUzaklik.ToString("0.0") + " birim");
        EkranArayuzu.Aciklama("Işın kameradan çıkar ve tıklanan noktadan geçer. Yalnızca collider'ı olan nesneler vurulabilir.");
        EkranArayuzu.PanelBitir();

        if (vurdu) EkranArayuzu.DunyaEtiketi(sonNokta + Vector3.up * 0.3f, "Işın buraya çarptı", "", 260f);
    }
}
