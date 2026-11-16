# Modül 2 | Ders 5 | Sahne ve Hiyerarşi

## Bu Uygulamada Ne Yapıyoruz

Üç küreyle küçük bir güneş sistemi kuruyoruz. Dunya nesnesini Gunes nesnesinin, Ay nesnesini Dunya nesnesinin çocuğu yapıyoruz. Yerel konum ile dünya konumu arasındaki farkı önce Inspector'da, sonra Console'da okuyoruz. Son olarak ikinci bir sahneyi açık sahnenin yanına yüklüyoruz.

## Sahneler

| Sahne | İçerik |
| --- | --- |
| Ders05_Baslangic | Yalnızca kamera ve ışık bulunur. Küreleri siz oluşturacaksınız. |
| Ders05_Tamamlanmis | Gunes, onun çocuğu Dunya ve Dunya'nın çocuğu Ay bulunur. Betikler eklenmiştir. |
| Menu | L tuşuyla yüklenen ikinci sahnedir. İçinde tek bir küp vardır. |

## Betikler

| Betik | Nesne | Ne yapar |
| --- | --- | --- |
| Dondur | Gunes ve Dunya | Nesneyi Y ekseni etrafında döndürür. Hız Inspector'dan ayarlanır. |
| KoordinatYaz | Ay | Yerel ve dünya konumunu her karede Console'a yazar. |
| SahneYukle | Gunes | L tuşuna basılınca Menu sahnesini Additive modda yükler. |

## Adım Adım

1. Ders05_Baslangic sahnesini açın. Hierarchy'de sağ tıklayıp 3D Object menüsünden üç Sphere oluşturun. Birincinin adını Gunes yapın ve 0, 0, 0 konumunda bırakın. İkincinin adını Dunya yapın ve konumunu 10, 0, 0 yapın. Üçüncünün adını Ay yapın, konumunu 12, 0, 0 ve ölçeğini 0.4, 0.4, 0.4 yapın.
2. Hierarchy'de Dunya nesnesini Gunes nesnesinin üzerine, Ay nesnesini Dunya nesnesinin üzerine sürükleyin. Dunya'yı seçin, Position hâlâ 10, 0, 0 değerindedir. Ay'ı seçin, Position 2, 0, 0 olmuştur. Inspector artık ebeveyne göre konumu gösterir.
3. Gunes'i seçin ve Position değerini 5, 0, 0 yapın. Scene penceresinde üç küre birlikte kayar. Dunya ve Ay nesnelerinin Position değerleri değişmez.
4. KoordinatYaz betiğini Ay nesnesine ekleyin ve Play tuşuna basın. Console'da yerel konum 2, 0, 0 ve dünya konumu 17, 0, 0 yazar. Play modundan çıkın.
5. Gunes'in Position değerini yeniden 0, 0, 0 yapın. Dondur betiğini Gunes ve Dunya nesnelerine ekleyin. Gunes'te hızı 10, Dunya'da hızı 90 yapın ve Play tuşuna basın. Dunya Gunes'in çevresinde, Ay Dunya'nın çevresinde döner.
6. Play modundayken Console'a bakın. Ay'ın yerel konumu hep 2, 0, 0 kalır. Dünya konumu her karede değişir.
7. Play modundan çıkın. Dunya'nın Scale değerini 2, 1, 1 yapın ve Scene penceresinde Ay'ın görünümüne bakın. Ebeveyndeki eşit olmayan ölçek çocuğu çarpıtır. Scale değerini yeniden 1, 1, 1 yapın.
8. SahneYukle betiğini Gunes nesnesine ekleyin. Play tuşuna basın, Game penceresine tıklayın ve L tuşuna basın. Hierarchy'de Menu adlı ikinci sahne belirir.

## Ne Gördük

| Konu | Sonuç |
| --- | --- |
| Ebeveyn hareket ederse | Çocuklar onunla birlikte hareket eder |
| Inspector'daki Position | Ebeveyne göre yerel konumdur |
| Dünya konumu | Kodda transform.position ile okunur |
| Ebeveynde eşit olmayan ölçek | Çocuğun şeklini bozar |
| Additive sahne yükleme | Açık sahne kapanmaz, yenisi yanına eklenir |

## Kendiniz Deneyin

* Ay nesnesine de Dondur betiği ekleyin ve hızı 200 yapın. Ay'ın çevresine dördüncü bir küre yerleştirebilir misiniz?
* File menüsünden Build Profiles penceresini açın ve Scene List içinde Menu sahnesinin işaretini kaldırın. L tuşuna bastığınızda Console'da ne yazıyor? Denemeden sonra işareti geri koyun.
* Gunes nesnesini Inspector'dan kapatın. Dunya ve Ay nesnelerine ne oluyor?

## Dikkat

Gunes ve Dunya nesnelerinin ölçeği 1, 1, 1 olmalıdır. Ebeveynin ölçeği farklı olursa çocuğun Inspector'da görünen yerel konumu da değişir ve yukarıdaki sayılar tutmaz.
