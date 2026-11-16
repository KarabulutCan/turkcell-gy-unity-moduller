using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Bir arayüz panelini boşluk tuşuyla ekrana kaydırır ve geri çeker.
/// Panelin konumu iki değer arasında yumuşatma eğrisiyle hesaplanır.
/// </summary>
public class PanelAcKapa : MonoBehaviour
{
    [SerializeField] RectTransform panel;
    [SerializeField] Vector2 kapaliKonum = new Vector2(420f, 0f);
    [SerializeField] Vector2 acikKonum = new Vector2(-20f, 0f);
    [SerializeField] float sure = 0.5f;
    [SerializeField] EgriTuru egri = EgriTuru.YavasBitir;
    [SerializeField] AnimationCurve ozelEgri = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

    bool acik;
    float gecen = 1000f;

    void Update()
    {
        if (panel == null) return;

        // Boşluk tuşu paneli açar ya da kapatır ve süreyi baştan başlatır.
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            acik = !acik;
            gecen = 0f;
        }

        gecen += Time.deltaTime;
        float t = Mathf.Clamp01(gecen / sure);
        float egriT = Yumusatma.Uygula(egri, t, ozelEgri);

        Vector2 a = acik ? kapaliKonum : acikKonum;
        Vector2 b = acik ? acikKonum : kapaliKonum;
        panel.anchoredPosition = Vector2.LerpUnclamped(a, b, egriT);
    }
}
