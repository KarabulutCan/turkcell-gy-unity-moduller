using UnityEngine;

/// <summary>
/// Küpü saniyede 90 derece döndürür.
/// Dönüş Time.deltaTime ile çarpıldığı için kare hızından bağımsızdır.
/// Doğru yöntemi göstermek için yazılmıştır.
/// </summary>
public class HareketDelta : MonoBehaviour
{
    void Update()
    {
        // Time.deltaTime bir önceki karenin süresidir. Hız ile çarpılınca o karede gidilecek yol bulunur.
        transform.Rotate(0f, 90f * Time.deltaTime, 0f);
    }
}
