using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Nesneye can verir. Hasar aldıkça can azalır.
/// Can bittiğinde canBitti olayı tetiklenir. Olaya hangi işin bağlanacağı Inspector'dan seçilir.
/// Aynı bileşen oyuncuya da sandığa da eklenebilir.
/// Game penceresinde nesnenin üstünde kalan can yazar.
/// </summary>
public class Saglik : MonoBehaviour
{
    // SerializeField, private alanı Inspector'da görünür yapar.
    [SerializeField] int enYuksekCan = 100;

    // Can bittiğinde çalışacak işler. Inspector'da artı düğmesiyle eklenir.
    public UnityEvent canBitti;

    int can;

    // Başka betiklerin canı okuyabilmesi için.
    public int Can { get { return can; } }
    public int EnYuksekCan { get { return enYuksekCan; } }

    void Awake() { can = enYuksekCan; }

    // Başka bileşenler bu fonksiyonu çağırarak hasar verir.
    public void HasarAl(int miktar)
    {
        can -= miktar;
        Debug.Log(name + " can " + can);
        if (can <= 0) canBitti.Invoke();
    }

    void OnGUI()
    {
        EkranArayuzu.Basla();
        EkranArayuzu.DunyaEtiketi(transform.position + Vector3.up * 1.3f, name + " Saglik bileşeni", "Can " + Mathf.Max(can, 0) + " / " + enYuksekCan, 300f);
    }
}
