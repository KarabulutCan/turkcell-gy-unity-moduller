using UnityEngine;

/// <summary>
/// Oyun başladığında verilen Prefab'dan rastgele konumlara çok sayıda kopya üretir.
/// Performans ölçümü için sahneyi bilerek kalabalık hale getirir.
/// Ekranda kare hızı, kare süresi ve küp sayısı yazar. Düğmelerle bütün küplerde yavaş ve hızlı yol arasında geçilir.
/// </summary>
public class KupUretici : MonoBehaviour
{
    [SerializeField] GameObject kupPrefab;
    [SerializeField] int adet = 1000;

    KupDavranisi[] kupler = new KupDavranisi[0];
    float olcumSuresi;
    int olcumKare;
    float fps;

    void Start()
    {
        for (int i = 0; i < adet; i++)
        {
            Vector3 konum = new Vector3(Random.Range(-30f, 30f), 1f, Random.Range(-30f, 30f));
            Instantiate(kupPrefab, konum, Quaternion.identity);
        }
        kupler = FindObjectsByType<KupDavranisi>(FindObjectsSortMode.None);
    }

    void Update()
    {
        // Kare hızı yarım saniyede bir ölçülür.
        olcumSuresi += Time.unscaledDeltaTime;
        olcumKare++;
        if (olcumSuresi < 0.5f) return;
        fps = olcumKare / olcumSuresi;
        olcumSuresi = 0f;
        olcumKare = 0;
    }

    void OnGUI()
    {
        EkranArayuzu.Basla();
        bool hizli = kupler.Length > 0 && kupler[0].HizliYol;

        EkranArayuzu.PanelBasla(20f, 20f, 540f);
        EkranArayuzu.Baslik("Performans ölçümü");
        EkranArayuzu.Vurgu("FPS " + Mathf.RoundToInt(fps) + "   kare " + (fps > 0f ? (1000f / fps).ToString("0.0") : "0") + " ms");
        EkranArayuzu.Satir("Sahnedeki küp sayısı " + kupler.Length);
        EkranArayuzu.Satir("Şu anki yol " + (hizli ? "HIZLI" : "YAVAŞ"));
        if (!hizli) EkranArayuzu.Satir("Her karede " + kupler.Length + " kez FindWithTag ile bütün sahne taranıyor.");

        EkranArayuzu.YatayBasla();
        if (EkranArayuzu.Dugme("Yavaş yol")) foreach (KupDavranisi k in kupler) k.HizliYolAyarla(false);
        if (EkranArayuzu.Dugme("Hızlı yol")) foreach (KupDavranisi k in kupler) k.HizliYolAyarla(true);
        EkranArayuzu.YatayBitir();

        EkranArayuzu.Aciklama("Hızlı yolda oyuncu bir kez bulunur ve saklanır. Window menüsünden Analysis, Profiler açılarak farkın nereden geldiği görülür.");
        EkranArayuzu.PanelBitir();
    }
}
