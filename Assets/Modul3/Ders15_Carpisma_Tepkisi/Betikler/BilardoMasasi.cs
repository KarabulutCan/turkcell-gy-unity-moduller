using UnityEngine;

/// <summary>
/// Mini bilardo masasının fiziğini hesaplar. Rigidbody kullanılmaz.
/// Her fizik adımında toplar sürtünmeyle yavaşlar, ilerler, duvarlardan seker ve birbirine çarpar.
/// Köşelerdeki ceplere giren toplar masadan çıkar.
/// Toplar bu nesnenin çocuğu olmalıdır.
/// </summary>
public class BilardoMasasi : MonoBehaviour
{
    [SerializeField] Vector2 masaBoyutu = new Vector2(12f, 6f);
    [SerializeField] float yavaslama = 1.2f;
    [SerializeField, Range(0f, 1f)] float esneklik = 0.9f;
    [SerializeField] float cepYaricapi = 0.55f;
    [SerializeField] BilardoTopu beyazTop;
    [SerializeField] Vector3 baslangicAtisi = Vector3.zero;

    BilardoTopu[] toplar;
    Vector3 beyazBaslangic;
    int puan;

    void Start()
    {
        toplar = GetComponentsInChildren<BilardoTopu>();
        if (beyazTop != null)
        {
            beyazBaslangic = beyazTop.transform.position;
            beyazTop.hiz = baslangicAtisi;
        }
    }

    void FixedUpdate()
    {
        float dt = Time.fixedDeltaTime;

        foreach (BilardoTopu top in toplar)
        {
            if (!top.gameObject.activeSelf) continue;
            Yavaslat(top, dt);
            top.transform.position += top.hiz * dt;
            DuvardanSektir(top);
            CepDenetimi(top);
        }

        // Her top çifti bir kez denetlenir.
        for (int i = 0; i < toplar.Length; i++)
        {
            for (int j = i + 1; j < toplar.Length; j++)
            {
                if (toplar[i].gameObject.activeSelf && toplar[j].gameObject.activeSelf) TopCarpismasi(toplar[i], toplar[j]);
            }
        }
    }

    // Sürtünme hıza ters yönde sabit bir ivmedir. Sürat sıfırın altına inmez.
    void Yavaslat(BilardoTopu top, float dt)
    {
        float surat = top.hiz.magnitude;
        if (surat <= 0f) return;
        float yeniSurat = Mathf.Max(0f, surat - yavaslama * dt);
        top.hiz = top.hiz / surat * yeniSurat;
    }

    // Masa kenarını aşan top geri alınır ve hızı duvarın normaline göre yansıtılır.
    void DuvardanSektir(BilardoTopu top)
    {
        Vector3 merkez = transform.position;
        Vector3 konum = top.transform.position;
        float yariX = masaBoyutu.x * 0.5f - top.Yaricap;
        float yariZ = masaBoyutu.y * 0.5f - top.Yaricap;

        if (konum.x > merkez.x + yariX) { konum.x = merkez.x + yariX; Yansit(top, Vector3.left); }
        if (konum.x < merkez.x - yariX) { konum.x = merkez.x - yariX; Yansit(top, Vector3.right); }
        if (konum.z > merkez.z + yariZ) { konum.z = merkez.z + yariZ; Yansit(top, Vector3.back); }
        if (konum.z < merkez.z - yariZ) { konum.z = merkez.z - yariZ; Yansit(top, Vector3.forward); }

        top.transform.position = konum;
    }

    // Yansıma. Hızın normal yönündeki bileşeni ters çevrilir ve esneklikle çarpılır.
    void Yansit(BilardoTopu top, Vector3 normal)
    {
        if (Vector3.Dot(top.hiz, normal) >= 0f) return;
        top.hiz = Vector3.Reflect(top.hiz, normal) * esneklik;
    }

    // İki top arasındaki çarpışma. Önce tespit, sonra ayırma, sonra hız değişimi.
    void TopCarpismasi(BilardoTopu a, BilardoTopu b)
    {
        Vector3 fark = b.transform.position - a.transform.position;
        float uzaklik = fark.magnitude;
        float toplam = a.Yaricap + b.Yaricap;

        // Tespit. Uzaklık yarıçapların toplamından küçükse toplar iç içedir.
        if (uzaklik >= toplam || uzaklik <= 0f) return;

        // Çarpışma normali, birinci toptan ikinci topa bakan birim vektördür.
        Vector3 normal = fark / uzaklik;

        // Ayırma. Toplar iç içe geçtikleri kadar, normal boyunca yarı yarıya itilir.
        float icIce = toplam - uzaklik;
        a.transform.position -= normal * icIce * 0.5f;
        b.transform.position += normal * icIce * 0.5f;

        // Topların normal boyunca birbirine yaklaşma hızı.
        float yaklasma = Vector3.Dot(a.hiz - b.hiz, normal);
        if (yaklasma <= 0f) return;

        // Tepki. Eşit kütleli toplar için itki, yaklaşma hızının esnekliğe bağlı bir bölümüdür.
        float itki = (1f + esneklik) * 0.5f * yaklasma;
        a.hiz -= normal * itki;
        b.hiz += normal * itki;
    }

    // Köşeye yeterince yaklaşan top cebe girer.
    void CepDenetimi(BilardoTopu top)
    {
        Vector3 merkez = transform.position;
        for (int sx = -1; sx <= 1; sx += 2)
        {
            for (int sz = -1; sz <= 1; sz += 2)
            {
                Vector3 kose = merkez + new Vector3(sx * masaBoyutu.x * 0.5f, 0f, sz * masaBoyutu.y * 0.5f);
                Vector3 fark = top.transform.position - kose;
                fark.y = 0f;
                if (fark.sqrMagnitude > cepYaricapi * cepYaricapi) continue;

                if (top == beyazTop)
                {
                    // Beyaz top cebe girerse başladığı yere döner.
                    top.transform.position = beyazBaslangic;
                    top.hiz = Vector3.zero;
                }
                else
                {
                    top.gameObject.SetActive(false);
                    puan++;
                }
                return;
            }
        }
    }

    void OnDrawGizmos()
    {
        Vector3 merkez = transform.position;
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(merkez + Vector3.up * 0.25f, new Vector3(masaBoyutu.x, 0.5f, masaBoyutu.y));
        for (int sx = -1; sx <= 1; sx += 2)
        {
            for (int sz = -1; sz <= 1; sz += 2)
            {
                Vector3 kose = merkez + new Vector3(sx * masaBoyutu.x * 0.5f, 0.05f, sz * masaBoyutu.y * 0.5f);
                Cizim.Cember(kose, Vector3.up, cepYaricapi, Color.red);
            }
        }
    }

    void OnGUI()
    {
        GUIStyle stil = new GUIStyle(GUI.skin.label);
        stil.fontSize = 24;
        GUI.Label(new Rect(20f, 20f, 600f, 40f), "Cebe giren top " + puan, stil);
    }
}
