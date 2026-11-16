using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        M3Ders07();
        M3Ders08();
        M3Ders09();
        M3Ders10();
        M3Ders11();
        M3Ders12();
        M3Ders13();
        M3Ders14();
        M3Ders15();
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
        else if (deger is Vector2) ozellik.vector2Value = (Vector2)deger;
        else if (deger is Vector4) ozellik.vector4Value = (Vector4)deger;
        else if (deger is AnimationCurve) ozellik.animationCurveValue = (AnimationCurve)deger;
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

    // Verilen yoldaki materyali oluşturur ve nesnenin görüntüsüne atar.
    static void Boya(GameObject nesne, string klasor, string ad, Color renk)
    {
        KlasorOlustur(Kok + klasor + "/Materyaller");
        nesne.GetComponent<Renderer>().sharedMaterial = MateryalOlustur(Kok + klasor + "/Materyaller/" + ad + ".mat", renk);
    }

    // Gövdesi, kanadı ve kuyruğu olan basit bir uçak kurar. Mavi burun uçağın ileri yönündedir.
    static GameObject Ucak(string ad, Vector3 konum, string klasor, Color renk)
    {
        GameObject ucak = new GameObject(ad);
        ucak.transform.position = konum;
        GameObject govde = Ilkel(PrimitiveType.Cube, "Govde", konum, new Vector3(0.4f, 0.4f, 2.2f));
        GameObject kanat = Ilkel(PrimitiveType.Cube, "Kanat", konum + new Vector3(0f, 0f, 0.2f), new Vector3(2.6f, 0.08f, 0.6f));
        GameObject kuyruk = Ilkel(PrimitiveType.Cube, "Kuyruk", konum + new Vector3(0f, 0.35f, -0.95f), new Vector3(0.08f, 0.6f, 0.4f));
        GameObject burun = Ilkel(PrimitiveType.Cube, "Burun", konum + new Vector3(0f, 0f, 1.2f), new Vector3(0.25f, 0.25f, 0.25f));
        foreach (GameObject parca in new[] { govde, kanat, kuyruk })
        {
            parca.transform.SetParent(ucak.transform, true);
            Boya(parca, klasor, ad + "Mat", renk);
        }
        burun.transform.SetParent(ucak.transform, true);
        Boya(burun, klasor, "MaviMat", new Color(0.2f, 0.4f, 1f));
        return ucak;
    }

    [MenuItem("Egitim/Modul 3/Ders 07 sahnelerini kur")]
    public static void M3Ders07()
    {
        Modul3Icin(() =>
        {
            const string klasor = "Ders07_Donusumler";
            const string baslik = "Modül 3 | Ders 7 | Dönüşümler";
            for (int i = 0; i < 2; i++)
            {
                bool tamamlanmis = i == 1;
                Scene sahne = YeniSahne();
                NotEkle(klasor, baslik, tamamlanmis
                    ? "Bu sahne dersin sonundaki durumdur. NoktaCevir ve IlerleVeDon betikleri Ebeveyn nesnesine eklenmiştir. Play tuşuna basın, Ebeveyn dönerek ilerler."
                    : "Bu sahne dersin başındaki durumdur. Ebeveyn, ona bağlı Cocuk ve ayrı duran Isaret hazırdır. NoktaCevir ve IlerleVeDon betiklerini Ebeveyn nesnesine siz ekleyeceksiniz.");
                Kamera(new Vector3(1.5f, 6.5f, -5.5f), new Vector3(45f, 0f, 0f));
                Ilkel(PrimitiveType.Plane, "Zemin", new Vector3(0f, -0.02f, 0f), new Vector3(3f, 1f, 3f));

                // Ebeveyn ve ona bağlı çocuk. Çocuğun yerel konumu 2, 0, 0 olur.
                GameObject ebeveyn = BurunluKup("Ebeveyn", new Vector3(0f, 0.5f, 0f), klasor);
                GameObject cocuk = Ilkel(PrimitiveType.Sphere, "Cocuk", Vector3.zero, new Vector3(0.6f, 0.6f, 0.6f));
                cocuk.transform.SetParent(ebeveyn.transform, false);
                cocuk.transform.localPosition = new Vector3(2f, 0f, 0f);
                Boya(cocuk, klasor, "TuruncuMat", new Color(1f, 0.55f, 0.15f));
                cocuk.AddComponent<DonusumGoster>();

                // Ebeveynin önünde ve sağında duran ayrı nesne.
                GameObject isaret = Ilkel(PrimitiveType.Sphere, "Isaret", new Vector3(3f, 0.5f, 3f), new Vector3(0.4f, 0.4f, 0.4f));
                Boya(isaret, klasor, "CamgobegiMat", new Color(0.2f, 0.85f, 0.95f));

                if (tamamlanmis)
                {
                    NoktaCevir nc = ebeveyn.AddComponent<NoktaCevir>();
                    Deger(nc, "dunyaNesnesi", isaret.transform);
                    ebeveyn.AddComponent<IlerleVeDon>();
                }
                Kaydet(sahne, klasor, tamamlanmis ? "Ders07_Tamamlanmis" : "Ders07_Baslangic");
            }
        });
    }

    [MenuItem("Egitim/Modul 3/Ders 08 sahnelerini kur")]
    public static void M3Ders08()
    {
        Modul3Icin(() =>
        {
            const string klasor = "Ders08_Matrislere_Giris";
            const string baslik = "Modül 3 | Ders 8 | Matrislere Giriş";
            for (int i = 0; i < 2; i++)
            {
                bool tamamlanmis = i == 1;
                Scene sahne = YeniSahne();
                NotEkle(klasor, baslik, tamamlanmis
                    ? "Bu sahne dersin sonundaki durumdur. Kup 3, 1, 2 konumunda ve Y ekseninde 90 derece dönmüştür. MatrisKupu nesnesine aynı matris elle girilmiştir."
                    : "Bu sahne dersin başındaki durumdur. Kup orijindedir ve matrisi birim matristir. MatrisKupu kapalıdır, dersin ikinci bölümünde siz açacaksınız.");
                Kamera(new Vector3(5.5f, 5f, -5.5f), new Vector3(30f, -40f, 0f));
                EksenEkle(5f);

                GameObject kup = Ilkel(PrimitiveType.Cube, "Kup", tamamlanmis ? new Vector3(3f, 1f, 2f) : Vector3.zero, Vector3.one);
                if (tamamlanmis) kup.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                kup.AddComponent<MatrisGoster>();

                GameObject matrisKupu = new GameObject("MatrisKupu");
                MatrisDonustur md = matrisKupu.AddComponent<MatrisDonustur>();
                if (tamamlanmis)
                {
                    // Y ekseninde 90 derece dönüş ve 3, 1, 2 ötelemesi.
                    Deger(md, "satir0", new Vector4(0f, 0f, 1f, 3f));
                    Deger(md, "satir1", new Vector4(0f, 1f, 0f, 1f));
                    Deger(md, "satir2", new Vector4(-1f, 0f, 0f, 2f));
                    Deger(md, "satir3", new Vector4(0f, 0f, 0f, 1f));
                }
                else
                {
                    matrisKupu.SetActive(false);
                }
                Kaydet(sahne, klasor, tamamlanmis ? "Ders08_Tamamlanmis" : "Ders08_Baslangic");
            }
        });
    }

    [MenuItem("Egitim/Modul 3/Ders 09 sahnelerini kur")]
    public static void M3Ders09()
    {
        Modul3Icin(() =>
        {
            const string klasor = "Ders09_Dondurme";
            const string baslik = "Modül 3 | Ders 9 | Döndürme";
            for (int i = 0; i < 2; i++)
            {
                bool tamamlanmis = i == 1;
                Scene sahne = YeniSahne();
                NotEkle(klasor, baslik, tamamlanmis
                    ? "Bu sahne dersin sonundaki durumdur. HedefeBak betiği Ucak2 nesnesine eklenmiş ve Hedef alanı doldurulmuştur. Play tuşuna basın, Ucak2 hedefe döner."
                    : "Bu sahne dersin başındaki durumdur. Ucak nesnesinde GimbalGoster hazırdır. HedefeBak betiğini Ucak2 nesnesine siz ekleyeceksiniz.");
                Kamera(new Vector3(0f, 5f, -13f), new Vector3(14f, 0f, 0f));
                Ilkel(PrimitiveType.Plane, "Zemin", new Vector3(0f, -0.02f, 0f), new Vector3(3f, 1f, 2f));

                GameObject ucak = Ucak("Ucak", new Vector3(-4.5f, 2.5f, 0f), klasor, new Color(0.85f, 0.85f, 0.85f));
                ucak.AddComponent<GimbalGoster>();

                GameObject ucak2 = Ucak("Ucak2", new Vector3(4.5f, 2.5f, 0f), klasor, new Color(0.95f, 0.75f, 0.3f));
                GameObject hedef = Ilkel(PrimitiveType.Sphere, "Hedef", new Vector3(8f, 4.5f, 4f), new Vector3(0.6f, 0.6f, 0.6f));
                Boya(hedef, klasor, "KirmiziMat", new Color(1f, 0.3f, 0.25f));
                if (tamamlanmis)
                {
                    HedefeBak hb = ucak2.AddComponent<HedefeBak>();
                    Deger(hb, "hedef", hedef.transform);
                }
                Kaydet(sahne, klasor, tamamlanmis ? "Ders09_Tamamlanmis" : "Ders09_Baslangic");
            }
        });
    }

    [MenuItem("Egitim/Modul 3/Ders 10 sahnelerini kur")]
    public static void M3Ders10()
    {
        Modul3Icin(() =>
        {
            const string klasor = "Ders10_Interpolasyon";
            const string baslik = "Modül 3 | Ders 10 | İnterpolasyon";
            Color[] renkler = { new Color(1f, 0.35f, 0.3f), new Color(1f, 0.8f, 0.2f), new Color(0.35f, 0.8f, 0.4f), new Color(0.35f, 0.6f, 1f) };
            for (int i = 0; i < 2; i++)
            {
                bool tamamlanmis = i == 1;
                Scene sahne = YeniSahne();
                NotEkle(klasor, baslik, tamamlanmis
                    ? "Bu sahne dersin sonundaki durumdur. Her küre farklı bir eğri kullanır. Play tuşuna basın, Game penceresine tıklayın ve boşluk tuşuna basın. Kamera yaklaşır ve bilgi paneli açılır."
                    : "Bu sahne dersin başındaki durumdur. Dört kürenin hepsi doğrusal eğriyle gider. Eğrileri siz değiştirecek, kameraya ve Canvas nesnesine betikleri siz ekleyeceksiniz.");

                // Kameranın iki durağı. Kamera başlangıçta KameraA noktasındadır.
                Vector3 kameraAKonum = new Vector3(0f, 7f, -10f);
                Vector3 kameraAAci = new Vector3(30f, 0f, 0f);
                Kamera(kameraAKonum, kameraAAci);
                GameObject kameraA = new GameObject("KameraA");
                kameraA.transform.SetPositionAndRotation(kameraAKonum, Quaternion.Euler(kameraAAci));
                GameObject kameraB = new GameObject("KameraB");
                kameraB.transform.SetPositionAndRotation(new Vector3(0f, 4f, -4.5f), Quaternion.Euler(28f, 0f, 0f));

                Ilkel(PrimitiveType.Plane, "Zemin", new Vector3(0f, -0.02f, 3.5f), new Vector3(2f, 1f, 1.5f));

                // Dört yol. Her kürenin bir başlangıç ve bir bitiş işaretçisi vardır.
                GameObject yollar = new GameObject("Yollar");
                for (int k = 0; k < 4; k++)
                {
                    float z = k * 2.5f;
                    Transform bas = Isaretci("Baslangic" + (k + 1), new Vector3(-5f, 0.5f, z), yollar.transform);
                    Transform bit = Isaretci("Bitis" + (k + 1), new Vector3(5f, 0.5f, z), yollar.transform);

                    GameObject kure = Ilkel(PrimitiveType.Sphere, "Kure" + (k + 1), bas.position, new Vector3(0.8f, 0.8f, 0.8f));
                    Boya(kure, klasor, "Kure" + (k + 1) + "Mat", renkler[k]);
                    EgriIleHareket hareket = kure.AddComponent<EgriIleHareket>();
                    Deger(hareket, "baslangic", bas);
                    Deger(hareket, "bitis", bit);

                    if (tamamlanmis)
                    {
                        // Kure1 hedefi aşıp geri dönen özel eğri, diğerleri hazır eğriler kullanır.
                        int[] turler = { (int)EgriTuru.Ozel, (int)EgriTuru.YavasBasla, (int)EgriTuru.YavasBitir, (int)EgriTuru.YumusakGecis };
                        Deger(hareket, "egri", turler[k]);
                        if (k == 0)
                        {
                            AnimationCurve asan = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.75f, 1.12f), new Keyframe(1f, 1f));
                            Deger(hareket, "ozelEgri", asan);
                        }
                    }
                }

                // Sağdan kayarak gelen bilgi paneli. Başlangıçta ekranın dışındadır.
                GameObject canvas = new GameObject("Canvas", typeof(RectTransform), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
                canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
                CanvasScaler olcekleyici = canvas.GetComponent<CanvasScaler>();
                olcekleyici.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                olcekleyici.referenceResolution = new Vector2(1920f, 1080f);
                olcekleyici.matchWidthOrHeight = 0.5f;

                GameObject panel = new GameObject("BilgiPaneli", typeof(RectTransform), typeof(Image));
                panel.transform.SetParent(canvas.transform, false);
                RectTransform panelAlani = panel.GetComponent<RectTransform>();
                panelAlani.anchorMin = new Vector2(1f, 0.5f);
                panelAlani.anchorMax = new Vector2(1f, 0.5f);
                panelAlani.pivot = new Vector2(1f, 0.5f);
                panelAlani.sizeDelta = new Vector2(400f, 340f);
                panelAlani.anchoredPosition = new Vector2(420f, 0f);
                panel.GetComponent<Image>().color = new Color(0.1f, 0.12f, 0.16f, 0.92f);

                GameObject yazi = new GameObject("Yazi", typeof(RectTransform), typeof(Text));
                yazi.transform.SetParent(panel.transform, false);
                RectTransform yaziAlani = yazi.GetComponent<RectTransform>();
                yaziAlani.anchorMin = Vector2.zero;
                yaziAlani.anchorMax = Vector2.one;
                yaziAlani.offsetMin = new Vector2(24f, 24f);
                yaziAlani.offsetMax = new Vector2(-24f, -24f);
                Text metin = yazi.GetComponent<Text>();
                metin.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
                metin.fontSize = 28;
                metin.color = Color.white;
                metin.text = "Yumuşatma Eğrileri\n\nKure1  özel eğri\nKure2  yavaş başla\nKure3  yavaş bitir\nKure4  yumuşak geçiş\n\nBoşluk tuşu paneli kapatır.";

                if (tamamlanmis)
                {
                    GameObject kamera = GameObject.Find("Main Camera");
                    EgriIleHareket kameraHareketi = kamera.AddComponent<EgriIleHareket>();
                    Deger(kameraHareketi, "baslangic", kameraA.transform);
                    Deger(kameraHareketi, "bitis", kameraB.transform);
                    Deger(kameraHareketi, "egri", (int)EgriTuru.YumusakGecis);
                    Deger(kameraHareketi, "sure", 1.2f);
                    Deger(kameraHareketi, "bosluklaTetikle", true);

                    PanelAcKapa acKapa = canvas.AddComponent<PanelAcKapa>();
                    Deger(acKapa, "panel", panelAlani);
                }
                Kaydet(sahne, klasor, tamamlanmis ? "Ders10_Tamamlanmis" : "Ders10_Baslangic");
            }
        });
    }

    // Yolun ucunu gösteren boş nesne. Altında zemini gösteren ince bir disk bulunur.
    static Transform Isaretci(string ad, Vector3 konum, Transform ebeveyn)
    {
        GameObject isaretci = new GameObject(ad);
        isaretci.transform.position = konum;
        isaretci.transform.SetParent(ebeveyn, true);
        GameObject disk = Ilkel(PrimitiveType.Cylinder, "Disk", new Vector3(konum.x, 0.01f, konum.z), new Vector3(0.6f, 0.01f, 0.6f));
        Object.DestroyImmediate(disk.GetComponent<Collider>());
        disk.transform.SetParent(isaretci.transform, true);
        return isaretci.transform;
    }

    [MenuItem("Egitim/Modul 3/Ders 11 sahnelerini kur")]
    public static void M3Ders11()
    {
        Modul3Icin(() =>
        {
            const string klasor = "Ders11_Rastgelelik";
            const string baslik = "Modül 3 | Ders 11 | Rastgelelik ve Prosedürel Üretim";
            for (int i = 0; i < 2; i++)
            {
                bool tamamlanmis = i == 1;
                Scene sahne = YeniSahne();
                NotEkle(klasor, baslik, tamamlanmis
                    ? "Bu sahne dersin sonundaki durumdur. GurultuArazi betiği Arazi nesnesine eklenmiştir. Play tuşuna basın, soldaki küreler dağılır ve sağda arazi üretilir."
                    : "Bu sahne dersin başındaki durumdur. Dagitici hazırdır. Arazi nesnesi boştur, GurultuArazi betiğini siz ekleyeceksiniz.");
                Kamera(new Vector3(3f, 24f, -30f), new Vector3(38f, 0f, 0f));
                Ilkel(PrimitiveType.Plane, "Zemin", new Vector3(2f, -0.02f, 0f), new Vector3(5f, 1f, 4f));

                GameObject dagitici = new GameObject("Dagitici");
                dagitici.transform.position = new Vector3(-13f, 0f, 0f);
                dagitici.AddComponent<RastgeleDagit>();

                GameObject arazi = new GameObject("Arazi");
                arazi.transform.position = new Vector3(10f, 0f, 0f);
                if (tamamlanmis) arazi.AddComponent<GurultuArazi>();
                Kaydet(sahne, klasor, tamamlanmis ? "Ders11_Tamamlanmis" : "Ders11_Baslangic");
            }
        });
    }

    [MenuItem("Egitim/Modul 3/Ders 12 sahnelerini kur")]
    public static void M3Ders12()
    {
        Modul3Icin(() =>
        {
            const string klasor = "Ders12_Kinematik";
            const string baslik = "Modül 3 | Ders 12 | Kinematik";
            for (int i = 0; i < 2; i++)
            {
                bool tamamlanmis = i == 1;
                Scene sahne = YeniSahne();
                NotEkle(klasor, baslik, tamamlanmis
                    ? "Bu sahne dersin sonundaki durumdur. AtisHareketi betiği Top nesnesine eklenmiştir. Play tuşuna basın, Game penceresine tıklayın ve boşluk tuşuyla mermiyi atın."
                    : "Bu sahne dersin başındaki durumdur. Top, Zemin ve mesafe işaretleri hazırdır. AtisHareketi betiğini Top nesnesine siz ekleyeceksiniz.");
                Kamera(new Vector3(4f, 2.3f, -10f), new Vector3(4f, 0f, 0f));
                Ilkel(PrimitiveType.Plane, "Zemin", new Vector3(5f, 0f, 0f), new Vector3(3f, 1f, 1f));

                // Top atış yönüne, yani X ekseninin artı yönüne bakar.
                GameObject top = Ilkel(PrimitiveType.Sphere, "Top", new Vector3(-5f, 0.25f, 0f), new Vector3(0.5f, 0.5f, 0.5f));
                top.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                Boya(top, klasor, "KirmiziMat", new Color(1f, 0.3f, 0.25f));

                // Toptan 5, 10 ve 15 metre uzaktaki işaret direkleri.
                GameObject isaretler = new GameObject("MesafeIsaretleri");
                Font yaziTipi = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
                for (int m = 5; m <= 15; m += 5)
                {
                    GameObject direk = Ilkel(PrimitiveType.Cube, "Isaret" + m + "m", new Vector3(-5f + m, 0.5f, 0.6f), new Vector3(0.08f, 1f, 0.08f));
                    direk.transform.SetParent(isaretler.transform, true);
                    Boya(direk, klasor, "BeyazMat", Color.white);

                    GameObject etiket = new GameObject("Yazi" + m + "m", typeof(TextMesh));
                    etiket.transform.SetParent(isaretler.transform, false);
                    etiket.transform.position = new Vector3(-5f + m, 1.35f, 0.6f);
                    TextMesh tm = etiket.GetComponent<TextMesh>();
                    tm.text = m + " m";
                    tm.font = yaziTipi;
                    tm.fontSize = 48;
                    tm.characterSize = 0.12f;
                    tm.anchor = TextAnchor.MiddleCenter;
                    tm.alignment = TextAlignment.Center;
                    tm.color = Color.white;
                    etiket.GetComponent<MeshRenderer>().sharedMaterial = yaziTipi.material;
                }

                if (tamamlanmis) top.AddComponent<AtisHareketi>();
                Kaydet(sahne, klasor, tamamlanmis ? "Ders12_Tamamlanmis" : "Ders12_Baslangic");
            }
        });
    }

    [MenuItem("Egitim/Modul 3/Ders 13 sahnelerini kur")]
    public static void M3Ders13()
    {
        Modul3Icin(() =>
        {
            const string klasor = "Ders13_Kuvvetler";
            const string baslik = "Modül 3 | Ders 13 | Kuvvetler";
            for (int i = 0; i < 2; i++)
            {
                bool tamamlanmis = i == 1;
                Scene sahne = YeniSahne();
                NotEkle(klasor, baslik, tamamlanmis
                    ? "Bu sahne dersin sonundaki durumdur. ZiplayanKarakter betiği Karakter nesnesine eklenmiştir. Play tuşuna basın ve Game penceresine tıklayın. A ve D tuşları yürütür, boşluk tuşu zıplatır."
                    : "Bu sahne dersin başındaki durumdur. Arkadaki üç küp hazırdır. ZiplayanKarakter betiğini Karakter nesnesine siz ekleyeceksiniz.");
                Kamera(new Vector3(-1f, 4f, -10f), new Vector3(14f, 0f, 0f));
                Ilkel(PrimitiveType.Plane, "Zemin", new Vector3(0f, -0.02f, 3f), new Vector3(4f, 1f, 2f));

                // Aynı kuvvetin uygulandığı, kütleleri farklı üç küp. Zemine değmezler, yer çekimi kapalıdır.
                float[] kutleler = { 1f, 2f, 4f };
                Color[] renkler = { new Color(0.35f, 0.8f, 0.4f), new Color(1f, 0.8f, 0.2f), new Color(1f, 0.35f, 0.3f) };
                for (int k = 0; k < 3; k++)
                {
                    GameObject kup = Ilkel(PrimitiveType.Cube, "Kup" + kutleler[k] + "kg", new Vector3(-8f, 0.55f, 4f + k * 2f), Vector3.one);
                    Boya(kup, klasor, "Kup" + kutleler[k] + "kgMat", renkler[k]);
                    Rigidbody govde = kup.AddComponent<Rigidbody>();
                    govde.mass = kutleler[k];
                    govde.useGravity = false;
                    govde.linearDamping = 0f;
                    govde.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
                    kup.AddComponent<KuvvetUygula>();
                }

                GameObject karakter = Ilkel(PrimitiveType.Capsule, "Karakter", new Vector3(0f, 1f, 0f), Vector3.one);
                Boya(karakter, klasor, "KarakterMat", new Color(0.35f, 0.6f, 1f));
                if (tamamlanmis) karakter.AddComponent<ZiplayanKarakter>();
                Kaydet(sahne, klasor, tamamlanmis ? "Ders13_Tamamlanmis" : "Ders13_Baslangic");
            }
        });
    }

    [MenuItem("Egitim/Modul 3/Ders 14 sahnelerini kur")]
    public static void M3Ders14()
    {
        Modul3Icin(() =>
        {
            const string klasor = "Ders14_Carpisma_Tespiti";
            const string baslik = "Modül 3 | Ders 14 | Çarpışma Tespiti";
            for (int i = 0; i < 2; i++)
            {
                bool tamamlanmis = i == 1;
                Scene sahne = YeniSahne();
                NotEkle(klasor, baslik, tamamlanmis
                    ? "Bu sahne dersin sonundaki durumdur. TiklaSec betiği Main Camera nesnesine eklenmiştir. Play tuşuna basın ve Game penceresinde nesnelere tıklayın. Tıklanan nesne sarıya boyanır."
                    : "Bu sahne dersin başındaki durumdur. Üç örnek de hazırdır. TiklaSec betiğini Main Camera nesnesine siz ekleyeceksiniz.");
                Kamera(new Vector3(0f, 9f, -16f), new Vector3(28f, 0f, 0f));
                Ilkel(PrimitiveType.Plane, "Zemin", new Vector3(0f, -0.02f, 0f), new Vector3(3f, 1f, 2f));

                // Soldaki örnek. Merkezleri arası 3.5, yarıçapları 1 ve 1.5 olan iki küre.
                GameObject daireOrnegi = new GameObject("DaireOrnegi");
                daireOrnegi.transform.position = new Vector3(-9f, 0f, 0f);
                GameObject daireA = Ilkel(PrimitiveType.Sphere, "DaireA", new Vector3(-10.75f, 1.5f, 0f), new Vector3(2f, 2f, 2f));
                GameObject daireB = Ilkel(PrimitiveType.Sphere, "DaireB", new Vector3(-7.25f, 1.5f, 0f), new Vector3(3f, 3f, 3f));
                daireA.transform.SetParent(daireOrnegi.transform, true);
                daireB.transform.SetParent(daireOrnegi.transform, true);
                Boya(daireA, klasor, "AcikMaviMat", new Color(0.55f, 0.75f, 1f));
                Boya(daireB, klasor, "AcikMaviMat", new Color(0.55f, 0.75f, 1f));
                DaireCarpisma dc = daireA.AddComponent<DaireCarpisma>();
                Deger(dc, "diger", daireB.transform);

                // Ortadaki örnek. X ekseninde ayrı, Y ve Z eksenlerinde örtüşen iki kutu.
                GameObject kutuOrnegi = new GameObject("KutuOrnegi");
                GameObject kutuA = Ilkel(PrimitiveType.Cube, "KutuA", new Vector3(-1f, 1f, 0f), new Vector3(2f, 2f, 2f));
                GameObject kutuB = Ilkel(PrimitiveType.Cube, "KutuB", new Vector3(1.75f, 1f, 0f), new Vector3(1.5f, 1.5f, 1.5f));
                kutuA.transform.SetParent(kutuOrnegi.transform, true);
                kutuB.transform.SetParent(kutuOrnegi.transform, true);
                Boya(kutuA, klasor, "GriMat", new Color(0.75f, 0.75f, 0.75f));
                Boya(kutuB, klasor, "GriMat", new Color(0.75f, 0.75f, 0.75f));
                KutuCarpisma kc = kutuA.AddComponent<KutuCarpisma>();
                Deger(kc, "diger", kutuB.transform);

                // Sağdaki örnek. Tıklanarak seçilecek nesneler.
                GameObject tiklamaOrnegi = new GameObject("TiklamaOrnegi");
                tiklamaOrnegi.transform.position = new Vector3(9.5f, 0f, 0f);
                GameObject kup = Ilkel(PrimitiveType.Cube, "Kup", new Vector3(8f, 0.5f, -1f), Vector3.one);
                GameObject silindir = Ilkel(PrimitiveType.Cylinder, "Silindir", new Vector3(10f, 1f, 1f), Vector3.one);
                GameObject kapsul = Ilkel(PrimitiveType.Capsule, "Kapsul", new Vector3(11.5f, 1f, -1f), Vector3.one);
                foreach (GameObject nesne in new[] { kup, silindir, kapsul }) nesne.transform.SetParent(tiklamaOrnegi.transform, true);

                if (tamamlanmis) GameObject.Find("Main Camera").AddComponent<TiklaSec>();
                Kaydet(sahne, klasor, tamamlanmis ? "Ders14_Tamamlanmis" : "Ders14_Baslangic");
            }
        });
    }

    [MenuItem("Egitim/Modul 3/Ders 15 sahnelerini kur")]
    public static void M3Ders15()
    {
        Modul3Icin(() =>
        {
            const string klasor = "Ders15_Carpisma_Tepkisi";
            const string baslik = "Modül 3 | Ders 15 | Çarpışma Tepkisi ve Modül Projesi";
            for (int i = 0; i < 2; i++)
            {
                bool tamamlanmis = i == 1;
                Scene sahne = YeniSahne();
                NotEkle(klasor, baslik, tamamlanmis
                    ? "Bu sahne dersin sonundaki durumdur. BilardoMasasi ve Istaka betikleri Masa nesnesine eklenmiştir. Play tuşuna basın, beyaz top ilk vuruşu kendiliğinden yapar."
                    : "Bu sahne dersin başındaki durumdur. Masa, duvarlar, cepler ve toplar hazırdır. BilardoMasasi ve Istaka betiklerini Masa nesnesine siz ekleyeceksiniz.");
                Kamera(new Vector3(0f, 10f, -5.5f), new Vector3(62f, 0f, 0f));

                // Masa 12 metreye 6 metredir. Toplar masanın çocuğudur.
                GameObject masa = new GameObject("Masa");
                GameObject kumas = Ilkel(PrimitiveType.Cube, "Kumas", new Vector3(0f, -0.1f, 0f), new Vector3(12f, 0.2f, 6f));
                kumas.transform.SetParent(masa.transform, true);
                Boya(kumas, klasor, "KumasMat", new Color(0.1f, 0.45f, 0.25f));

                GameObject duvarlar = new GameObject("Duvarlar");
                duvarlar.transform.SetParent(masa.transform, true);
                Vector3[] duvarKonum = { new Vector3(0f, 0.1f, 3.2f), new Vector3(0f, 0.1f, -3.2f), new Vector3(6.2f, 0.1f, 0f), new Vector3(-6.2f, 0.1f, 0f) };
                Vector3[] duvarOlcek = { new Vector3(12.8f, 0.4f, 0.4f), new Vector3(12.8f, 0.4f, 0.4f), new Vector3(0.4f, 0.4f, 6f), new Vector3(0.4f, 0.4f, 6f) };
                string[] duvarAd = { "UstDuvar", "AltDuvar", "SagDuvar", "SolDuvar" };
                for (int d = 0; d < 4; d++)
                {
                    GameObject duvar = Ilkel(PrimitiveType.Cube, duvarAd[d], duvarKonum[d], duvarOlcek[d]);
                    duvar.transform.SetParent(duvarlar.transform, true);
                    Boya(duvar, klasor, "DuvarMat", new Color(0.45f, 0.28f, 0.15f));
                }

                GameObject cepler = new GameObject("Cepler");
                cepler.transform.SetParent(masa.transform, true);
                int cepNo = 1;
                for (int sx = -1; sx <= 1; sx += 2)
                {
                    for (int sz = -1; sz <= 1; sz += 2)
                    {
                        GameObject cep = Ilkel(PrimitiveType.Cylinder, "Cep" + cepNo++, new Vector3(sx * 6f, 0.005f, sz * 3f), new Vector3(1.1f, 0.01f, 1.1f));
                        cep.transform.SetParent(cepler.transform, true);
                        Boya(cep, klasor, "CepMat", new Color(0.05f, 0.05f, 0.05f));
                    }
                }

                GameObject beyaz = Ilkel(PrimitiveType.Sphere, "BeyazTop", new Vector3(-3.5f, 0.25f, 0f), new Vector3(0.5f, 0.5f, 0.5f));
                beyaz.transform.SetParent(masa.transform, true);
                Boya(beyaz, klasor, "BeyazMat", Color.white);
                BilardoTopu beyazTop = beyaz.AddComponent<BilardoTopu>();

                // Üçgen dizilmiş altı renkli top.
                Color[] renkler = { new Color(1f, 0.25f, 0.2f), new Color(1f, 0.8f, 0.1f), new Color(0.2f, 0.4f, 1f), new Color(1f, 0.5f, 0.1f), new Color(0.6f, 0.25f, 0.8f), new Color(0.1f, 0.6f, 0.3f) };
                int no = 0;
                for (int satir = 0; satir < 3; satir++)
                {
                    for (int j = 0; j <= satir; j++)
                    {
                        Vector3 konum = new Vector3(2.5f + satir * 0.45f, 0.25f, (j - satir * 0.5f) * 0.52f);
                        GameObject top = Ilkel(PrimitiveType.Sphere, "Top" + (no + 1), konum, new Vector3(0.5f, 0.5f, 0.5f));
                        top.transform.SetParent(masa.transform, true);
                        Boya(top, klasor, "Top" + (no + 1) + "Mat", renkler[no]);
                        top.AddComponent<BilardoTopu>();
                        no++;
                    }
                }

                // Nişan çizgisi. Istaka betiği fare basılıyken açar.
                GameObject nisan = new GameObject("NisanCizgisi", typeof(LineRenderer));
                LineRenderer cizgi = nisan.GetComponent<LineRenderer>();
                cizgi.positionCount = 2;
                cizgi.useWorldSpace = true;
                cizgi.startWidth = 0.05f;
                cizgi.endWidth = 0.05f;
                cizgi.SetPosition(0, beyaz.transform.position);
                cizgi.SetPosition(1, beyaz.transform.position + Vector3.right);
                KlasorOlustur(Kok + klasor + "/Materyaller");
                string cizgiYolu = Kok + klasor + "/Materyaller/NisanMat.mat";
                Material cizgiMat = AssetDatabase.LoadAssetAtPath<Material>(cizgiYolu);
                if (cizgiMat == null)
                {
                    cizgiMat = new Material(Shader.Find("Universal Render Pipeline/Unlit"));
                    AssetDatabase.CreateAsset(cizgiMat, cizgiYolu);
                }
                cizgiMat.SetColor("_BaseColor", Color.white);
                EditorUtility.SetDirty(cizgiMat);
                cizgi.sharedMaterial = cizgiMat;
                cizgi.enabled = false;

                if (tamamlanmis)
                {
                    BilardoMasasi bm = masa.AddComponent<BilardoMasasi>();
                    Deger(bm, "beyazTop", beyazTop);
                    Deger(bm, "baslangicAtisi", new Vector3(10f, 0f, 0.3f));
                    Istaka istaka = masa.AddComponent<Istaka>();
                    Deger(istaka, "beyazTop", beyazTop);
                    Deger(istaka, "nisanCizgisi", cizgi);
                }
                Kaydet(sahne, klasor, tamamlanmis ? "Ders15_Tamamlanmis" : "Ders15_Baslangic");
            }
        });
    }
}
