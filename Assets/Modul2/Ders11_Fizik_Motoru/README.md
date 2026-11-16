# Modül 2 | Ders 11 | Fizik Motoru

## Bu Uygulamada Ne Yapıyoruz

Bir topa fizik veriyor, zıplayan bir malzeme atıyor, kütle ve sönüm değerlerini değiştiriyoruz. Sonra koddan itki uyguluyor, çarpışmaları ve tetikleyici girişlerini Console'da okuyoruz. Katmanlarla hangi nesnelerin çarpışacağını belirliyor ve kameradan ışın göndererek tıklanan nesneyi buluyoruz.

## Sahneler

| Sahne | İçerik |
| --- | --- |
| Ders11_Baslangic | Zemin, yukarıda Top, Rampa, Kutu ve saydam Alan bulunur. Alan nesnesinin collider'ında Is Trigger açıktır. Betikler eklenmemiştir. |
| Ders11_Tamamlanmis | Top nesnesinde Rigidbody, Zipla malzemesi ve Sekme vardır. Alan nesnesinde TetikAlani, Main Camera nesnesinde IsinGonder vardır. |

## Betikler ve Varlıklar

| Ad | Ne yapar |
| --- | --- |
| Sekme | Boşluk tuşuyla topa yukarı itki verir, çarpışmaları Console'a yazar. |
| TetikAlani | Tetikleyici bölgeye giren ve çıkan nesneyi Console'a yazar. |
| IsinGonder | Fareyle tıklanan noktaya ışın gönderir, çarpılan nesneyi Console'a yazar. |
| Zipla | Fizik malzemesidir. Bounciness 0.9, Bounce Combine Maximum değerindedir. |

## Adım Adım

1. Ders11_Baslangic sahnesini açın. Top nesnesini seçin ve Rigidbody ekleyin. Play tuşuna basın, top düşer ve durur. Play modundan çıkın.
2. Materyaller klasöründeki Zipla fizik malzemesini topun Sphere Collider bileşenindeki Material alanına sürükleyin. Play tuşuna basın, top sekmeye başlar.
3. Play modundayken Rigidbody bileşenindeki Mass değerini 1 yerine 10 yapın. Sonra Linear Damping değerini 0 yerine 2 yapın. Top yavaşlayarak düşer. Play modundan çıkın.
4. Sekme betiğini topa ekleyin. Play tuşuna basın, Game penceresine tıklayın ve Boşluk tuşuna basın. Console'da Carpti satırlarını ve hız değerlerini okuyun.
5. Alan nesnesini seçin, Box Collider bileşeninde Is Trigger kutusunun açık olduğunu görün ve TetikAlani betiğini ekleyin. Play modunda topu Scene penceresinde sürükleyip alanın içinden geçirin. Console'da Girdi ve Cikti satırları belirir.
6. Edit menüsünden Project Settings, Physics bölümünü açın ve Layer Collision Matrix tablosunu bulun. Kutu nesnesini Kutu adlı yeni bir katmana, Top nesnesini Top adlı yeni bir katmana alın. Matriste Top ile Kutu satırının kesiştiği kutunun işaretini kaldırın. Play modunda top kutunun içinden geçer.
7. IsinGonder betiğini Main Camera nesnesine ekleyin ve Kamera alanına Main Camera nesnesini sürükleyin. Play modunda Game penceresinde topa, kutuya ve zemine tıklayın. Console'da Vuruldu satırları, Scene penceresinde kırmızı çizgi görünür.

## Ne Gördük

| Kavram | Görevi |
| --- | --- |
| Rigidbody | Nesneyi fizik motoruna dahil eder |
| Collider | Nesnenin çarpışma hacmini tanımlar |
| Fizik malzemesi | Sürtünmeyi ve sekmeyi belirler |
| Tetikleyici | Nesneleri durdurmadan giriş ve çıkışı bildirir |
| Katman matrisi | Hangi katmanların birbiriyle çarpışacağını belirler |
| Raycast | Bir ışının ilk çarptığı collider'ı bulur |

## Kendiniz Deneyin

* Sekme betiğindeki itki değerini Inspector'dan 20 yapın. Top ne kadar yükseliyor?
* Topun Rigidbody bileşeninde Collision Detection ayarını Continuous yapın ve itkiyi 200 yapın. Top zeminden geçiyor mu?
* Topu rampanın üst ucuna taşıyın ve Zipla malzemesini kaldırın. Top rampadan nasıl iniyor?

## Dikkat

Altıncı adımdaki katman değişikliği bütün projeyi etkiler. Denemeden sonra matristeki işareti geri koyun.
