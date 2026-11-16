# Modül 2 | Ders 10 | Işık ve Gölge

## Bu Uygulamada Ne Yapıyoruz

Küçük bir odayı aydınlatıyoruz. Önce yönlü ışığın açısını ve rengini değiştiriyor, sonra noktasal ve spot ışık ekliyoruz. Işıkları Baked moduna alıp bir ışık haritası pişiriyor, hareketli nesnenin pişirilmiş odada nasıl aydınlandığına bakıyor ve gölge ayarlarını düzenliyoruz.

## Sahneler

| Sahne | İçerik |
| --- | --- |
| Ders10_Baslangic | Zemin, dört duvar, üç küp ve bir küre bulunur. Hepsi Static olarak işaretlidir. Tek ışık Directional Light nesnesidir. |
| Ders10_Tamamlanmis | Noktasal ve spot ışık eklenmiş, ışık haritası pişirilmiştir. Kure nesnesinin Static işareti kaldırılmıştır. |

Sahnelerde Isik Probu Hacmi adlı bir nesne bulunur. Bu nesne, pişirme sırasında hareketli nesneleri aydınlatacak ışık problarının yerleştirileceği bölgeyi belirler.

## Adım Adım

1. Ders10_Baslangic sahnesini açın ve Directional Light nesnesini seçin. Rotation X değerini 10 ile 80 arasında gezdirin, gölgeler uzar ve kısalır. Color alanından sıcak bir turuncu seçin.
2. Hierarchy'de sağ tıklayın, Light menüsünden Point Light ekleyin ve odanın ortasına, duvarların üst hizasına yerleştirin. Range değerini 10 yapın ve Intensity değerini artırın.
3. Light menüsünden Spot Light ekleyin ve küreye doğrultun. Spot Angle değerini 30 yerine 90 yapın. Inner ve Outer açılarının ışık konisini nasıl değiştirdiğine bakın.
4. Directional Light nesnesinin Mode alanında Realtime, Mixed ve Baked seçeneklerini sırayla inceleyin ve Baked seçin. Point Light ve Spot Light nesnelerini de Baked yapın.
5. Window menüsünden Rendering, Lighting penceresini açın. Lightmap Resolution değerini 10 yapın ve Generate Lighting düğmesine basın. Sağ alttaki ilerleme çubuğunu izleyin. Pişirme bitince odanın köşelerindeki dolaylı ışığa ve yumuşak gölgelere bakın.
6. Kure nesnesini seçin ve Static işaretini kaldırın. Play tuşuna basın ve küreyi Scene penceresinde sürükleyin. Küre pişirilmiş odada aydınlanmaya devam eder. Lighting penceresinde Adaptive Probe Volumes bölümüne bakın.
7. Directional Light nesnesini yeniden Mixed yapın. Gölge ayarlarında Bias değerini 0 yapın, zeminde çizgili gölge lekeleri oluşur. Değeri 1 yapın, küpün gölgesi tabanından kopar. Değeri ikisinin arasında bir yere getirin.

## Ne Gördük

| Işık modu | Ne zaman hesaplanır | Hareketli nesneyi aydınlatır mı |
| --- | --- | --- |
| Realtime | Her karede | Evet |
| Mixed | Dolaylı ışık önceden, doğrudan ışık her karede | Evet |
| Baked | Tamamı önceden | Yalnızca ışık probları üzerinden |

## Kendiniz Deneyin

* Lightmap Resolution değerini 40 yapıp yeniden pişirin. Gölge kenarları ve pişirme süresi nasıl değişiyor?
* Bir küpün Static işaretini kaldırıp yeniden pişirin. Küpün gölgesi ışık haritasında kalıyor mu?
* Window menüsünden Rendering, Lighting penceresinde Environment sekmesini açın ve Intensity Multiplier değerini 0 yapın. Oda nasıl görünüyor?

## Dikkat

Pişirme bilgisayarın gücüne göre birkaç saniye ile birkaç dakika arasında sürer. Pişirilmiş ışık, sahne değiştikçe kendiliğinden güncellenmez. Nesneleri ya da ışıkları değiştirdikten sonra yeniden Generate Lighting düğmesine basmanız gerekir.
