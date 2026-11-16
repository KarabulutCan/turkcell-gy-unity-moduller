using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEditor.Events;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

/// <summary>
/// Derslerin Baslangic ve Tamamlanmis sahnelerini kurar.
/// Unity'nin üst menüsündeki Egitim menüsünden çalıştırılır.
/// Var olan ders sahnelerinin üzerine yazar. Bir sahneyi bozduysanız bu menüyle ilk haline döndürebilirsiniz.
/// Sahnedeki ders notu, ders klasöründeki README.md dosyasından okunur.
/// </summary>
public static partial class SahneKurucu
{
    static string Kok = "Assets/Modul2/";

    [MenuItem("Egitim/Modul 2/Tum sahneleri kur")]
    public static void TumunuKur()
    {
        Ders01();
        Ders03();
        Ders04();
        Ders05();
        Ders06();
        Ders07();
        Ders08();
        Ders09();
        Ders10();
        Ders11();
        Ders12();
        Ders13();
        Ders14();
        Ders15();
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log("[Egitim] Modul 2 sahneleri kuruldu.");
    }

    [MenuItem("Egitim/Modul 2/Ders 01 sahnelerini kur")]
    public static void Ders01()
    {
        const string klasor = "Ders01_Oyun_Motoru_Nedir";
        const string baslik = "Modül 2 | Ders 1 | Oyun Motoru Nedir?";

        // Başlangıç. Yalnızca kamera ve ışık bulunan boş sahne.
        Scene sahne = YeniSahne();
        NotEkle(klasor, baslik, "Bu sahne dersin başındaki durumdur. Adımları burada kendiniz uygulayın.");
        Kaydet(sahne, klasor, "Ders01_Baslangic");

        // Tamamlanmış. Zemin ve yukarıdan düşen fizikli küp.
        sahne = YeniSahne();
        NotEkle(klasor, baslik, "Bu sahne dersin sonundaki durumdur. Play tuşuna basın ve küpün düşüşünü izleyin.");
        Ilkel(PrimitiveType.Plane, "Plane", Vector3.zero, new Vector3(3f, 1f, 3f));
        GameObject kup = Ilkel(PrimitiveType.Cube, "Cube", new Vector3(0f, 5f, 0f), Vector3.one);
        kup.AddComponent<Rigidbody>();
        Kaydet(sahne, klasor, "Ders01_Tamamlanmis");
    }

    [MenuItem("Egitim/Modul 2/Ders 03 sahnelerini kur")]
    public static void Ders03()
    {
        const string klasor = "Ders03_Oyun_Dongusu";
        const string baslik = "Modül 2 | Ders 3 | Oyun Döngüsü";

        // Başlangıç. Küp ve zemin hazır, betikler henüz eklenmemiş.
        Scene sahne = YeniSahne();
        NotEkle(klasor, baslik, "Bu sahne dersin başındaki durumdur. Betikler klasörde hazırdır, küpe siz ekleyeceksiniz.");
        Ilkel(PrimitiveType.Plane, "Zemin", Vector3.zero, new Vector3(2f, 1f, 2f));
        Ilkel(PrimitiveType.Cube, "Kup", new Vector3(0f, 0.5f, 0f), Vector3.one);
        Kaydet(sahne, klasor, "Ders03_Baslangic");

        // Tamamlanmış. İki küp. Biri kare hızı denemesi, diğeri yürütme sırası denemesi içindir.
        sahne = YeniSahne();
        NotEkle(klasor, baslik, "Bu sahne dersin sonundaki durumdur. Kup_KareHizi etkindir. Yürütme sırasını görmek için Kup_DonguSirasi nesnesini Inspector'dan açın.");
        Ilkel(PrimitiveType.Plane, "Zemin", Vector3.zero, new Vector3(2f, 1f, 2f));
        GameObject kareHizi = Ilkel(PrimitiveType.Cube, "Kup_KareHizi", new Vector3(0f, 0.5f, 0f), Vector3.one);
        kareHizi.AddComponent<KareHizi>();
        GameObject donguSirasi = Ilkel(PrimitiveType.Cube, "Kup_DonguSirasi", new Vector3(2.5f, 0.5f, 0f), Vector3.one);
        donguSirasi.AddComponent<DonguSirasi>();
        donguSirasi.SetActive(false);
        Kaydet(sahne, klasor, "Ders03_Tamamlanmis");
    }


    [MenuItem("Egitim/Modul 2/Ders 04 sahnelerini kur")]
    public static void Ders04()
    {
        const string klasor = "Ders04_Zaman_Yonetimi";
        const string baslik = "Modül 2 | Ders 4 | Zaman Yönetimi";

        for (int i = 0; i < 2; i++)
        {
            bool tamamlanmis = i == 1;
            Scene sahne = YeniSahne();
            NotEkle(klasor, baslik, tamamlanmis
                ? "Bu sahne dersin sonundaki durumdur. Top Play tuşuna basılınca düşer ve Interpolate ayarı açıktır."
                : "Bu sahne dersin başındaki durumdur. Betikler eklenmiştir. Top havada bekler, düşürmek için Rigidbody bileşeninde Is Kinematic kutusunu kapatın.");
            Kamera(new Vector3(0f, 3f, -9f), new Vector3(12f, 0f, 0f));
            Ilkel(PrimitiveType.Plane, "Zemin", Vector3.zero, new Vector3(2f, 1f, 2f));
            Ilkel(PrimitiveType.Cube, "KupSabit", new Vector3(-1.5f, 0.5f, 0f), Vector3.one).AddComponent<HareketSabit>();
            Ilkel(PrimitiveType.Cube, "KupDelta", new Vector3(1.5f, 0.5f, 0f), Vector3.one).AddComponent<HareketDelta>();

            GameObject top = Ilkel(PrimitiveType.Sphere, "Top", new Vector3(0f, 5f, 2f), Vector3.one);
            Rigidbody govde = top.AddComponent<Rigidbody>();
            govde.isKinematic = !tamamlanmis;
            govde.interpolation = tamamlanmis ? RigidbodyInterpolation.Interpolate : RigidbodyInterpolation.None;

            new GameObject("ZamanDenetimi").AddComponent<ZamanDenetimi>();
            Kaydet(sahne, klasor, tamamlanmis ? "Ders04_Tamamlanmis" : "Ders04_Baslangic");
        }
    }

