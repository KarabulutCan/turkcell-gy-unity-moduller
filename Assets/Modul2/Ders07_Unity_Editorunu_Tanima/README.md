# Modül 2 | Ders 7 | Unity Editörünü Tanıma

## Bu Uygulamada Ne Yapıyoruz

Editörde sistemli bir tur atıyoruz. Scene penceresinde gezinmeyi, taşıma, döndürme ve ölçekleme araçlarını, ızgaraya yapıştırmayı, gizmo çizimini ve Play modunun tuzaklarını deniyoruz.

## Sahneler

| Sahne | İçerik |
| --- | --- |
| Ders07_Baslangic | Zemin, üç küp ve bir kapsül bulunur. Kup2 döndürülmüş durumdadır. |
| Ders07_Tamamlanmis | Aynı sahnedir. Kapsul nesnesine GizmoCiz eklenmiş ve Yaricap değeri 5 yapılmıştır. |

## Betikler

| Betik | Ne yapar |
| --- | --- |
| GizmoCiz | Nesne seçiliyken Scene penceresinde çevresine sarı tel küre çizer. |

## Adım Adım

1. Unity Hub'da Installs sekmesinde kurulu editör sürümlerine, Projects sekmesinde projenin sürüm sütununa bakın. Projeyi ve Ders07_Baslangic sahnesini açın.
2. Scene penceresinde farenin sağ tuşunu basılı tutun ve W, A, S, D tuşlarıyla uçun. Bir küp seçip F tuşuna basın, kamera küpe odaklanır. Alt tuşunu basılı tutup sol tuşla sürükleyin, kamera küpün çevresinde döner. Sağ üstteki eksen küpünün üst koluna tıklayın, sahneye tepeden bakarsınız.
3. W, E ve R tuşlarıyla taşıma, döndürme ve ölçekleme araçları arasında geçiş yapın. Bir küpü W aracıyla Ctrl tuşu basılıyken sürükleyin. Inspector'daki Position değerleri birer birim değişir.
4. İki küpü birlikte seçin. Araç çubuğunda Pivot ile Center arasında, sonra Local ile Global arasında geçiş yapın. Kup2 döndürülmüş olduğu için Local seçiliyken okların yönü değişir.
5. Kapsul nesnesini seçin ve GizmoCiz bileşenini ekleyin. Scene penceresinde sarı tel küre görünür. Yaricap değerini 5 yapın, küre büyür. Game penceresindeki Gizmos düğmesini kapatın.
6. Edit menüsünden Preferences penceresini açın, Colors bölümünde Playmode tint rengini açık kırmızı yapın. Play tuşuna basın, editör renk değiştirir. Play modunda bir küpün konumunu değiştirin ve Play modundan çıkın. Küp eski yerine döner.
7. Yeniden Play tuşuna basın ve küpü taşıyın. Transform bileşeninin sağ üstündeki menüden Copy Component seçin. Play modundan çıkın ve aynı menüden Paste Component Values seçin. Küp yeni konumunda kalır.
8. Ctrl ve K tuşlarıyla Search penceresini açın, Fixed Timestep yazın ve Project Settings sonucuna tıklayın. Window menüsünden Layouts, Save Layout ile pencere düzeninizi kaydedin.

## Kısayollar

| Tuş | İşlev |
| --- | --- |
| Q | Görünümü kaydırma |
| W | Taşıma |
| E | Döndürme |
| R | Ölçekleme |
| T | Dikdörtgen aracı |
| F | Seçili nesneye odaklanma |
| Ctrl ve P | Play moduna girme ve çıkma |
| Ctrl ve K | Arama penceresi |

## Kendiniz Deneyin

* GizmoCiz betiğinde OnDrawGizmosSelected adını OnDrawGizmos yapın. Küre artık ne zaman görünüyor?
* Bir küpü V tuşu basılıyken köşesinden tutup başka bir küpün köşesine yapıştırın.
* Window menüsünden Layouts altındaki hazır düzenleri sırayla deneyin ve kendi düzeninize geri dönün.

## Dikkat

Play modunda yapılan değişiklikler Play modundan çıkınca geri alınır. Playmode tint rengini belirgin bir renge ayarlamak, Play modunda olduğunuzu unutmamanızı sağlar.
