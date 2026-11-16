using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Modül 3 derslerinin sahnelerini kurar. Ortak yardımcılar SahneKurucu.cs dosyasındadır.
/// </summary>
public static partial class SahneKurucu
{
    const string KokModul3 = "Assets/Modul3/";

    // Modül 3 işleri sırasında kök klasör geçici olarak değiştirilir.
    static void Modul3Icin(System.Action isler)
    {
        string onceki = Kok;
        Kok = KokModul3;
        try { isler(); }
        finally { Kok = onceki; }
    }

    [MenuItem("Egitim/Modul 3/Tum sahneleri kur")]
    public static void Modul3TumunuKur()
    {
        M3Ders01();
        M3Ders02();
        M3Ders03();
        M3Ders04();
        M3Ders05();
        M3Ders06();
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log("[Egitim] Modul 3 sahneleri kuruldu.");
    }

    // Eksenleri çizen nesneyi sahneye ekler.
    static GameObject EksenEkle(float uzunluk)
    {
        GameObject eksenler = new GameObject("Eksenler");
        EksenGoster goster = eksenler.AddComponent<EksenGoster>();
        SerializedObject so = new SerializedObject(goster);
        so.FindProperty("uzunluk").floatValue = uzunluk;
        so.ApplyModifiedPropertiesWithoutUndo();
        return eksenler;
    }

    // Bileşenin sayı, renk ya da metin alanına değer atar.
    static void Deger(Object bilesen, string alan, object deger)
    {
        SerializedObject so = new SerializedObject(bilesen);
        SerializedProperty ozellik = so.FindProperty(alan);
        if (ozellik == null)
        {
            Debug.LogError("[Egitim] Alan bulunamadı " + alan);
            return;
        }
        if (deger is float) ozellik.floatValue = (float)deger;
        else if (deger is int) ozellik.intValue = (int)deger;
        else if (deger is bool) ozellik.boolValue = (bool)deger;
        else if (deger is string) ozellik.stringValue = (string)deger;
        else if (deger is Color) ozellik.colorValue = (Color)deger;
        else if (deger is Vector3) ozellik.vector3Value = (Vector3)deger;
        else if (deger is Object) ozellik.objectReferenceValue = (Object)deger;
        so.ApplyModifiedPropertiesWithoutUndo();
    }

    [MenuItem("Egitim/Modul 3/Ders 01 sahnelerini kur")]
    public static void M3Ders01()
    {
        Modul3Icin(() =>
        {
            const string klasor = "Ders01_Koordinat_Sistemleri";
            const string baslik = "Modül 3 | Ders 1 | Koordinat Sistemleri";
            for (int i = 0; i < 2; i++)
            {
                bool tamamlanmis = i == 1;
                Scene sahne = YeniSahne();
                NotEkle(klasor, baslik, tamamlanmis
                    ? "Bu sahne dersin sonundaki durumdur. Nokta 3, 2, 4 konumundadır. Kesikli çizgiler konumun üç eksendeki karşılığını gösterir."
                    : "Bu sahne dersin başındaki durumdur. Nokta sahnenin merkezindedir. Konumunu siz değiştireceksiniz.");
                Kamera(new Vector3(7f, 6f, -9f), new Vector3(27f, -38f, 0f));
                Ilkel(PrimitiveType.Plane, "Zemin", new Vector3(0f, -0.02f, 0f), new Vector3(2f, 1f, 2f));
                EksenEkle(5f);
                GameObject nokta = Ilkel(PrimitiveType.Sphere, "Nokta", tamamlanmis ? new Vector3(3f, 2f, 4f) : Vector3.zero, new Vector3(0.4f, 0.4f, 0.4f));
                nokta.AddComponent<KonumGoster>();
                // Uzun gövde ve ilerisini gösteren mavi burun. Burun Z ekseninin artı yönündedir.
                GameObject yonKupu = new GameObject("YonKupu");
                yonKupu.transform.position = new Vector3(-3f, 0.5f, 0f);
                GameObject govde = Ilkel(PrimitiveType.Cube, "Govde", new Vector3(-3f, 0.5f, 0f), new Vector3(0.4f, 0.4f, 1.4f));
                govde.transform.SetParent(yonKupu.transform, true);
                GameObject burun = Ilkel(PrimitiveType.Cube, "Burun", new Vector3(-3f, 0.5f, 0.8f), new Vector3(0.25f, 0.25f, 0.25f));
                burun.transform.SetParent(yonKupu.transform, true);
                KlasorOlustur(Kok + klasor + "/Materyaller");
                burun.GetComponent<Renderer>().sharedMaterial = MateryalOlustur(Kok + klasor + "/Materyaller/MaviMat.mat", new Color(0.2f, 0.4f, 1f));
                if (tamamlanmis) yonKupu.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                Kaydet(sahne, klasor, tamamlanmis ? "Ders01_Tamamlanmis" : "Ders01_Baslangic");
            }
        });
    }

