# Modül 3 | Ders 13 | Kuvvetler

## Bu Uygulamada Ne Yapıyoruz

Önce arkadaki üç küpe aynı kuvveti uygulayıp kütlenin ivmeye etkisini izliyoruz. Sonra öndeki küpü, Rigidbody kullanmadan, kuvvetlerle yürüyen ve zıplayan bir karaktere dönüştürüyoruz. Zıplama yüksekliğini metre cinsinden veriyor, gereken hızı koda hesaplatıyoruz.

## Sahneler

| Sahne | İçerik |
| --- | --- |
| Ders13_Baslangic | Arkadaki üç küp hazırdır. ZiplayanKarakter betiğini Karakter nesnesine siz ekleyeceksiniz. |
| Ders13_Tamamlanmis | ZiplayanKarakter betiği Karakter nesnesine eklenmiştir. A ve D tuşları yürütür, boşluk tuşu zıplatır. |

## Betikler

| Betik | Ne yapar |
| --- | --- |
| ZiplayanKarakter | Kuvvetleri toplar, ivmeyi bulur ve karakteri Euler entegrasyonuyla hareket ettirir. Rigidbody kullanmaz. |
| KuvvetUygula | Rigidbody bileşenine her fizik adımında sabit bir kuvvet uygular. Nesneyi belirli aralıklarla başa alır. |

## Tuşlar

| Tuş | Etki |
| --- | --- |
| A ve D | Karakteri sola ve sağa yürütür. |
| Boşluk | Karakteri zıplatır. |

## Adım Adım

1. Ders13_Baslangic sahnesini açın ve Play tuşuna basın. Arkadaki üç küpe aynı kuvvet uygulanır. Üzerlerindeki yazılardan kütleleri ve ivmeleri okuyun. Kütlesi küçük olan öne geçer. Play modundan çıkın.
2. Project penceresinde Betikler klasöründeki ZiplayanKarakter betiğini açın. Update fonksiyonunda kuvvetlerin toplandığı satırları, ivmenin hesaplandığı satırı ve zıplama satırını bulun.
3. ZiplayanKarakter betiğini Karakter nesnesine ekleyin. Karakterin 2 metre üzerinde sarı bir çizgi belirir. Yazıda zıplama hızı 8.94 görünür.
4. Play tuşuna basın ve Game penceresine tıklayın. D tuşunu basılı tutun. Hız yaklaşık 6.67 değerinde sabitlenir. Tuşu bırakın. Karakter kayarak durur.
5. Boşluk tuşuna basın. Karakter sarı çizgiye kadar yükselir. Yazıdaki ulaşılan yükseklik değerini okuyun.
6. Play modundayken Ziplama Yuksekligi değerini 4 yapın ve zıplayın. Sonra Yercekimi değerini 40 yapın ve yeniden zıplayın. Karakter aynı yüksekliğe daha kısa sürede çıkar.
7. Kutle değerini 4 yapın. Karakter daha yavaş hızlanır ama zıplama yüksekliği değişmez.
8. Surtunme değerini önce 1, sonra 20 yapın ve yürüyün. Play modundan çıkın.

## Ne Gördük

| Değişiklik | Yürümeye etkisi | Zıplamaya etkisi |
| --- | --- | --- |
| Ziplama Yuksekligi artarsa | Etkilemez | Karakter daha yükseğe zıplar |
| Yercekimi artarsa | Etkilemez | Yükseklik aynı kalır, havada kalma süresi kısalır |
| Kutle artarsa | Karakter daha yavaş hızlanır | Etkilemez |
| Yurume Kuvveti artarsa | En yüksek hız artar | Etkilemez |
| Surtunme artarsa | En yüksek hız düşer, karakter çabuk durur | Etkilemez |

## Kendiniz Deneyin

* Yurume Kuvveti değerini 80 yapın. En yüksek hız kaç oluyor? Hesaplayıp yazıdaki değerle karşılaştırın.
* KuvvetOrnegi altındaki Kutle4 nesnesinde Rigidbody bileşeninin Mass değerini 8 yapın. İvme kaç oluyor?
* Kutle1 nesnesinde Rigidbody bileşeninin Linear Damping değerini 2 yapın. Küpün hızı nasıl değişiyor?
* ZiplayanKarakter betiğinde sürtünme satırını silin. Karakter nasıl davranıyor?

## Dikkat

Sarı çizgi ve yazılar Gizmos ile çizilir. Görünmüyorsa Scene penceresinin araç çubuğundaki Gizmos düğmesinin açık olduğunu denetleyin. Tuşların çalışması için Play modunda Game penceresine bir kez tıklamak gerekir. Karakterin zemini, Play modu başladığında bulunduğu yüksekliktir.
