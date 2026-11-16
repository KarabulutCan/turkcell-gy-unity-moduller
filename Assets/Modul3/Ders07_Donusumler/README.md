# Modül 3 | Ders 7 | Dönüşümler

## Bu Uygulamada Ne Yapıyoruz

Bir küpe bağlı bir kürenin yerel ve dünya konumunu izliyoruz. Ebeveyni döndürüp ölçekleyip taşıdıkça yerel konumun değişmediğini, dünya konumunun değiştiğini görüyoruz. Ardından iki uzay arasında nokta çeviriyor ve aynı öteleme vektörünün yerel ve dünya uzayında nasıl farklı sonuç verdiğini gözlüyoruz.

## Sahneler

| Sahne | İçerik |
| --- | --- |
| Ders07_Baslangic | Ebeveyn, ona bağlı Cocuk ve ayrı duran Isaret bulunur. NoktaCevir ve IlerleVeDon betiklerini Ebeveyn nesnesine siz ekleyeceksiniz. |
| Ders07_Tamamlanmis | NoktaCevir ve IlerleVeDon betikleri Ebeveyn nesnesine eklenmiştir. Play tuşuna basıldığında Ebeveyn dönerek ilerler. |

## Betikler

| Betik | Ne yapar |
| --- | --- |
| DonusumGoster | Cocuk nesnesinin yerel ve dünya konumunu yazar. Ebeveynin eksenlerini çizer. |
| NoktaCevir | Yerel bir noktayı dünya uzayına, bir nesnenin dünya konumunu yerel uzaya çevirir ve sonuçları gösterir. |
| IlerleVeDon | Nesneyi döndürür ve seçilen uzaya göre ileri doğru öteler. |

## Adım Adım

1. Ders07_Baslangic sahnesini açın. Hierarchy'de Ebeveyn nesnesinin altındaki Cocuk nesnesini seçin. Inspector'da Position 2, 0, 0 görünür. Kürenin üzerindeki yazıda yerel konum 2, 0, 0 ve dünya konumu 2, 0.5, 0 yazar.
2. Ebeveyn nesnesini seçin ve Rotation Y değerini 90 yapın. Cocuk nesnesinin dünya konumu 0, 0.5, -2 olur. Yerel konumu değişmez.
3. Ebeveyn nesnesinin Scale değerini 2, 2, 2 yapın. Dünya konumu 0, 0.5, -4 olur.
4. Ebeveyn nesnesinin Position X değerini 5 yapın. Dünya konumu 5, 0.5, -4 olur. Ardından Ebeveyn nesnesini ilk haline döndürün. Position 0, 0.5, 0, Rotation 0, 0, 0 ve Scale 1, 1, 1 olmalıdır.
5. NoktaCevir betiğini Ebeveyn nesnesine ekleyin. Isaret nesnesini betiğin Dunya Nesnesi alanına sürükleyin. Burnun önünde sarı bir küre belirir. Isaret nesnesinin üzerinde yerel uzaydaki konumu 3, 0, 3 ve önde ve sağda yazısı görünür.
6. Ebeveyn nesnesinin Rotation Y değerini 90 yapın. Sarı küre burunla birlikte döner. Isaret nesnesinin yerel konumu -3, 0, 3 olur ve yazı önde ve solda der. Değeri yeniden 0 yapın.
7. Project penceresinde Betikler klasöründeki IlerleVeDon betiğini açın ve okuyun. Betiği Ebeveyn nesnesine ekleyin ve Play tuşuna basın. Ebeveyn daire çizerek ilerler.
8. Play modundayken Uzay alanını World yapın. Ebeveyn dönmeyi sürdürür ama düz bir çizgide ilerler. Play modundan çıkın.

## Ne Gördük

| Ebeveynde yapılan değişiklik | Çocuğun yerel konumu | Çocuğun dünya konumu |
| --- | --- | --- |
| Başlangıç | 2, 0, 0 | 2, 0.5, 0 |
| Rotation Y 90 | 2, 0, 0 | 0, 0.5, -2 |
| Scale 2, 2, 2 | 2, 0, 0 | 0, 0.5, -4 |
| Position X 5 | 2, 0, 0 | 5, 0.5, -4 |

## Kendiniz Deneyin

* NoktaCevir bileşeninde Yerel Nokta değerini 2, 0, 0 yapın. Sarı küre nerede beliriyor? Cocuk nesnesinin konumuyla karşılaştırın.
* Ebeveyn nesnesinin Scale değerini 3, 1, 1 yapın ve Rotation Y değerini yavaşça değiştirin. Cocuk nesnesinin biçimi nasıl etkileniyor?
* Isaret nesnesini Ebeveyn nesnesinin arkasına ve soluna taşıyın. Yerel konumun X ve Z değerlerinin işaretlerini yazıdan okuyun.
* IlerleVeDon bileşeninde Donus Hizi değerini 0 yapın. Self ve World seçenekleri arasında fark kalıyor mu? Neden?

## Dikkat

Oklar, kesikli çizgiler ve yazılar Gizmos ile çizilir. Görünmüyorsa Scene penceresinin araç çubuğundaki Gizmos düğmesinin açık olduğunu denetleyin. Play modunda yapılan Inspector değişiklikleri Play modundan çıkıldığında geri alınır.
