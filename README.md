# Turkcell Geleceği Yazanlar Oyun Programlama Bootcamp'i — Unity Proje Dosyaları

Bu depo, **Turkcell Geleceği Yazanlar Oyun Programlama Bootcamp'i** kapsamında hazırlanan kayıtlı derslere ait Unity sahnelerini, betikleri ve ders notlarını içerir. Bootcamp'in oyun programlama eğitimi **Rysesoft** tarafından yürütülmektedir.

Depoda şu an **Modül 2** ve **Modül 3** dersleri yer almaktadır. Her dersin kendi klasörü vardır; videoyu izlerken aynı adımları kendi bilgisayarınızda uygulayabilirsiniz.

---

## Program Hakkında

| | |
|---|---|
| **Program** | Turkcell Geleceği Yazanlar Oyun Programlama Bootcamp'i |
| **Organizatör** | Turkcell Geleceği Yazanlar |
| **Eğitim Sağlayıcı** | Rysesoft |
| **Eğitmen** | Can Karabulut |
| **Tarihler** | 24 Aralık 2026 – 20 Mayıs 2027 |
| **Süre** | 16 hafta, 120 saat |
| **Format** | Çevrim içi, Türkçe |
| **Seviye** | Başlangıç |

Program, Unity ile masaüstü 3D oyun geliştirmeye odaklanır. İlk 12 hafta canlı derslerle ilerler. Son 4 haftalık uygulama döneminde katılımcılar takım hâlinde ortak bir oyun geliştirir, oyunu Steam'de yayımlar ve Demo Day'de jüriye sunar.

