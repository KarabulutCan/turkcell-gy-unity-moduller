# Modül 3 | Ders 11 | Rastgelelik ve Prosedürel Üretim

## Bu Uygulamada Ne Yapıyoruz

İki küçük örnekle rastgeleliği inceliyoruz. Soldaki örnekte küreleri bir dairenin içine rastgele dağıtıyor ve tohumun aynı dizilimi nasıl yeniden ürettiğini görüyoruz. Sağdaki örnekte Perlin gürültüsüyle küplerden bir arazi üretiyor, ölçeğin, yüksekliğin ve tohumun araziyi nasıl değiştirdiğini izliyoruz.

## Sahneler

| Sahne | İçerik |
| --- | --- |
| Ders11_Baslangic | Dagitici hazırdır. Arazi nesnesi boştur, GurultuArazi betiğini siz ekleyeceksiniz. |
| Ders11_Tamamlanmis | GurultuArazi betiği Arazi nesnesine eklenmiştir. Play tuşuna basıldığında arazi üretilir. |

## Betikler

| Betik | Ne yapar |
| --- | --- |
| RastgeleDagit | Küreleri bir dairenin içine rastgele konum ve boyutlarla yerleştirir. Tohumla yinelenebilir. |
| GurultuArazi | Küplerden bir arazi üretir. Yükseklikleri Perlin gürültüsünden ya da bağımsız rastgele sayılardan okur. |

## Adım Adım

1. Ders11_Baslangic sahnesini açın ve Play tuşuna basın. Soldaki dairenin içine 40 küre dağılır. Play modundan çıkıp yeniden çalıştırın. Küreler aynı yerlerdedir.
2. Play modundan çıkın. Dagitici nesnesini seçin ve Tohum değerini 7 yapın. Çalıştırın. Dizilim değişir. Play modundan çıkın, Tohum Kullan kutusunun işaretini kaldırın ve iki kez çalıştırın. Dizilim her seferinde farklıdır.
3. Project penceresinde Betikler klasöründeki GurultuArazi betiğini açın ve Guncelle fonksiyonunu okuyun. Perlin gürültüsünün çağrıldığı satırı bulun.
4. GurultuArazi betiğini Arazi nesnesine ekleyin ve Play tuşuna basın. 900 küpten oluşan bir arazi üretilir.
5. Play modundayken Arazi nesnesinde Perlin Kullan kutusunun işaretini kaldırın. Arazi sivri sütunlara döner. Kutuyu yeniden işaretleyin.
6. Olcek değerini sırasıyla 0.05, 0.3 ve 1 yapın. Tepeler önce genişler, sonra sıklaşır, sonunda arazi düzleşir. Değeri yeniden 0.12 yapın.
7. Yukseklik değerini 12 yapın ve Su Seviyesi sürgüsünü oynatın. Değerleri eski haline getirin.
8. Tohum değerini 1, 2 ve 3 yapın. Her tohum farklı bir arazi verir. Yeniden 1 yaptığınızda ilk arazi geri gelir. Play modundan çıkın.

## Ne Gördük

| Değer | Etkisi |
| --- | --- |
| Tohum | Hangi dizilimin ya da hangi arazinin üretileceğini belirler |
| Perlin Kullan | Kapalıyken yükseklikler bağımsız rastgele sayılardan gelir ve arazi sivrileşir |
| Olcek | Tepelerin genişliğini belirler |
| Yukseklik | En yüksek noktanın boyunu belirler |
| Su Seviyesi | Bu değerin altındaki yerler düzleştirilir ve maviye boyanır |

## Kendiniz Deneyin

* Dagitici nesnesinde Adet değerini 400 yapın. Küreler dairenin içine eşit dağılıyor mu?
* GurultuArazi betiğinde gürültü satırındaki iki kaymadan birini silin. Arazi nasıl değişiyor?
* Boyut değerini 60 yapıp Play modunu yeniden başlatın. Arazi kaç küpten oluşuyor?
* Su Seviyesi değerini 0 ve 1 yapın. Her iki durumda arazi nasıl görünüyor?

## Dikkat

Küreler ve küpler Play modunda oluşturulur. Play modundan çıkıldığında silinir. Boyut değeri küplerin sayısını belirlediği için yalnızca Play modu başlarken okunur. Diğer değerler Play modunda değiştirildiğinde arazi hemen yeniden hesaplanır.
