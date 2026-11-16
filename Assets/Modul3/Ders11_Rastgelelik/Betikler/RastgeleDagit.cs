using UnityEngine;

/// <summary>
/// Bir dairenin içine rastgele konumlarda küçük küreler yerleştirir.
/// Tohum Kullan kutusu işaretliyse aynı tohum her çalıştırmada aynı dizilimi üretir.
/// </summary>
public class RastgeleDagit : MonoBehaviour
{
    [SerializeField] int adet = 40;
    [SerializeField] float yaricap = 4f;
    [SerializeField] bool tohumKullan = true;
    [SerializeField] int tohum = 42;

    void Start()
    {
        // Tohum, rastgele sayı dizisinin başlangıç noktasıdır.
        if (tohumKullan) Random.InitState(tohum);

        for (int i = 0; i < adet; i++)
        {
            // Yarıçapı bir olan dairenin içinden rastgele bir nokta seçilir.
            Vector2 nokta = Random.insideUnitCircle * yaricap;

            GameObject kure = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            kure.transform.SetParent(transform);
            kure.transform.position = transform.position + new Vector3(nokta.x, 0.2f, nokta.y);

            // Boyut iki değer arasında rastgele seçilir.
            float boyut = Random.Range(0.2f, 0.5f);
            kure.transform.localScale = new Vector3(boyut, boyut, boyut);
        }
    }

    void OnDrawGizmos()
    {
        Cizim.Cember(transform.position, Vector3.up, yaricap, Color.gray);
        string metin = tohumKullan ? "tohum " + tohum : "tohum yok";
        Cizim.Yazi(transform.position + Vector3.up * 1.5f, metin, Color.white);
    }
}
