using UnityEngine;

/// <summary>
/// Inspector'dan girilen dört satırlık matrisle bir birim küpü dönüştürür.
/// Gri küp dönüşümden önceki, sarı küp dönüşümden sonraki haldir.
/// Kırmızı, yeşil ve mavi oklar matrisin ilk üç sütunudur.
/// </summary>
public class MatrisDonustur : MonoBehaviour
{
    [SerializeField] Vector4 satir0 = new Vector4(1f, 0f, 0f, 0f);
    [SerializeField] Vector4 satir1 = new Vector4(0f, 1f, 0f, 0f);
    [SerializeField] Vector4 satir2 = new Vector4(0f, 0f, 1f, 0f);
    [SerializeField] Vector4 satir3 = new Vector4(0f, 0f, 0f, 1f);

    Matrix4x4 Matris()
    {
        Matrix4x4 m = new Matrix4x4();
        m.SetRow(0, satir0);
        m.SetRow(1, satir1);
        m.SetRow(2, satir2);
        m.SetRow(3, satir3);
        return m;
    }

    void OnDrawGizmos()
    {
        Matrix4x4 m = Matris();
        Vector3 kupMerkezi = new Vector3(0.5f, 0.5f, 0.5f);

        // Dönüşümden önceki birim küp. Bir köşesi orijindedir.
        Gizmos.matrix = Matrix4x4.identity;
        Gizmos.color = Color.gray;
        Gizmos.DrawWireCube(kupMerkezi, Vector3.one);

        // Aynı küp matrisle dönüştürülerek çizilir.
        Gizmos.matrix = m;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(kupMerkezi, Vector3.one);
        Gizmos.color = new Color(1f, 0.9f, 0.2f, 0.25f);
        Gizmos.DrawCube(kupMerkezi, Vector3.one);
        Gizmos.matrix = Matrix4x4.identity;

        // İlk üç sütun, birim eksenlerin dönüşümden sonra gittiği yerdir. Dördüncü sütun ötelemedir.
        Vector3 oteleme = m.GetColumn(3);
        Cizim.Ok(oteleme, oteleme + (Vector3)m.GetColumn(0), Color.red);
        Cizim.Ok(oteleme, oteleme + (Vector3)m.GetColumn(1), Color.green);
        Cizim.Ok(oteleme, oteleme + (Vector3)m.GetColumn(2), Color.blue);

        // Örnek nokta. Küpün orijine en uzak köşesi matrisle çarpılır.
        Vector3 kose = m.MultiplyPoint3x4(Vector3.one);
        Cizim.Yazi(kose + Vector3.up * 0.4f, "(1, 1, 1) noktası " + Cizim.Vektor(kose), Color.yellow);
    }
}
