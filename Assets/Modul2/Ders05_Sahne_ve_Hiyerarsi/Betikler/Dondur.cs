using UnityEngine;

/// <summary>
/// Nesneyi Y ekseni etrafında döndürür.
/// Nesnenin çocukları da onunla birlikte döner.
/// Çocuğu olan nesnelerde Game penceresinde nesnenin üstüne dönüş hızı yazılır.
/// </summary>
public class Dondur : MonoBehaviour
{
    // Saniyedeki dönüş açısı. Inspector'dan değiştirilebilir.
    public float derecePerSaniye = 30f;

    void Update()
    {
        transform.Rotate(0f, derecePerSaniye * Time.deltaTime, 0f);
    }

    void OnGUI()
    {
        // Etiket yalnızca çocuğu olan nesnelerde çizilir. Böylece başka derslerde dönen tek nesneler ekranı kalabalıklaştırmaz.
        if (transform.childCount == 0) return;
        EkranArayuzu.Basla();
        string ebeveyn = transform.parent != null ? transform.parent.name + " ile birlikte de döner" : "Ebeveyni yok";
        EkranArayuzu.DunyaEtiketi(transform.position + Vector3.up * 1.2f, name + " " + derecePerSaniye + " derece/sn", ebeveyn, 380f);
    }
}
