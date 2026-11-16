# Modül 3 | Ders 4 | Nokta Çarpım

## Bu Uygulamada Ne Yapıyoruz

Bir düşmana görüş konisi veriyoruz. Düşmanın ileri yönü ile oyuncuya giden yönün nokta çarpımını alıyor, sonucu bir eşikle karşılaştırıyoruz. Oyuncuyu sahnede gezdirerek nokta çarpımın, açının ve uzaklığın nasıl değiştiğini ve düşmanın oyuncuyu ne zaman gördüğünü izliyoruz.

## Sahneler

| Sahne | İçerik |
| --- | --- |
| Ders04_Baslangic | Zemin, Dusman ve Oyuncu bulunur. GorusKonisi betiğini Dusman nesnesine siz ekleyeceksiniz. |
| Ders04_Tamamlanmis | GorusKonisi betiği Dusman nesnesine eklenmiş ve Hedef alanı doldurulmuştur. |

## Betikler

| Betik | Ne yapar |
| --- | --- |
| GorusKonisi | Hedefin menzil ve görüş açısı içinde olup olmadığını hesaplar. Koniyi çizer, sayıları yazar ve Play modunda düşmanı boyar. |

## Adım Adım

1. Ders04_Baslangic sahnesini açın. Project penceresinde Betikler klasöründeki GorusKonisi betiğini açın ve Hesapla fonksiyonunu okuyun. Nokta çarpımın ve eşiğin hesaplandığı satırları bulun.
2. Hierarchy'de Dusman nesnesini seçin. GorusKonisi betiğini Inspector'a sürükleyin. Hierarchy'deki Oyuncu nesnesini betiğin Hedef alanına sürükleyin. Zeminde görüş konisi belirir. Oyuncu tam karşıda olduğu için nokta çarpım 1, açı 0 görünür ve koni kırmızıdır.
3. Oyuncu nesnesini seçin ve Position X değerini 2 yapın. Nokta çarpım 0.89, açı 27 olur. Değer eşiğin üstünde olduğu için koni kırmızı kalır.
4. Oyuncu konumunu 5, 0.5, 2 yapın. Uzaklık 5.39 ile menzilin içindedir ama nokta çarpım 0.37 değerine düşer. Koni sarıya döner.
5. Oyuncu konumunu 0, 0.5, -4 yapın. Nokta çarpım -1 olur ve yazıda arkada sözcüğü görünür.
6. Oyuncu konumunu 0, 0.5, 8 yapın. Nokta çarpım 1 olmasına karşın uzaklık menzili aştığı için koni sarı kalır. Oyuncuyu 2, 0.5, 4 konumuna geri alın.
7. Dusman nesnesini seçin ve Rotation Y değerini 90 yapın. Koni düşmanla birlikte döner ve oyuncu koninin dışında kalır. Değeri yeniden 0 yapın.
8. Play tuşuna basın. Scene penceresinde Oyuncu nesnesini sürükleyin. Oyuncu koninin içine girdiğinde Dusman kırmızıya, çıktığında griye döner.
9. Play modundayken Dusman nesnesinde Gorus Acisi değerini 180 yapın. Düşman menzil içinde önündeki her şeyi görür. Play modundan çıkın.

## Ne Gördük

| Durum | Nokta çarpım | Sonuç |
| --- | --- | --- |
| Oyuncu tam karşıda ve yakın | 1 | Görüyor |
| Oyuncu koninin içinde | 0.71 ile 1 arası | Görüyor |
| Oyuncu yanda | 0 ile 0.71 arası | Görmüyor |
| Oyuncu arkada | Eksi değer | Görmüyor |
| Oyuncu karşıda ama uzak | 1 | Görmüyor, menzilin dışında |

## Kendiniz Deneyin

* Gorus Acisi değerini 30 yapın. Eşik kaç olur? Oyuncuyu koninin tam kenarına getirip nokta çarpımı okuyun.
* Menzil değerini 3 yapın ve oyuncuyu düşmana doğru yürütün. Koni hangi uzaklıkta kırmızıya dönüyor?
* Oyuncu nesnesinin Y değerini 5 yapın. Nokta çarpım ve açı nasıl değişiyor? Neden?
* Betikte koşuldaki büyüktür işaretini küçüktür yapın. Düşman artık nereyi görüyor?

## Dikkat

Koni ve yazı Gizmos ile çizilir. Görünmüyorsa Scene penceresinin araç çubuğundaki Gizmos düğmesinin açık olduğunu denetleyin. Düşmanın rengi yalnızca Play modunda değişir. Play modu dışında görme durumunu koninin rengi gösterir.
