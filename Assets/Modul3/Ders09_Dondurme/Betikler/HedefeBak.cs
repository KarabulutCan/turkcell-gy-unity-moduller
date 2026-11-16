using UnityEngine;

/// <summary>
/// Nesneyi hedefe doğru yumuşak biçimde döndürür.
/// Hedef yönü LookRotation ile bir dönüşe çevrilir. RotateTowards bu dönüşe sabit hızla yaklaşır.
/// Hesap quaternion ile yapıldığı için gimbal kilidi oluşmaz.
/// </summary>
public class HedefeBak : MonoBehaviour
{
    [SerializeField] Transform hedef;
    [SerializeField] float donusHizi = 90f;

    void Update()
    {
        if (hedef == null) return;

        Vector3 yon = hedef.position - transform.position;
        if (yon.sqrMagnitude < 0.0001f) return;

        // İleri yönü hedefe bakan dönüş.
        Quaternion istenen = Quaternion.LookRotation(yon);

        // Şimdiki dönüşten istenen dönüşe doğru, bu karede en çok izin verilen açı kadar dönülür.
        transform.rotation = Quaternion.RotateTowards(transform.rotation, istenen, donusHizi * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        if (hedef == null) return;

        Vector3 o = transform.position;
        Cizim.KesikliCizgi(o, hedef.position, Color.white);
        Cizim.Ok(o, o + transform.forward * 2.5f, Color.blue);

        float aci = Vector3.Angle(transform.forward, hedef.position - o);
        Cizim.Yazi(o + Vector3.up * 2.2f, "hedefe kalan açı " + Mathf.RoundToInt(aci), Color.white);
    }
}
