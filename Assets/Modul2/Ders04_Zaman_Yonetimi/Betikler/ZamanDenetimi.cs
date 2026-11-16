using UnityEngine;

/// <summary>
/// Kare hızını, zaman ölçeğini ve fizik adımını ekrandaki düğmelerle değiştirir.
/// Her küpün üstünde saniyede kaç derece döndüğü yazar. Böylece hangi küpün kare hızından etkilendiği sayıyla görülür.
/// </summary>
public class ZamanDenetimi : MonoBehaviour
{
    Transform kupSabit;
    Transform kupDelta;
    Rigidbody top;
    Vector3 topBaslangic;

    // Ölçümler yarım saniyede bir güncellenir, böylece sayılar okunabilir.
    float olcumSuresi;
    int olcumKare;
    float sabitAci;
    float deltaAci;
    float sonSabitY;
    float sonDeltaY;
    float fps;
    float sabitHiz;
    float deltaHiz;

    // Kendi kare hızı sınırımız. Editörde Application.targetFrameRate her zaman uygulanmadığı için kare süresi burada beklenerek ayarlanır.
    int sinir = 60;
    readonly System.Diagnostics.Stopwatch saat = System.Diagnostics.Stopwatch.StartNew();
    double sonKare;

    void Start()
    {
        // VSync kapalıyken hedef kare hızı geçerli olur. Başlangıçta 60 kare.
        QualitySettings.vSyncCount = 0;
        SinirAyarla(60);

        // Sahnedeki nesneler adlarıyla bulunur.
        GameObject a = GameObject.Find("KupSabit");
        GameObject b = GameObject.Find("KupDelta");
        GameObject t = GameObject.Find("Top");
        if (a != null) { kupSabit = a.transform; sonSabitY = kupSabit.eulerAngles.y; }
        if (b != null) { kupDelta = b.transform; sonDeltaY = kupDelta.eulerAngles.y; }
        if (t != null) { top = t.GetComponent<Rigidbody>(); topBaslangic = t.transform.position; }
    }

    void Update()
    {
        Olc();
    }

    void SinirAyarla(int deger)
    {
        sinir = deger;
        Application.targetFrameRate = deger;
    }

    // Kare bitmeden önce, hedef kare süresi dolana kadar beklenir. Böylece kare hızı sınırı editörde de kesin uygulanır.
    void LateUpdate()
    {
        if (sinir > 0)
        {
            double hedefSure = 1.0 / sinir;
            while (true)
            {
                double kalan = hedefSure - (saat.Elapsed.TotalSeconds - sonKare);
                if (kalan <= 0) break;
                if (kalan > 0.002) System.Threading.Thread.Sleep((int)((kalan - 0.001) * 1000));
            }
        }
        sonKare = saat.Elapsed.TotalSeconds;
    }

    // Her küpün gerçek zamanda saniyede kaç derece döndüğü ölçülür.
    void Olc()
    {
        if (kupSabit != null) { sabitAci += Mathf.Abs(Mathf.DeltaAngle(sonSabitY, kupSabit.eulerAngles.y)); sonSabitY = kupSabit.eulerAngles.y; }
        if (kupDelta != null) { deltaAci += Mathf.Abs(Mathf.DeltaAngle(sonDeltaY, kupDelta.eulerAngles.y)); sonDeltaY = kupDelta.eulerAngles.y; }

        olcumSuresi += Time.unscaledDeltaTime;
        olcumKare++;
        if (olcumSuresi < 0.5f) return;

        fps = olcumKare / olcumSuresi;
        sabitHiz = sabitAci / olcumSuresi;
        deltaHiz = deltaAci / olcumSuresi;
        olcumSuresi = 0f;
        olcumKare = 0;
        sabitAci = 0f;
        deltaAci = 0f;
    }

