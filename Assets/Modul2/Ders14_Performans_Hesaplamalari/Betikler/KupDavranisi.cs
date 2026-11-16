using UnityEngine;

/// <summary>
/// Küpü her karede oyuncuya doğru çevirir.
/// Hızlı yol kapalıyken bilerek yavaş çalışır. Her karede oyuncuyu sahnede yeniden arar ve bir metin birleştirir.
/// Hızlı yol açıkken oyuncuyu yalnızca bir kez bulur ve saklar.
/// Profiler ile darboğaz bulma alıştırması için yazılmıştır.
/// </summary>
public class KupDavranisi : MonoBehaviour
{
    [SerializeField] bool hizliYol = false;
    Transform oyuncu;

    void Awake()
    {
        // Hızlı yolda arama bir kez yapılır ve sonuç saklanır.
        if (hizliYol) oyuncu = GameObject.FindWithTag("Player").transform;
    }

    public bool HizliYol { get { return hizliYol; } }

    // Ekrandaki düğme bütün küplerde yolu bu fonksiyonla değiştirir.
    public void HizliYolAyarla(bool acik)
    {
        hizliYol = acik;
        if (hizliYol && oyuncu == null) oyuncu = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        // Yavaş yolda her küp her karede bütün sahneyi tarar.
        Transform hedef = hizliYol ? oyuncu : GameObject.FindWithTag("Player").transform;
        transform.LookAt(hedef);

        // Metin birleştirme her karede bellekte yeni bir nesne oluşturur ve çöp toplayıcıya iş çıkarır.
        string mesaj = "Kup " + name + " bakiyor";
        if (!hizliYol && mesaj.Length == 0) Debug.Log(mesaj);
    }
}
