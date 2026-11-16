using UnityEngine;

/// <summary>
/// Yerel uzay ile dünya uzayı arasında nokta çevirir.
/// Yerel Nokta alanındaki değer dünya uzayına çevrilip sarı küreyle gösterilir.
/// Dunya Nesnesi alanındaki nesnenin konumu bu nesnenin yerel uzayına çevrilip yazılır.
/// </summary>
public class NoktaCevir : MonoBehaviour
{
    [SerializeField] Vector3 yerelNokta = new Vector3(0f, 0f, 2f);
    [SerializeField] Transform dunyaNesnesi;

    void OnDrawGizmos()
    {
        // Yerelden dünyaya. Nesnenin ölçeği, dönüşü ve konumu noktaya uygulanır.
        Vector3 dunyaNoktasi = transform.TransformPoint(yerelNokta);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(dunyaNoktasi, 0.2f);
        Cizim.Yazi(dunyaNoktasi + Vector3.up * 0.5f, "yerel " + Cizim.Vektor(yerelNokta) + "\n" + "dünya " + Cizim.Vektor(dunyaNoktasi), Color.yellow);

        if (dunyaNesnesi == null) return;

        // Dünyadan yerele. Sonuç, nesnenin kendi eksenlerine göre konumdur.
        Vector3 yerel = transform.InverseTransformPoint(dunyaNesnesi.position);

        // Yerel uzayda X artıysa nokta sağda, Z artıysa önde demektir.
        string taraf = yerel.x >= 0f ? "sağda" : "solda";
        string onArka = yerel.z >= 0f ? "önde" : "arkada";

        Cizim.KesikliCizgi(transform.position, dunyaNesnesi.position, Color.cyan);
        Cizim.Yazi(dunyaNesnesi.position + Vector3.up * 0.7f, "yerel uzayda " + Cizim.Vektor(yerel) + "\n" + onArka + " ve " + taraf, Color.cyan);
    }
}
