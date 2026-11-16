# Modül 3 | Ders 14 | Çarpışma Tespiti

## Bu Uygulamada Ne Yapıyoruz

Üç küçük örnekle çarpışma tespitini inceliyoruz. Soldaki örnekte iki kürenin çarpışmasını uzaklıkla, ortadaki örnekte iki kutunun kesişimini eksen eksen sınıyoruz. Sağdaki örnekte fare konumundan sahneye bir ışın gönderiyor ve ışının çarptığı nesneyi seçiyoruz.

## Sahneler

| Sahne | İçerik |
| --- | --- |
| Ders14_Baslangic | Üç örnek de sahnededir. TiklaSec betiğini Main Camera nesnesine siz ekleyeceksiniz. |
| Ders14_Tamamlanmis | TiklaSec betiği Main Camera nesnesine eklenmiştir. Play modunda tıklanan nesne sarıya boyanır. |

## Betikler

| Betik | Ne yapar |
| --- | --- |
| DaireCarpisma | İki kürenin çarpışmasını merkezler arası uzaklık ve yarıçaplarla sınar. Sonucu renkle gösterir. |
| KutuCarpisma | İki nesnenin eksen hizalı sınır kutularının kesişimini eksen eksen sınar. |
| TiklaSec | Fare konumundan ışın gönderir ve çarpılan nesneyi seçer. Işını ve yüzey normalini çizer. |

## Tuşlar

| Tuş | Etki |
| --- | --- |
| Farenin sol tuşu | Play modunda Game penceresinde tıklanan nesneyi seçer. |

## Adım Adım

1. Ders14_Baslangic sahnesini açın. Hierarchy'de DaireOrnegi nesnesini seçin ve Scene penceresinde F tuşuna basın. Çemberler yeşildir. Yazıda uzaklık 3.5 ve yarıçaplar toplamı 2.5 görünür.
2. DaireB nesnesini DaireA nesnesine doğru sürükleyin. Uzaklık 2.5 değerinin altına indiğinde çemberler kırmızıya döner. DaireB nesnesinin Scale değerini 5, 5, 5 yaparak yarıçapın etkisini görün. Sonra ölçeği 3, 3, 3 yapın ve küreyi eski yerine alın.
3. KutuOrnegi nesnesini seçin ve F tuşuna basın. Yazıda X ekseninde ayrı, Y ve Z eksenlerinde örtüşme görünür. KutuB nesnesini sola sürükleyin. X ekseninde de örtüşme başladığında kutular kırmızıya döner.
4. KutuB nesnesinin Position Y değerini 4 yapın. Y ekseninde ayrıldıkları için kesişim biter. Değeri yeniden 1 yapın ve kutuyu eski yerine alın.
5. KutuA nesnesinin Rotation Y değerini 45 yapın. Küp döner ama sınır kutusu dönmez, büyür. Değeri yeniden 0 yapın.
6. Project penceresinde Betikler klasöründeki TiklaSec betiğini açın. Update fonksiyonunda ışının üretildiği ve gönderildiği satırları bulun.
7. TiklaSec betiğini Main Camera nesnesine ekleyin ve Play tuşuna basın. Game penceresinde sağdaki nesnelere tıklayın. Tıklanan nesne sarıya boyanır. Scene penceresinde gönderilen ışını ve yüzey normalini görün.
8. Zemine, gökyüzüne ve soldaki kürelere tıklayın. Zemin seçildiğinde çarpma noktası tıklanan yerin koordinatlarını verir. Play modundan çıkın.

## Ne Gördük

| Test | Gereken bilgi | Kural |
| --- | --- | --- |
| Küre ile küre | İki merkez ve iki yarıçap | Uzaklık yarıçapların toplamından küçükse çarpışır |
| Kutu ile kutu | Her kutunun min ve max köşeleri | Üç eksenin üçünde de örtüşüyorsa kesişir |
| Işın ile sahne | Başlangıç noktası ve yön | Işının çarptığı ilk çarpıştırıcı bulunur |

## Kendiniz Deneyin

* DaireA nesnesini DaireB nesnesinin tam üstüne, Y ekseninde 3 birim yukarı taşıyın. Çemberler ne renk? Neden?
* SecimOrnegi altındaki Kup nesnesinde Box Collider bileşenini kapatın. Play modunda küpe tıkladığınızda ne seçiliyor?
* TiklaSec bileşeninde Menzil değerini 5 yapın. Hangi nesneler artık seçilemiyor?
* KutuA nesnesini üç eksende de 45 derece döndürün. Sınır kutusu küpün kaç katı kadar yer kaplıyor?

## Dikkat

Çemberler, tel kutular ve ışın Gizmos ile çizilir. Görünmüyorsa Scene penceresinin araç çubuğundaki Gizmos düğmesinin açık olduğunu denetleyin. Tıklamaların algılanması için Play modunda Game penceresinin etkin olması gerekir. Işın yalnızca Collider bileşeni olan nesnelere çarpar.
