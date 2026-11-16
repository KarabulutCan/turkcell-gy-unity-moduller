using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Beyaz topa fareyle vuruş yaptırır.
/// Farenin sol tuşu basılı tutulurken nişan çizgisi görünür. Tuş bırakıldığında top, farenin gösterdiği noktaya doğru vurulur.
/// Fare toptan ne kadar uzaksa vuruş o kadar güçlüdür.
/// </summary>
public class Istaka : MonoBehaviour
{
    [SerializeField] BilardoTopu beyazTop;
    [SerializeField] LineRenderer nisanCizgisi;
    [SerializeField] float gucCarpani = 3f;
    [SerializeField] float enCokSurat = 14f;

    Camera kamera;

    void Start()
    {
        kamera = Camera.main;
        if (nisanCizgisi != null) nisanCizgisi.enabled = false;
    }

    void Update()
    {
        if (beyazTop == null || kamera == null || Mouse.current == null) return;

        // Top hareket ederken vuruş yapılamaz.
        bool topDuruyor = beyazTop.hiz.sqrMagnitude < 0.01f;
        bool basili = Mouse.current.leftButton.isPressed;
        bool birakildi = Mouse.current.leftButton.wasReleasedThisFrame;

        if (!topDuruyor || (!basili && !birakildi))
        {
            if (nisanCizgisi != null) nisanCizgisi.enabled = false;
            return;
        }

        // Fareden çıkan ışının masa düzlemini kestiği nokta bulunur.
        Vector3 topKonumu = beyazTop.transform.position;
        Plane masaDuzlemi = new Plane(Vector3.up, topKonumu);
        Ray isin = kamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (!masaDuzlemi.Raycast(isin, out float uzaklik)) return;
        Vector3 hedef = isin.GetPoint(uzaklik);

        // Vuruş yönü hedef eksi konumun normalize edilmiş halidir. Sürat uzaklıkla artar.
        Vector3 fark = hedef - topKonumu;
        fark.y = 0f;
        float surat = Mathf.Min(fark.magnitude * gucCarpani, enCokSurat);
        Vector3 yon = fark.normalized;

        if (nisanCizgisi != null)
        {
            nisanCizgisi.enabled = basili;
            nisanCizgisi.SetPosition(0, topKonumu);
            nisanCizgisi.SetPosition(1, hedef);
        }

        // Tuş bırakıldığında topa hız verilir. Bu bir itkidir.
        if (birakildi) beyazTop.hiz = yon * surat;
    }
}
