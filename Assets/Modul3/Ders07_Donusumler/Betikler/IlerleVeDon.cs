using UnityEngine;

/// <summary>
/// Nesneyi her karede biraz döndürür ve ileri doğru öteler.
/// Uzay alanı Self ise nesne kendi ileri yönünde, World ise dünyanın ileri yönünde ilerler.
/// </summary>
public class IlerleVeDon : MonoBehaviour
{
    [SerializeField] float hiz = 2f;
    [SerializeField] float donusHizi = 45f;
    [SerializeField] Space uzay = Space.Self;

    void Update()
    {
        // Döndürme. Nesne kendi Y ekseni etrafında döner.
        transform.Rotate(0f, donusHizi * Time.deltaTime, 0f);

        // Öteleme. Aynı vektör seçilen uzaya göre farklı yöne götürür.
        transform.Translate(Vector3.forward * hiz * Time.deltaTime, uzay);
    }
}
