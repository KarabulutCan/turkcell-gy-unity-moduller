using UnityEngine;

/// <summary>
/// Unity'nin olay fonksiyonlarını hangi sırayla çağırdığını gösterir.
/// Her fonksiyon Console penceresine kendi adını ve o anki kare numarasını yazar.
/// Console'da Collapse kapalı olmalıdır, açıksa aynı satırlar tek satırda toplanır.
/// </summary>
public class DonguSirasi : MonoBehaviour
{
    // Nesne yüklendiğinde bir kez çağrılır. Start'tan önce çalışır.
    void Awake()       { Debug.Log("Awake, kare " + Time.frameCount); }

    // Nesne ya da bileşen her etkinleştiğinde çağrılır.
    void OnEnable()    { Debug.Log("OnEnable, kare " + Time.frameCount); }

    // İlk Update'ten hemen önce bir kez çağrılır.
    void Start()       { Debug.Log("Start, kare " + Time.frameCount); }

    // Sabit zaman adımıyla çağrılır. Bir karede hiç çalışmayabilir ya da birden fazla kez çalışabilir.
    void FixedUpdate() { Debug.Log("FixedUpdate, kare " + Time.frameCount); }

    // Her karede bir kez çağrılır.
    void Update()      { Debug.Log("Update, kare " + Time.frameCount); }

    // Her karede, bütün Update çağrıları bittikten sonra çağrılır.
    void LateUpdate()  { Debug.Log("LateUpdate, kare " + Time.frameCount); }
}
