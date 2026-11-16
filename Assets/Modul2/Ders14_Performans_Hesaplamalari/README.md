# Modül 2 | Ders 14 | Performans Hesaplamaları

## Bu Uygulamada Ne Yapıyoruz

Sahneye bin küp üretiyoruz. Her küpte bilerek yavaş yazılmış bir betik çalışıyor. Profiler ile darboğazı buluyor, tek bir ayarla düzeltiyor ve farkı ölçüyoruz. Sonra çizim tarafına geçip Batches değerine ve Frame Debugger penceresine bakıyoruz.

## Klasörler

| Klasör | İçerik |
| --- | --- |
| Betikler | KupUretici ve KupDavranisi betikleri bulunur. |
| Prefabs | Kup Prefab'ı bulunur. Üzerinde KupDavranisi vardır ve Hizli Yol kapalıdır. |
| Materyaller | Kup Prefab'ının kullandığı KupMat materyali bulunur. |
| Tamamlanmis | Hizli Yol açık Kup_Tamamlanmis Prefab'ı ve GPU Instancing açık materyali bulunur. |

## Sahneler

| Sahne | İçerik |
| --- | --- |
| Ders14_Baslangic | Zemin ve etiketi Player olan Oyuncu adlı kapsül bulunur. |
| Ders14_Tamamlanmis | Uretici nesnesi bin küp üretir. Küplerde Hizli Yol açıktır. |

## Adım Adım

1. Ders14_Baslangic sahnesini açın. Boş bir nesne oluşturun, adını Uretici yapın ve KupUretici betiğini ekleyin. Kup Prefab alanına Prefabs klasöründeki Kup Prefab'ını sürükleyin, Adet 1000 olsun. Play tuşuna basın, Game penceresinde Stats düğmesini açın ve FPS ile CPU sürelerini okuyun.
2. Window menüsünden Analysis, Profiler penceresini açın ve CPU Usage modülünü seçin. Birkaç saniye kayıt alın ve grafikte bir kareye tıklayın. Alttaki görünümü Hierarchy yapın. Scripts dilimini ve KupDavranisi.Update satırını bulun. Total, Self, Calls ve GC Alloc sütunlarını okuyun.
3. KupDavranisi.Update satırını genişletin. Altında GameObject.FindWithTag satırını ve metin birleştirmeden gelen GC Alloc değerini görün.
4. Play modundan çıkın. Kup Prefab'ını seçin ve KupDavranisi bileşeninde Hizli Yol kutusunu açın. Yeniden Play tuşuna basın. Stats panelindeki FPS ve CPU sürelerini, Profiler'da KupDavranisi.Update süresini ve GC Alloc değerini önceki ölçümle karşılaştırın.
5. Stats panelindeki Batches değerini okuyun. Project penceresinde KupMat materyalini seçin ve Enable GPU Instancing kutusunu işaretleyin. Play modunda Batches değerine yeniden bakın.
6. Window menüsünden Analysis, Frame Debugger penceresini açın ve Enable düğmesine basın. Soldaki listede küplerin nasıl gruplandığına bakın. Bir küpün ölçeğini değiştirin ve listede ayrıldığını görün. Disable düğmesine basın.

## Ne Gördük

| Sorun | Belirti | Çözüm |
| --- | --- | --- |
| Her karede sahnede arama | Scripts dilimi büyür | Sonucu bir kez bulup saklamak |
| Her karede metin birleştirme | GC Alloc değeri yükselir | Gereksiz birleştirmeyi kaldırmak |
| Çok sayıda ayrı çizim | Batches değeri yükselir | Aynı materyali paylaşmak ve toplu çizim |

## Kendiniz Deneyin

* Adet değerini 5000 yapın. Hizli Yol açıkken ve kapalıyken FPS kaç oluyor?
* Profiler penceresinde Deep Profile düğmesini açın ve yeniden kayıt alın. Görünüm nasıl değişiyor ve oyun ne kadar yavaşlıyor?
* KupDavranisi betiğindeki metin birleştirme satırını silin. GC Alloc sütununda ne görüyorsunuz?

## Dikkat

Ölçüm sonuçları bilgisayara göre değişir. Önemli olan sayıların kendisi değil, değişiklikten önceki ve sonraki farktır. Editörde ölçülen süreler, derlenmiş oyundaki sürelerden daha yüksektir.