    [MenuItem("Egitim/Modul 2/Ders 05 sahnelerini kur")]
    public static void Ders05()
    {
        const string klasor = "Ders05_Sahne_ve_Hiyerarsi";
        const string baslik = "Modül 2 | Ders 5 | Sahne ve Hiyerarşi";

        // Menu. L tuşuyla yüklenen ikinci sahne. Kamera ve ışık içermez.
        Scene sahne = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        Ilkel(PrimitiveType.Cube, "MenuKupu", new Vector3(0f, 4f, 0f), Vector3.one);
        Kaydet(sahne, klasor, "Menu");

        // Başlangıç. Yalnızca kamera ve ışık.
        sahne = YeniSahne();
        NotEkle(klasor, baslik, "Bu sahne dersin başındaki durumdur. Küreleri siz oluşturacaksınız.");
        Kamera(new Vector3(0f, 16f, -11f), new Vector3(55f, 0f, 0f));
        Kaydet(sahne, klasor, "Ders05_Baslangic");

        // Tamamlanmış. Gunes, çocuğu Dunya ve onun çocuğu Ay.
        sahne = YeniSahne();
        NotEkle(klasor, baslik, "Bu sahne dersin sonundaki durumdur. Play tuşuna basın, Console'da Ay nesnesinin konumlarını okuyun. L tuşu Menu sahnesini yükler.");
        Kamera(new Vector3(0f, 16f, -11f), new Vector3(55f, 0f, 0f));
        GameObject gunes = Ilkel(PrimitiveType.Sphere, "Gunes", Vector3.zero, Vector3.one);
        GameObject dunya = Ilkel(PrimitiveType.Sphere, "Dunya", new Vector3(10f, 0f, 0f), Vector3.one);
        GameObject ay = Ilkel(PrimitiveType.Sphere, "Ay", new Vector3(12f, 0f, 0f), new Vector3(0.4f, 0.4f, 0.4f));
        dunya.transform.SetParent(gunes.transform, true);
        ay.transform.SetParent(dunya.transform, true);
        gunes.AddComponent<Dondur>().derecePerSaniye = 10f;
        dunya.AddComponent<Dondur>().derecePerSaniye = 90f;
        ay.AddComponent<KoordinatYaz>();
        gunes.AddComponent<SahneYukle>();
        Kaydet(sahne, klasor, "Ders05_Tamamlanmis");

        SahneListesineEkle(Kok + klasor + "/Ders05_Baslangic.unity", Kok + klasor + "/Ders05_Tamamlanmis.unity", Kok + klasor + "/Menu.unity");
    }

    [MenuItem("Egitim/Modul 2/Ders 06 sahnelerini kur")]
    public static void Ders06()
    {
        const string klasor = "Ders06_Nesne_Bilesen_Mimarisi";
        const string baslik = "Modül 2 | Ders 6 | Nesne Bileşen Mimarisi";

        for (int i = 0; i < 2; i++)
        {
            bool tamamlanmis = i == 1;
            Scene sahne = YeniSahne();
            NotEkle(klasor, baslik, tamamlanmis
                ? "Bu sahne dersin sonundaki durumdur. Play tuşuna basın, Game penceresine tıklayın ve Boşluk tuşuna iki kez basın. Sandik silinir."
                : "Bu sahne dersin başındaki durumdur. Betikler klasörde hazırdır, nesnelere siz ekleyeceksiniz.");
            Kamera(new Vector3(0f, 3f, -9f), new Vector3(12f, 0f, 0f));
            Ilkel(PrimitiveType.Plane, "Zemin", Vector3.zero, new Vector3(2f, 1f, 2f));
            GameObject oyuncu = Ilkel(PrimitiveType.Capsule, "Oyuncu", new Vector3(0f, 1f, 0f), Vector3.one);
            GameObject sandik = Ilkel(PrimitiveType.Cube, "Sandik", new Vector3(-3f, 0.5f, 0f), Vector3.one);
            GameObject dusman = Ilkel(PrimitiveType.Cube, "Dusman", new Vector3(3f, 0.5f, 0f), Vector3.one);

            if (tamamlanmis)
            {
                SaglikKur(oyuncu, 100);
                Saglik sandikSagligi = SaglikKur(sandik, 60);
                HasarAlani alan = dusman.AddComponent<HasarAlani>();
                AlanAyarla(alan, "hedef", sandikSagligi);
            }
            Kaydet(sahne, klasor, tamamlanmis ? "Ders06_Tamamlanmis" : "Ders06_Baslangic");
        }
    }

    // Nesneye Saglik ve YokOl ekler, canBitti olayını YokOl.Calistir fonksiyonuna bağlar.
    static Saglik SaglikKur(GameObject nesne, int enYuksekCan)
    {
        Saglik saglik = nesne.AddComponent<Saglik>();
        YokOl yokOl = nesne.AddComponent<YokOl>();
        SerializedObject so = new SerializedObject(saglik);
        so.FindProperty("enYuksekCan").intValue = enYuksekCan;
        so.ApplyModifiedPropertiesWithoutUndo();
        if (saglik.canBitti == null) saglik.canBitti = new UnityEvent();
        UnityEventTools.AddVoidPersistentListener(saglik.canBitti, new UnityAction(yokOl.Calistir));
        EditorUtility.SetDirty(saglik);
        return saglik;
    }

    [MenuItem("Egitim/Modul 2/Ders 07 sahnelerini kur")]
    public static void Ders07()
    {
        const string klasor = "Ders07_Unity_Editorunu_Tanima";
        const string baslik = "Modül 2 | Ders 7 | Unity Editörünü Tanıma";

        for (int i = 0; i < 2; i++)
        {
            bool tamamlanmis = i == 1;
            Scene sahne = YeniSahne();
            NotEkle(klasor, baslik, tamamlanmis
                ? "Bu sahne dersin sonundaki durumdur. Kapsul nesnesini seçin, Scene penceresinde sarı tel küreyi görürsünüz."
                : "Bu sahne dersin başındaki durumdur. Gezinme ve araç denemelerini burada yapın.");
            Kamera(new Vector3(0f, 4f, -10f), new Vector3(15f, 0f, 0f));
            Ilkel(PrimitiveType.Plane, "Zemin", Vector3.zero, new Vector3(2f, 1f, 2f));
            Ilkel(PrimitiveType.Cube, "Kup1", new Vector3(-3f, 0.5f, 0f), Vector3.one);
            GameObject kup2 = Ilkel(PrimitiveType.Cube, "Kup2", new Vector3(0f, 0.5f, 2f), Vector3.one);
            kup2.transform.rotation = Quaternion.Euler(0f, 35f, 0f);
            Ilkel(PrimitiveType.Cube, "Kup3", new Vector3(3f, 0.5f, -1f), Vector3.one);
            GameObject kapsul = Ilkel(PrimitiveType.Capsule, "Kapsul", new Vector3(0f, 1f, -2f), Vector3.one);

            if (tamamlanmis)
            {
                GizmoCiz gizmo = kapsul.AddComponent<GizmoCiz>();
                SerializedObject so = new SerializedObject(gizmo);
                so.FindProperty("yaricap").floatValue = 5f;
                so.ApplyModifiedPropertiesWithoutUndo();
            }
            Kaydet(sahne, klasor, tamamlanmis ? "Ders07_Tamamlanmis" : "Ders07_Baslangic");
        }
    }


