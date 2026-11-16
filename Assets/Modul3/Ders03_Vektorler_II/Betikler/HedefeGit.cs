using UnityEngine;

/// <summary>
/// Nesneyi hedefe doğru hareket ettirir.
/// Yön, hedefin konumundan nesnenin konumu çıkarılarak bulunur ve normalize edilir.
/// Normalize Et kutusu kapatılırsa hız uzaklığa bağlı hale gelir. Bu, normalizasyonun neden gerektiğini gösterir.
/// </summary>
public class HedefeGit : MonoBehaviour
{
    [SerializeField] Transform hedef;
    [SerializeField] float hiz = 3f;
    [SerializeField] bool normalizeEt = true;
    [SerializeField] float durmaMesafesi = 0.1f;

    void Update()
    {
        if (hedef == null) return;

        // Hedef eksi konum. Bu vektör nesneden hedefe uzanır.
        Vector3 fark = hedef.position - transform.position;

        // Vektörün uzunluğu iki nokta arasındaki uzaklıktır.
        if (fark.magnitude <= durmaMesafesi) return;

        // Normalize edilmiş vektörün uzunluğu birdir. Yalnızca yön bilgisi taşır.
        Vector3 yon = normalizeEt ? fark.normalized : fark;

        // Yön çarpı hız çarpı geçen süre, bu karede gidilecek yoldur.
        transform.position += yon * hiz * Time.deltaTime;

        // Nesnenin ön yüzü gidiş yönüne çevrilir.
        transform.forward = fark.normalized;
    }

    void OnDrawGizmos()
    {
        if (hedef == null) return;
        Vector3 fark = hedef.position - transform.position;

        Cizim.KesikliCizgi(transform.position, hedef.position, Color.gray);
        Cizim.Ok(transform.position, transform.position + fark.normalized, Color.yellow);
        Cizim.Yazi(transform.position + Vector3.up * 0.9f, "uzaklık " + Cizim.Sayi(fark.magnitude), Color.white);
    }
}