    [MenuItem("Egitim/Modul 3/Ders 02 sahnelerini kur")]
    public static void M3Ders02()
    {
        Modul3Icin(() =>
        {
            const string klasor = "Ders02_Vektorler_I";
            const string baslik = "Modül 3 | Ders 2 | Vektörler I";
            for (int i = 0; i < 2; i++)
            {
                bool tamamlanmis = i == 1;
                Scene sahne = YeniSahne();
                NotEkle(klasor, baslik, tamamlanmis
                    ? "Bu sahne dersin sonundaki durumdur. A ve B vektörleri, toplamları, A vektörünün iki katı ve A noktasından B noktasına giden vektör birlikte görünür."
                    : "Bu sahne dersin başındaki durumdur. Yalnızca A vektörü görünür. UcB, Toplam, Olcek ve Fark nesneleri kapalıdır, derste sırayla açılır.");
                Kamera(new Vector3(2.5f, 2.5f, -10f), Vector3.zero);
                EksenEkle(6f);

                GameObject ucA = Ilkel(PrimitiveType.Sphere, "UcA", new Vector3(3f, 1f, 0f), new Vector3(0.3f, 0.3f, 0.3f));
                VektorGoster a = ucA.AddComponent<VektorGoster>();
                Deger(a, "ad", "A");
                Deger(a, "renk", new Color(1f, 0.35f, 0.3f));

                GameObject ucB = Ilkel(PrimitiveType.Sphere, "UcB", new Vector3(1f, 2f, 0f), new Vector3(0.3f, 0.3f, 0.3f));
                VektorGoster b = ucB.AddComponent<VektorGoster>();
                Deger(b, "ad", "B");
                Deger(b, "renk", new Color(0.35f, 0.6f, 1f));

                GameObject toplam = new GameObject("Toplam");
                VektorToplam t = toplam.AddComponent<VektorToplam>();
                Deger(t, "a", a);
                Deger(t, "b", b);

                GameObject olcek = new GameObject("Olcek");
                VektorOlcek o = olcek.AddComponent<VektorOlcek>();
                Deger(o, "a", a);
                Deger(o, "carpan", 2f);

                GameObject fark = new GameObject("Fark");
                VektorFark f = fark.AddComponent<VektorFark>();
                Deger(f, "a", a);
                Deger(f, "b", b);

                if (!tamamlanmis)
                {
                    ucB.SetActive(false);
                    toplam.SetActive(false);
                    olcek.SetActive(false);
                    fark.SetActive(false);
                }
                Kaydet(sahne, klasor, tamamlanmis ? "Ders02_Tamamlanmis" : "Ders02_Baslangic");
            }
        });
    }

