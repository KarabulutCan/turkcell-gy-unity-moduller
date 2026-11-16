# Modül 3 | Ders 8 | Matrislere Giriş

## Bu Uygulamada Ne Yapıyoruz

Önce bir küpün Transform değerlerini değiştirip dönüşüm matrisinin hangi sayılarının değiştiğini izliyoruz. Sonra tersini yapıyor, matrisin sayılarını elle yazarak bir birim küpü ölçekliyor, taşıyor, döndürüyor ve eğiyoruz.

## Sahneler

| Sahne | İçerik |
| --- | --- |
| Ders08_Baslangic | Kup orijindedir ve matrisi birim matristir. MatrisKupu kapalıdır, dersin ikinci bölümünde siz açacaksınız. |
| Ders08_Tamamlanmis | Kup 3, 1, 2 konumunda ve Y ekseninde 90 derece dönmüş durumdadır. MatrisKupu nesnesine aynı matris elle girilmiştir. |

## Betikler

| Betik | Ne yapar |
| --- | --- |
| MatrisGoster | Nesnenin dönüşüm matrisini dört satır halinde yazar. İlk üç sütunu ok olarak çizer. |
| MatrisDonustur | Inspector'dan girilen dört satırlık matrisle bir birim küpü dönüştürür. Gri küp önceki, sarı küp sonraki haldir. |

## Adım Adım

1. Ders08_Baslangic sahnesini açın ve Hierarchy'de Kup nesnesini seçin. Küpün üzerindeki dört satır, nesnenin matrisidir. Başlangıçta birim matris görünür.
2. Kup nesnesinin Position değerini 3, 1, 2 yapın. Matrisin yalnızca son sütunu değişir.
3. Scale değerini 2, 1, 1 yapın. Birinci sütunun ilk sayısı 2 olur ve kırmızı ok uzar. Scale değerini yeniden 1, 1, 1 yapın.
4. Rotation Y değerini 90 yapın. Birinci sütun 0, 0, -1 ve üçüncü sütun 1, 0, 0 olur. Kırmızı ve mavi okların yeni yönlerini sütunlarla karşılaştırın.
5. Kup nesnesini seçip Inspector'ın en üstündeki kutunun işaretini kaldırarak kapatın. MatrisKupu nesnesini açın. Inspector'da dört satırlık birim matris, sahnede üst üste duran gri ve sarı küp görünür.
6. Satir 0 alanının X değerini 2 yapın. Sarı küp X ekseninde uzar. Ardından Satir 0, Satir 1 ve Satir 2 alanlarının W değerlerini sırasıyla 3, 1 ve 2 yapın. Küp taşınır.
7. Satir 0 değerini 0, 0, 1, 3 ve Satir 2 değerini -1, 0, 0, 2 yapın. Sarı küp Y ekseni etrafında 90 derece döner.
8. Satir 0 değerini 1, 0.5, 0, 0 ve Satir 2 değerini 0, 0, 1, 0 yapın. Satir 1 alanının W değerini 0 yapın. Küp yana doğru eğilir.

## Ne Gördük

| Değişiklik | Matriste değişen yer |
| --- | --- |
| Position | Dördüncü sütun |
| Scale | İlgili sütunun uzunluğu |
| Rotation | İlk üç sütunun yönleri |
| Eğme | Bir sütunun başka bir eksene doğru yatması |

## Kendiniz Deneyin

* MatrisKupu nesnesinde köşegendeki üç sayıyı 0.5 yapın. Küp nasıl değişiyor?
* Satir 0 alanının X değerini -1 yapın. Küp hangi düzleme göre ayna görüntüsüne dönüyor?
* Satir 0 değerini 0, 0, 0, 0 yapın. Küp neye dönüşüyor? Neden?
* Kup nesnesini açın ve Rotation Y değerini 45 yapın. Birinci sütundaki sayıları altıncı dersteki kosinüs ve sinüs değerleriyle karşılaştırın.

## Dikkat

Matris yazısı, oklar ve sarı küp Gizmos ile çizilir. Görünmüyorsa Scene penceresinin araç çubuğundaki Gizmos düğmesinin açık olduğunu denetleyin. MatrisDonustur betiği MatrisKupu nesnesinin Transform değerlerini kullanmaz. Küp yalnızca Inspector'daki dört satıra göre çizilir.
