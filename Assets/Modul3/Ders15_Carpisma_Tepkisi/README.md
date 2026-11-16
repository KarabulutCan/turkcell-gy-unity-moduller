# Modül 3 | Ders 15 | Çarpışma Tepkisi ve Modül Projesi

## Bu Uygulamada Ne Yapıyoruz

Modülün bütün konularını bir mini bilardo sahnesinde birleştiriyoruz. Fizik motoru kullanmıyoruz. Topların ilerlemesini, sürtünmeyle yavaşlamasını, duvarlardan sekmesini ve birbirine çarpmasını kendi yazdığımız kodla hesaplıyoruz. Beyaz topa fareyle nişan alıp vuruyoruz.

## Sahneler

| Sahne | İçerik |
| --- | --- |
| Ders15_Baslangic | Masa, duvarlar, cepler ve toplar hazırdır. BilardoMasasi ve Istaka betiklerini Masa nesnesine siz ekleyeceksiniz. |
| Ders15_Tamamlanmis | İki betik de Masa nesnesine eklenmiştir. Play tuşuna basıldığında beyaz top ilk vuruşu kendiliğinden yapar. |

## Betikler

| Betik | Ne yapar |
| --- | --- |
| BilardoTopu | Topun hızını tutar. Hareketi kendisi hesaplamaz. |
| BilardoMasasi | Her fizik adımında topları yavaşlatır, ilerletir, duvarlardan sektirir, birbiriyle çarpıştırır ve cepleri denetler. |
| Istaka | Fare konumundan masaya ışın gönderir, nişan çizgisini çizer ve tuş bırakıldığında beyaz topa hız verir. |

## Tuşlar

| Tuş | Etki |
| --- | --- |
| Farenin sol tuşu | Basılı tutulduğunda nişan çizgisi görünür. Bırakıldığında beyaz top farenin gösterdiği noktaya doğru vurulur. |

## Adım Adım

1. Ders15_Baslangic sahnesini açın. Project penceresinde Betikler klasöründeki BilardoMasasi betiğini açın. FixedUpdate fonksiyonunu okuyun ve her top için yapılan dört işi bulun.
2. Aynı betikte DuvardanSektir, Yansit ve TopCarpismasi fonksiyonlarını okuyun. Ayırma adımını ve hız değişimi adımını ayırt edin.
3. BilardoMasasi betiğini Masa nesnesine ekleyin. BeyazTop nesnesini betiğin Beyaz Top alanına sürükleyin. Baslangic Atisi değerini 10, 0, 0.3 yapın.
4. Play tuşuna basın. Beyaz top üçgeni dağıtır. Toplar duvarlardan seker, birbirine çarpar ve yavaşlayarak durur. Play modundan çıkın.
5. Istaka betiğini açın ve okuyun. Betiği Masa nesnesine ekleyin. Beyaz Top alanına BeyazTop, Nisan Cizgisi alanına NisanCizgisi nesnesini sürükleyin.
6. BilardoMasasi bileşeninde Baslangic Atisi değerini 0, 0, 0 yapın. Play tuşuna basın. Game penceresinde farenin sol tuşunu basılı tutarak nişan alın ve bırakarak vurun.
7. Play modundayken Esneklik değerini 1, sonra 0.3 yapın ve vuruş yapın. Sonra Yavaslama değerini 0.2 ve 5 yaparak deneyin.
8. Renkli topları köşelerdeki ceplere sokmayı deneyin. Sol üstteki sayaç cebe giren top sayısını gösterir. Play modundan çıkın.

## Ne Gördük

| Değer | Etkisi |
| --- | --- |
| Esneklik 1 | Toplar çarpışmalarda hız kaybetmez |
| Esneklik 0.3 | Toplar duvara çarpınca neredeyse durur |
| Yavaslama küçük | Toplar uzun süre yuvarlanır |
| Yavaslama büyük | Toplar çabuk durur |
| Guc Carpani | Nişan çizgisinin uzunluğuna karşılık gelen vuruş süratini belirler |

## Kendiniz Deneyin

* BilardoMasasi betiğinde ayırma satırlarını geçici olarak silin. Toplar çarpıştığında ne oluyor?
* Yansit fonksiyonundaki `Vector3.Reflect` çağrısını slayttaki formülle elle yazın. Davranış değişiyor mu?
* Masaya yedinci bir top ekleyin. Topun Masa nesnesinin çocuğu olması ve BilardoTopu betiğini taşıması yeterlidir.
* Cep Yaricapi değerini 1.5 yapın. Oyun nasıl değişiyor?

## Dikkat

Toplar Masa nesnesinin çocuğu olmalıdır. BilardoMasasi betiği topları Play modu başlarken çocukları arasından bulur. Vuruş yalnızca beyaz top dururken yapılabilir. Nişan almak için Play modunda Game penceresinin etkin olması gerekir.