    [MenuItem("Egitim/Modul 3/Ders 03 sahnelerini kur")]
    public static void M3Ders03()
    {
        Modul3Icin(() =>
        {
            const string klasor = "Ders03_Vektorler_II";
            const string baslik = "Modül 3 | Ders 3 | Vektörler II";
            for (int i = 0; i < 2; i++)
            {
                bool tamamlanmis = i == 1;
                Scene sahne = YeniSahne();
                NotEkle(klasor, baslik, tamamlanmis
                    ? "Bu sahne dersin sonundaki durumdur. Play tuşuna basın. Takipci sabit hızla Hedef nesnesine gider. Hedef nesnesini Scene penceresinde sürükleyin, Takipci yön değiştirir."
                    : "Bu sahne dersin başındaki durumdur. HedefeGit betiği klasörde hazırdır, Takipci nesnesine siz ekleyeceksiniz.");
                Kamera(new Vector3(0f, 9f, -11f), new Vector3(40f, 0f, 0f));
                Ilkel(PrimitiveType.Plane, "Zemin", Vector3.zero, new Vector3(2f, 1f, 2f));
                GameObject takipci = Ilkel(PrimitiveType.Cube, "Takipci", new Vector3(-5f, 0.5f, -3f), new Vector3(0.6f, 0.6f, 1.2f));
                GameObject hedef = Ilkel(PrimitiveType.Sphere, "Hedef", new Vector3(4f, 0.5f, 3f), new Vector3(0.6f, 0.6f, 0.6f));
                if (tamamlanmis)
                {
                    HedefeGit git = takipci.AddComponent<HedefeGit>();
                    Deger(git, "hedef", hedef.transform);
                }
                Kaydet(sahne, klasor, tamamlanmis ? "Ders03_Tamamlanmis" : "Ders03_Baslangic");
            }
        });
    }

    // Ön yüzünü mavi bir burunla gösteren küp oluşturur. Burun küpün ileri yönündedir.
    static GameObject BurunluKup(string ad, Vector3 konum, string klasor)
    {
        GameObject kup = Ilkel(PrimitiveType.Cube, ad, konum, Vector3.one);
        GameObject burun = Ilkel(PrimitiveType.Cube, "Burun", konum + new Vector3(0f, 0f, 0.6f), new Vector3(0.3f, 0.3f, 0.3f));
        burun.transform.SetParent(kup.transform, true);
        KlasorOlustur(Kok + klasor + "/Materyaller");
        burun.GetComponent<Renderer>().sharedMaterial = MateryalOlustur(Kok + klasor + "/Materyaller/MaviMat.mat", new Color(0.2f, 0.4f, 1f));
        return kup;
    }

    // Vektörün ucunu gösteren küçük küre oluşturur ve VektorGoster betiğini ekler.
    static VektorGoster VektorUcu(string ad, Vector3 konum, string harf, Color renk)
    {
        GameObject uc = Ilkel(PrimitiveType.Sphere, ad, konum, new Vector3(0.3f, 0.3f, 0.3f));
        VektorGoster goster = uc.AddComponent<VektorGoster>();
        Deger(goster, "ad", harf);
        Deger(goster, "renk", renk);
        return goster;
    }

    [MenuItem("Egitim/Modul 3/Ders 04 sahnelerini kur")]
    public static void M3Ders04()
    {
        Modul3Icin(() =>
        {
            const string klasor = "Ders04_Nokta_Carpim";
            const string baslik = "Modül 3 | Ders 4 | Nokta Çarpım";
            for (int i = 0; i < 2; i++)
            {
                bool tamamlanmis = i == 1;
                Scene sahne = YeniSahne();
                NotEkle(klasor, baslik, tamamlanmis
                    ? "Bu sahne dersin sonundaki durumdur. GorusKonisi betiği Dusman nesnesine eklenmiştir. Oyuncu nesnesini sürükleyin ya da Dusman nesnesini döndürün. Koni kırmızıya döndüğünde düşman oyuncuyu görüyordur."
                    : "Bu sahne dersin başındaki durumdur. GorusKonisi betiği klasörde hazırdır, Dusman nesnesine siz ekleyeceksiniz.");
                Kamera(new Vector3(0f, 13f, -9f), new Vector3(55f, 0f, 0f));
                Ilkel(PrimitiveType.Plane, "Zemin", new Vector3(0f, -0.02f, 0f), new Vector3(2.5f, 1f, 2.5f));
                GameObject dusman = BurunluKup("Dusman", new Vector3(0f, 0.5f, 0f), klasor);
                GameObject oyuncu = Ilkel(PrimitiveType.Sphere, "Oyuncu", tamamlanmis ? new Vector3(2f, 0.5f, 4f) : new Vector3(0f, 0.5f, 4f), new Vector3(0.8f, 0.8f, 0.8f));
                if (tamamlanmis)
                {
                    GorusKonisi koni = dusman.AddComponent<GorusKonisi>();
                    Deger(koni, "hedef", oyuncu.transform);
                }
                Kaydet(sahne, klasor, tamamlanmis ? "Ders04_Tamamlanmis" : "Ders04_Baslangic");
            }
        });
    }