    void OnGUI()
    {
        // Arayüz 1080 satırlık ekrana göre çizilir ve Game penceresinin boyutuna göre ölçeklenir.
        float olcek = Screen.height / 1080f;
        GUI.matrix = Matrix4x4.Scale(new Vector3(olcek, olcek, 1f));

        GUIStyle baslik = new GUIStyle(GUI.skin.label) { fontSize = 28, fontStyle = FontStyle.Bold };
        GUIStyle yazi = new GUIStyle(GUI.skin.label) { fontSize = 22 };
        GUIStyle dugme = new GUIStyle(GUI.skin.button) { fontSize = 20 };
        baslik.normal.textColor = new Color(1f, 0.8f, 0.2f);
        yazi.normal.textColor = Color.white;

        // Sol panel. Ölçülen değerler ve düğmeler.
        GUI.Box(new Rect(10f, 10f, 430f, 830f), "");
        float y = 20f;
        GUI.Label(new Rect(25f, y, 410f, 40f), "Zaman Denetimi", baslik); y += 46f;
        GUI.Label(new Rect(25f, y, 410f, 30f), "FPS " + Mathf.RoundToInt(fps), yazi); y += 30f;
        GUI.Label(new Rect(25f, y, 410f, 30f), "Time.deltaTime " + Time.deltaTime.ToString("0.0000"), yazi); y += 30f;
        GUI.Label(new Rect(25f, y, 410f, 30f), "Time.timeScale " + Time.timeScale.ToString("0.##"), yazi); y += 30f;
        GUI.Label(new Rect(25f, y, 410f, 30f), "Fizik adımı " + Time.fixedDeltaTime.ToString("0.###") + " saniye", yazi); y += 44f;

        GUI.Label(new Rect(25f, y, 410f, 30f), "Kare hızı sınırı", baslik); y += 40f;
        if (GUI.Button(new Rect(25f, y, 92f, 44f), "15", dugme)) SinirAyarla(15);
        if (GUI.Button(new Rect(122f, y, 92f, 44f), "30", dugme)) SinirAyarla(30);
        if (GUI.Button(new Rect(219f, y, 92f, 44f), "60", dugme)) SinirAyarla(60);
        if (GUI.Button(new Rect(316f, y, 110f, 44f), "Sınırsız", dugme)) SinirAyarla(-1);
        y += 54f;

        // Sürgü ile hedef kare hızı 1 ile 240 arasında istenen değere ayarlanır.
        int hedef = sinir > 0 ? sinir : 240;
        GUI.Label(new Rect(25f, y, 410f, 30f), "Hedef " + (sinir > 0 ? hedef.ToString() : "sınırsız"), yazi); y += 32f;
        int yeni = Mathf.RoundToInt(GUI.HorizontalSlider(new Rect(25f, y, 401f, 30f), hedef, 1f, 240f));
        if (yeni != hedef) SinirAyarla(yeni);
        y += 36f;

        GUI.Label(new Rect(25f, y, 410f, 30f), "Zaman ölçeği", baslik); y += 40f;
        if (GUI.Button(new Rect(25f, y, 125f, 44f), "Normal 1", dugme)) Time.timeScale = 1f;
        if (GUI.Button(new Rect(155f, y, 140f, 44f), "Ağır 0,25", dugme)) Time.timeScale = 0.25f;
        if (GUI.Button(new Rect(300f, y, 126f, 44f), "Durdur 0", dugme)) Time.timeScale = 0f;
        y += 62f;

        GUI.Label(new Rect(25f, y, 410f, 30f), "Fizik", baslik); y += 40f;
        if (top != null)
        {
            if (GUI.Button(new Rect(25f, y, 195f, 44f), "Topu bırak", dugme)) top.isKinematic = false;
            if (GUI.Button(new Rect(231f, y, 195f, 44f), "Topu başa al", dugme))
            {
                top.isKinematic = true;
                top.position = topBaslangic;
                top.transform.position = topBaslangic;
            }
            y += 52f;
            if (GUI.Button(new Rect(25f, y, 195f, 44f), "Adım 0,02", dugme)) Time.fixedDeltaTime = 0.02f;
            if (GUI.Button(new Rect(231f, y, 195f, 44f), "Adım 0,1", dugme)) Time.fixedDeltaTime = 0.1f;
            y += 52f;
            bool acik = top.interpolation == RigidbodyInterpolation.Interpolate;
            if (GUI.Button(new Rect(25f, y, 401f, 44f), acik ? "Interpolate açık. Kapat" : "Interpolate kapalı. Aç", dugme))
                top.interpolation = acik ? RigidbodyInterpolation.None : RigidbodyInterpolation.Interpolate;
        }

        // Küplerin üstündeki etiketler.
        Etiket(kupSabit, "Her karede 1,5 derece", "Kare hızına bağlı", sabitHiz, olcek, -1f);
        Etiket(kupDelta, "90 x Time.deltaTime", "Kare hızından bağımsız", deltaHiz, olcek, 1f);
    }

    // Küpün ekrandaki yerinin üstüne bir bilgi kutusu çizer.
    void Etiket(Transform kup, string satir1, string satir2, float hiz, float olcek, float yon)
    {
        if (kup == null) return;
        Camera kamera = Camera.main;
        if (kamera == null) return;

        Vector3 ekran = kamera.WorldToScreenPoint(kup.position + Vector3.up * 1.2f);
        if (ekran.z < 0f) return;

        // Ekran koordinatı arayüz koordinatına çevrilir. Arayüzde Y aşağı doğru artar.
        float x = ekran.x / olcek;
        float y = (Screen.height - ekran.y) / olcek;
        // Kutular küpün üstünde, iki küp yakın olsa da çakışmasın diye dışa doğru kaydırılır.
        Rect kutu = new Rect(x - 150f + yon * 90f, y - 140f, 300f, 130f);
        GUI.Box(kutu, "");

        GUIStyle s1 = new GUIStyle(GUI.skin.label) { fontSize = 22, alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Bold };
        GUIStyle s2 = new GUIStyle(GUI.skin.label) { fontSize = 20, alignment = TextAnchor.MiddleCenter };
        GUIStyle s3 = new GUIStyle(GUI.skin.label) { fontSize = 30, alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Bold };
        s1.normal.textColor = Color.white;
        s2.normal.textColor = new Color(0.85f, 0.85f, 0.85f);
        s3.normal.textColor = new Color(1f, 0.8f, 0.2f);

        GUI.Label(new Rect(kutu.x, kutu.y + 6f, kutu.width, 30f), satir1, s1);
        GUI.Label(new Rect(kutu.x, kutu.y + 36f, kutu.width, 28f), satir2, s2);
        GUI.Label(new Rect(kutu.x, kutu.y + 70f, kutu.width, 50f), Mathf.RoundToInt(hiz) + " derece/sn", s3);
    }
}
