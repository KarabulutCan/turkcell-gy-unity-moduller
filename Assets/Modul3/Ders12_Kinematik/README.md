# Modül 3 | Ders 12 | Kinematik

## Bu Uygulamada Ne Yapıyoruz

Fizik motoru kullanmadan bir mermi atıyoruz. Merminin hızını ve konumunu her karede kendi iki satırımızla güncelliyoruz. Aynı hesabı bir döngüde art arda çalıştırarak merminin gideceği yolu atıştan önce çiziyoruz. Zaman adımını büyüterek Euler entegrasyonunun hatasını gözlüyoruz.

## Sahneler

| Sahne | İçerik |
| --- | --- |
| Ders12_Baslangic | Top, Zemin ve mesafe işaretleri bulunur. AtisHareketi betiğini Top nesnesine siz ekleyeceksiniz. |
| Ders12_Tamamlanmis | AtisHareketi betiği Top nesnesine eklenmiştir. Yörünge sahnede çizilir ve boşluk tuşu mermiyi atar. |

## Betikler

| Betik | Ne yapar |
| --- | --- |
| Mermi | Atılan küreyi Euler entegrasyonuyla hareket ettirir. Zemine indiğinde menzili ve süreyi Console'a yazar. |
| AtisHareketi | Açıdan ve sürattan ilk hızı hesaplar, mermiyi atar ve yolunu önceden çizer. |

## Tuşlar

| Tuş | Etki |
| --- | --- |
| Boşluk | Mermiyi atar. |

## Adım Adım

1. Ders12_Baslangic sahnesini açın. Project penceresinde Betikler klasöründeki Mermi betiğini açın ve Update fonksiyonundaki iki satırı bulun.
2. AtisHareketi betiğini açın. IlkHiz fonksiyonunu ve OnDrawGizmos içindeki döngüyü okuyun.
3. AtisHareketi betiğini Top nesnesine ekleyin. Scene penceresinde 2D düğmesine basarak sahneye karşıdan bakın. Sarı ve gri çizgiler neredeyse üst üste durur. Yazıda menzil 10.19, tepe 2.55 ve süre 1.44 görünür.
4. Play tuşuna basın, Game penceresine tıklayın ve boşluk tuşuna basın. Mermi çizilen yolu izler ve 10 metre işaretinin biraz ötesine düşer. Console'daki menzil ve süre değerlerini okuyun. Play modundan çıkın.
5. Top nesnesinde Aci sürgüsünü 20, 45 ve 70 değerlerine getirin. En uzak atış 45 derecede olur. 20 ve 70 derecede mermi aynı yere düşer.
6. Aci değerini yeniden 45 yapın. Surat değerini 5 ve 14 yapın, menzili okuyun. Değeri yeniden 10 yapın.
7. Adim değerini 0.2, sonra 0.4 yapın. Sarı çizgi köşeli hale gelir ve gri çizginin altında kalır. Değeri yeniden 0.02 yapın.
8. Yercekimi alanının Y değerini -1.62 yapın ve menzili okuyun. Değeri yeniden -9.81 yapın.

## Ne Gördük

| Değişiklik | Sonuç |
| --- | --- |
| Açı 45 derece | Aynı süratle en uzak atış |
| Açı 20 ve 70 derece | Farklı yükseklik, aynı menzil |
| Sürat iki katına çıkarsa | Menzil dört katına çıkar |
| Adım büyürse | Euler entegrasyonuyla hesaplanan yol formülle bulunan yoldan uzaklaşır |
| Yerçekimi azalırsa | Mermi daha yükseğe ve daha uzağa gider |

## Kendiniz Deneyin

* Top nesnesini Y ekseninde 2 birim yukarı taşıyın. Mermi nereye düşüyor? Zemin yüksekliği betikte nasıl belirleniyor?
* Play modunda art arda boşluk tuşuna basarken Aci sürgüsünü oynatın. Mermilerin oluşturduğu biçime bakın.
* Mermi betiğindeki iki satırın yerini değiştirin ve menzili Console'dan okuyun. Fark ne kadar?
* Yercekimi alanının X değerini 2 yapın. Sarı çizgi ile gri çizgi neden hâlâ üst üste?

## Dikkat

Sarı ve gri çizgiler Gizmos ile çizilir. Görünmüyorsa Scene penceresinin araç çubuğundaki Gizmos düğmesinin açık olduğunu denetleyin. Boşluk tuşunun çalışması için Play modunda Game penceresine bir kez tıklamak gerekir. Mermiler 10 saniye sonra kendiliğinden silinir.
