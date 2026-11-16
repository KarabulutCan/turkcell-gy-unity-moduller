using UnityEngine;

/// <summary>
/// Rigidbody bileşenine her fizik adımında sabit bir kuvvet uygular.
/// Aynı kuvvet farklı kütlelere uygulandığında ivmenin nasıl değiştiğini gösterir.
/// Nesne belirli bir süre sonra başladığı yere döner.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class KuvvetUygula : MonoBehaviour
{
    [SerializeField] Vector3 kuvvet = new Vector3(4f, 0f, 0f);
    [SerializeField] float sure = 2.5f;

    Rigidbody govde;
    Vector3 baslangic;
    float gecen;

    void Start()
    {
        govde = GetComponent<Rigidbody>();
        baslangic = transform.position;
    }

    void FixedUpdate()
    {
        // Kuvvet fizik motoruna bildirilir. Motor ivmeyi kuvveti kütleye bölerek bulur.
        govde.AddForce(kuvvet);

        // Süre dolduğunda nesne başa alınır.
        gecen += Time.fixedDeltaTime;
        if (gecen >= sure)
        {
            gecen = 0f;
            govde.position = baslangic;
            govde.linearVelocity = Vector3.zero;
        }
    }

    void OnDrawGizmos()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null) return;

        // İvme, kuvvetin kütleye bölümüdür.
        Vector3 ivme = kuvvet / rb.mass;
        Cizim.Ok(transform.position, transform.position + kuvvet * 0.3f, Color.red);
        string metin = "kütle " + Cizim.Sayi(rb.mass) + "  ivme " + Cizim.Sayi(ivme.magnitude) + "  sürat " + Cizim.Sayi(rb.linearVelocity.magnitude);
        Cizim.Yazi(transform.position + Vector3.up * 1.2f, metin, Color.white);
    }
}
