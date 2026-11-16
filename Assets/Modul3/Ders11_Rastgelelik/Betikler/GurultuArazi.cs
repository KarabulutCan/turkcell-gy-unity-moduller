using UnityEngine;

/// <summary>
/// Küplerden oluşan bir araziyi gürültüyle üretir.
/// Her küpün yüksekliği Perlin gürültüsünden okunur. Perlin Kullan kapatılırsa yükseklikler bağımsız rastgele sayılardan gelir.
/// Değerler Play modunda değiştirildiğinde arazi yeniden hesaplanır.
/// </summary>
public class GurultuArazi : MonoBehaviour
{
    [SerializeField] int boyut = 30;
    [SerializeField] float olcek = 0.12f;
    [SerializeField] float yukseklik = 6f;
    [SerializeField] int tohum = 0;
    [SerializeField] bool perlinKullan = true;
    [SerializeField, Range(0f, 1f)] float suSeviyesi = 0.35f;

    Transform[,] kupler;
    MaterialPropertyBlock blok;
    bool yenile;

    void Start()
    {
        blok = new MaterialPropertyBlock();
        kupler = new Transform[boyut, boyut];

        // Küpler bir kez oluşturulur. Sonraki değişikliklerde yalnızca boyları ve renkleri güncellenir.
        for (int x = 0; x < boyut; x++)
        {
            for (int z = 0; z < boyut; z++)
            {
                GameObject kup = GameObject.CreatePrimitive(PrimitiveType.Cube);
                kup.transform.SetParent(transform);
                kupler[x, z] = kup.transform;
            }
        }

        Guncelle();
    }

    // Inspector'da bir değer değiştiğinde çağrılır.
    void OnValidate()
    {
        yenile = true;
    }

    void Update()
    {
        if (!yenile) return;
        yenile = false;
        Guncelle();
    }

    void Guncelle()
    {
        if (kupler == null) return;

        // Tohum hem rastgele sayıları hem gürültüde okunan bölgeyi belirler.
        Random.InitState(tohum);
        float kayma = tohum * 17.31f;

        for (int x = 0; x < kupler.GetLength(0); x++)
        {
            for (int z = 0; z < kupler.GetLength(1); z++)
            {
                // Perlin gürültüsünde komşu noktalar birbirine yakın değer alır. Random.value ise her seferinde bağımsızdır.
                float deger = perlinKullan
                    ? Mathf.PerlinNoise(x * olcek + kayma, z * olcek + kayma)
                    : Random.value;
                deger = Mathf.Clamp01(deger);

                // Su seviyesinin altı düz bırakılır.
                float boy = Mathf.Max(deger, suSeviyesi) * yukseklik + 0.2f;

                Transform kup = kupler[x, z];
                kup.localScale = new Vector3(1f, boy, 1f);
                kup.position = transform.position + new Vector3(x - kupler.GetLength(0) * 0.5f, boy * 0.5f, z - kupler.GetLength(1) * 0.5f);

                // Renk yüksekliğe göre seçilir. Su mavi, alçak yerler yeşil, yüksek yerler beyazdır.
                Color renk = deger < suSeviyesi
                    ? new Color(0.2f, 0.45f, 0.9f)
                    : Color.Lerp(new Color(0.25f, 0.6f, 0.25f), Color.white, Mathf.InverseLerp(suSeviyesi, 1f, deger));
                blok.SetColor("_BaseColor", renk);
                kup.GetComponent<Renderer>().SetPropertyBlock(blok);
            }
        }
    }
}