    [MenuItem("Egitim/Modul 3/Ders 05 sahnelerini kur")]
    public static void M3Ders05()
    {
        Modul3Icin(() =>
        {
            const string klasor = "Ders05_Capraz_Carpim";
            const string baslik = "Modül 3 | Ders 5 | Çapraz Çarpım";
            for (int i = 0; i < 2; i++)
            {
                bool tamamlanmis = i == 1;
                Scene sahne = YeniSahne();
                NotEkle(klasor, baslik, tamamlanmis
                    ? "Bu sahne dersin sonundaki durumdur. Ortada çapraz çarpım, sağda üçgenin normali, solda sağ sol göstergesi bulunur. Play tuşuna basın ve Hedef nesnesini sürükleyin. Gozcu hedefe kısa yoldan döner."
                    : "Bu sahne dersin başındaki durumdur. Ortadaki ve sağdaki örnekler hazırdır. Soldaki Gozcu nesnesine SagSolGoster betiğini siz ekleyeceksiniz.");
                Kamera(new Vector3(0f, 9f, -15f), new Vector3(28f, 0f, 0f));
                Ilkel(PrimitiveType.Plane, "Zemin", new Vector3(0f, -0.02f, 0f), new Vector3(3f, 1f, 2f));

                // Ortadaki örnek. A ve B vektörleri ile çapraz çarpımları.
                GameObject caprazGrup = new GameObject("CaprazOrnegi");
                EksenEkle(4f).transform.SetParent(caprazGrup.transform, true);
                VektorGoster a = VektorUcu("UcA", new Vector3(0f, 0f, 2f), "A", new Color(1f, 0.35f, 0.3f));
                VektorGoster b = VektorUcu("UcB", new Vector3(2f, 0f, 0f), "B", new Color(0.35f, 0.6f, 1f));
                a.transform.SetParent(caprazGrup.transform, true);
                b.transform.SetParent(caprazGrup.transform, true);
                GameObject capraz = new GameObject("Capraz");
                capraz.transform.SetParent(caprazGrup.transform, true);
                CaprazGoster cg = capraz.AddComponent<CaprazGoster>();
                Deger(cg, "a", a);
                Deger(cg, "b", b);

                // Sağdaki örnek. Üç köşe ve üçgenin normali.
                GameObject normalGrup = new GameObject("NormalOrnegi");
                normalGrup.transform.position = new Vector3(7f, 0f, 0f);
                GameObject koseA = Ilkel(PrimitiveType.Sphere, "KoseA", new Vector3(7f, 0f, 0f), new Vector3(0.3f, 0.3f, 0.3f));
                GameObject koseB = Ilkel(PrimitiveType.Sphere, "KoseB", new Vector3(7f, 0f, 3f), new Vector3(0.3f, 0.3f, 0.3f));
                GameObject koseC = Ilkel(PrimitiveType.Sphere, "KoseC", new Vector3(10f, 0f, 0f), new Vector3(0.3f, 0.3f, 0.3f));
                koseA.transform.SetParent(normalGrup.transform, true);
                koseB.transform.SetParent(normalGrup.transform, true);
                koseC.transform.SetParent(normalGrup.transform, true);
                UcgenNormal un = normalGrup.AddComponent<UcgenNormal>();
                Deger(un, "a", koseA.transform);
                Deger(un, "b", koseB.transform);
                Deger(un, "c", koseC.transform);

                // Soldaki örnek. Gözcü ve hedefi.
                GameObject sagSolGrup = new GameObject("SagSolOrnegi");
                sagSolGrup.transform.position = new Vector3(-9f, 0f, 0f);
                GameObject gozcu = BurunluKup("Gozcu", new Vector3(-9f, 0.5f, 0f), klasor);
                GameObject hedef = Ilkel(PrimitiveType.Sphere, "Hedef", new Vector3(-6f, 0.5f, 3f), new Vector3(0.6f, 0.6f, 0.6f));
                gozcu.transform.SetParent(sagSolGrup.transform, true);
                hedef.transform.SetParent(sagSolGrup.transform, true);
                if (tamamlanmis)
                {
                    SagSolGoster ss = gozcu.AddComponent<SagSolGoster>();
                    Deger(ss, "hedef", hedef.transform);
                    Deger(ss, "hedefeDon", true);
                }
                Kaydet(sahne, klasor, tamamlanmis ? "Ders05_Tamamlanmis" : "Ders05_Baslangic");
            }
        });
    }

