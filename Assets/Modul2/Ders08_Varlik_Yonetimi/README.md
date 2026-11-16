# Modül 2 | Ders 8 | Varlık Yönetimi

## Bu Uygulamada Ne Yapıyoruz

İki iş yapıyoruz. Önce bir dokuyu projeye alıyor, içe aktarma ayarlarını değiştiriyor ve meta dosyasını inceliyoruz. Sonra bir düşman Prefab'ı kuruyor, sahneye örneklerini yerleştiriyor, bir örnekte değeri geçersiz kılıyor ve bir Prefab varyantı oluşturuyoruz.

## Klasörler

| Klasör | İçerik |
| --- | --- |
| DisKaynak~ | ornek_doku.png dosyası bulunur. Unity, adı ~ işaretiyle biten klasörleri içe aktarmaz. Bu klasörü yalnızca dosya gezgininde görürsünüz. |
| Art | Boştur. Dokuyu buraya sürükleyeceksiniz. |
| Prefabs | Boştur. Prefab'ı burada oluşturacaksınız. |
| Materyaller | Varyantta kullanacağınız KirmiziMat materyali bulunur. |
| Tamamlanmis | Dersin sonundaki doku, Prefab ve varyant bulunur. |

## Sahneler

| Sahne | İçerik |
| --- | --- |
| Ders08_Baslangic | Yalnızca zemin bulunur. |
| Ders08_Tamamlanmis | Dusman Prefab'ının dört örneği ve DusmanKirmizi varyantının bir örneği bulunur. İkinci örnekte En Yuksek Can değeri 50 olarak geçersiz kılınmıştır. |

Bu derste altıncı dersin Saglik ve YokOl betikleri kullanılır.

## Adım Adım

1. Dosya gezgininde bu dersin klasöründeki DisKaynak~ klasörünü açın ve ornek_doku.png dosyasını Unity'deki Art klasörüne sürükleyin. Dokuyu seçin ve Inspector'daki içe aktarma ayarlarını inceleyin. En altta önizleme ve boyut bilgisi yer alır.
2. Max Size değerini 512 yapın ve Apply düğmesine basın. Önizlemedeki boyut küçülür. Compression ayarını None yapın ve Apply düğmesine basın, boyut artar. Ayarları yeniden 2048 ve Normal Quality yapın.
3. Project penceresinde dokuya sağ tıklayın ve Show in Explorer seçin. Dosya gezgininde ornek_doku.png ile ornek_doku.png.meta yan yana durur. Meta dosyasını bir metin editöründe açın, guid ve maxTextureSize satırlarını bulun.
4. Editöre dönün. Hierarchy'de bir küp oluşturun ve adını Dusman yapın. Saglik ve YokOl bileşenlerini ekleyin, Can Bitti olayına YokOl bileşeninin Calistir fonksiyonunu bağlayın. Küpü Prefabs klasörüne sürükleyin. Hierarchy'deki küpün adı maviye döner.
5. Prefab'ı Hierarchy'ye üç kez daha sürükleyin ve örnekleri yan yana dizin. Project'teki Prefab'ı seçin ve En Yuksek Can değerini 100 yerine 200 yapın. Sahnedeki dört örneğin hepsinde değer 200 olur.
6. Sahnedeki ikinci örneği seçin ve En Yuksek Can değerini 50 yapın. Inspector'da değer kalın yazılır ve yanında mavi bir çizgi belirir. Sağ üstteki Overrides menüsünü açın, Revert All ve Apply All seçeneklerine bakın ama basmayın.
7. Project'teki Prefab'a sağ tıklayın, Create menüsünden Prefab Variant seçin ve adını DusmanKirmizi yapın. Varyantı açın, Mesh Renderer bileşenindeki materyali Materyaller klasöründeki KirmiziMat ile değiştirin. Varyantı sahneye sürükleyin. Ana Prefab'da En Yuksek Can değerini 300 yapın. Varyanttaki değer de 300 olur.

## Ne Gördük

| Kavram | Anlamı |
| --- | --- |
| Meta dosyası | Varlığın kimliğini (GUID) ve içe aktarma ayarlarını tutar |
| Prefab | Yeniden kullanılabilir nesne kalıbıdır |
| Örnek | Prefab'ın sahnedeki kopyasıdır, Prefab değişince o da değişir |
| Geçersiz kılma | Tek bir örnekte Prefab'dan farklı bırakılan değerdir |
| Varyant | Bir Prefab'dan türeyen ve onun değişikliklerini izleyen ikinci Prefab'dır |

## Kendiniz Deneyin

* Dokunun Filter Mode ayarını Point yapın ve dokuyu bir küpe sürükleyin. Yakından bakınca görüntü nasıl değişiyor?
* Meta dosyasını silin ve Unity'ye dönün. Unity yeni bir meta dosyası üretir. GUID aynı mı?
* İkinci örnekte Overrides menüsünden Revert All seçin. Değer kaç oluyor?

## Dikkat

Bir varlığı dosya gezgininden taşırsanız meta dosyasını da birlikte taşıyın. En güvenli yol, taşıma ve yeniden adlandırma işlemlerini Unity'nin Project penceresinde yapmaktır.
