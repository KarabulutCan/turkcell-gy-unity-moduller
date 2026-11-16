using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Fareyle tıklanan nesneyi ışın göndererek seçer.
/// Işın kameradan çıkar ve tıklanan ekran noktasından geçer.
/// Işının çarptığı ilk nesne sarıya boyanır.
/// </summary>
public class TiklaSec : MonoBehaviour
{
    [SerializeField] float menzil = 100f;

    Camera kamera;
    Renderer secili;
    MaterialPropertyBlock blok;
    Vector3 isinBaslangici;
    Vector3 carpmaNoktasi;
    Vector3 carpmaNormali;
    float carpmaUzakligi;
    bool carpti;

    void Start()
    {
        kamera = GetComponent<Camera>();
        blok = new MaterialPropertyBlock();
    }

    void Update()
    {
        if (Mouse.current == null || !Mouse.current.leftButton.wasPressedThisFrame) return;

        // Ekrandaki fare konumundan sahneye doğru bir ışın üretilir.
        Vector2 fare = Mouse.current.position.ReadValue();
        Ray isin = kamera.ScreenPointToRay(fare);
        isinBaslangici = isin.origin;

        // Önceki seçimin rengi geri alınır.
        if (secili != null) secili.SetPropertyBlock(null);
        secili = null;

        // Işın bir çarpıştırıcıya çarparsa bilgileri carpma değişkenine yazılır.
        carpti = Physics.Raycast(isin, out RaycastHit carpma, menzil);
        if (!carpti)
        {
            carpmaNoktasi = isin.origin + isin.direction * menzil;
            return;
        }

        carpmaNoktasi = carpma.point;
        carpmaNormali = carpma.normal;
        carpmaUzakligi = carpma.distance;

        // Çarpılan nesne sarıya boyanır.
        secili = carpma.collider.GetComponent<Renderer>();
        if (secili != null)
        {
            blok.SetColor("_BaseColor", Color.yellow);
            secili.SetPropertyBlock(blok);
        }
    }

    string Metin()
    {
        if (!carpti || secili == null) return "seçili nesne yok";
        return "seçili nesne " + secili.name + "  uzaklık " + Cizim.Sayi(carpmaUzakligi) + "\n" + "çarpma noktası " + Cizim.Vektor(carpmaNoktasi);
    }

    void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;

        // Son gönderilen ışın ve çarptığı yüzeyin normali.
        Gizmos.color = carpti ? Color.yellow : Color.gray;
        Gizmos.DrawLine(isinBaslangici, carpmaNoktasi);
        if (!carpti) return;
        Gizmos.DrawWireSphere(carpmaNoktasi, 0.1f);
        Cizim.Ok(carpmaNoktasi, carpmaNoktasi + carpmaNormali, Color.green);
    }

    void OnGUI()
    {
        GUIStyle stil = new GUIStyle(GUI.skin.label);
        stil.fontSize = 22;
        GUI.Label(new Rect(20f, 20f, 900f, 70f), Metin(), stil);
    }
}
