using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Nesneyi iki nokta arasında, seçilen yumuşatma eğrisiyle götürüp getirir.
/// Boslukla Tetikle kutusu işaretliyse hareket boşluk tuşuna basılınca başlar.
/// Konum Lerp ile, dönüş Slerp ile hesaplanır.
/// </summary>
public class EgriIleHareket : MonoBehaviour
{
    [SerializeField] Transform baslangic;
    [SerializeField] Transform bitis;
    [SerializeField] float sure = 2f;
    [SerializeField] EgriTuru egri = EgriTuru.Dogrusal;
    [SerializeField] AnimationCurve ozelEgri = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
    [SerializeField] bool bosluklaTetikle = false;

    float gecen;
    float bekleme;
    bool ileri = true;
    bool calisiyor;

    void Start()
    {
        calisiyor = !bosluklaTetikle;
    }

    void Update()
    {
        if (baslangic == null || bitis == null) return;

        if (bosluklaTetikle && !calisiyor)
        {
            // Hareket boşluk tuşuyla başlatılır.
            if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                calisiyor = true;
                gecen = 0f;
            }
            return;
        }

        // İki gidiş arasında kısa bir bekleme vardır.
        if (bekleme > 0f)
        {
            bekleme -= Time.deltaTime;
            return;
        }

        // Oran, geçen sürenin toplam süreye bölümüdür. Sıfır ile bir arasında tutulur.
        gecen += Time.deltaTime;
        float t = Mathf.Clamp01(gecen / sure);

        // Oran seçilen eğriden geçirilir.
        float egriT = Yumusatma.Uygula(egri, t, ozelEgri);

        Transform a = ileri ? baslangic : bitis;
        Transform b = ileri ? bitis : baslangic;

        // Konum ve dönüş için ara değer alınır.
        transform.position = Vector3.LerpUnclamped(a.position, b.position, egriT);
        transform.rotation = Quaternion.SlerpUnclamped(a.rotation, b.rotation, egriT);

        // Yol bittiğinde yön değiştirilir.
        if (t >= 1f)
        {
            ileri = !ileri;
            gecen = 0f;
            if (bosluklaTetikle) calisiyor = false;
            else bekleme = 0.6f;
        }
    }

    void OnDrawGizmos()
    {
        if (baslangic == null || bitis == null) return;

        Vector3 a = baslangic.position;
        Vector3 b = bitis.position;
        Cizim.KesikliCizgi(a, b, Color.gray);

        // Eğrinin grafiği yolun üzerine çizilir. Yatay eksen oran, dikey eksen eğrinin sonucudur.
        Vector3 taban = a + Vector3.up * 0.8f;
        Vector3 yatay = b - a;
        Gizmos.color = Color.yellow;
        Vector3 onceki = taban;
        for (int i = 1; i <= 32; i++)
        {
            float t = i / 32f;
            Vector3 nokta = taban + yatay * t + Vector3.up * Yumusatma.Uygula(egri, t, ozelEgri) * 1.5f;
            Gizmos.DrawLine(onceki, nokta);
            onceki = nokta;
        }
        Cizim.Yazi(taban + Vector3.up * 2f, Yumusatma.Ad(egri), Color.yellow);
    }
}
