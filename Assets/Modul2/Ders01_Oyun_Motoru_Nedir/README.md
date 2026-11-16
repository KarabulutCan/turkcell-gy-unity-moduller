# Modül 2 | Ders 1 | Oyun Motoru Nedir?

## Bu Uygulamada Ne Yapıyoruz

Tek satır kod yazmadan boş bir Unity projesinin hazır sunduğu sistemleri sayıyoruz. Sahneye bir küp ve bir zemin ekliyor, küpe fizik veriyor ve Play tuşuna basıyoruz. Küp düşüyor, zemine çarpıyor ve duruyor. Bütün bunları motor yapıyor.

## Sahneler

| Sahne | İçerik |
| --- | --- |
| Ders01_Baslangic | Yalnızca Main Camera ve Directional Light bulunur. Yeni açılmış boş bir sahnedir. |
| Ders01_Tamamlanmis | Zemin ve 5 birim yukarıda duran, Rigidbody eklenmiş bir küp bulunur. |

## Adım Adım

1. Ders01_Baslangic sahnesini açın. Hierarchy penceresinde Main Camera ve Directional Light nesnelerine sırayla tıklayın. Boş sahne bile bir kamera ve bir ışıkla gelir.
2. Scene, Game, Inspector, Project ve Console pencerelerinin yerini bulun. Scene dünyayı düzenlediğiniz görünümdür, Game ise oyuncunun kameradan gördüğü görüntüdür.
3. Hierarchy'de boş alana sağ tıklayın, 3D Object menüsünden Cube seçin. Inspector'da küpün dört bileşenini inceleyin. Bunlar Transform, Mesh Filter, Mesh Renderer ve Box Collider bileşenleridir.
4. Küpün Transform bileşeninde Position Y değerini 5 yapın. Ardından 3D Object menüsünden Plane ekleyin ve Scale değerini 3, 1, 3 olarak ayarlayın.
5. Küpü seçin, Add Component düğmesine basın ve Rigidbody ekleyin. Play tuşuna basın. Küp düşer, zemine çarpar ve durur.
6. Play modundayken Game penceresinin sağ üstündeki Stats düğmesini açın. FPS, Batches ve Tris değerlerini okuyun.
7. Play modundan çıkın. File menüsünden Build Profiles penceresini açın ve platform listesine bakın.

## Ne Gördük

| Yaptığımız iş | Motorun sağladığı sistem |
| --- | --- |
| Sahnede hazır kamera ve ışık | Kamera ve ışıklandırma |
| Pencerelerle çalışma | Editör |
| Küpün bileşenleri | Bileşen sistemi ve görüntüleme |
| Küpün düşmesi ve çarpması | Fizik |
| Stats paneli | Performans ölçümü |
| Build Profiles listesi | Platform desteği |

## Kendiniz Deneyin

* Küpün Rigidbody bileşeninde Use Gravity kutusunu kapatın ve Play tuşuna basın. Küp neden düşmüyor?
* Plane nesnesini devre dışı bırakın ve Play tuşuna basın. Küp nereye kadar düşüyor?
* Küpün Position Y değerini 20 yapın. Düşme süresi nasıl değişiyor?

## Dikkat

Play modundayken yaptığınız değişiklikler Play'den çıkınca geri alınır. Kalıcı olmasını istediğiniz ayarları Play modu kapalıyken yapın.