    [MenuItem("Egitim/Modul 2/Ders 08 sahnelerini kur")]
    public static void Ders08()
    {
        const string klasor = "Ders08_Varlik_Yonetimi";
        const string baslik = "Modül 2 | Ders 8 | Varlık Yönetimi";
        string kok = Kok + klasor + "/";

        KlasorOlustur(kok + "Materyaller");
        KlasorOlustur(kok + "Tamamlanmis/Prefabs");
        Material kirmizi = MateryalOlustur(kok + "Materyaller/KirmiziMat.mat", Color.red);

        // Başlangıç. Yalnızca zemin.
        Scene sahne = YeniSahne();
        NotEkle(klasor, baslik, "Bu sahne dersin başındaki durumdur. Dokuyu ve Prefab'ı siz oluşturacaksınız.");
        Kamera(new Vector3(0f, 4f, -10f), new Vector3(15f, 0f, 0f));
        Ilkel(PrimitiveType.Plane, "Zemin", Vector3.zero, new Vector3(2f, 1f, 2f));
        Kaydet(sahne, klasor, "Ders08_Baslangic");

        // Tamamlanmış. Prefab, dört örnek, bir geçersiz kılma ve bir varyant.
        sahne = YeniSahne();
        NotEkle(klasor, baslik, "Bu sahne dersin sonundaki durumdur. Hierarchy'de mavi adlı nesneler Prefab örnekleridir. İkinci örnekte En Yuksek Can değeri geçersiz kılınmıştır.");
        Kamera(new Vector3(0f, 4f, -10f), new Vector3(15f, 0f, 0f));
        Ilkel(PrimitiveType.Plane, "Zemin", Vector3.zero, new Vector3(2f, 1f, 2f));

        GameObject dusman = Ilkel(PrimitiveType.Cube, "Dusman", new Vector3(-4.5f, 0.5f, 0f), Vector3.one);
        SaglikKur(dusman, 300);
        GameObject prefab = PrefabUtility.SaveAsPrefabAssetAndConnect(dusman, kok + "Tamamlanmis/Prefabs/Dusman.prefab", InteractionMode.AutomatedAction);

        for (int i = 1; i < 4; i++)
        {
            GameObject ornek = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
            ornek.name = "Dusman (" + i + ")";
            ornek.transform.position = new Vector3(-4.5f + i * 2f, 0.5f, 0f);
            if (i == 1)
            {
                Saglik saglik = ornek.GetComponent<Saglik>();
                SerializedObject so = new SerializedObject(saglik);
                so.FindProperty("enYuksekCan").intValue = 50;
                so.ApplyModifiedPropertiesWithoutUndo();
                PrefabUtility.RecordPrefabInstancePropertyModifications(saglik);
            }
        }

        // Varyant. Prefab örneği yeni bir Prefab olarak kaydedilince varyant oluşur.
        GameObject gecici = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
        gecici.GetComponent<MeshRenderer>().sharedMaterial = kirmizi;
        GameObject varyant = PrefabUtility.SaveAsPrefabAsset(gecici, kok + "Tamamlanmis/Prefabs/DusmanKirmizi.prefab");
        Object.DestroyImmediate(gecici);
        GameObject varyantOrnegi = (GameObject)PrefabUtility.InstantiatePrefab(varyant);
        varyantOrnegi.transform.position = new Vector3(3.5f, 0.5f, 0f);

        Kaydet(sahne, klasor, "Ders08_Tamamlanmis");
    }

    [MenuItem("Egitim/Modul 2/Ders 09 sahnelerini kur")]
    public static void Ders09()
    {
        const string klasor = "Ders09_Render";
        const string baslik = "Modül 2 | Ders 9 | Render";
        string kok = Kok + klasor + "/";

        KlasorOlustur(kok + "Materyaller");
        KlasorOlustur(kok + "Tamamlanmis");

        // Normal haritasının doku türü Normal map olmalıdır.
        string normalYolu = kok + "Dokular/normal_harita.png";
        TextureImporter aktarici = AssetImporter.GetAtPath(normalYolu) as TextureImporter;
        if (aktarici != null && aktarici.textureType != TextureImporterType.NormalMap)
        {
            aktarici.textureType = TextureImporterType.NormalMap;
            aktarici.SaveAndReimport();
        }
        Texture2D normal = AssetDatabase.LoadAssetAtPath<Texture2D>(normalYolu);

        // Pembe materyal. Built-in hattın Standard shader'ını kullanır, URP projesinde pembe görünür.
        Shader standard = Shader.Find("Standard");
        if (standard == null) Debug.LogError("[Egitim] Standard shader bulunamadı");
        string eskiYol = kok + "Materyaller/EskiMateryal.mat";
        Material eski = AssetDatabase.LoadAssetAtPath<Material>(eskiYol);
        if (eski == null)
        {
            eski = new Material(standard);
            AssetDatabase.CreateAsset(eski, eskiYol);
        }
        else
        {
            eski.shader = standard;
        }
        eski.color = new Color(0.2f, 0.5f, 0.9f);
        EditorUtility.SetDirty(eski);

        // Dersin sonundaki materyaller.
        Material deneme = MateryalOlustur(kok + "Tamamlanmis/DenemeMat.mat", Color.red);
        deneme.SetFloat("_Metallic", 1f);
        deneme.SetFloat("_Smoothness", 1f);
        if (normal != null)
        {
            deneme.SetTexture("_BumpMap", normal);
            deneme.EnableKeyword("_NORMALMAP");
        }
        deneme.EnableKeyword("_EMISSION");
        deneme.SetColor("_EmissionColor", new Color(1f, 0.45f, 0f));
        deneme.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
        EditorUtility.SetDirty(deneme);
        Material kapsulMat = MateryalOlustur(kok + "Tamamlanmis/KapsulMat.mat", new Color(0.2f, 0.5f, 0.9f));

        for (int i = 0; i < 2; i++)
        {
            bool tamamlanmis = i == 1;
            Scene sahne = YeniSahne();
            NotEkle(klasor, baslik, tamamlanmis
                ? "Bu sahne dersin sonundaki durumdur. Kure nesnesindeki DenemeMat materyalini ve düzelmiş Kapsul nesnesini inceleyin."
                : "Bu sahne dersin başındaki durumdur. Kapsul pembe görünür, çünkü materyali bu projenin render hattıyla uyumlu değildir.");
            Kamera(new Vector3(0f, 2f, -8f), new Vector3(8f, 0f, 0f));
            Ilkel(PrimitiveType.Plane, "Zemin", Vector3.zero, new Vector3(3f, 1f, 3f));
            GameObject kure = Ilkel(PrimitiveType.Sphere, "Kure", new Vector3(-2f, 0.75f, -2f), new Vector3(1.5f, 1.5f, 1.5f));
            Ilkel(PrimitiveType.Cube, "Kup", new Vector3(0f, 1f, 6f), new Vector3(2f, 2f, 2f));
            GameObject kapsul = Ilkel(PrimitiveType.Capsule, "Kapsul", new Vector3(2f, 1f, -2f), Vector3.one);
            kapsul.GetComponent<MeshRenderer>().sharedMaterial = tamamlanmis ? kapsulMat : eski;
            if (tamamlanmis) kure.GetComponent<MeshRenderer>().sharedMaterial = deneme;
            Kaydet(sahne, klasor, tamamlanmis ? "Ders09_Tamamlanmis" : "Ders09_Baslangic");
        }
    }


