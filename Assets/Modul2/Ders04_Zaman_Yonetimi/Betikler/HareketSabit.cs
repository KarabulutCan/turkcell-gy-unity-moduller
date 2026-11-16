using UnityEngine;

/// <summary>
/// Küpü her karede sabit 1.5 derece döndürür.
/// Kare hızına bağlıdır. Kare hızı düşerse yavaşlar, yükselirse hızlanır.
/// Yanlış yöntemi göstermek için yazılmıştır.
/// </summary>
public class HareketSabit : MonoBehaviour
{
    void Update()
    {
        // Saniyede 60 karede 90 derece eder. Kare hızı değişince dönüş hızı da değişir.
        transform.Rotate(0f, 1.5f, 0f);
    }
}
