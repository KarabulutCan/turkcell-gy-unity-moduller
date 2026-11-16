using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Ekrandaki düğmeyle Menu sahnesini açık sahnenin yanına yükler ve kaldırır.
/// Sahnenin yüklenebilmesi için Build Profiles altındaki Scene List içinde bulunması gerekir.
/// </summary>
public class SahneYukle : MonoBehaviour
{
    void OnGUI()
    {
        EkranArayuzu.Basla();
        Scene menu = SceneManager.GetSceneByName("Menu");
        bool yuklu = menu.isLoaded;

        EkranArayuzu.PanelBasla(20f, 640f, 520f);
        EkranArayuzu.Baslik("Sahne yükleme");
        EkranArayuzu.Satir("Açık sahne sayısı " + SceneManager.sceneCount);
        for (int i = 0; i < SceneManager.sceneCount; i++)
            EkranArayuzu.Satir("   " + SceneManager.GetSceneAt(i).name);

        // Additive modda açık sahne kapanmaz, yeni sahne onun yanına eklenir.
        if (!yuklu && EkranArayuzu.Dugme("Menu sahnesini ekle (Additive)"))
            SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
        if (yuklu && EkranArayuzu.Dugme("Menu sahnesini kaldır"))
            SceneManager.UnloadSceneAsync(menu);

        EkranArayuzu.Aciklama("Menu sahnesindeki küp, açık sahnenin yanına eklenir. Hierarchy penceresinde iki sahne birlikte görünür.");
        EkranArayuzu.PanelBitir();
    }
}