    [MenuItem("Egitim/Modul 2/Ders 10 sahnelerini kur")]
    public static void Ders10()
    {
        const string klasor = "Ders10_Isik_ve_Golge";
        const string baslik = "Modül 2 | Ders 10 | Işık ve Gölge";
        string kok = Kok + klasor + "/";

        ProbSisteminiAc();

        for (int i = 0; i < 2; i++)
        {
            bool tamamlanmis = i == 1;
            Scene sahne = YeniSahne();
            NotEkle(klasor, baslik, tamamlanmis
                ? "Bu sahne dersin sonundaki durumdur. Işık haritası pişirilmiştir. Kure nesnesini Play modunda sürükleyerek pişirilmiş odada nasıl aydınlandığına bakın."
                : "Bu sahne dersin başındaki durumdur. Bütün nesneler Static olarak işaretlidir ve tek ışık Directional Light nesnesidir.");
            Kamera(new Vector3(0f, 9f, -11f), new Vector3(42f, 0f, 0f));

            // Oda. Zemin ve dört duvar.
            Statik(Ilkel(PrimitiveType.Plane, "Zemin", Vector3.zero, new Vector3(1.2f, 1f, 1.2f)));
            Statik(Ilkel(PrimitiveType.Cube, "DuvarArka", new Vector3(0f, 1.5f, 6f), new Vector3(12f, 3f, 0.3f)));
            Statik(Ilkel(PrimitiveType.Cube, "DuvarOn", new Vector3(0f, 1.5f, -6f), new Vector3(12f, 3f, 0.3f)));
            Statik(Ilkel(PrimitiveType.Cube, "DuvarSol", new Vector3(-6f, 1.5f, 0f), new Vector3(0.3f, 3f, 12f)));
            Statik(Ilkel(PrimitiveType.Cube, "DuvarSag", new Vector3(6f, 1.5f, 0f), new Vector3(0.3f, 3f, 12f)));

            // Odanın içindeki nesneler.
            Statik(Ilkel(PrimitiveType.Cube, "Kup1", new Vector3(-2f, 0.5f, 1.5f), Vector3.one));
            Statik(Ilkel(PrimitiveType.Cube, "Kup2", new Vector3(2.5f, 1f, 2.5f), new Vector3(2f, 2f, 2f)));
            GameObject kup3 = Ilkel(PrimitiveType.Cube, "Kup3", new Vector3(0.5f, 0.5f, -2.5f), Vector3.one);
            kup3.transform.rotation = Quaternion.Euler(0f, 30f, 0f);
            Statik(kup3);
            GameObject kure = Ilkel(PrimitiveType.Sphere, "Kure", new Vector3(-3f, 0.75f, -2f), new Vector3(1.5f, 1.5f, 1.5f));
            if (!tamamlanmis) Statik(kure);

            // Hareketli nesneler için ışık problarının yerleşeceği bölge.
            GameObject probNesnesi = new GameObject("Isik Probu Hacmi");
            probNesnesi.transform.position = new Vector3(0f, 1.5f, 0f);
            ProbeVolume hacim = probNesnesi.AddComponent<ProbeVolume>();
            hacim.mode = ProbeVolume.Mode.Local;
            hacim.size = new Vector3(12f, 4f, 12f);

            // Pişirme ayarları. Başlangıçta çözünürlük varsayılan değerdedir, derste 10 yapılır.
            LightingSettings ayar = new LightingSettings();
            ayar.bakedGI = true;
            ayar.realtimeGI = false;
            ayar.lightmapResolution = tamamlanmis ? 10f : 40f;
            ayar.lightmapMaxSize = 512;
            ayar.directSampleCount = 16;
            ayar.indirectSampleCount = 64;
            ayar.environmentSampleCount = 64;
            string ayarYolu = kok + (tamamlanmis ? "IsikAyarlari_Tamamlanmis.lighting" : "IsikAyarlari_Baslangic.lighting");
            AssetDatabase.DeleteAsset(ayarYolu);
            AssetDatabase.CreateAsset(ayar, ayarYolu);
            Lightmapping.lightingSettings = ayar;

            if (tamamlanmis)
            {
                Light gunes = GameObject.Find("Directional Light").GetComponent<Light>();
                gunes.color = new Color(1f, 0.82f, 0.62f);
                gunes.lightmapBakeType = LightmapBakeType.Mixed;

                GameObject noktasal = new GameObject("Point Light");
                noktasal.transform.position = new Vector3(0f, 2.7f, 0f);
                Light nokta = noktasal.AddComponent<Light>();
                nokta.type = LightType.Point;
                nokta.range = 10f;
                nokta.intensity = 8f;
                nokta.lightmapBakeType = LightmapBakeType.Baked;

                GameObject spotNesnesi = new GameObject("Spot Light");
                spotNesnesi.transform.position = new Vector3(-3f, 2.8f, -4.5f);
                spotNesnesi.transform.LookAt(kure.transform.position);
                Light spot = spotNesnesi.AddComponent<Light>();
                spot.type = LightType.Spot;
                spot.range = 10f;
                spot.spotAngle = 90f;
                spot.intensity = 12f;
                spot.color = new Color(0.6f, 0.8f, 1f);
                spot.lightmapBakeType = LightmapBakeType.Baked;
            }

            Kaydet(sahne, klasor, tamamlanmis ? "Ders10_Tamamlanmis" : "Ders10_Baslangic");

            if (tamamlanmis)
            {
                // Işık haritasını pişir ve sahneyi yeniden kaydet.
                double basla = EditorApplication.timeSinceStartup;
                bool sonuc = Lightmapping.Bake();
                Debug.Log("[Egitim] Pişirme sonucu " + sonuc + " süre " + (EditorApplication.timeSinceStartup - basla).ToString("F1") + " sn");
                EditorSceneManager.SaveScene(sahne);
            }
        }
    }

    // Nesneyi Static olarak işaretler.
    static void Statik(GameObject nesne)
    {
        nesne.isStatic = true;
    }

    // Etkin URP varlığında ışık probu sistemini Adaptive Probe Volumes yapar.
    static void ProbSisteminiAc()
    {
        RenderPipelineAsset hat = GraphicsSettings.currentRenderPipeline;
        if (hat == null)
        {
            Debug.LogWarning("[Egitim] Etkin render hattı varlığı bulunamadı");
            return;
        }
        SerializedObject so = new SerializedObject(hat);
        SerializedProperty ozellik = so.FindProperty("m_LightProbeSystem");
        if (ozellik == null)
        {
            Debug.LogWarning("[Egitim] Işık probu sistemi alanı bulunamadı");
            return;
        }
        if (ozellik.intValue != 1)
        {
            ozellik.intValue = 1;
            so.ApplyModifiedPropertiesWithoutUndo();
            EditorUtility.SetDirty(hat);
            AssetDatabase.SaveAssets();
            Debug.Log("[Egitim] Işık probu sistemi Adaptive Probe Volumes yapıldı " + AssetDatabase.GetAssetPath(hat));
        }
    }

