using UnityEngine;

/// <summary>
/// Derslerde vektörleri ve noktaları görünür kılmak için ortak çizim yardımcıları.
/// Fonksiyonlar OnDrawGizmos içinden çağrılır. Çizimler Scene penceresinde görünür.
/// Game penceresinde görmek için pencerenin üstündeki Gizmos düğmesi açılır.
/// </summary>
public static class Cizim
{
    // Baştan uca doğru ok çizer. Ok başı iki kısa çizgiden oluşur.
    public static void Ok(Vector3 bas, Vector3 uc, Color renk)
    {
        Gizmos.color = renk;
        Gizmos.DrawLine(bas, uc);

        Vector3 yon = uc - bas;
        float boy = yon.magnitude;
        if (boy < 0.0001f) return;

        // Ok başının boyu okun boyuna göre ayarlanır ama çok büyümez.
        float basBoyu = Mathf.Min(0.35f, boy * 0.3f);
        Vector3 geri = -yon / boy * basBoyu;

        // Ok başının açılacağı yan yön. Ok dikeyse başka bir eksen seçilir.
        Vector3 yan = Vector3.Cross(yon, Vector3.up);
        if (yan.sqrMagnitude < 0.0001f) yan = Vector3.Cross(yon, Vector3.right);
        yan = yan.normalized * basBoyu * 0.5f;

        Gizmos.DrawLine(uc, uc + geri + yan);
        Gizmos.DrawLine(uc, uc + geri - yan);
    }

    // İki nokta arasına kesikli çizgi çizer.
    public static void KesikliCizgi(Vector3 bas, Vector3 uc, Color renk, float parca = 0.2f)
    {
        Gizmos.color = renk;
        Vector3 fark = uc - bas;
        float boy = fark.magnitude;
        if (boy < 0.0001f) return;
        Vector3 yon = fark / boy;
        for (float d = 0f; d < boy; d += parca * 2f)
        {
            Gizmos.DrawLine(bas + yon * d, bas + yon * Mathf.Min(d + parca, boy));
        }
    }

    // Verilen dünya konumuna yazı yazar. Yalnızca editörde çalışır.
    public static void Yazi(Vector3 konum, string metin, Color renk)
    {
#if UNITY_EDITOR
        GUIStyle stil = new GUIStyle();
        stil.normal.textColor = renk;
        stil.fontSize = 14;
        stil.fontStyle = FontStyle.Bold;
        UnityEditor.Handles.Label(konum, metin, stil);
#endif
    }

    // Sayıyı iki ondalık basamakla yazar.
    public static string Sayi(float deger)
    {
        // Sıfıra çok yakın değerler sıfır olarak yazılır.
        if (Mathf.Abs(deger) < 0.005f) deger = 0f;
        return deger.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture);
    }

    // Vektörü parantez içinde iki ondalık basamakla yazar.
    public static string Vektor(Vector3 v)
    {
        return "(" + Sayi(v.x) + ", " + Sayi(v.y) + ", " + Sayi(v.z) + ")";
    }
}
