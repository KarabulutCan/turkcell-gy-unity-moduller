using UnityEngine;

/// <summary>
/// Çağrıldığında bağlı olduğu nesneyi sahneden siler.
/// Saglik bileşenindeki canBitti olayına bağlanmak için yazılmıştır.
/// </summary>
public class YokOl : MonoBehaviour
{
    public void Calistir() { Destroy(gameObject); }
}