    [MenuItem("Egitim/Modul 2/Ders 11 sahnelerini kur")]
    public static void Ders11()
    {
        const string klasor = "Ders11_Fizik_Motoru";
        const string baslik = "Modül 2 | Ders 11 | Fizik Motoru";
        string kok = Kok + klasor + "/";

        KlasorOlustur(kok + "Materyaller");

        // Zıplayan fizik malzemesi.
        string ziplaYolu = kok + "Materyaller/Zipla.physicMaterial";
        PhysicsMaterial zipla = AssetDatabase.LoadAssetAtPath<PhysicsMaterial>(ziplaYolu);
        if (zipla == null)
        {
            zipla = new PhysicsMaterial("Zipla");
            AssetDatabase.CreateAsset(zipla, ziplaYolu);
        }
        zipla.bounciness = 0.9f;
        zipla.bounceCombine = PhysicsMaterialCombine.Maximum;
        EditorUtility.SetDirty(zipla);

        Material saydam = SaydamMateryal(kok + "Materyaller/AlanMat.mat", new Color(0.2f, 0.8f, 0.4f, 0.3f));

        for (int i = 0; i < 2; i++)
        {
            bool tamamlanmis = i == 1;
            Scene sahne = YeniSahne();
            NotEkle(klasor, baslik, tamamlanmis
                ? "Bu sahne dersin sonundaki durumdur. Play tuşuna basın, Game penceresine tıklayın. Boşluk tuşu topu zıplatır, fare tıklaması ışın gönderir."
                : "Bu sahne dersin başındaki durumdur. Betikler klasörde hazırdır, nesnelere siz ekleyeceksiniz.");
            Kamera(new Vector3(0f, 4f, -11f), new Vector3(14f, 0f, 0f));
            Ilkel(PrimitiveType.Plane, "Zemin", Vector3.zero, new Vector3(3f, 1f, 3f));
            GameObject top = Ilkel(PrimitiveType.Sphere, "Top", new Vector3(0f, 5f, 0f), Vector3.one);
            GameObject rampa = Ilkel(PrimitiveType.Cube, "Rampa", new Vector3(-4f, 1f, 0f), new Vector3(4f, 0.3f, 3f));
            rampa.transform.rotation = Quaternion.Euler(0f, 0f, -20f);
            Ilkel(PrimitiveType.Cube, "Kutu", new Vector3(3.5f, 0.5f, 0f), Vector3.one);
            GameObject alan = Ilkel(PrimitiveType.Cube, "Alan", new Vector3(0f, 1.25f, 3.5f), new Vector3(3f, 2.5f, 3f));
            alan.GetComponent<BoxCollider>().isTrigger = true;
            alan.GetComponent<MeshRenderer>().sharedMaterial = saydam;

            if (tamamlanmis)
            {
                top.AddComponent<Rigidbody>();
                top.GetComponent<SphereCollider>().sharedMaterial = zipla;
                top.AddComponent<Sekme>();
                alan.AddComponent<TetikAlani>();
                GameObject kamera = GameObject.Find("Main Camera");
                IsinGonder isin = kamera.AddComponent<IsinGonder>();
                AlanAyarla(isin, "kamera", kamera.GetComponent<Camera>());
            }
            Kaydet(sahne, klasor, tamamlanmis ? "Ders11_Tamamlanmis" : "Ders11_Baslangic");
        }
    }


    [MenuItem("Egitim/Modul 2/Ders 12 sahnelerini kur")]
    public static void Ders12()
    {
        const string klasor = "Ders12_Ses_Sistemi";
        const string baslik = "Modül 2 | Ders 12 | Ses Sistemi";
        string kok = Kok + klasor + "/";

        KlasorOlustur(kok + "Tamamlanmis");
        string mixerYolu = kok + "AnaMixer.mixer";
        string tamMixerYolu = kok + "Tamamlanmis/AnaMixer_Tamamlanmis.mixer";
        MixerOlustur(mixerYolu, false);
        MixerOlustur(tamMixerYolu, true);

        AudioClip muzik = AssetDatabase.LoadAssetAtPath<AudioClip>(kok + "Sesler/muzik.ogg");
        AudioClip radyoSesi = AssetDatabase.LoadAssetAtPath<AudioClip>(kok + "Sesler/radyo.ogg");
        AudioClip tik = AssetDatabase.LoadAssetAtPath<AudioClip>(kok + "Sesler/tik.wav");

        for (int i = 0; i < 2; i++)
        {
            bool tamamlanmis = i == 1;
            Scene sahne = YeniSahne();
            NotEkle(klasor, baslik, tamamlanmis
                ? "Bu sahne dersin sonundaki durumdur. Play tuşuna basın ve Game penceresine tıklayın. W A S D ile radyoya yaklaşın, Boşluk ile efekt çalın, P ile müziği boğuklaştırın."
                : "Bu sahne dersin başındaki durumdur. Oyuncu W A S D tuşlarıyla hareket eder. Ses kaynaklarını siz ekleyeceksiniz.");
            Ilkel(PrimitiveType.Plane, "Zemin", Vector3.zero, new Vector3(3f, 1f, 3f));
            GameObject oyuncu = Ilkel(PrimitiveType.Capsule, "Oyuncu", new Vector3(0f, 1f, 0f), Vector3.one);
            oyuncu.AddComponent<KlavyeHareket>();
            GameObject radyo = Ilkel(PrimitiveType.Cube, "Radyo", new Vector3(6f, 0.5f, 4f), Vector3.one);

            // Kamera oyuncunun çocuğudur. Audio Listener kameranın üzerinde olduğu için oyuncuyla birlikte taşınır.
            GameObject kamera = GameObject.Find("Main Camera");
            kamera.transform.SetParent(oyuncu.transform, false);
            kamera.transform.localPosition = new Vector3(0f, 3f, -7f);
            kamera.transform.localRotation = Quaternion.Euler(18f, 0f, 0f);

            if (tamamlanmis)
            {
                AudioMixerGroup muzikGrubu = AltVarlik<AudioMixerGroup>(tamMixerYolu, "Muzik");
                AudioMixerGroup efektGrubu = AltVarlik<AudioMixerGroup>(tamMixerYolu, "Efekt");
                AudioMixerSnapshot normal = AltVarlik<AudioMixerSnapshot>(tamMixerYolu, "Normal");
                AudioMixerSnapshot duraklat = AltVarlik<AudioMixerSnapshot>(tamMixerYolu, "Duraklat");

                AudioSource muzikKaynagi = new GameObject("Muzik").AddComponent<AudioSource>();
                muzikKaynagi.clip = muzik;
                muzikKaynagi.loop = true;
                muzikKaynagi.playOnAwake = true;
                muzikKaynagi.volume = 0.6f;
                muzikKaynagi.outputAudioMixerGroup = muzikGrubu;

                AudioSource radyoKaynagi = radyo.AddComponent<AudioSource>();
                radyoKaynagi.clip = radyoSesi;
                radyoKaynagi.loop = true;
                radyoKaynagi.playOnAwake = true;
                radyoKaynagi.spatialBlend = 1f;
                radyoKaynagi.minDistance = 1f;
                radyoKaynagi.maxDistance = 10f;
                radyoKaynagi.outputAudioMixerGroup = efektGrubu;

                AudioSource oyuncuKaynagi = oyuncu.AddComponent<AudioSource>();
                oyuncuKaynagi.playOnAwake = false;
                oyuncuKaynagi.outputAudioMixerGroup = efektGrubu;
                EfektCal efekt = oyuncu.AddComponent<EfektCal>();
                AlanAyarla(efekt, "tik", tik);
                AlanAyarla(efekt, "normal", normal);
                AlanAyarla(efekt, "duraklat", duraklat);
            }
            Kaydet(sahne, klasor, tamamlanmis ? "Ders12_Tamamlanmis" : "Ders12_Baslangic");
        }
    }

