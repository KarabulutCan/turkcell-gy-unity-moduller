using UnityEngine;

/// <summary>
/// Nesne seçildiğinde Scene penceresinde çevresine sarı bir tel küre çizer.
/// Gizmo yalnızca editörde görünen yardımcı çizimdir, oyuncu bunu görmez.
/// </summary>
public class GizmoCiz : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("GizmoCiz scripti çalıştı.");
        Debug.LogWarning("GizmoCiz scripti çalıştı. Bu bir uyarıdır.");
        Debug.LogError("GizmoCiz scripti çalıştı. Bu bir hatadır.");
    }
    [SerializeField] float yaricap = 3f;

    // Yalnızca nesne seçiliyken çağrılır.
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, yaricap);
    }
}
