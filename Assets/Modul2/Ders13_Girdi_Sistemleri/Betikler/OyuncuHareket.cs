using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Oyuncuyu Input Actions varlığında tanımlanan Hareket ve Zipla eylemleriyle yönetir.
/// PlayerInput bileşeni Send Messages modundayken her eylem için On ile başlayan fonksiyonu çağırır.
/// Betik hangi tuşa ya da hangi cihaza basıldığını bilmez, yalnızca eylemin değerini okur.
/// Eylemlerin anlık değerleri ve kullanılan cihaz ekranda yazar.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class OyuncuHareket : MonoBehaviour
{
    [SerializeField] float hiz = 5f;
    [SerializeField] float ziplamaItkisi = 6f;
    Rigidbody govde;
    Vector2 hareketGirdisi;
    bool ziplaIstegi;
    float sonZiplama = -10f;
    PlayerInput oyuncuGirdisi;

    void Awake()
    {
        govde = GetComponent<Rigidbody>();
        oyuncuGirdisi = GetComponent<PlayerInput>();
    }

    // Hareket eylemi değer değiştirdiğinde PlayerInput tarafından çağrılır.
    public void OnHareket(InputValue deger) { hareketGirdisi = deger.Get<Vector2>(); }

    // Zipla eylemi tetiklendiğinde PlayerInput tarafından çağrılır.
    public void OnZipla(InputValue deger)
    {
        if (!deger.isPressed) return;
        ziplaIstegi = true;
        sonZiplama = Time.time;
    }

    // Fizik nesnesi sabit zaman adımında hareket ettirilir.
    void FixedUpdate()
    {
        Vector3 yatay = new Vector3(hareketGirdisi.x, 0f, hareketGirdisi.y) * hiz;

        // Düşey hız korunur, böylece yer çekimi ve zıplama bozulmaz.
        govde.linearVelocity = new Vector3(yatay.x, govde.linearVelocity.y, yatay.z);

        if (ziplaIstegi)
        {
            ziplaIstegi = false;
            govde.AddForce(Vector3.up * ziplamaItkisi, ForceMode.Impulse);
        }
    }

    void OnGUI()
    {
        EkranArayuzu.Basla();
        EkranArayuzu.PanelBasla(20f, 20f, 540f);
        EkranArayuzu.Baslik("Input Actions");
        EkranArayuzu.Satir("Game penceresine tıklayın. Klavyede W A S D ve Boşluk, oyun kolunda sol çubuk ve alt düğme.");

        string cihaz = oyuncuGirdisi != null && !string.IsNullOrEmpty(oyuncuGirdisi.currentControlScheme) ? oyuncuGirdisi.currentControlScheme : "henüz yok";
        EkranArayuzu.Satir("Kullanılan cihaz şeması");
        EkranArayuzu.Vurgu(cihaz);

        EkranArayuzu.Satir("Hareket eylemi değeri");
        EkranArayuzu.Vurgu("(" + hareketGirdisi.x.ToString("0.00") + "   " + hareketGirdisi.y.ToString("0.00") + ")");

        // Zıplama yazısı basıştan sonra yarım saniye görünür.
        bool yeniZipladi = Time.time - sonZiplama < 0.5f;
        EkranArayuzu.Satir("Zipla eylemi " + (yeniZipladi ? "TETİKLENDİ" : "bekliyor"));

        EkranArayuzu.Aciklama("Betik tuşları tanımaz. Yalnızca Hareket ve Zipla eylemlerinin değerini okur. Tuş ya da cihaz değişse de betik aynı kalır.");
        EkranArayuzu.PanelBitir();
    }
}
