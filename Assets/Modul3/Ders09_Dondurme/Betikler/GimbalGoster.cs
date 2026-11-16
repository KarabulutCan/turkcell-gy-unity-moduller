using UnityEngine;

/// <summary>
/// Euler açılarını üç sürgüyle değiştirir ve üç halkayla gösterir.
/// Yeşil halka Y, kırmızı halka X, mavi halka Z dönüşünün eksenine diktir.
/// X açısı 90 derece olduğunda mavi halka yeşil halkayla aynı düzleme gelir. Bu durum gimbal kilididir.
/// </summary>
[ExecuteAlways]
public class GimbalGoster : MonoBehaviour
{
    [SerializeField, Range(-180f, 180f)] float x = 0f;
    [SerializeField, Range(-180f, 180f)] float y = 0f;
    [SerializeField, Range(-180f, 180f)] float z = 0f;
    [SerializeField] float halkaYaricapi = 1.8f;

    void Update()
    {
        Uygula();
    }

    // Inspector'da bir sürgü değiştiğinde çağrılır.
    void OnValidate()
    {
        Uygula();
    }

    void Uygula()
    {
        // Üç Euler açısı tek bir dönüşe çevrilir. Unity sırasıyla Z, X ve Y eksenlerinde döndürür.
        transform.rotation = Quaternion.Euler(x, y, z);
    }

    void OnDrawGizmos()
    {
        Vector3 o = transform.position;

        // Dıştaki halka. Y dönüşünün ekseni her zaman dünyanın yukarı yönüdür.
        Vector3 eksenY = Vector3.up;

        // Ortadaki halka. X dönüşünün ekseni Y dönüşünden etkilenir.
        Vector3 eksenX = Quaternion.Euler(0f, y, 0f) * Vector3.right;

        // İçteki halka. Z dönüşünün ekseni hem Y hem X dönüşünden etkilenir.
        Vector3 eksenZ = Quaternion.Euler(x, y, 0f) * Vector3.forward;

        Cizim.Cember(o, eksenY, halkaYaricapi * 1.1f, Color.green);
        Cizim.Cember(o, eksenX, halkaYaricapi, Color.red);
        Cizim.Cember(o, eksenZ, halkaYaricapi * 0.9f, Color.blue);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(o - eksenY * 2.4f, o + eksenY * 2.4f);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(o - eksenX * 2.4f, o + eksenX * 2.4f);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(o - eksenZ * 2.4f, o + eksenZ * 2.4f);

        // Y ekseni ile Z ekseni aynı doğrultuya geldiyse bir dönme serbestliği kaybolmuştur.
        bool kilit = Mathf.Abs(Vector3.Dot(eksenY, eksenZ)) > 0.999f;

        Quaternion q = transform.rotation;
        string metin = "Euler  X " + Cizim.Sayi(x) + "  Y " + Cizim.Sayi(y) + "  Z " + Cizim.Sayi(z) + "\n"
            + "quaternion (" + Cizim.Sayi(q.x) + ", " + Cizim.Sayi(q.y) + ", " + Cizim.Sayi(q.z) + ", " + Cizim.Sayi(q.w) + ")"
            + (kilit ? "\nGİMBAL KİLİDİ" : "");
        Cizim.Yazi(o + Vector3.up * 3.4f, metin, kilit ? Color.red : Color.white);
    }
}