    // Muzik ve Efekt grupları ile Normal ve Duraklat anlık görüntülerini içeren bir Audio Mixer oluşturur.
    // Unity bu iş için açık bir komut sunmadığından editörün iç sınıfları kullanılır.
    static void MixerOlustur(string yol, bool lowpassEkle)
    {
        if (AssetDatabase.LoadAssetAtPath<AudioMixer>(yol) != null) return;
        try
        {
            const BindingFlags bayrak = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
            Assembly derleme = typeof(AudioImporter).Assembly;
            System.Type tur = derleme.GetType("UnityEditor.Audio.AudioMixerController", true);

            object mixer = tur.GetMethod("CreateMixerControllerAtPath", bayrak).Invoke(null, new object[] { yol });
            object ana = tur.GetProperty("masterGroup", bayrak).GetValue(mixer, null);

            MethodInfo grupOlustur = tur.GetMethod("CreateNewGroup", bayrak);
            MethodInfo cocukEkle = tur.GetMethod("AddChildToParent", bayrak);
            object muzikGrubu = null;
            foreach (string ad in new string[] { "Muzik", "Efekt" })
            {
                object grup = grupOlustur.Invoke(mixer, new object[] { ad, false });
                cocukEkle.Invoke(mixer, new object[] { grup, ana });
                if (ad == "Muzik") muzikGrubu = grup;
            }

            // Varsayılan anlık görüntünün adı Normal yapılır, kopyası Duraklat olur.
            PropertyInfo hedef = tur.GetProperty("TargetSnapshot", bayrak);
            Object normal = hedef.GetValue(mixer, null) as Object;
            normal.name = "Normal";
            tur.GetMethod("CloneNewSnapshotFromTarget", bayrak).Invoke(mixer, new object[] { false });
            Object duraklat = hedef.GetValue(mixer, null) as Object;
            duraklat.name = "Duraklat";
            hedef.SetValue(mixer, normal, null);

            if (lowpassEkle)
            {
                System.Type efektTuru = derleme.GetType("UnityEditor.Audio.AudioMixerEffectController", true);
                object efekt = System.Activator.CreateInstance(efektTuru, new object[] { "Lowpass" });
                System.Type grupTuru = muzikGrubu.GetType();
                System.Array efektler = grupTuru.GetProperty("effects", bayrak).GetValue(muzikGrubu, null) as System.Array;
                grupTuru.GetMethod("InsertEffect", bayrak).Invoke(muzikGrubu, new object[] { efekt, efektler.Length });
                AssetDatabase.AddObjectToAsset(efekt as Object, mixer as Object);
                efektTuru.GetMethod("PreallocateGUIDs", bayrak).Invoke(efekt, null);
                MethodInfo degerAta = efektTuru.GetMethod("SetValueForParameter", bayrak);
                degerAta.Invoke(efekt, new object[] { mixer, normal, "Cutoff freq", 22000f });
                degerAta.Invoke(efekt, new object[] { mixer, duraklat, "Cutoff freq", 800f });
            }

            EditorUtility.SetDirty(mixer as Object);
            AssetDatabase.SaveAssets();
            AssetDatabase.ImportAsset(yol);
            Debug.Log("[Egitim] Mixer oluşturuldu " + yol);
        }
        catch (System.Exception e)
        {
            Debug.LogError("[Egitim] Mixer oluşturulamadı " + yol + "\n" + e);
            AssetDatabase.DeleteAsset(yol);
        }
    }

    // Bir varlık dosyasının içindeki alt varlığı adına göre bulur.
    static T AltVarlik<T>(string yol, string ad) where T : Object
    {
        foreach (Object varlik in AssetDatabase.LoadAllAssetsAtPath(yol))
        {
            T sonuc = varlik as T;
            if (sonuc != null && sonuc.name == ad) return sonuc;
        }
        Debug.LogWarning("[Egitim] Alt varlık bulunamadı " + ad + " " + yol);
        return null;
    }


    [MenuItem("Egitim/Modul 2/Ders 13 sahnelerini kur")]
    public static void Ders13()
    {
        const string klasor = "Ders13_Girdi_Sistemleri";
        const string baslik = "Modül 2 | Ders 13 | Girdi Sistemleri";
        string kok = Kok + klasor + "/";
        InputActionAsset girdi = AssetDatabase.LoadAssetAtPath<InputActionAsset>(kok + "Tamamlanmis/OyuncuGirdi.inputactions");
        if (girdi == null) Debug.LogError("[Egitim] Girdi varlığı yüklenemedi");

        for (int i = 0; i < 2; i++)
        {
            bool tamamlanmis = i == 1;
            Scene sahne = YeniSahne();
            NotEkle(klasor, baslik, tamamlanmis
                ? "Bu sahne dersin sonundaki durumdur. Play tuşuna basın ve Game penceresine tıklayın. W A S D ya da oyun kolunun sol çubuğu hareket ettirir, Boşluk ya da güney düğmesi zıplatır."
                : "Bu sahne dersin başındaki durumdur. Girdi varlığını siz oluşturacak, Player Input ve OyuncuHareket bileşenlerini siz ekleyeceksiniz.");
            Kamera(new Vector3(0f, 5f, -10f), new Vector3(20f, 0f, 0f));
            Ilkel(PrimitiveType.Plane, "Zemin", Vector3.zero, new Vector3(3f, 1f, 3f));
            GameObject oyuncu = OyuncuKapsulu(new Vector3(0f, 1f, 0f));
            if (tamamlanmis) OyuncuGirdisiKur(oyuncu, girdi);
            Kaydet(sahne, klasor, tamamlanmis ? "Ders13_Tamamlanmis" : "Ders13_Baslangic");
        }
    }