    [MenuItem("Egitim/Modul 3/Ders 06 sahnelerini kur")]
    public static void M3Ders06()
    {
        Modul3Icin(() =>
        {
            const string klasor = "Ders06_Trigonometri";
            const string baslik = "Modül 3 | Ders 6 | Trigonometri";
            for (int i = 0; i < 2; i++)
            {
                bool tamamlanmis = i == 1;
                Scene sahne = YeniSahne();
                NotEkle(klasor, baslik, tamamlanmis
                    ? "Bu sahne dersin sonundaki durumdur. Play tuşuna basın. Gezegen Merkez nesnesinin çevresinde döner, Yuzen nesnesi yukarı aşağı süzülür. Soldaki AciOku nesnesinde açıyı sürgüyle değiştirebilirsiniz."
                    : "Bu sahne dersin başındaki durumdur. Soldaki AciOku hazırdır. DaireselHareket betiğini Gezegen nesnesine, DalgaHareketi betiğini Yuzen nesnesine siz ekleyeceksiniz.");
                Kamera(new Vector3(0f, 8f, -15f), new Vector3(24f, 0f, 0f));
                Ilkel(PrimitiveType.Plane, "Zemin", new Vector3(0f, -0.02f, 0f), new Vector3(3f, 1f, 2f));

                // Soldaki örnek. Açıyı yöne çeviren birim çember.
                GameObject aciOku = new GameObject("AciOku");
                aciOku.transform.position = new Vector3(-9f, 3.5f, 0f);
                aciOku.AddComponent<AcidanYone>();

                // Ortadaki örnek. Merkezin çevresinde dönen gezegen.
                GameObject merkez = Ilkel(PrimitiveType.Sphere, "Merkez", new Vector3(0f, 1f, 0f), Vector3.one);
                GameObject gezegen = Ilkel(PrimitiveType.Sphere, "Gezegen", new Vector3(3f, 1f, 0f), new Vector3(0.5f, 0.5f, 0.5f));

                // Sağdaki örnek. Yukarı aşağı süzülen küp.
                GameObject yuzen = Ilkel(PrimitiveType.Cube, "Yuzen", new Vector3(8f, 1.5f, 0f), new Vector3(0.7f, 0.7f, 0.7f));
                yuzen.transform.rotation = Quaternion.Euler(0f, 45f, 0f);

                if (tamamlanmis)
                {
                    DaireselHareket dh = gezegen.AddComponent<DaireselHareket>();
                    Deger(dh, "merkez", merkez.transform);
                    yuzen.AddComponent<DalgaHareketi>();
                }
                Kaydet(sahne, klasor, tamamlanmis ? "Ders06_Tamamlanmis" : "Ders06_Baslangic");
            }
        });
    }
}
