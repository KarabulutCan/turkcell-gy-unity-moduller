# Modül 2 | Ders 13 | Girdi Sistemleri

## Bu Uygulamada Ne Yapıyoruz

Önce hiç kod yazmadan girdi tanımını kuruyoruz. Hareket ve Zipla adlı iki eylem tanımlıyor, her birine hem klavye hem oyun kolu bağlıyoruz. Sonra tek bir betikle kapsülü iki cihazla da hareket ettiriyoruz.

## Klasörler

| Klasör | İçerik |
| --- | --- |
| Betikler | OyuncuHareket betiği bulunur. |
| Tamamlanmis | Dersin sonundaki OyuncuGirdi girdi varlığı bulunur. |

## Sahneler

| Sahne | İçerik |
| --- | --- |
| Ders13_Baslangic | Zemin ve Rigidbody eklenmiş Oyuncu adlı kapsül bulunur. Kapsülün devrilmemesi için Rigidbody bileşeninde dönüş eksenleri dondurulmuştur. |
| Ders13_Tamamlanmis | Oyuncu nesnesinde PlayerInput ve OyuncuHareket vardır. W A S D ya da oyun kolunun sol çubuğu hareket ettirir, Boşluk ya da güney düğmesi zıplatır. |

## Eylemler

| Eylem | Tür | Klavye | Oyun kolu |
| --- | --- | --- | --- |
| Hareket | Value, Vector 2 | W A S D | Sol çubuk |
| Zipla | Button | Boşluk | Güney düğmesi |

## Adım Adım

1. Ders13_Baslangic sahnesini açın. Project penceresinde sağ tıklayın, Create menüsünden Input Actions seçin ve adını OyuncuGirdi yapın. Çift tıklayarak pencereyi açın. Sol sütunda artı düğmesiyle Oyuncu adlı bir Action Map oluşturun.
2. Orta sütunda Hareket adlı bir eylem oluşturun. Action Type alanını Value, Control Type alanını Vector 2 yapın. Bağlama eklemek için artı düğmesine basın, Add Up Down Left Right Composite seçin ve W, S, A, D tuşlarını atayın. İkinci bağlama olarak Gamepad altındaki Left Stick seçin.
3. Zipla adlı ikinci eylemi oluşturun ve türünü Button yapın. Bağlama olarak Keyboard altında Space ve Gamepad altında Button South seçin. Sağ üstteki Save Asset düğmesine basın.
4. Hareket eyleminin Left Stick bağlamasını seçin. Sağ sütunda Processors altında artı düğmesiyle Stick Deadzone ekleyin. Sonra eylemin kendisini seçin ve Normalize Vector 2 işlemcisini ekleyin. Kaydedin.
5. Oyuncu nesnesini seçin ve Player Input bileşenini ekleyin. Actions alanına OyuncuGirdi varlığını sürükleyin. Default Map alanında Oyuncu seçin. Behavior alanı Send Messages olarak kalsın. OyuncuHareket betiğini ekleyin.
6. Play tuşuna basın ve Game penceresine tıklayın. W, A, S, D ile hareket edin, Boşluk ile zıplayın. Oyun kolunuz varsa sol çubukla hareket edin ve güney düğmesiyle zıplayın. Çubuğu hafif ve tam eğerek hız farkına bakın.
7. Window menüsünden Analysis, Input Debugger penceresini açın. Bağlı cihazların listesine bakın. Bir cihaza çift tıklayın ve tuşlara bastıkça değerlerin değiştiğini izleyin.

## Ne Gördük

| Kavram | Anlamı |
| --- | --- |
| Action | Oyundaki bir eylemdir, örneğin hareket ya da zıplama |
| Binding | Eylemi bir tuşa ya da cihaz kontrolüne bağlar |
| Action Map | Bir bağlama ait eylemlerin kümesidir |
| Processor | Girdi değerini kod çalışmadan önce düzenler |
| Player Input | Eylemleri betikteki fonksiyonlara iletir |

## Kendiniz Deneyin

* Hareket eylemine ok tuşlarıyla ikinci bir Composite bağlama ekleyin. Betikte hiçbir şeyi değiştirmeden ok tuşları çalışıyor mu?
* Zipla eylemine Interactions altından Hold ekleyin. Zıplamak için tuşu ne kadar basılı tutmanız gerekiyor?
* Player Input bileşeninde Behavior alanını Invoke Unity Events yapın. Inspector'da neler değişiyor?

## Dikkat

OyuncuHareket betiğindeki fonksiyon adları eylem adlarıyla eşleşmelidir. Eylemin adı Hareket ise fonksiyonun adı OnHareket olur. Eylemin adını değiştirirseniz fonksiyonun adını da değiştirmeniz gerekir.
