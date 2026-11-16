# Modül 3 | Ders 2 | Vektörler I

## Bu Uygulamada Ne Yapıyoruz

Vektörleri ok olarak çizen bir sahnede çalışıyoruz. Okların ucundaki küreleri sürükleyerek vektörleri değiştiriyoruz. Toplamayı, çıkarmayı, sayıyla çarpmayı ve uzunluğu hem ok olarak hem sayı olarak izliyoruz.

## Sahneler

| Sahne | İçerik |
| --- | --- |
| Ders02_Baslangic | Yalnızca A vektörü görünür. UcB, Toplam, Olcek ve Fark nesneleri kapalıdır, sırayla siz açacaksınız. |
| Ders02_Tamamlanmis | A ve B vektörleri, toplamları, A vektörünün iki katı ve A noktasından B noktasına giden vektör birlikte görünür. |

## Betikler

| Betik | Ne yapar |
| --- | --- |
| VektorGoster | Orijinden bulunduğu nesneye uzanan vektörü ok olarak çizer. Bileşenleri ve uzunluğu yazar. |
| VektorToplam | İki vektörün toplamını uç uca ekleme yöntemiyle çizer. |
| VektorOlcek | Bir vektörün Carpan değeriyle çarpımını çizer. |
| VektorFark | Birinci vektörün ucundan ikinci vektörün ucuna giden vektörü çizer. |

## Adım Adım

1. Ders02_Baslangic sahnesini açın. Scene penceresindeki 2D düğmesine basarak sahneye karşıdan bakın. Kırmızı ok A vektörüdür. Yanındaki yazıda bileşenleri 3, 1, 0 ve uzunluğu 3.16 görünür.
2. UcA nesnesini seçin ve taşıma aracıyla sürükleyin. Ok küreyi izler, sayılar güncellenir. Position değerini 3, 4, 0 yapın ve uzunluğun 5 olduğunu görün. Değeri yeniden 3, 1, 0 yapın.
3. Hierarchy'de UcB nesnesini seçin ve Inspector'ın en üstündeki kutuyu işaretleyerek nesneyi açın. Mavi ok B vektörüdür. Bileşenleri 1, 2, 0 ve uzunluğu 2.24 görünür.
4. Toplam nesnesini açın. Gri kesikli çizgi, A vektörünün ucuna taşınmış B vektörüdür. Beyaz ok toplamdır. Bileşenleri 4, 3, 0 ve uzunluğu 5 görünür.
5. UcB nesnesini sürükleyin ve toplamın nasıl değiştiğini izleyin. B vektörü A ile aynı yöne bakarken toplam en uzun, ters yöne bakarken en kısa halini alır. UcB konumunu yeniden 1, 2, 0 yapın.
6. Olcek nesnesini açın. Açık mavi ok A vektörünün iki katıdır. Inspector'da Carpan değerini sırasıyla 0.5 ve -1 yapın. Ok önce kısalır, sonra ters yöne döner.
7. Olcek nesnesini kapatın ve Fark nesnesini açın. Yeşil ok A vektörünün ucundan B vektörünün ucuna gider. Bileşenleri -2, 1, 0 görünür. Uzunluğu iki uç arasındaki uzaklıktır.
8. 2D düğmesine yeniden basarak 3D görünüme dönün. UcA nesnesinin Z değerini 2 yapın ve sahnenin çevresinde dönerek oklara farklı açılardan bakın.

## Ne Gördük

| İşlem | Sahnede görülen | Sayı |
| --- | --- | --- |
| A vektörü | Kırmızı ok | 3, 1, 0 ve uzunluk 3.16 |
| B vektörü | Mavi ok | 1, 2, 0 ve uzunluk 2.24 |
| A artı B | Beyaz ok | 4, 3, 0 ve uzunluk 5 |
| A vektörünün iki katı | Açık mavi ok | 6, 2, 0 ve uzunluk 6.32 |
| B eksi A | Yeşil ok | -2, 1, 0 ve uzunluk 2.24 |

## Kendiniz Deneyin

* UcB nesnesini öyle bir yere taşıyın ki toplam vektör sıfır olsun. UcB hangi konumda durmalı?
* Olcek nesnesinde Carpan değerini 0 yapın. Ok neden kayboluyor?
* UcA ve UcB nesnelerini aynı konuma getirin. Fark vektörünün uzunluğu kaç oluyor?
* Uzunluğu tam 10 olan ve bileşenlerinin hiçbiri sıfır olmayan bir A vektörü bulun.

## Dikkat

Oklar ve yazılar Gizmos ile çizilir. Görünmüyorsa Scene penceresinin araç çubuğundaki Gizmos düğmesinin açık olduğunu denetleyin. Kapalı bir nesnenin çizimi görünmez. Nesneyi açmak için Hierarchy'de seçin ve Inspector'ın en üstündeki kutuyu işaretleyin.
