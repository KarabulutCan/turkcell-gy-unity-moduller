# Modül 2 | Ders 15 | Derleme ve Dağıtım

## Bu Uygulamada Ne Yapıyoruz

Modülün sonunda ilk derlememizi alıyoruz. Küçük bir oyun sahnesini Windows için derliyor, çıkan dosyaları inceliyor, derleme raporunu okuyor ve Web profilinin ayarlarına bakıyoruz.

## Sahne

| Sahne | İçerik |
| --- | --- |
| Ders15_Oyun | Önceki derslerin parçalarından kurulmuş küçük bir oyundur. Oyuncu W A S D ile hareket eder, Boşluk ile zıplar. Dönen küplere dokununca küp kaybolur ve Console'a puan yazılır. Arka planda müzik çalar. |

Bu sahne on üçüncü dersin OyuncuHareket betiğini ve girdi varlığını, beşinci dersin Dondur betiğini, on ikinci dersin müziğini kullanır. Gorseller klasöründe uygulama simgesi olarak kullanabileceğiniz oyun_ikonu görseli bulunur.

## Adım Adım

1. Ders15_Oyun sahnesini açın. File menüsünden Build Profiles penceresini açın ve Platforms listesinde Windows seçin. Scene List bölümünde Add Open Scenes düğmesine basın. Listede yalnızca Ders15_Oyun sahnesinin işaretli olduğundan emin olun, çünkü oyun listedeki ilk işaretli sahneyle başlar.
2. Player Settings düğmesine basın. Company Name ve Product Name alanlarını doldurun, Version alanına 0.1.0 yazın. Default Icon alanına oyun_ikonu görselini sürükleyin. Resolution and Presentation altında Fullscreen Mode ayarına bakın.
3. Other Settings altında Scripting Backend alanını bulun ve Mono seçili kalsın. Build Profiles penceresine dönün, Development Build ve Autoconnect Profiler kutularını işaretleyin.
4. Build düğmesine basın ve boş bir klasör seçin. Derleme ilerleme çubuğunu izleyin.
5. Derleme bitince klasörü dosya gezgininde açın. Exe dosyasını, Data klasörünü, UnityPlayer.dll dosyasını ve MonoBleedingEdge klasörünü bulun. Exe dosyasını çalıştırın. Oyun açılır, köşede Development Build yazısı görünür ve Profiler kendiliğinden bağlanır. Oyunu kapatın.
6. Console penceresinin sağ üst menüsünden Open Editor Log seçin. Dosyada Build Report bölümünü bulun ve varlıkların boyuta göre sıralandığı listeye bakın.
7. Build Profiles penceresine dönün ve Platforms listesinde Web seçin ama Switch Platform düğmesine basmayın. Sağdaki ayarlarda Compression Format, Memory Size ve WebGL Template alanlarına bakın. Player Settings içinde Scripting Backend alanının IL2CPP olarak kilitli olduğunu görün.

## Derleme Klasöründe Neler Var

| Dosya ya da klasör | İçerik |
| --- | --- |
| Exe dosyası | Oyunu başlatan küçük programdır |
| Data klasörü | Sahneler, varlıklar ve derlenmiş betiklerdir |
| UnityPlayer.dll | Motorun kendisidir |
| MonoBleedingEdge | Betikleri çalıştıran Mono çalışma ortamıdır |

## Kendiniz Deneyin

* Development Build kutusunu kapatıp yeniden derleyin. Klasörün boyutu ve oyunun açılış süresi nasıl değişiyor?
* Scripting Backend ayarını IL2CPP yapıp derleyin. Derleme süresi ve çıkan dosyalar nasıl değişiyor?
* Web platformunun modülü kuruluysa Web için derleyin ve Build And Run düğmesiyle tarayıcıda açın.

## Dikkat

Derleme klasörünü proje klasörünün içine koymayın. Derleme çıktıları sürüm kontrolüne eklenmez. Web derlemesi, index.html dosyasına çift tıklanarak açılamaz. Tarayıcı güvenlik nedeniyle dosyaları yüklemez, bu yüzden Build And Run ya da yerel bir sunucu kullanılır.
