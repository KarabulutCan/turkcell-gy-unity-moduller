using UnityEngine;

/// <summary>
/// Oyuncu dokunduğunda puanı bir artırır, Console'a yazar ve nesneyi siler.
/// Nesnenin collider'ında Is Trigger açık olmalıdır.
/// Puan ekranın sol üstünde görünür. Gösterge ilk toplanabilir nesne tarafından bir kez oluşturulur.
/// </summary>
public class Toplanabilir : MonoBehaviour
{
    // static alan bütün toplanabilir nesneler arasında ortaktır.
    static int puan;
    static int toplam;

    public static int Puan { get { return puan; } }
    public static int Toplam { get { return toplam; } }

    void Start()
    {
        // Oyun her başladığında sayılar sıfırlanır ve sahnedeki toplanabilir nesneler sayılır.
        if (FindAnyObjectByType<PuanGostergesi>() == null)
        {
            puan = 0;
            toplam = FindObjectsByType<Toplanabilir>(FindObjectsSortMode.None).Length;
            new GameObject("PuanGostergesi").AddComponent<PuanGostergesi>();
        }
    }

    void OnTriggerEnter(Collider diger)
    {
        // Yalnızca etiketi Player olan nesne toplayabilir.
        if (!diger.CompareTag("Player")) return;
        puan++;
        Debug.Log("Puan " + puan);
        Destroy(gameObject);
    }
}
