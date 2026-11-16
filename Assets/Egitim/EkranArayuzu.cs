using UnityEngine;

/// <summary>
/// Derslerdeki ekran panelleri için ortak çizim yardımcısı.
/// Bütün paneller 1080 satırlık ekrana göre çizilir ve Game penceresinin boyutuna göre ölçeklenir.
/// Yalnızca OnGUI içinden çağrılır.
/// </summary>
public static class EkranArayuzu
{
    public static float Olcek { get; private set; } = 1f;

    static Texture2D koyu;
    static readonly Color sari = new Color(1f, 0.8f, 0.2f);

    // Her OnGUI çağrısının başında bir kez çağrılır.
    public static void Basla()
    {
        Olcek = Screen.height / 1080f;
        GUI.matrix = Matrix4x4.Scale(new Vector3(Olcek, Olcek, 1f));
    }

    static GUIStyle KutuStili()
    {
        if (koyu == null)
        {
            koyu = new Texture2D(1, 1);
            koyu.SetPixel(0, 0, new Color(0.05f, 0.05f, 0.12f, 0.82f));
            koyu.Apply();
        }
        GUIStyle s = new GUIStyle(GUI.skin.box) { padding = new RectOffset(16, 16, 12, 14) };
        s.normal.background = koyu;
        return s;
    }

    // Verilen noktadan başlayan ve içeriğine göre uzayan bir panel açar.
    public static void PanelBasla(float x, float y, float genislik)
    {
        GUILayout.BeginArea(new Rect(x, y, genislik, 1060f));
        GUILayout.BeginVertical(KutuStili());
    }

    public static void PanelBitir()
    {
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

    public static void Baslik(string metin)
    {
        GUIStyle s = new GUIStyle(GUI.skin.label) { fontSize = 28, fontStyle = FontStyle.Bold, wordWrap = true };
        s.normal.textColor = sari;
        GUILayout.Label(metin, s);
    }

    public static void Satir(string metin)
    {
        GUIStyle s = new GUIStyle(GUI.skin.label) { fontSize = 22, wordWrap = true };
        s.normal.textColor = Color.white;
        GUILayout.Label(metin, s);
    }

    public static void Vurgu(string metin)
    {
        GUIStyle s = new GUIStyle(GUI.skin.label) { fontSize = 32, fontStyle = FontStyle.Bold, wordWrap = true };
        s.normal.textColor = sari;
        GUILayout.Label(metin, s);
    }

    public static void Aciklama(string metin)
    {
        GUIStyle s = new GUIStyle(GUI.skin.label) { fontSize = 19, wordWrap = true, fontStyle = FontStyle.Italic };
        s.normal.textColor = new Color(0.8f, 0.82f, 0.9f);
        GUILayout.Label(metin, s);
    }

    public static void Bosluk(float piksel = 10f)
    {
        GUILayout.Space(piksel);
    }

    public static bool Dugme(string metin)
    {
        GUIStyle s = new GUIStyle(GUI.skin.button) { fontSize = 21, fixedHeight = 44f };
        return GUILayout.Button(metin, s);
    }

    public static void YatayBasla() { GUILayout.BeginHorizontal(); }
    public static void YatayBitir() { GUILayout.EndHorizontal(); }

    // Bir dünya noktasının üstüne, ekranda ortalanmış bir bilgi kutusu çizer.
    public static void DunyaEtiketi(Vector3 dunyaKonumu, string ust, string alt, float genislik = 340f)
    {
        Camera kamera = Camera.main;
        if (kamera == null) return;
        Vector3 ekran = kamera.WorldToScreenPoint(dunyaKonumu);
        if (ekran.z < 0f) return;

        // Ekran koordinatı arayüz koordinatına çevrilir. Arayüzde Y aşağı doğru artar.
        float x = ekran.x / Olcek;
        float y = (Screen.height - ekran.y) / Olcek;
        float yukseklik = string.IsNullOrEmpty(alt) ? 50f : 92f;
        Rect kutu = new Rect(x - genislik / 2f, y - yukseklik - 6f, genislik, yukseklik);
        GUI.Box(kutu, "", KutuStili());

        GUIStyle s1 = new GUIStyle(GUI.skin.label) { fontSize = 21, alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Bold };
        s1.normal.textColor = Color.white;
        GUI.Label(new Rect(kutu.x, kutu.y + 6f, genislik, 36f), ust, s1);
        if (string.IsNullOrEmpty(alt)) return;
        GUIStyle s2 = new GUIStyle(GUI.skin.label) { fontSize = 26, alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Bold };
        s2.normal.textColor = sari;
        GUI.Label(new Rect(kutu.x, kutu.y + 42f, genislik, 44f), alt, s2);
    }
}
