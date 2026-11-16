# Modül 3 | Ders 5 | Çapraz Çarpım

## Bu Uygulamada Ne Yapıyoruz

Üç küçük örnekle çapraz çarpımı inceliyoruz. Ortadaki örnekte iki vektörün çapraz çarpımını ok olarak görüyoruz. Sağdaki örnekte bir üçgenin normalini buluyoruz. Soldaki örnekte bir gözcünün hedefini sağında mı solunda mı gördüğünü hesaplıyor ve gözcüyü hedefe kısa yoldan döndürüyoruz.

## Sahneler

| Sahne | İçerik |
| --- | --- |
| Ders05_Baslangic | Üç örnek de sahnededir. Gozcu nesnesine SagSolGoster betiğini siz ekleyeceksiniz. |
| Ders05_Tamamlanmis | SagSolGoster betiği Gozcu nesnesine eklenmiş, Hedef alanı doldurulmuş ve Hedefe Don kutusu işaretlenmiştir. |

## Betikler

| Betik | Ne yapar |
| --- | --- |
| CaprazGoster | İki vektörün çapraz çarpımını ve oluşturdukları paralelkenarı çizer. |
| UcgenNormal | Üç köşesi verilen üçgeni ve yüzey normalini çizer. |
| SagSolGoster | Hedefin sağda mı solda mı olduğunu bulur. Hedefe Don kutusu işaretliyse nesneyi hedefe döndürür. |
| VektorGoster | İkinci dersin betiğidir. A ve B vektörlerini ok olarak çizer. |

## Adım Adım

1. Ders05_Baslangic sahnesini açın. Hierarchy'de CaprazOrnegi nesnesini seçin ve Scene penceresinde F tuşuna basın. Kırmızı ok A, mavi ok B vektörüdür. Yeşil ok çapraz çarpımdır ve 0, 4, 0 değeriyle yukarı bakar.
2. UcB nesnesini A vektörüne doğru sürükleyin. Yeşil ok kısalır. UcB konumunu 0, 0, 3 yapın. İki vektör aynı yöne bakar ve çapraz çarpım sıfır olur.
3. UcB konumunu -2, 0, 0 yapın. Yeşil ok aşağı döner ve 0, -4, 0 değerini alır. Konumu yeniden 2, 0, 0 yapın.
4. NormalOrnegi nesnesini seçin ve F tuşuna basın. Üçgen yerde yatar ve normali yukarı bakar. KoseB nesnesinin Position Y değerini 2 yapın. Üçgen eğilir, normal yüzeye dik kalır.
5. Project penceresinde Betikler klasöründeki SagSolGoster betiğini açın ve Update fonksiyonunu okuyun. Çapraz çarpımın Y bileşeninin Rotate fonksiyonuna nasıl verildiğini bulun.
6. SagSolOrnegi nesnesini seçin ve F tuşuna basın. SagSolGoster betiğini Gozcu nesnesine ekleyin. Hedef nesnesini betiğin Hedef alanına sürükleyin. Yazıda çapraz çarpımın Y bileşeni 0.71 ve SAĞDA görünür.
7. Hedef nesnesini Gozcu nesnesinin soluna sürükleyin. Y bileşeni eksi olur, yazı SOLDA der ve yeşil ok aşağı döner.
8. Gozcu nesnesinde Hedefe Don kutusunu işaretleyin ve Play tuşuna basın. Scene penceresinde Hedef nesnesini sürükleyin. Gozcu hedefe her zaman kısa yoldan döner. Play modundan çıkın.

## Ne Gördük

| Gözlem | Sonuç |
| --- | --- |
| Zemindeki iki vektörün çapraz çarpımı | Zemine dik bir vektördür |
| B vektörü A vektörünün sağında | Sonuç yukarı bakar |
| B vektörü A vektörünün solunda | Sonuç aşağı bakar |
| A ve B aynı doğrultuda | Sonuç sıfır vektörüdür |
| Üçgen eğilirse | Normal yüzeye dik kalarak eğilir |
| Çapraz çarpımın Y bileşeni | Artıysa hedef sağda, eksiyse soldadır |

## Kendiniz Deneyin

* UcA ve UcB nesnelerini çapraz çarpımın uzunluğu 6 olacak biçimde yerleştirin. Birden çok çözüm var mı?
* NormalOrnegi nesnesinde UcgenNormal bileşeninin B ve C alanlarındaki nesnelerin yerini değiştirin. Normal hangi yöne bakıyor?
* Gozcu nesnesinde Donus Hizi değerini 30 ve 360 yaparak Play modunda deneyin.
* Hedef nesnesini Gozcu nesnesinin tam arkasına koyun. Gozcu hangi yöne dönüyor? Neden?

## Dikkat

Oklar ve yazılar Gizmos ile çizilir. Görünmüyorsa Scene penceresinin araç çubuğundaki Gizmos düğmesinin açık olduğunu denetleyin. Üç örnek aynı sahnede yan yana durur. Bir örneğe yakından bakmak için Hierarchy'de seçip Scene penceresinde F tuşuna basın.
