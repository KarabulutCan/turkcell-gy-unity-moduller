# Modül 2 | Ders 6 | Nesne Bileşen Mimarisi

## Bu Uygulamada Ne Yapıyoruz

Hazır nesnelere davranışları bileşen olarak ekliyoruz. Saglik bileşeni can tutar, HasarAlani bileşeni hasar verir, YokOl bileşeni nesneyi siler. Aynı Saglik bileşenini önce oyuncuda, sonra sandıkta kullanıyor ve kodu hiç değiştirmeden farklı sonuç alıyoruz.

## Sahneler

| Sahne | İçerik |
| --- | --- |
| Ders06_Baslangic | Zemin, Oyuncu adlı kapsül, Sandik ve Dusman adlı iki küp bulunur. Betikler klasörde hazırdır ama nesnelere eklenmemiştir. |
| Ders06_Tamamlanmis | Oyuncu ve Sandik nesnelerinde Saglik ile YokOl vardır. Dusman nesnesindeki HasarAlani bileşeninin hedefi Sandik nesnesidir. |

## Betikler

| Betik | Ne yapar |
| --- | --- |
| Saglik | Can tutar. Can bitince canBitti olayını tetikler. |
| HasarAlani | Boşluk tuşuna basılınca hedefe hasar verir. |
| YokOl | Çağrıldığında nesneyi sahneden siler. |

## Adım Adım

1. Ders06_Baslangic sahnesini açın. Oyuncu nesnesini seçin ve Inspector'daki bileşen listesini inceleyin. Hierarchy'de sağ tıklayıp Create Empty ile boş bir nesne oluşturun. Boş nesnede yalnızca Transform bileşeni vardır.
2. Oyuncu nesnesini seçin, Add Component düğmesine basın ve Saglik bileşenini ekleyin. Inspector'da En Yuksek Can alanını ve Can Bitti olay listesini bulun.
3. Oyuncu nesnesine YokOl bileşenini ekleyin. Saglik bileşenindeki Can Bitti listesinde artı düğmesine basın, açılan satıra Oyuncu nesnesini sürükleyin ve fonksiyon listesinden YokOl, Calistir seçin.
4. Dusman nesnesini seçin ve HasarAlani bileşenini ekleyin. Hedef alanına Oyuncu nesnesini sürükleyin. Hasar değeri 30 olarak kalsın.
5. Play tuşuna basın, Game penceresine tıklayın ve Boşluk tuşuna dört kez basın. Console'da can değeri 70, 40, 10 ve eksi 20 olarak yazar. Dördüncü basışta Oyuncu nesnesi Hierarchy'den silinir.
6. Play modundan çıkın. Sandik nesnesine Saglik bileşenini ekleyin ve En Yuksek Can değerini 60 yapın. YokOl bileşenini ekleyin ve Can Bitti olayına bağlayın. Dusman nesnesindeki HasarAlani bileşeninin hedefini Sandik yapın.
7. Play tuşuna basın ve Boşluk tuşuna iki kez basın. Sandik silinir. Aynı Saglik bileşeni bu kez sandıkta çalıştı ve kodda hiçbir değişiklik yapmadık.

## Ne Gördük

| Konu | Sonuç |
| --- | --- |
| Nesne | Bileşenleri taşıyan boş bir kaptır |
| Bileşen | Tek bir işi yapan parçadır |
| Aynı bileşen farklı nesnede | Kod değişmeden yeniden kullanılır |
| SerializeField | private alanı Inspector'a açar |
| UnityEvent | Bileşenleri kod yazmadan birbirine bağlar |

## Kendiniz Deneyin

* YokOl betiğinin sınıf tanımının üstüne RequireComponent(typeof(Saglik)) niteliğini köşeli parantez içinde ekleyin. YokOl bileşenini boş bir nesneye eklediğinizde ne oluyor?
* Dusman nesnesine de Saglik bileşeni ekleyin ve ikinci bir HasarAlani ile ona hasar verin.
* Can Bitti olayına ikinci bir satır ekleyin ve Sandik silinirken Dusman nesnesinin de silinmesini sağlayın.

## Dikkat

Boşluk tuşunun algılanması için Play modunda Game penceresine bir kez tıklamanız gerekir.
