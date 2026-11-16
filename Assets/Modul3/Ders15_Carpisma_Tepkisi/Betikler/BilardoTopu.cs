using UnityEngine;

/// <summary>
/// Bir bilardo topunun hızını tutar.
/// Hareketi ve çarpışmaları BilardoMasasi betiği hesaplar.
/// </summary>
public class BilardoTopu : MonoBehaviour
{
    public Vector3 hiz;

    // Topun yarıçapı ölçeğinin yarısıdır.
    public float Yaricap
    {
        get { return transform.localScale.x * 0.5f; }
    }

    void OnDrawGizmos()
    {
        if (hiz.sqrMagnitude < 0.0001f) return;
        Cizim.Ok(transform.position, transform.position + hiz * 0.3f, Color.yellow);
    }
}
