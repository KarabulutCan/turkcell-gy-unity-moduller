# Modül 2 | Ders 4 | Zaman Yönetimi

## Bu Uygulamada Ne Yapıyoruz

Yan yana iki küp döndürüyoruz. Soldaki küp her karede sabit açıyla, sağdaki küp Time.deltaTime ile çarpılarak döner. Kare hızını ve zaman ölçeğini tuşlarla değiştirip iki küp arasındaki farkı izliyoruz. Sonra bir topu düşürerek sabit zaman adımını ve enterpolasyonu görüyoruz.

## Sahneler

| Sahne | İçerik |
| --- | --- |
| Ders04_Baslangic | Zemin, KupSabit, KupDelta, Top ve ZamanDenetimi nesneleri bulunur. Betikler eklenmiştir. Top havada bekler, çünkü Rigidbody bileşeninde Is Kinematic açıktır. |
| Ders04_Tamamlanmis | Aynı sahnedir. Topta Is Kinematic kapalı, Interpolate ayarı Interpolate durumundadır. |

## Betikler

| Betik | Nesne | Ne yapar |
| --- | --- | --- |
| HareketSabit | KupSabit | Her karede sabit 1.5 derece döndürür. Kare hızına bağlıdır. |
| HareketDelta | KupDelta | Saniyede 90 derece döndürür. Kare hızından bağımsızdır. |
| ZamanDenetimi | ZamanDenetimi | Başlangıçta kare hızını 60 yapar, tuşlarla kare hızını ve zaman ölçeğini değiştirir. |

## Tuşlar

| Tuş | Etki |
| --- | --- |
| 1 | Kare hızı sınırı kalkar |
| 2 | Hedef kare hızı 15 olur |
| P | Zaman ölçeği 0 ise 1, değilse 0 olur |
| S | Zaman ölçeği 0.25 olur |

## Adım Adım

1. Ders04_Baslangic sahnesini açın. HareketSabit ve HareketDelta betiklerini açıp karşılaştırın. Game penceresinde Stats düğmesini açın ve Play tuşuna basın. FPS 60 iken iki küp aynı hızda döner.
2. Game penceresine tıklayın ve 2 tuşuna basın. Hedef kare hızı 15 olur. Soldaki küp yavaşlar, sağdaki küp aynı hızda dönmeye devam eder.
3. 1 tuşuna basın. Kare hızı sınırı kalkar. Soldaki küp çok hızlanır, sağdaki küp yine aynı hızda döner.
4. P tuşuna basın. Zaman ölçeği 0 olur. Sağdaki küp durur, soldaki küp dönmeye devam eder. Tekrar P tuşuna basın.
5. S tuşuna basın. Zaman ölçeği 0.25 olur. Hierarchy'de Top nesnesini seçin ve Rigidbody bileşeninde Is Kinematic kutusunu kapatın. Top ağır çekimde düşer. Normal hıza dönmek için P tuşuna iki kez basın. İlk basış oyunu durdurur, ikincisi devam ettirir.
6. Play modundan çıkın. Edit menüsünden Project Settings, Time bölümünü açın. Fixed Timestep 0.02 ve Maximum Allowed Timestep 0.3333 değerlerini bulun. Fixed Timestep değerini 0.1 yapın. Top nesnesinde Is Kinematic kutusunu bu kez Play modu kapalıyken kapatın.
7. Play tuşuna basın. Top kesik kesik düşer. Play modundan çıkın ve Fixed Timestep değerini yeniden 0.02 yapın. Topun Rigidbody bileşeninde Interpolate ayarını Interpolate yapın ve Play tuşuna basın. Düşüş artık pürüzsüzdür.

## Ne Gördük

| Konu | Araç |
| --- | --- |
| Kare hızından bağımsız hareket | Time.deltaTime |
| Fizik hesapları | Sabit zaman adımı (Fixed Timestep) |
| Duraklatma ve ağır çekim | Time.timeScale |
| Fizik nesnesinde pürüzsüz görüntü | Rigidbody Interpolate |

## Kendiniz Deneyin

* HareketSabit betiğindeki 1.5 değerini 90 ile Time.deltaTime çarpımıyla değiştirin. İki küp artık her kare hızında aynı mı dönüyor?
* S tuşundan sonra Stats panelindeki FPS değerine bakın. Zaman ölçeği kare hızını değiştiriyor mu?
* Fixed Timestep değerini 0.005 yapın ve topu düşürün. Hareket nasıl görünüyor? Denemeden sonra değeri 0.02 yapmayı unutmayın.

## Dikkat

Fixed Timestep bütün projeyi etkileyen bir ayardır. Dersin sonunda 0.02 değerinde bıraktığınızdan emin olun.
