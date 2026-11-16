using UnityEngine;

/// <summary>
/// Nesneyi sinüs dalgasıyla yukarı aşağı hareket ettirir.
/// Genlik hareketin yüksekliğini, frekans hızını belirler.
/// Nesnenin X ve Z konumuna dokunulmaz.
/// </summary>
public class DalgaHareketi : MonoBehaviour
{
    [SerializeField] float genlik = 0.5f;
    [SerializeField] float frekans = 2f;

    float baslangicY;

    void Start()
    {
        baslangicY = transform.position.y;
    }

    void Update()
    {
        // Sinüs eksi bir ile bir arasında gidip gelir. Genlikle çarpılınca hareketin sınırları belirlenir.
        float kayma = genlik * Mathf.Sin(frekans * Time.time);

        Vector3 konum = transform.position;
        konum.y = baslangicY + kayma;
        transform.position = konum;
    }

    void OnDrawGizmos()
    {
        // Hareketin alt ve üst sınırı. Play modu dışında nesnenin bulunduğu yükseklik orta nokta kabul edilir.
        float ortaY = Application.isPlaying ? baslangicY : transform.position.y;
        Vector3 orta = new Vector3(transform.position.x, ortaY, transform.position.z);
        Vector3 ust = orta + Vector3.up * genlik;
        Vector3 alt = orta - Vector3.up * genlik;

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(alt, ust);
        Gizmos.DrawLine(ust - Vector3.right * 0.3f, ust + Vector3.right * 0.3f);
        Gizmos.DrawLine(alt - Vector3.right * 0.3f, alt + Vector3.right * 0.3f);
        Cizim.Yazi(ust + Vector3.up * 0.9f, "genlik " + Cizim.Sayi(genlik) + "  frekans " + Cizim.Sayi(frekans), Color.cyan);
    }
}
