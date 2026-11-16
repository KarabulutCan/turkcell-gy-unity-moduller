using UnityEngine;

/// <summary>
/// Hızı ve ivmesi verilen bir nesneyi Euler entegrasyonuyla hareket ettirir.
/// Fizik motoru kullanılmaz. Her karede önce hız, sonra konum güncellenir.
/// Nesne zemin yüksekliğine indiğinde durur ve aldığı yolu Console'a yazar.
/// </summary>
public class Mermi : MonoBehaviour
{
    public Vector3 hiz;
    public Vector3 ivme = new Vector3(0f, -9.81f, 0f);
    public float zeminY = 0f;

    Vector3 baslangic;
    float sure;
    bool durdu;

    void Start()
    {
        baslangic = transform.position;
    }

    void Update()
    {
        if (durdu) return;

        float dt = Time.deltaTime;

        // İvme hızı değiştirir.
        hiz += ivme * dt;

        // Hız konumu değiştirir.
        transform.position += hiz * dt;
        sure += dt;

        // Zemine inildiyse hareket biter.
        if (transform.position.y <= zeminY)
        {
            durdu = true;
            Vector3 konum = transform.position;
            konum.y = zeminY;
            transform.position = konum;

            float menzil = Vector3.Distance(baslangic, konum);
            Debug.Log("Menzil " + menzil.ToString("0.00") + " metre, süre " + sure.ToString("0.00") + " saniye");
        }
    }
}
