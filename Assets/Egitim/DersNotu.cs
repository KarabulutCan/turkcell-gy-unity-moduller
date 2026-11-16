using UnityEngine;

/// <summary>
/// Sahnenin ders notunu tutar.
/// Hierarchy penceresinde "_DERS NOTU" nesnesini seçtiğinizde not Inspector penceresinde okunur.
/// Oyunun çalışmasına hiçbir etkisi yoktur, yalnızca bilgi taşır.
/// </summary>
[DisallowMultipleComponent]
[AddComponentMenu("Egitim/Ders Notu")]
public class DersNotu : MonoBehaviour
{
    [Tooltip("Modül ve ders adı")]
    public string dersBasligi = "Ders";

    [Tooltip("Bu sahnede ne yapıldığının kısa özeti")]
    [TextArea(2, 8)]
    public string amac;

    [Tooltip("Sırayla izlenecek adımlar")]
    [TextArea(2, 8)]
    public string[] adimlar;

    [Tooltip("Dersten sonra denenebilecek küçük değişiklikler")]
    [TextArea(2, 8)]
    public string[] kendinDene;
}
