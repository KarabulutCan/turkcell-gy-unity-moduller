using UnityEditor;
using UnityEngine;

/// <summary>
/// DersNotu bileşenini Inspector penceresinde okunaklı bir not sayfası olarak çizer.
/// Notu değiştirmek için en alttaki "Notu düzenle" bölümü açılır.
/// </summary>
[CustomEditor(typeof(DersNotu))]
public class DersNotuEditor : Editor
{
    bool duzenle;
    GUIStyle baslikStili;
    GUIStyle altBaslikStili;
    GUIStyle govdeStili;

    void StilleriKur()
    {
        if (baslikStili != null) return;
        baslikStili = new GUIStyle(EditorStyles.boldLabel) { fontSize = 15, wordWrap = true };
        altBaslikStili = new GUIStyle(EditorStyles.boldLabel) { fontSize = 12, wordWrap = true };
        govdeStili = new GUIStyle(EditorStyles.label) { fontSize = 12, wordWrap = true };
    }

    public override void OnInspectorGUI()
    {
        StilleriKur();
        var not = (DersNotu)target;

        GUILayout.Space(6);
        GUILayout.Label(not.dersBasligi, baslikStili);
        GUILayout.Space(4);

        if (!string.IsNullOrEmpty(not.amac))
        {
            GUILayout.Label("Bu sahnede ne yapıyoruz", altBaslikStili);
            GUILayout.Label(not.amac, govdeStili);
            GUILayout.Space(8);
        }

        Liste("Adım adım", not.adimlar, true);
        Liste("Kendin dene", not.kendinDene, false);

        GUILayout.Space(6);
        duzenle = EditorGUILayout.Foldout(duzenle, "Notu düzenle", true);
        if (duzenle) DrawDefaultInspector();
    }

    void Liste(string baslik, string[] satirlar, bool numarali)
    {
        if (satirlar == null || satirlar.Length == 0) return;
        GUILayout.Label(baslik, altBaslikStili);
        for (int i = 0; i < satirlar.Length; i++)
        {
            string on = numarali ? (i + 1) + ". " : "• ";
            GUILayout.Label(on + satirlar[i], govdeStili);
            GUILayout.Space(2);
        }
        GUILayout.Space(8);
    }
}