Programın tüm ayrıntıları için: [Program sayfası](https://www.rysesoft.com/tr/training/gelecegi-yazanlar-game-programming-bootcamp)

Bootcamp'e eşlik eden kayıtlı dersler dört modülden oluşur. Her modülde yaklaşık 20 dakikalık 15 ders bulunur.

| Modül | Başlık | Bu depoda |
|---|---|---|
| Modül 1 | Temel Oyun Teknolojileri ve Oyun Tasarımına Giriş | — |
| **Modül 2** | **Oyun Motorları ve Çalışma Prensipleri** | ✅ |
| **Modül 3** | **Hesaplamalı Geometri, Matematik ve Fizik** | ✅ |
| Modül 4 | Unity ile Oyun Programlamaya Giriş ve İlk Oyun | — |

---

## Gereksinimler

- **Unity:** 6000.3.26f1 (Unity 6.3). Projeyi bu sürümle açmanız önerilir. Farklı bir sürümle açıldığında Unity projeyi yükseltmeyi teklif eder.
- **Input System** paketi (3D URP şablonunda hazır gelir)

## Projeyi Açma

1. Depoyu klonlayın ya da **Code > Download ZIP** ile indirin:
   ```
   git clone https://github.com/KarabulutCan/turkcell-gy-unity-moduller.git
   ```
2. Unity Hub'da **Add > Add project from disk** ile indirdiğiniz klasörü seçin.
3. Proje ilk açılışta `Library` klasörünü yeniden üretir. Bu işlem birkaç dakika sürebilir.

## Notları Nereden Okurum

Notlar üç yerde bulunur.

| Yer | Ne işe yarar |
| --- | --- |
| Ders klasöründeki README.md | Dersin amacı, adımlar ve denenecek değişiklikler |
| Sahnedeki _DERS NOTU nesnesi | Hierarchy'de seçildiğinde aynı adımlar Inspector'da görünür |
| Betiklerdeki açıklama satırları | Her fonksiyonun ne yaptığı kodun hemen üstünde yazar |

## Sahneler

Uygulaması olan her derste iki sahne vardır.

| Sahne | İçerik |
| --- | --- |
| Baslangic | Dersin başındaki durum. Adımları bu sahnede kendiniz uygularsınız. |
| Tamamlanmis | Dersin sonundaki durum. Takıldığınızda karşılaştırmak için kullanırsınız. |

---

## Modül 2 | Oyun Motorları ve Çalışma Prensipleri

Oyun döngüsünden ilk build'e kadar bir oyun motorunun nasıl çalıştığını ve Unity editörünü ele alır.

| Ders | Konu | Klasör |
| --- | --- | --- |
| 1 | Oyun Motoru Nedir? | Assets/Modul2/Ders01_Oyun_Motoru_Nedir |
| 2 | Oyun Motorlarını Karşılaştırma | Assets/Modul2/Ders02_Oyun_Motorlarini_Karsilastirma |
| 3 | Oyun Döngüsü | Assets/Modul2/Ders03_Oyun_Dongusu |
| 4 | Zaman Yönetimi | Assets/Modul2/Ders04_Zaman_Yonetimi |
| 5 | Sahne ve Hiyerarşi | Assets/Modul2/Ders05_Sahne_ve_Hiyerarsi |
| 6 | Nesne Bileşen Mimarisi | Assets/Modul2/Ders06_Nesne_Bilesen_Mimarisi |
| 7 | Unity Editörünü Tanıma | Assets/Modul2/Ders07_Unity_Editorunu_Tanima |
| 8 | Varlık Yönetimi | Assets/Modul2/Ders08_Varlik_Yonetimi |
| 9 | Render | Assets/Modul2/Ders09_Render |
| 10 | Işık ve Gölge | Assets/Modul2/Ders10_Isik_ve_Golge |
| 11 | Fizik Motoru | Assets/Modul2/Ders11_Fizik_Motoru |
| 12 | Ses Sistemi | Assets/Modul2/Ders12_Ses_Sistemi |
| 13 | Girdi Sistemleri | Assets/Modul2/Ders13_Girdi_Sistemleri |
| 14 | Performans Hesaplamaları | Assets/Modul2/Ders14_Performans_Hesaplamalari |
| 15 | Derleme ve Dağıtım | Assets/Modul2/Ders15_Derleme_ve_Dagitim |

## Modül 3 | Hesaplamalı Geometri, Matematik ve Fizik

Hareket, yön ve çarpışmanın arkasındaki matematiği işler. Her konu, formüle geçilmeden önce Unity içinde görsel olarak gösterilir.

| Ders | Konu | Klasör |
| --- | --- | --- |
| 1 | Koordinat Sistemleri | Assets/Modul3/Ders01_Koordinat_Sistemleri |
| 2 | Vektörler I | Assets/Modul3/Ders02_Vektorler_I |
| 3 | Vektörler II | Assets/Modul3/Ders03_Vektorler_II |
| 4 | Nokta Çarpım | Assets/Modul3/Ders04_Nokta_Carpim |
| 5 | Çapraz Çarpım | Assets/Modul3/Ders05_Capraz_Carpim |
| 6 | Trigonometri | Assets/Modul3/Ders06_Trigonometri |
| 7 | Dönüşümler | Assets/Modul3/Ders07_Donusumler |
| 8 | Matrislere Giriş | Assets/Modul3/Ders08_Matrislere_Giris |
| 9 | Döndürme | Assets/Modul3/Ders09_Dondurme |
| 10 | İnterpolasyon | Assets/Modul3/Ders10_Interpolasyon |
| 11 | Rastgelelik ve Prosedürel Üretim | Assets/Modul3/Ders11_Rastgelelik |
| 12 | Kinematik | Assets/Modul3/Ders12_Kinematik |
| 13 | Kuvvetler | Assets/Modul3/Ders13_Kuvvetler |
| 14 | Çarpışma Tespiti | Assets/Modul3/Ders14_Carpisma_Tespiti |
| 15 | Çarpışma Tepkisi ve Modül Projesi | Assets/Modul3/Ders15_Carpisma_Tepkisi |

## Sahneleri İlk Hâline Döndürme

Bir sahneyi bozduysanız Unity'nin üst menüsünden **Egitim** başlığı altında ilgili modülün komutunu çalıştırın. Komut o dersin sahnelerini yeniden kurar.

---

## Kullanım Koşulları

Bu depodaki içerikler, Turkcell Geleceği Yazanlar Oyun Programlama Bootcamp'i katılımcılarının eğitim amaçlı kullanımı için hazırlanmıştır.

## Bağlantılar

- [Program sayfası (Türkçe)](https://www.rysesoft.com/tr/training/gelecegi-yazanlar-game-programming-bootcamp)
- [Program page (English)](https://www.rysesoft.com/training/gelecegi-yazanlar-game-programming-bootcamp)
- [Program duyurusu](https://www.rysesoft.com/tr/news/gelecegi-yazanlar-game-programming-bootcamp)
- [Rysesoft eğitim programları](https://www.rysesoft.com/tr/training)
- [Rysesoft](https://www.rysesoft.com/tr)

## İletişim

**Rysesoft**  
E-posta: info@rysesoft.com  
[LinkedIn](https://www.linkedin.com/company/rysesoft/) · [Instagram](https://www.instagram.com/rysesoft/) · [Discord](https://discord.com/invite/2aFKcp7heg) · [Steam](https://store.steampowered.com/developer/RYSESOFT)

---

<sub>Bu depo Turkcell Geleceği Yazanlar programı için Rysesoft tarafından hazırlanmıştır.</sub>
