# Modül 3 | Ders 1 | Koordinat Sistemleri

## Bu Uygulamada Ne Yapıyoruz

Orijinden çıkan üç eksenin ve bir noktanın bulunduğu sahnede çalışıyoruz. Noktanın konumunu eksen eksen değiştirerek üç sayının sahnede neye karşılık geldiğini izliyoruz. Ardından bir nesneyi döndürerek dünya eksenleri ile yerel eksenler arasındaki farka bakıyoruz.

## Sahneler

| Sahne | İçerik |
| --- | --- |
| Ders01_Baslangic | Eksenler, orijinde duran Nokta ve dönmemiş YonKupu bulunur. Değerleri siz değiştireceksiniz. |
| Ders01_Tamamlanmis | Nokta 3, 2, 4 konumundadır. YonKupu Y ekseni etrafında 90 derece dönmüştür. |

## Betikler

| Betik | Ne yapar |
| --- | --- |
| EksenGoster | Bulunduğu noktadan başlayan X, Y ve Z eksenlerini renkli oklarla çizer. Her birime bir çentik koyar. |
| KonumGoster | Nesneyi kesikli çizgilerle zemine ve eksenlere bağlar, konumu sayı olarak yazar. |
| Cizim | Ok, kesikli çizgi ve yazı çizen ortak yardımcıdır. Assets/Egitim klasöründedir ve modülün bütün derslerinde kullanılır. |

## Adım Adım

1. Ders01_Baslangic sahnesini açın. Scene penceresinin sağ üst köşesindeki eksen simgesine bakın. Kırmızı kol X, yeşil kol Y, mavi kol Z eksenidir. Sahnenin ortasındaki üç ok aynı eksenleri orijinden başlayarak gösterir. Her çentik bir birimdir.
2. Hierarchy'de Nokta nesnesini seçin. Inspector'da Position değeri 0, 0, 0 görünür. X değerini 3 yapın. Küre kırmızı eksen boyunca 3 birim ilerler.
3. Y değerini 2, ardından Z değerini 4 yapın. Küre önce yükselir, sonra ileri gider. Yeşil kesikli çizgi yüksekliği, zemindeki iki kesikli çizgi X ve Z değerlerini gösterir.
4. X değerini -2, Y değerini -1 yapın. Küre kırmızı eksenin ters tarafına geçer ve zeminin altına iner. Değerleri yeniden 3, 2, 4 yapın.
5. W tuşuna basarak taşıma aracını seçin. Mavi oku sürükleyin ve Inspector'da yalnızca Z değerinin değiştiğini görün.
6. Sol elinizi kaldırın. Baş parmağınızı sağa, işaret parmağınızı yukarı tutun. Orta parmağınız ileriyi gösterir. Parmaklarınızı sahnedeki kırmızı, yeşil ve mavi eksenlerle karşılaştırın.
7. YonKupu nesnesini seçin. Mavi uç nesnenin ilerisidir. Rotation Y değerini 90 yapın. Nesne yukarıdan bakıldığında saat yönünde döner ve mavi uç X ekseni yönüne bakar.
8. YonKupu seçiliyken araç çubuğundaki Global seçeneğini Local yapın. Taşıma okları nesneyle birlikte döner. Bunlar nesnenin yerel eksenleridir. Seçeneği yeniden Global yapın.
9. Scene penceresindeki 2D düğmesine basın. Görünüm XY düzlemine karşıdan bakar. Düğmeye yeniden basarak 3D görünüme dönün.
10. Play tuşuna basın. Game penceresinin sol üst köşesinde Nokta nesnesinin konumu yazar. Inspector'dan değerleri değiştirin ve yazının güncellendiğini görün. Play modundan çıkın.

## Ne Gördük

| Konu | Sonuç |
| --- | --- |
| Position X | Nesneyi kırmızı eksen boyunca taşır |
| Position Y | Nesneyi yeşil eksen boyunca, yani yukarı ve aşağı taşır |
| Position Z | Nesneyi mavi eksen boyunca, yani ileri ve geri taşır |
| Eksi değer | Eksenin ters yönünü gösterir |
| Rotation Y artı değer | Yukarıdan bakıldığında saat yönünde döndürür |
| Global ve Local | Taşıma oklarının dünya eksenlerini ya da nesnenin kendi eksenlerini göstermesini seçer |

## Kendiniz Deneyin

* Nokta nesnesini yalnızca Inspector'a sayı girerek YonKupu nesnesinin tam üstüne, 2 birim yukarısına taşıyın. Hangi değerleri girdiniz?
* Eksenler nesnesini seçin ve Uzunluk değerini 10 yapın. Kaç çentik görüyorsunuz?
* YonKupu seçiliyken Local seçeneği açıkken mavi oku sürükleyin. Inspector'da hangi Position değerleri değişiyor? Global seçeneğinde aynı deneyi yineleyin.

## Dikkat

Eksenler, kesikli çizgiler ve yazılar Gizmos ile çizilir. Görünmüyorsa Scene penceresinin araç çubuğundaki Gizmos düğmesinin açık olduğunu denetleyin. Aynı çizimleri Game penceresinde görmek için o pencerenin Gizmos düğmesini de açmanız gerekir.
