# Modül 3 | Ders 3 | Vektörler II

## Bu Uygulamada Ne Yapıyoruz

Bir küpü bir küreye doğru sabit hızla yürütüyoruz. Yönü hedef eksi konum işlemiyle buluyor ve normalize ediyoruz. Ardından normalizasyonu kapatarak hızın nasıl bozulduğunu ve durma mesafesini sıfırlayarak nesnenin hedefte nasıl titrediğini izliyoruz.

## Sahneler

| Sahne | İçerik |
| --- | --- |
| Ders03_Baslangic | Zemin, Takipci ve Hedef bulunur. HedefeGit betiğini Takipci nesnesine siz ekleyeceksiniz. |
| Ders03_Tamamlanmis | HedefeGit betiği Takipci nesnesine eklenmiş ve Hedef alanı doldurulmuştur. Play tuşuna basıldığında Takipci hedefe gider. |

## Betikler

| Betik | Ne yapar |
| --- | --- |
| HedefeGit | Nesneyi Hedef alanındaki nesneye doğru yürütür. Hiz, Normalize Et ve Durma Mesafesi değerleri Inspector'dan ayarlanır. |

## Adım Adım

1. Ders03_Baslangic sahnesini açın. Project penceresinde Betikler klasöründeki HedefeGit betiğini açın ve Update fonksiyonunu okuyun. Fark vektörünün, yönün ve hareketin hesaplandığı satırları bulun.
2. Hierarchy'de Takipci nesnesini seçin. HedefeGit betiğini Inspector'a sürükleyin. Hierarchy'deki Hedef nesnesini betiğin Hedef alanına sürükleyin.
3. Scene penceresine bakın. İki nesne arasında kesikli bir çizgi, Takipci üzerinde kısa sarı bir ok görünür. Sarı ok normalize edilmiş yöndür. Üstündeki yazı uzaklığı 10.82 olarak gösterir.
4. Play tuşuna basın. Takipci hedefe doğru sabit hızla ilerler ve varınca durur.
5. Play modundayken Scene penceresinde Hedef nesnesini sürükleyin. Takipci yön değiştirerek hedefi izler. Sarı okun boyu değişmez.
6. Play modundan çıkın. Normalize Et kutusunun işaretini kaldırın ve yeniden Play tuşuna basın. Takipci önce çok hızlı gider, hedefe yaklaştıkça yavaşlar. Play modundan çıkın ve kutuyu yeniden işaretleyin.
7. Hiz değerini 6 yapın ve Play tuşuna basın. Takipci iki kat hızlı gider. Play modundan çıkın.
8. Durma Mesafesi değerini 0 yapın ve Play tuşuna basın. Takipci hedefe varınca durmaz, hedefin üzerinde titrer. Play modundan çıkın ve değeri yeniden 0.1 yapın.

## Ne Gördük

| Ayar | Sonuç |
| --- | --- |
| Normalize Et işaretli | Hız sabittir ve yalnızca Hiz değerine bağlıdır |
| Normalize Et işaretsiz | Hız uzaklıkla çarpılır. Nesne uzakta hızlı, yakında yavaş gider |
| Hiz iki katına çıkarılırsa | Nesne aynı yolu yarı sürede alır |
| Durma Mesafesi 0 | Nesne hedefi aşar ve hedefin çevresinde titrer |
| Hedef Play modunda taşınırsa | Yön her karede yeniden hesaplandığı için nesne hedefi izler |

## Kendiniz Deneyin

* HedefeGit betiğindeki hareket satırını `Vector3.MoveTowards` kullanarak yeniden yazın. Durma Mesafesi 0 iken titreme sürüyor mu?
* Hedef nesnesini Takipci nesnesinin tam üstüne, 5 birim yukarı taşıyın. Takipci nasıl davranıyor?
* Takipci nesnesinin hedeften kaçması için betikte tek bir işareti değiştirmeniz yeterlidir. Hangisi?

## Dikkat

Kesikli çizgi, sarı ok ve uzaklık yazısı Gizmos ile çizilir. Görünmüyorsa Scene penceresinin araç çubuğundaki Gizmos düğmesinin açık olduğunu denetleyin. Play modunda yapılan Inspector değişiklikleri Play modundan çıkıldığında geri alınır. Kalıcı olması istenen değerler Play modu dışında girilmelidir.