    // Etiketi Player olan, Rigidbody eklenmiş ve devrilmemesi için dönüşü dondurulmuş kapsül.
    static GameObject OyuncuKapsulu(Vector3 konum)
    {
        GameObject oyuncu = Ilkel(PrimitiveType.Capsule, "Oyuncu", konum, Vector3.one);
        oyuncu.tag = "Player";
        Rigidbody govde = oyuncu.AddComponent<Rigidbody>();
        govde.constraints = RigidbodyConstraints.FreezeRotation;
        return oyuncu;
    }

    // Oyuncuya Player Input ve OyuncuHareket ekler.
    static void OyuncuGirdisiKur(GameObject oyuncu, InputActionAsset girdi)
    {
        PlayerInput oyuncuGirdisi = oyuncu.AddComponent<PlayerInput>();
        oyuncuGirdisi.actions = girdi;
        oyuncuGirdisi.defaultActionMap = "Oyuncu";
        oyuncuGirdisi.notificationBehavior = PlayerNotifications.SendMessages;
        oyuncu.AddComponent<OyuncuHareket>();
    }

    [MenuItem("Egitim/Modul 2/Ders 14 sahnelerini kur")]
    public static void Ders14()
    {
        const string klasor = "Ders14_Performans_Hesaplamalari";
        const string baslik = "Modül 2 | Ders 14 | Performans Hesaplamaları";
        string kok = Kok + klasor + "/";

        KlasorOlustur(kok + "Prefabs");
        KlasorOlustur(kok + "Materyaller");
        KlasorOlustur(kok + "Tamamlanmis");
        Color mavi = new Color(0.35f, 0.6f, 0.9f);
        Material materyal = MateryalOlustur(kok + "Materyaller/KupMat.mat", mavi);
        materyal.enableInstancing = false;
        Material materyalTamam = MateryalOlustur(kok + "Tamamlanmis/KupMat_Tamamlanmis.mat", mavi);
        materyalTamam.enableInstancing = true;
        KupPrefabi(kok + "Prefabs/Kup.prefab", materyal, false);
        GameObject prefabTamam = KupPrefabi(kok + "Tamamlanmis/Kup_Tamamlanmis.prefab", materyalTamam, true);

        for (int i = 0; i < 2; i++)
        {
            bool tamamlanmis = i == 1;
            Scene sahne = YeniSahne();
            NotEkle(klasor, baslik, tamamlanmis
                ? "Bu sahne dersin sonundaki durumdur. Play tuşuna basın, bin küp üretilir. Küplerde Hizli Yol açıktır. Stats panelinde ve Profiler penceresinde süreleri okuyun."
                : "Bu sahne dersin başındaki durumdur. Uretici nesnesini siz oluşturacak ve Kup Prefab'ını siz atayacaksınız.");
            Kamera(new Vector3(0f, 25f, -45f), new Vector3(28f, 0f, 0f));
            Ilkel(PrimitiveType.Plane, "Zemin", Vector3.zero, new Vector3(7f, 1f, 7f));
            GameObject oyuncu = Ilkel(PrimitiveType.Capsule, "Oyuncu", new Vector3(0f, 1f, 0f), Vector3.one);
            oyuncu.tag = "Player";

            if (tamamlanmis)
            {
                KupUretici uretici = new GameObject("Uretici").AddComponent<KupUretici>();
                AlanAyarla(uretici, "kupPrefab", prefabTamam);
            }
            Kaydet(sahne, klasor, tamamlanmis ? "Ders14_Tamamlanmis" : "Ders14_Baslangic");
        }
    }

    // Üzerinde KupDavranisi bulunan küp Prefab'ı oluşturur.
    static GameObject KupPrefabi(string yol, Material materyal, bool hizliYol)
    {
        GameObject kup = GameObject.CreatePrimitive(PrimitiveType.Cube);
        kup.name = "Kup";
        kup.GetComponent<MeshRenderer>().sharedMaterial = materyal;
        KupDavranisi davranis = kup.AddComponent<KupDavranisi>();
        SerializedObject so = new SerializedObject(davranis);
        so.FindProperty("hizliYol").boolValue = hizliYol;
        so.ApplyModifiedPropertiesWithoutUndo();
        GameObject prefab = PrefabUtility.SaveAsPrefabAsset(kup, yol);
        Object.DestroyImmediate(kup);
        return prefab;
    }

    [MenuItem("Egitim/Modul 2/Ders 15 sahnelerini kur")]
    public static void Ders15()
    {
        const string klasor = "Ders15_Derleme_ve_Dagitim";
        const string baslik = "Modül 2 | Ders 15 | Derleme ve Dağıtım";
        string kok = Kok + klasor + "/";

        InputActionAsset girdi = AssetDatabase.LoadAssetAtPath<InputActionAsset>(Kok + "Ders13_Girdi_Sistemleri/Tamamlanmis/OyuncuGirdi.inputactions");
        AudioClip muzik = AssetDatabase.LoadAssetAtPath<AudioClip>(Kok + "Ders12_Ses_Sistemi/Sesler/muzik.ogg");
        KlasorOlustur(kok + "Materyaller");
        Material hedefMateryali = MateryalOlustur(kok + "Materyaller/HedefMat.mat", new Color(1f, 0.54f, 0.24f));

        Scene sahne = YeniSahne();
        NotEkle(klasor, baslik, "Bu sahne derlenecek küçük oyundur. Play tuşuna basın ve Game penceresine tıklayın. W A S D ile hareket edin, Boşluk ile zıplayın ve dönen küpleri toplayın.");
        Kamera(new Vector3(0f, 10f, -16f), new Vector3(32f, 0f, 0f));
        Ilkel(PrimitiveType.Plane, "Zemin", Vector3.zero, new Vector3(3f, 1f, 3f));
        GameObject oyuncu = OyuncuKapsulu(new Vector3(0f, 1f, -9f));
        OyuncuGirdisiKur(oyuncu, girdi);

        Ilkel(PrimitiveType.Cube, "Platform1", new Vector3(-6f, 0.5f, 0f), new Vector3(4f, 1f, 4f));
        Ilkel(PrimitiveType.Cube, "Platform2", new Vector3(6f, 0.5f, 3f), new Vector3(4f, 1f, 4f));
        Ilkel(PrimitiveType.Cube, "Duvar", new Vector3(0f, 0.75f, 9f), new Vector3(12f, 1.5f, 0.5f));

        Vector3[] yerler =
        {
            new Vector3(0f, 0.8f, -4f), new Vector3(-3f, 0.8f, 4f), new Vector3(3f, 0.8f, -1f),
            new Vector3(-6f, 1.8f, 0f), new Vector3(6f, 1.8f, 3f), new Vector3(0f, 0.8f, 6f)
        };
        for (int i = 0; i < yerler.Length; i++)
        {
            GameObject hedef = Ilkel(PrimitiveType.Cube, "Hedef (" + (i + 1) + ")", yerler[i], new Vector3(0.6f, 0.6f, 0.6f));
            hedef.transform.rotation = Quaternion.Euler(45f, 45f, 0f);
            hedef.GetComponent<BoxCollider>().isTrigger = true;
            hedef.GetComponent<MeshRenderer>().sharedMaterial = hedefMateryali;
            hedef.AddComponent<Dondur>().derecePerSaniye = 120f;
            hedef.AddComponent<Toplanabilir>();
        }

        AudioSource muzikKaynagi = new GameObject("Muzik").AddComponent<AudioSource>();
        muzikKaynagi.clip = muzik;
        muzikKaynagi.loop = true;
        muzikKaynagi.volume = 0.5f;

        Kaydet(sahne, klasor, "Ders15_Oyun");
    }

