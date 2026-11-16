# Modül 3 | Ders 10 | İnterpolasyon

## Bu Uygulamada Ne Yapıyoruz

Dört küreyi aynı yolda, aynı sürede ama farklı yumuşatma eğrileriyle hareket ettiriyoruz. Eğrilerin grafiğini yolun üzerinde izliyoruz. Ardından aynı betikle kamerayı iki durak arasında yumuşak biçimde taşıyor ve bir arayüz panelini ekrana kaydırıyoruz.

## Sahneler

| Sahne | İçerik |
| --- | --- |
| Ders10_Baslangic | Dört kürenin hepsi doğrusal eğriyle gider. Eğrileri siz değiştirecek, kameraya ve Canvas nesnesine betikleri siz ekleyeceksiniz. |
| Ders10_Tamamlanmis | Her küre farklı bir eğri kullanır. Boşluk tuşu kamerayı yaklaştırır ve bilgi panelini açar. |

## Betikler

| Betik | Ne yapar |
| --- | --- |
| Yumusatma | Eğri türlerini ve oranı eğriden geçiren Uygula fonksiyonunu içerir. |
| EgriIleHareket | Nesneyi iki işaretçi arasında seçilen eğriyle götürüp getirir. Konum için Lerp, dönüş için Slerp kullanır. |
| PanelAcKapa | Bir arayüz panelini boşluk tuşuyla ekrana kaydırır ve geri çeker. |

## Tuşlar

| Tuş | Etki |
| --- | --- |
| Boşluk | Tamamlanmış sahnede kamerayı iki durak arasında taşır ve bilgi panelini açar ya da kapatır. |

## Adım Adım

1. Ders10_Baslangic sahnesini açın. Project penceresinde Betikler klasöründeki Yumusatma ve EgriIleHareket betiklerini açın. Uygula fonksiyonundaki dört eğriyi ve Update içindeki oran hesabını bulun.
2. Play tuşuna basın. Dört küre birlikte gider ve birlikte döner. Yolların üzerindeki sarı grafikler düz çizgidir. Play modundan çıkın.
3. Kure2 nesnesini seçin ve Egri alanını Yavas Basla yapın. Kure3 için Yavas Bitir, Kure4 için Yumusak Gecis seçin. Sarı grafiklerin biçimi değişir.
4. Play tuşuna basın. Küreler aynı anda yola çıkar ve aynı anda varır ama yolda birbirinden ayrılır. Play modundan çıkın.
5. Kure1 nesnesini seçin ve Egri alanını Ozel yapın. Ozel Egri kutusuna tıklayın. Eğrinin sonuna yakın bir yere çift tıklayarak nokta ekleyin ve noktayı 1 değerinin biraz üstüne çekin. Play tuşuna basın. Kure1 hedefi aşıp geri döner. Play modundan çıkın.
6. Main Camera nesnesini seçin ve EgriIleHareket betiğini ekleyin. Baslangic alanına KameraA, Bitis alanına KameraB nesnesini sürükleyin. Egri alanını Yumusak Gecis, Sure değerini 1.2 yapın ve Boslukla Tetikle kutusunu işaretleyin.
7. Canvas nesnesini seçin ve PanelAcKapa betiğini ekleyin. Canvas altındaki BilgiPaneli nesnesini betiğin Panel alanına sürükleyin.
8. Play tuşuna basın, Game penceresine tıklayın ve boşluk tuşuna basın. Kamera kürelere yaklaşır ve panel sağdan kayarak gelir. Boşluk tuşuna yeniden basın. Play modundan çıkın.

## Ne Gördük

| Eğri | Hareketin karakteri | Uygun kullanım |
| --- | --- | --- |
| Doğrusal | Sabit hız | Taşıyıcı bant, ilerleme çubuğu |
| Yavaş başla | Yavaş başlar, hızlanarak biter | Düşen ya da kalkışa geçen nesne |
| Yavaş bitir | Hızlı başlar, yavaşlayarak biter | Ekrana gelen panel, duran araç |
| Yumuşak geçiş | İki uçta yavaş, ortada hızlı | Kamera geçişi, ileri geri giden platform |
| Özel | Çizilen eğriye göre | Hedefi aşan ya da seken hareketler |

## Kendiniz Deneyin

* Dört kürenin Sure değerini 0.5 yapın. Eğriler arasındaki fark hâlâ seçilebiliyor mu? 5 yapın ve yeniden bakın.
* PanelAcKapa bileşeninde Egri alanını Dogrusal yapın ve panelin açılışını Yavas Bitir ile karşılaştırın.
* Yumusatma betiğine `t * t * t` formülüyle beşinci bir eğri ekleyin. Yavaş başla eğrisinden farkı nedir?
* KameraB işaretçisini taşıyın ve döndürün. Kameranın boşluk tuşuyla gittiği yer nasıl değişiyor?

## Dikkat

Yolların üzerindeki sarı grafikler Gizmos ile çizilir. Görünmüyorsa Scene penceresinin araç çubuğundaki Gizmos düğmesinin açık olduğunu denetleyin. Boşluk tuşunun çalışması için Play modunda Game penceresine bir kez tıklamak gerekir.
