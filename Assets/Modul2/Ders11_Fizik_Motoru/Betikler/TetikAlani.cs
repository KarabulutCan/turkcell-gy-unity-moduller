using UnityEngine;

/// <summary>
/// Is Trigger açık olan collider'a bir nesne girdiğinde ve çıktığında ekranda ve Console'da bildirir.
/// Tetikleyici nesneleri durdurmaz, yalnızca giriş ve çıkışı bildirir.
/// </summary>
public class TetikAlani : MonoBehaviour
{
    int icerideki;
    string sonOlay = "Boş";

    void OnTriggerEnter(Collider diger)
    {
        icerideki++;
        sonOlay = diger.name + " girdi";
        Debug.Log("Girdi " + diger.name);
    }

    void OnTriggerExit(Collider diger)
    {
        icerideki--;
        sonOlay = diger.name + " çıktı";
        Debug.Log("Cikti " + diger.name);
    }

    void OnGUI()
    {
        EkranArayuzu.Basla();
        EkranArayuzu.DunyaEtiketi(transform.position + Vector3.up * (transform.localScale.y * 0.5f + 0.3f), "Tetik alanı. İçeride " + icerideki, sonOlay, 320f);
    }
}