    // ---------------------------------------------------------------- yardımcılar

    // Ana kamerayı verilen konuma ve açıya taşır.
    static void Kamera(Vector3 konum, Vector3 aci)
    {
        GameObject kamera = GameObject.Find("Main Camera");
        if (kamera == null) return;
        kamera.transform.position = konum;
        kamera.transform.rotation = Quaternion.Euler(aci);
    }

    // Bileşenin Inspector'da görünen bir nesne alanına değer atar.
    static void AlanAyarla(Object bilesen, string alan, Object deger)
    {
        SerializedObject so = new SerializedObject(bilesen);
        SerializedProperty ozellik = so.FindProperty(alan);
        if (ozellik == null)
        {
            Debug.LogError("[Egitim] Alan bulunamadı " + alan);
            return;
        }
        ozellik.objectReferenceValue = deger;
        so.ApplyModifiedPropertiesWithoutUndo();
    }

    // Sahneleri Build Profiles altındaki Scene List içine ekler. Zaten varsa dokunmaz.
    static void SahneListesineEkle(params string[] yollar)
    {
        var liste = new List<EditorBuildSettingsScene>(EditorBuildSettings.scenes);
        foreach (string yol in yollar)
        {
            bool mevcut = false;
            foreach (EditorBuildSettingsScene kayit in liste)
            {
                if (kayit.path == yol) { mevcut = true; break; }
            }
            if (!mevcut) liste.Add(new EditorBuildSettingsScene(yol, true));
        }
        EditorBuildSettings.scenes = liste.ToArray();
    }

    // Klasör yoksa oluşturur.
    static void KlasorOlustur(string yol)
    {
        if (Directory.Exists(yol)) return;
        Directory.CreateDirectory(yol);
        AssetDatabase.Refresh();
    }

    // URP Lit shader'ı ile verilen renkte materyal oluşturur. Varsa aynı varlığı günceller.
    static Material MateryalOlustur(string yol, Color renk)
    {
        Shader lit = Shader.Find("Universal Render Pipeline/Lit");
        Material materyal = AssetDatabase.LoadAssetAtPath<Material>(yol);
        if (materyal == null)
        {
            materyal = new Material(lit);
            AssetDatabase.CreateAsset(materyal, yol);
        }
        else
        {
            materyal.shader = lit;
        }
        materyal.SetColor("_BaseColor", renk);
        EditorUtility.SetDirty(materyal);
        return materyal;
    }

    // URP Lit shader'ı ile saydam materyal oluşturur. Rengin alfa değeri saydamlığı belirler.
    static Material SaydamMateryal(string yol, Color renk)
    {
        Material materyal = MateryalOlustur(yol, renk);
        materyal.SetFloat("_Surface", 1f);
        materyal.SetFloat("_Blend", 0f);
        materyal.SetFloat("_SrcBlend", (float)BlendMode.SrcAlpha);
        materyal.SetFloat("_DstBlend", (float)BlendMode.OneMinusSrcAlpha);
        materyal.SetFloat("_ZWrite", 0f);
        materyal.EnableKeyword("_SURFACE_TYPE_TRANSPARENT");
        materyal.SetOverrideTag("RenderType", "Transparent");
        materyal.renderQueue = (int)RenderQueue.Transparent;
        EditorUtility.SetDirty(materyal);
        return materyal;
    }

    static Scene YeniSahne()
    {
        // Kamera ve yönlü ışıkla gelen standart boş sahne.
        return EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);
    }

    static void Kaydet(Scene sahne, string klasor, string ad)
    {
        string yol = Kok + klasor + "/" + ad + ".unity";
        EditorSceneManager.SaveScene(sahne, yol);
        Debug.Log("[Egitim] Sahne kaydedildi " + yol);
    }

    static GameObject Ilkel(PrimitiveType tur, string ad, Vector3 konum, Vector3 olcek)
    {
        GameObject nesne = GameObject.CreatePrimitive(tur);
        nesne.name = ad;
        nesne.transform.position = konum;
        nesne.transform.localScale = olcek;
        return nesne;
    }

    static void NotEkle(string klasor, string baslik, string sahneAciklamasi)
    {
        GameObject nesne = new GameObject("_DERS NOTU");
        nesne.transform.SetAsFirstSibling();
        DersNotu not = nesne.AddComponent<DersNotu>();
        not.dersBasligi = baslik;
        ReadmeOku(Kok + klasor + "/README.md", not);
        not.amac = string.IsNullOrEmpty(not.amac) ? sahneAciklamasi : sahneAciklamasi + "\n\n" + not.amac;
    }

    // README.md içinden amaç, adımlar ve deneme önerilerini okur.
    static void ReadmeOku(string yol, DersNotu not)
    {
        if (!File.Exists(yol))
        {
            Debug.LogWarning("[Egitim] README bulunamadı " + yol);
            return;
        }

        var amac = new List<string>();
        var adimlar = new List<string>();
        var dene = new List<string>();
        string bolum = "";

        foreach (string ham in File.ReadAllLines(yol))
        {
            string satir = ham.Trim();
            if (satir.StartsWith("## ")) { bolum = satir.Substring(3).Trim(); continue; }
            if (satir.Length == 0 || satir.StartsWith("#") || satir.StartsWith("|")) continue;

            if (bolum == "Bu Uygulamada Ne Yapıyoruz") amac.Add(satir);
            else if (bolum == "Adım Adım") adimlar.Add(NumaraSil(satir));
            else if (bolum == "Kendiniz Deneyin") dene.Add(satir.TrimStart('*', ' '));
        }

        not.amac = string.Join("\n\n", amac.ToArray());
        not.adimlar = adimlar.ToArray();
        not.kendinDene = dene.ToArray();
    }

    // "3. Metin" biçimindeki satırın başındaki numarayı siler.
    static string NumaraSil(string satir)
    {
        int i = 0;
        while (i < satir.Length && char.IsDigit(satir[i])) i++;
        if (i > 0 && i < satir.Length && satir[i] == '.') return satir.Substring(i + 1).Trim();
        return satir;
    }
}
