using System;

class Program
{
    static void Main(string[] args)
    {
        // Задані значення частот
        double[] frequencies = { 1, 3, 5, 7 }; // в МГц

        // Задані значення відношень потужності сигналу до потужності перешкоди
        for (double snr_ratio = 0; snr_ratio <= 10; snr_ratio += 0.5)
        {
            Console.WriteLine($"Для вiдношення потужностi сигналу до потужностi перешкоди {snr_ratio}:");

            // Для кожної частоти
            foreach (var frequency in frequencies)
            {
                // Обчислення пропускної спроможності для поточного значення частоти
                double bandwidth = CalculateBandwidth(snr_ratio, frequency * Math.Pow(10, 6)); // переведення МГц в Гц
                Console.WriteLine($"Частота: {frequency} МГц, Пропускна спроможнiсть: {bandwidth} Гц");
            }

            Console.WriteLine();
        }
    }

    // Функція для обчислення пропускної спроможності
    static double CalculateBandwidth(double snr_ratio, double frequency)
    {
        double noise_density = 1 / Math.Pow(10, snr_ratio / 10); // обчислення спектральної щільності шуму
        return Math.Log(1 + snr_ratio) / Math.Log(2) * frequency;
    }
}
