using UnityEngine;

/// <summary>
/// Hedefin nesnenin sağında mı solunda mı olduğunu çapraz çarpımla bulur.
/// Hedefe Don kutusu işaretlenirse nesne hedefe doğru kısa yoldan döner.
/// </summary>
public class SagSolGoster : MonoBehaviour
{
    [SerializeField] Transform hedef;
    [SerializeField] bool hedefeDon = false;
    [SerializeField] float donusHizi = 90f;

    void Update()
    {
        if (hedef == null || !hedefeDon) return;

        Vector3 yon = HedefYonu();

        // Çapraz çarpımın Y bileşeni artıysa hedef sağda, eksiyse soldadır.
        float taraf = Vector3.Cross(transform.forward, yon).y;

        // Hedefe bakılıyorsa dönmeye gerek yoktur.
        float aci = Vector3.Angle(transform.forward, yon);
        if (aci < 0.01f) return;

        // Bu karede dönülecek açı, kalan açıdan büyük olamaz.
        float adim = Mathf.Min(donusHizi * Time.deltaTime, aci);
        transform.Rotate(0f, Mathf.Sign(taraf) * adim, 0f);
    }

    // Hedefe giden birim vektör. Yükseklik farkı hesaba katılmaz.
    Vector3 HedefYonu()
    {
        Vector3 fark = hedef.position - transform.position;
        fark.y = 0f;
        return fark.normalized;
    }

    string Metin()
    {
        Vector3 yon = HedefYonu();
        float taraf = Vector3.Cross(transform.forward, yon).y;
        float onArka = Vector3.Dot(transform.forward, yon);
        return "çapraz çarpım Y " + Cizim.Sayi(taraf) + "  " + (taraf >= 0f ? "SAĞDA" : "SOLDA") + "\n" + "nokta çarpım " + Cizim.Sayi(onArka) + "  " + (onArka >= 0f ? "önde" : "arkada");
    }

    void OnDrawGizmos()
    {
        if (hedef == null) return;

        Vector3 o = transform.position;
        Vector3 yon = HedefYonu();
        Vector3 capraz = Vector3.Cross(transform.forward, yon);

        Cizim.Ok(o, o + transform.forward * 2f, Color.blue);
        Cizim.Ok(o, o + transform.right * 2f, Color.red);
        Cizim.KesikliCizgi(o, hedef.position, Color.white);

        // Çapraz çarpım vektörü. Hedef sağdaysa yukarı, soldaysa aşağı bakar.
        Cizim.Ok(o, o + capraz * 2f, Color.green);
        Cizim.Yazi(o + Vector3.up * 2.6f, Metin(), Color.white);
    }

    void OnGUI()
    {
        if (hedef == null) return;
        GUIStyle stil = new GUIStyle(GUI.skin.label);
        stil.fontSize = 22;
        GUI.Label(new Rect(20f, 20f, 900f, 70f), Metin(), stil);
    }
}
