using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Oyuncuyu W, A, S ve D tuşlarıyla zemin üzerinde hareket ettirir.
/// Kamera oyuncunun çocuğu olduğu için kamera ve üzerindeki Audio Listener da onunla birlikte taşınır.
/// Ekranda Radyo nesnesine olan uzaklık yazar. Uzaklık arttıkça radyonun sesi azalır.
/// Bu betik derste yazılmaz, sahnede hazır gelir.
/// </summary>
public class KlavyeHareket : MonoBehaviour
{
    [SerializeField] float hiz = 4f;

    Transform radyo;

    void Start()
    {
        GameObject r = GameObject.Find("Radyo");
        if (r != null) radyo = r.transform;
    }

    void Update()
    {
        var k = Keyboard.current;
        if (k == null) return;

        float x = 0f;
        float z = 0f;
        if (k.aKey.isPressed) x -= 1f;
        if (k.dKey.isPressed) x += 1f;
        if (k.sKey.isPressed) z -= 1f;
        if (k.wKey.isPressed) z += 1f;

        // Çapraz gidişte hız artmasın diye yön vektörü normalize edilir.
        Vector3 yon = new Vector3(x, 0f, z).normalized;
        transform.Translate(yon * hiz * Time.deltaTime, Space.World);
    }

    void OnGUI()
    {
        EkranArayuzu.Basla();
        EkranArayuzu.PanelBasla(20f, 620f, 520f);
        EkranArayuzu.Baslik("Kulak oyuncunun üzerinde");
        EkranArayuzu.Satir("Game penceresine tıklayın, W A S D ile yürüyün.");
        if (radyo != null)
        {
            float uzaklik = Vector3.Distance(transform.position, radyo.position);
            EkranArayuzu.Vurgu("Radyoya uzaklık " + uzaklik.ToString("0.0") + " m");
            EkranArayuzu.DunyaEtiketi(radyo.position + Vector3.up * 1f, "Radyo", uzaklik.ToString("0.0") + " m", 200f);
        }
        EkranArayuzu.Aciklama("Audio Listener kameradadır ve kamera oyuncuyla birlikte taşınır. Radyodan uzaklaştıkça ses azalır, sağa ya da sola geçince ses o kulağa kayar.");
        EkranArayuzu.PanelBitir();
    }
}
