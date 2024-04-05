using System;

class Program
{
    static void Main(string[] args)
    {
        // Задані довжини сигналів
        double[] t0_values = { 0.2, 0.3, 0.5, 0.8 };
        double[] t1_values = { 0.8, 0.7, 0.5, 0.2 };

        // Для кожного варіанту
        for (int i = 0; i < t0_values.Length; i++)
        {
            double t0 = t0_values[i];
            double t1 = t1_values[i];

            // Обчислення ймовірностей появи нульового та одиничного сигналів
            double p0 = 1 - t0;
            double p1 = 1 - t1;

            // Обчислення максимальної швидкості передачі інформації за формулою Шеннона
            double max_rate = Math.Log(2, Math.E) * (p0 * Math.Log(1 / p0, Math.E) + p1 * Math.Log(1 / p1, Math.E));

            Console.WriteLine($"Для варiанту {(char)('а' + i)} максимальна швидкiсть передачi iнформацiї: {max_rate}");
        }
    }
}
