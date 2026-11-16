using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Ekrandaki düğmeyle kısa bir efekt sesini rastgele perde ve ses düzeyiyle çalar.
/// İkinci düğme Audio Mixer üzerindeki Normal ve Duraklat anlık görüntüleri arasında geçiş yapar.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class EfektCal : MonoBehaviour
{
    [SerializeField] AudioClip tik;
    [SerializeField] AudioMixerSnapshot normal;
    [SerializeField] AudioMixerSnapshot duraklat;

    AudioSource kaynak;
    bool duraklatildi;
    float sonPerde = 1f;
    float sonDuzey = 1f;

    void Awake() { kaynak = GetComponent<AudioSource>(); }

    void EfektiCal()
    {
        // Perde her seferinde biraz değişir, böylece aynı ses tekrar tekrar çalınınca kulağı yormaz.
        sonPerde = Random.Range(0.9f, 1.1f);
        sonDuzey = Random.Range(0.8f, 1f);
        kaynak.pitch = sonPerde;

        // PlayOneShot, çalmakta olan sesi kesmeden üstüne yeni bir ses ekler.
        kaynak.PlayOneShot(tik, sonDuzey);
    }

    void AnlikGoruntuDegistir()
    {
        // Yarım saniyede diğer anlık görüntüye geçilir.
        duraklatildi = !duraklatildi;
        (duraklatildi ? duraklat : normal).TransitionTo(0.5f);
    }

    void OnGUI()
    {
        EkranArayuzu.Basla();
        EkranArayuzu.PanelBasla(20f, 20f, 520f);
        EkranArayuzu.Baslik("Ses efekti ve Audio Mixer");

        if (EkranArayuzu.Dugme("Efekt çal")) EfektiCal();
        EkranArayuzu.Satir("Son perde " + sonPerde.ToString("0.00") + "   ses düzeyi " + sonDuzey.ToString("0.00"));
        EkranArayuzu.Bosluk();

        if (EkranArayuzu.Dugme(duraklatildi ? "Duraklat görüntüsünden çık" : "Duraklat görüntüsüne geç")) AnlikGoruntuDegistir();
        EkranArayuzu.Vurgu("Mixer " + (duraklatildi ? "Duraklat" : "Normal"));
        EkranArayuzu.Aciklama("Duraklat anlık görüntüsünde müzik kısılır ve Lowpass süzgeci sesi boğuklaştırır. Geçiş yarım saniye sürer.");
        EkranArayuzu.PanelBitir();
    }
}
