# Modül 3 | Ders 6 | Trigonometri

## Bu Uygulamada Ne Yapıyoruz

Üç küçük örnekle trigonometriyi inceliyoruz. Soldaki birim çemberde açıyı değiştirerek kosinüs ve sinüsü izliyoruz. Ortadaki gezegeni kosinüs ve sinüsle bir merkezin çevresinde döndürüyoruz. Sağdaki küpü sinüsle yukarı aşağı süzdürüyoruz. Sonunda iki hareketi aynı nesnede birleştiriyoruz.

## Sahneler

| Sahne | İçerik |
| --- | --- |
| Ders06_Baslangic | AciOku hazırdır. Gezegen ve Yuzen nesnelerinde betik yoktur, siz ekleyeceksiniz. |
| Ders06_Tamamlanmis | DaireselHareket Gezegen nesnesine, DalgaHareketi Yuzen nesnesine eklenmiştir. Play tuşuna basıldığında ikisi de hareket eder. |

## Betikler

| Betik | Ne yapar |
| --- | --- |
| AcidanYone | Birim çemberi çizer. Sürgüyle seçilen açının kosinüsünü, sinüsünü ve yön vektörünü gösterir. |
| DaireselHareket | Nesneyi Merkez alanındaki nesnenin çevresinde zemin düzleminde döndürür. |
| DalgaHareketi | Nesneyi sinüs dalgasıyla yukarı aşağı hareket ettirir. |

## Adım Adım

1. Ders06_Baslangic sahnesini açın. Hierarchy'de AciOku nesnesini seçin ve Scene penceresinde F tuşuna basın. Inspector'daki Aci Derece sürgüsünü 0 konumundan 90 konumuna sürükleyin. Kırmızı çizgi kosinüs, yeşil çizgi sinüstür. Biri kısalırken diğeri uzar.
2. Sürgüyü 180, 270 ve 360 değerlerine getirin ve yazıdaki kosinüs ve sinüs değerlerini okuyun. Sonra 45 yapın. İki değer de 0.71 görünür.
3. Project penceresinde Betikler klasöründeki DaireselHareket betiğini açın ve Update fonksiyonunu okuyun.
4. DaireselHareket betiğini Gezegen nesnesine ekleyin. Merkez nesnesini betiğin Merkez alanına sürükleyin. Play tuşuna basın. Gezegen merkezin çevresinde 4 saniyede bir tur atar.
5. Play modundayken Yaricap değerini 5, Tur Hizi değerini 180 yapın. Scene penceresinde Merkez nesnesini sürükleyin. Yörünge merkezle birlikte taşınır. Play modundan çıkın.
6. DalgaHareketi betiğini açın ve Update fonksiyonunu okuyun. Betiği Yuzen nesnesine ekleyin ve Play tuşuna basın. Küp yukarı aşağı süzülür.
7. Play modundayken Genlik değerini 1.5, Frekans değerini 6 yapın. Hareket büyür ve hızlanır. Play modundan çıkın.
8. DalgaHareketi betiğini Gezegen nesnesine de ekleyin ve Play tuşuna basın. Gezegen hem döner hem yukarı aşağı dalgalanır. Play modundan çıkın.

## Ne Gördük

| Değer | Etkisi |
| --- | --- |
| Aci Derece | Yön vektörünü çember üzerinde döndürür |
| Yaricap | Yörünge çemberinin büyüklüğünü belirler |
| Tur Hizi | Saniyede kaç derece dönüleceğini belirler |
| Genlik | Dalganın orta noktadan ne kadar uzaklaşacağını belirler |
| Frekans | Dalganın ne kadar hızlı yineleneceğini belirler |

## Kendiniz Deneyin

* Tur Hizi değerini eksi bir sayı yapın. Gezegen hangi yöne dönüyor?
* DaireselHareket betiğinde kosinüs ile sinüsün yerini değiştirin. Ne değişti?
* DalgaHareketi betiğinde sinüs yerine kosinüs kullanın. Hareket nereden başlıyor?
* Gezegen nesnesinin çevresinde dönen küçük bir uydu ekleyin. Uydunun Merkez alanına hangi nesneyi vermelisiniz?

## Dikkat

Çemberler, çizgiler ve yazılar Gizmos ile çizilir. Görünmüyorsa Scene penceresinin araç çubuğundaki Gizmos düğmesinin açık olduğunu denetleyin. Play modunda yapılan Inspector değişiklikleri Play modundan çıkıldığında geri alınır.
