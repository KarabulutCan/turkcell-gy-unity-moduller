# Modül 3 | Ders 9 | Döndürme

## Bu Uygulamada Ne Yapıyoruz

Soldaki uçakta Euler açılarını üç sürgüyle değiştiriyor ve üç halkayla izliyoruz. X açısını 90 dereceye getirdiğimizde iki halkanın aynı düzleme geldiğini ve bir dönme serbestliğinin kaybolduğunu görüyoruz. Sağdaki uçağı ise quaternion fonksiyonlarıyla hedefine en kısa yoldan döndürüyoruz.

## Sahneler

| Sahne | İçerik |
| --- | --- |
| Ders09_Baslangic | Ucak nesnesinde GimbalGoster hazırdır. HedefeBak betiğini Ucak2 nesnesine siz ekleyeceksiniz. |
| Ders09_Tamamlanmis | HedefeBak betiği Ucak2 nesnesine eklenmiş ve Hedef alanı doldurulmuştur. Play tuşuna basıldığında Ucak2 hedefe döner. |

## Betikler

| Betik | Ne yapar |
| --- | --- |
| GimbalGoster | Üç sürgüyle Euler açılarını değiştirir ve dönüşleri üç halkayla gösterir. Euler ve quaternion değerlerini yazar. |
| HedefeBak | Nesneyi Hedef alanındaki nesneye doğru yumuşak biçimde döndürür. |

## Adım Adım

1. Ders09_Baslangic sahnesini açın ve Hierarchy'de Ucak nesnesini seçin. GimbalGoster bileşenindeki Y, X ve Z sürgülerini sırayla oynatın. Her sürgü uçağı farklı bir yönde döndürür. Sürgüleri sıfıra alın.
2. Y sürgüsünü 60 yapın. Kırmızı ve mavi halkalar birlikte döner, yeşil halka yerinde kalır. Sürgüyü sıfıra alın.
3. X sürgüsünü yavaşça 90 değerine getirin. Mavi halka yeşil halkayla aynı düzleme gelir. Yazı kırmızıya döner ve GİMBAL KİLİDİ yazar.
4. X sürgüsü 90 iken önce Y sürgüsünü, sonra Z sürgüsünü oynatın. İkisi de uçağı aynı eksen etrafında döndürür. Sürgüleri sıfıra alın.
5. X sürgüsünü 180 yapın ve yazıdaki quaternion değerini okuyun. Sonra X değerini 0, Y ve Z değerlerini 180 yapın. Uçağın duruşu ve quaternion değeri aynıdır. Sürgüleri sıfıra alın.
6. Project penceresinde Betikler klasöründeki HedefeBak betiğini açın ve Update fonksiyonunu okuyun.
7. HedefeBak betiğini Ucak2 nesnesine ekleyin. Hedef nesnesini betiğin Hedef alanına sürükleyin. Play tuşuna basın. Ucak2 hedefe yumuşak biçimde döner.
8. Play modundayken Scene penceresinde Hedef nesnesini uçağın üstüne, altına ve arkasına sürükleyin. Uçak her seferinde en kısa yoldan döner. Play modundan çıkın.

## Ne Gördük

| Gözlem | Sonuç |
| --- | --- |
| Y sürgüsü | Dıştaki yeşil halkanın dönüşüdür ve diğer iki halkayı taşır |
| X sürgüsü 90 | Mavi halka yeşil halkayla aynı düzleme gelir. Gimbal kilidi oluşur |
| Kilit durumunda Y ve Z sürgüleri | Uçağı aynı eksen etrafında döndürür |
| 180, 0, 0 ile 0, 180, 180 | Aynı yönelimi ve aynı quaternion değerini verir |
| HedefeBak | Uçağı açı okuyup yazmadan en kısa yoldan hedefe döndürür |

## Kendiniz Deneyin

* X sürgüsünü 89 yapın ve Y ile Z sürgülerini oynatın. İki hareket birbirine ne kadar benziyor?
* Ucak2 nesnesinde Donus Hizi değerini 20 ve 360 yaparak Play modunda deneyin.
* HedefeBak betiğinde `Quaternion.LookRotation(yon)` yerine `Quaternion.LookRotation(-yon)` yazın. Uçak nereye bakıyor?
* Ucak nesnesinde GimbalGoster bileşenini kapatın ve Transform bileşenindeki Rotation değerlerini elle değiştirin. Sürgülerle aynı sonucu alıyor musunuz?

## Dikkat

Halkalar ve yazılar Gizmos ile çizilir. Görünmüyorsa Scene penceresinin araç çubuğundaki Gizmos düğmesinin açık olduğunu denetleyin. GimbalGoster bileşeni açıkken Ucak nesnesinin dönüşünü sürgüler belirler. Transform bileşenindeki Rotation satırına elle yazılan değerler sürgülerin değeriyle değiştirilir.
