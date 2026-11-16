# Modül 2 | Ders 3 | Oyun Döngüsü

## Bu Uygulamada Ne Yapıyoruz

İki şeyi kendi gözümüzle görüyoruz. Önce Unity'nin olay fonksiyonlarını hangi sırayla çağırdığını Console penceresinde okuyoruz. Sonra üç tuşla kare hızı ayarını değiştiriyor ve Stats panelinde sonucu izliyoruz.

## Sahneler

| Sahne | İçerik |
| --- | --- |
| Ders03_Baslangic | Bir küp ve bir zemin bulunur. Betikler klasörde hazırdır ama küpe eklenmemiştir. |
| Ders03_Tamamlanmis | İki küp bulunur. Kup_KareHizi etkindir. Kup_DonguSirasi kapalıdır, denemek için Inspector'dan açılır. |

## Betikler

| Betik | Ne yapar |
| --- | --- |
| DonguSirasi | Awake, OnEnable, Start, FixedUpdate, Update ve LateUpdate fonksiyonlarında Console'a fonksiyon adını ve kare numarasını yazar. |
| KareHizi | Küpü döndürür. 1, 2 ve 3 tuşlarıyla VSync ve hedef kare hızı ayarını değiştirir. |

## Hazırlık

* Console penceresinde Collapse düğmesi kapalı, Clear on Play açık olmalıdır.
* KareHizi betiği Input System paketini kullanır. Edit menüsünden Project Settings, Player, Active Input Handling ayarı Input System Package (New) ya da Both olmalıdır.

## Adım Adım

1. Ders03_Baslangic sahnesini açın. Project penceresinde Betikler klasöründeki DonguSirasi betiğine çift tıklayın ve altı fonksiyonu okuyun.
2. DonguSirasi betiğini Hierarchy'deki küpün üzerine sürükleyin. Play tuşuna basın, yaklaşık iki saniye sonra Pause tuşuna basın. Console'u en üste kaydırın. Awake, OnEnable ve Start birer kez yazılmıştır.
3. Sonraki satırlara bakın. Her karede Update ve LateUpdate bir kez yazılır. FixedUpdate bazı karelerde iki kez görünür, bazılarında hiç görünmez. Çünkü FixedUpdate kareyle değil sabit zaman adımıyla çağrılır.
4. Play modundan çıkın. Küpten DonguSirasi bileşenini kaldırın ve KareHizi betiğini ekleyin. Game penceresinde Stats düğmesini açın ve Play tuşuna basın.
5. Game penceresine tıklayın ve 1 tuşuna basın. VSync kapanır, FPS değeri çok yükselir. Küp aynı hızda dönmeye devam eder.
6. 2 tuşuna basın. VSync açılır, FPS değeri ekranınızın yenileme hızına iner.
7. 3 tuşuna basın. FPS değeri 30 olur. Küp hâlâ aynı hızda döner.

## Tuşlar

| Tuş | VSync | Hedef kare hızı | Beklenen FPS |
| --- | --- | --- | --- |
| 1 | Kapalı | Sınırsız | Yüzlerce ya da binlerce |
| 2 | Açık | Ekrana bağlı | Ekranın yenileme hızı |
| 3 | Kapalı | 30 | 30 |

## Kendiniz Deneyin

* KareHizi betiğinde Time.deltaTime çarpımını silin ve 1 ile 3 tuşları arasında geçiş yapın. Küpün dönüş hızı neden değişiyor?
* DonguSirasi betiği ekliyken küpü Inspector'dan kapatıp açın. Console'a hangi fonksiyon yeniden yazılıyor?
* Edit menüsünden Project Settings, Time bölümünde Fixed Timestep değerini 0.02 yerine 0.1 yapın. FixedUpdate satırlarının sıklığı nasıl değişiyor? Denemeden sonra değeri 0.02 yapmayı unutmayın.

## Sık Karşılaşılan Durumlar

| Durum | Neden | Çözüm |
| --- | --- | --- |
| Tuşlara basınca hiçbir şey olmuyor | Game penceresi seçili değil | Play modunda Game penceresine bir kez tıklayın |
| Console'da satırlar tek satırda toplanıyor | Collapse açık | Console'daki Collapse düğmesini kapatın |
| Betik eklenirken hata veriyor | Dosya adı ile sınıf adı farklı | Dosya adının sınıf adıyla aynı olduğunu kontrol edin |
