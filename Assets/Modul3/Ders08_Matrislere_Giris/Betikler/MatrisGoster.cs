using UnityEngine;

/// <summary>
/// Nesnenin dönüşüm matrisini dört satır halinde yazar.
/// İlk üç sütunu nesnenin eksenleri olarak, dördüncü sütunu konum olarak çizer.
/// Transform değerleri değiştikçe matrisin hangi sayılarının değiştiği izlenir.
/// </summary>
public class MatrisGoster : MonoBehaviour
{
    string Metin()
    {
        // Yerelden dünyaya dönüşüm matrisi. Konum, dönüş ve ölçek bu tek matristedir.
        Matrix4x4 m = transform.localToWorldMatrix;

        string metin = "";
        for (int satir = 0; satir < 4; satir++)
        {
            Vector4 s = m.GetRow(satir);
            metin += Hucre(s.x) + Hucre(s.y) + Hucre(s.z) + Hucre(s.w) + "\n";
        }
        return metin;
    }

    string Hucre(float deger)
    {
        return Cizim.Sayi(deger).PadLeft(7);
    }

    void OnDrawGizmos()
    {
        Matrix4x4 m = transform.localToWorldMatrix;

        // Dördüncü sütun nesnenin konumudur.
        Vector3 konum = m.GetColumn(3);

        // İlk üç sütun nesnenin sağ, yukarı ve ileri eksenleridir. Uzunlukları ölçeği verir.
        Vector3 sutun0 = m.GetColumn(0);
        Vector3 sutun1 = m.GetColumn(1);
        Vector3 sutun2 = m.GetColumn(2);

        Cizim.Ok(konum, konum + sutun0, Color.red);
        Cizim.Ok(konum, konum + sutun1, Color.green);
        Cizim.Ok(konum, konum + sutun2, Color.blue);
        Cizim.KesikliCizgi(Vector3.zero, konum, Color.gray);
        Cizim.Yazi(konum + Vector3.up * 2.6f, Metin(), Color.white);
    }

    void OnGUI()
    {
        GUIStyle stil = new GUIStyle(GUI.skin.label);
        stil.fontSize = 22;
        GUI.Label(new Rect(20f, 20f, 600f, 140f), Metin(), stil);
    }
}
