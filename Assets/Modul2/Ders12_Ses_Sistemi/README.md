# Modül 2 | Ders 12 | Ses Sistemi

## Bu Uygulamada Ne Yapıyoruz

Dört iş yapıyoruz. Arka plan müziği çalan bir kaynak kuruyoruz. Radyoyu, uzaklaştıkça sesi azalan üç boyutlu bir ses kaynağı yapıyoruz. Kısa bir efekti her seferinde biraz farklı perdeyle çalıyoruz. Son olarak Audio Mixer ile ses gruplarını yönetiyor ve duraklatma anında müziği boğuklaştırıyoruz.

## Klasörler

| Klasör | İçerik |
| --- | --- |
| Sesler | muzik, radyo ve tik ses dosyaları bulunur. Üçü de bu eğitim için üretilmiştir ve serbestçe kullanılabilir. |
| Betikler | EfektCal ve hazır gelen KlavyeHareket betikleri bulunur. |
| AnaMixer | Muzik ve Efekt grupları ile Normal ve Duraklat anlık görüntülerini içeren Audio Mixer varlığıdır. |
| Tamamlanmis | Lowpass efekti eklenmiş AnaMixer_Tamamlanmis varlığı bulunur. |

## Sahneler

| Sahne | İçerik |
| --- | --- |
| Ders12_Baslangic | Zemin, W A S D tuşlarıyla hareket eden Oyuncu ve Radyo adlı küp bulunur. Kamera Oyuncu nesnesinin çocuğudur. Ses kaynağı yoktur. |
| Ders12_Tamamlanmis | Muzik nesnesi, üç boyutlu ses çalan Radyo ve EfektCal eklenmiş Oyuncu bulunur. Ses kaynakları mixer gruplarına bağlıdır. |

## Tuşlar

| Tuş | Etki |
| --- | --- |
| W A S D | Oyuncuyu hareket ettirir |
| Boşluk | Tık efektini çalar |
| P | Normal ve Duraklat anlık görüntüleri arasında geçer |

## Adım Adım

1. Ders12_Baslangic sahnesini açın. Main Camera nesnesini seçin ve Audio Listener bileşenini bulun. Hierarchy'de boş bir nesne oluşturun, adını Muzik yapın ve Audio Source ekleyin. AudioClip alanına muzik dosyasını sürükleyin. Play On Awake açık kalsın, Loop kutusunu açın ve Play tuşuna basın.
2. Radyo nesnesini seçin, Audio Source ekleyin, radyo dosyasını atayın ve Loop kutusunu açın. Spatial Blend değerini 1 yapın. Min Distance 1, Max Distance 10 olsun. Play modunda Game penceresine tıklayın ve W A S D tuşlarıyla radyoya yaklaşıp uzaklaşın.
3. Play modundayken Radyo nesnesinde Volume Rolloff ayarını Logarithmic yerine Linear Rolloff yapın ve alttaki sönüm eğrisine bakın. Play modundan çıkın.
4. Oyuncu nesnesini seçin ve EfektCal betiğini ekleyin. Tik alanına tik dosyasını, Normal ve Duraklat alanlarına AnaMixer içindeki aynı adlı anlık görüntüleri sürükleyin. Play modunda Boşluk tuşuna art arda basın.
5. Window menüsünden Audio, Audio Mixer penceresini açın ve AnaMixer içindeki Master, Muzik ve Efekt gruplarını bulun. Muzik nesnesindeki Audio Source bileşeninin Output alanına Muzik grubunu, Oyuncu ve Radyo nesnelerinin Output alanına Efekt grubunu atayın. Play modunda Muzik grubunun kaydırıcısını indirin.
6. Muzik grubunu seçin, Add Effect düğmesiyle Lowpass ekleyin. Snapshots bölümünde Normal seçiliyken Cutoff freq değerini 22000 yapın. Duraklat seçiliyken 800 yapın. Play modunda P tuşuna basın, müzik boğuklaşır. Yeniden basın, müzik açılır.

## Ne Gördük

| Parça | Görevi |
| --- | --- |
| AudioClip | Ses dosyasının kendisidir |
| Audio Source | Sesi sahnede bir noktadan çalar |
| Audio Listener | Sesi duyan noktadır, sahnede bir tane bulunur |
| Spatial Blend | 0 değerinde ses her yerde aynıdır, 1 değerinde uzaklığa göre değişir |
| Audio Mixer | Sesleri gruplar, efekt ekler ve anlık görüntüler arasında geçiş yapar |

## Kendiniz Deneyin

* Radyo nesnesinde Spatial Blend değerini 0.5 yapın. Uzaklaşınca ses tamamen kayboluyor mu?
* EfektCal betiğindeki perde aralığını 0.5 ile 1.5 yapın. Efekt nasıl duyuluyor?
* Duraklat anlık görüntüsünde Efekt grubunun ses düzeyini eksi 80 yapın. P tuşuna bastıktan sonra tık efekti duyuluyor mu?

## Dikkat

Sesi duyabilmek için Game penceresinin üstündeki Mute Audio düğmesinin kapalı olduğundan emin olun. Sahnede birden fazla Audio Listener bulunursa Unity Console'da uyarı verir.
