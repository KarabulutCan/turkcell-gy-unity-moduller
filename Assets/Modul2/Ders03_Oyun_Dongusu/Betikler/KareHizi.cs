using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Küpü döndürür ve üç tuşla kare hızı ayarını değiştirir.
/// 1 tuşu VSync kapalı ve sınırsız kare hızı
/// 2 tuşu VSync açık
/// 3 tuşu VSync kapalı ve hedef 30 kare
/// Ölçülen kare hızı ve geçerli ayar Game penceresinin sol üst köşesinde görünür.
/// Tuşların algılanması için önce Game penceresine tıklanmalıdır.
/// </summary>
public class KareHizi : MonoBehaviour
{
    // Ekranda gösterilen kare hızı. Okunabilsin diye yarım saniyede bir güncellenir.
    float gosterilenFps;
    float toplamSure;
    int kareSayisi;

    void Update()
    {
        // Klavye bağlı değilse hiçbir şey yapma.
        var k = Keyboard.current;
        if (k != null)
        {
            // 1 tuşu. VSync kapanır, hedef kare hızı kaldırılır. Döngü olabildiğince hızlı döner.
            if (k.digit1Key.wasPressedThisFrame) { QualitySettings.vSyncCount = 0; Application.targetFrameRate = -1; }

            // 2 tuşu. VSync açılır. Kare hızı ekranın yenileme hızına kilitlenir.
            if (k.digit2Key.wasPressedThisFrame) { QualitySettings.vSyncCount = 1; }

            // 3 tuşu. VSync kapalı, hedef saniyede 30 kare.
            if (k.digit3Key.wasPressedThisFrame) { QualitySettings.vSyncCount = 0; Application.targetFrameRate = 120; }
        }

        // Saniyede 90 derece dönüş. Time.deltaTime ile çarpıldığı için kare hızı değişse de dönüş hızı aynı kalır.
        transform.Rotate(0f, 90f * Time.deltaTime, 0f);

        // Kare hızı ölçümü. Geçen süre ve kare sayısı biriktirilir, yarım saniyede bir ortalama alınır.
        toplamSure += Time.unscaledDeltaTime;
        kareSayisi++;
        if (toplamSure >= 0.5f)
        {
            gosterilenFps = kareSayisi / toplamSure;
            toplamSure = 0f;
            kareSayisi = 0;
        }
    }

    void OnGUI()
    {
        // Geçerli ayar metne çevrilir.
        string ayar;
        if (QualitySettings.vSyncCount > 0) ayar = "VSync açık";
        else if (Application.targetFrameRate > 0) ayar = "VSync kapalı, hedef " + Application.targetFrameRate;
        else ayar = "VSync kapalı, sınırsız";

        // Yazının okunması için koyu bir kutu çizilir.
        GUI.Box(new Rect(10f, 10f, 520f, 110f), "");

        GUIStyle stil = new GUIStyle(GUI.skin.label);
        stil.fontSize = 34;
        stil.normal.textColor = Color.white;
        GUI.Label(new Rect(24f, 14f, 500f, 50f), "FPS " + Mathf.RoundToInt(gosterilenFps), stil);

        stil.fontSize = 24;
        GUI.Label(new Rect(24f, 62f, 500f, 40f), ayar + "    tuşlar 1  2  3", stil);
    }
}
