using UnityEngine;

/// <summary>
/// Yumuşatma eğrisi türleri.
/// </summary>
public enum EgriTuru
{
    Dogrusal,
    YavasBasla,
    YavasBitir,
    YumusakGecis,
    Ozel
}

/// <summary>
/// Sıfır ile bir arasındaki oranı seçilen eğriden geçirir.
/// Sonuç Lerp fonksiyonuna oran olarak verilir.
/// </summary>
public static class Yumusatma
{
    // Eğri türünün ekranda gösterilecek adı.
    public static string Ad(EgriTuru tur)
    {
        switch (tur)
        {
            case EgriTuru.YavasBasla: return "yavaş başla";
            case EgriTuru.YavasBitir: return "yavaş bitir";
            case EgriTuru.YumusakGecis: return "yumuşak geçiş";
            case EgriTuru.Ozel: return "özel eğri";
            default: return "doğrusal";
        }
    }

    public static float Uygula(EgriTuru tur, float t, AnimationCurve ozel)
    {
        switch (tur)
        {
            // Yavaş başlar, hızlanarak biter.
            case EgriTuru.YavasBasla:
                return t * t;

            // Hızlı başlar, yavaşlayarak biter.
            case EgriTuru.YavasBitir:
                return 1f - (1f - t) * (1f - t);

            // İki uçta yavaş, ortada hızlıdır.
            case EgriTuru.YumusakGecis:
                return t * t * (3f - 2f * t);

            // Inspector'da çizilen eğri kullanılır.
            case EgriTuru.Ozel:
                return ozel != null ? ozel.Evaluate(t) : t;

            // Oran değiştirilmeden kullanılır. Hız sabittir.
            default:
                return t;
        }
    }
}
