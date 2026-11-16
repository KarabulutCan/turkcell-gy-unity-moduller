# Modül 2 | Ders 9 | Render

## Bu Uygulamada Ne Yapıyoruz

Kameranın görüş açısını ve kırpma düzlemini değiştiriyoruz. Sahneye tel kafes görünümünde bakıp üçgenleri görüyoruz. Yeni bir materyal oluşturup rengini, metalliğini, pürüzsüzlüğünü, normal haritasını ve ışımasını ayarlıyoruz. Son olarak pembe görünen bir materyali URP'ye dönüştürüyoruz.

## Klasörler

| Klasör | İçerik |
| --- | --- |
| Dokular | normal_harita ve metal_doku dokuları bulunur. |
| Materyaller | Pembe görünen EskiMateryal bulunur. Built-in hattın Standard shader'ını kullanır. |
| Tamamlanmis | Dersin sonundaki DenemeMat ve KapsulMat materyalleri bulunur. |

## Sahneler

| Sahne | İçerik |
| --- | --- |
| Ders09_Baslangic | Zemin, Kure, Kup ve pembe görünen Kapsul bulunur. |
| Ders09_Tamamlanmis | Kure nesnesinde DenemeMat vardır. Kapsul nesnesinin materyali URP ile uyumludur. |

## Adım Adım

1. Ders09_Baslangic sahnesini açın ve Main Camera nesnesini seçin. Field of View değerini 60 yerine 20, sonra 110 yapın ve Game penceresine bakın. Projection ayarını Orthographic yapın, sonra Perspective değerine geri alın.
2. Clipping Planes altındaki Far değerini 1000 yerine 8 yapın. Uzaktaki küp kaybolur. Değeri yeniden 1000 yapın.
3. Scene penceresinin Shading Mode menüsünü açın ve Wireframe seçin. Küreye yaklaşın, yüzeyin üçgenlerden oluştuğunu görürsünüz. Game penceresinde Stats düğmesini açın, Verts ve Tris değerlerini okuyun. Shading Mode ayarını Shaded değerine geri alın.
4. Project penceresinde sağ tıklayın, Create menüsünden Material seçin ve adını DenemeMat yapın. Inspector'da shader'ın Universal Render Pipeline altındaki Lit olduğunu görün. Materyali küreye sürükleyin.
5. Base Color rengini kırmızı yapın. Metallic değerini 0 ile 1 arasında, Smoothness değerini 0 ile 1 arasında gezdirin ve her değişimde küreye bakın.
6. Normal Map alanına Dokular klasöründeki normal_harita dokusunu sürükleyin ve küreye yaklaşın. Yüzey kabartmalı görünür ama üçgen sayısı değişmez. Emission kutusunu açın, rengini turuncu yapın.
7. Kapsul nesnesini seçin. Materyalinin shader'ı Standard olduğu için pembe görünür. Window menüsünden Rendering, Render Pipeline Converter penceresini açın. Built-in to URP seçin, Material Upgrade kutusunu işaretleyin, Initialize Converters ve Convert Assets düğmelerine basın. Kapsül düzelir.

## Ne Gördük

| Ayar | Etkisi |
| --- | --- |
| Field of View | Küçük değer yakınlaştırır, büyük değer geniş açı verir |
| Far Clipping Plane | Bu uzaklığın ötesindeki nesneler çizilmez |
| Metallic ve Smoothness | Yüzeyin metal gibi mi, parlak mı görüneceğini belirler |
| Normal Map | Üçgen eklemeden yüzeye kabartma görüntüsü verir |
| Pembe materyal | Shader projedeki render hattıyla uyumlu değildir |

## Kendiniz Deneyin

* DenemeMat materyalinde Base Map alanına metal_doku dokusunu sürükleyin. Metallic 1 ve Smoothness 0.6 ile nasıl görünüyor?
* Kamerada Projection ayarını Orthographic yapın ve Size değerini değiştirin. Nesnelerin boyutu uzaklığa göre değişiyor mu?
* Küpe ikinci bir materyal oluşturun ve Surface Type ayarını Transparent yapın. Base Color rengindeki Alpha değerini düşürün.

## Dikkat

Dönüştürme işlemi EskiMateryal varlığını kalıcı olarak değiştirir. Pembe materyali geri getirmek için üst menüden Egitim, Modul 2, Ders 09 sahnelerini kur komutunu çalıştırın.
