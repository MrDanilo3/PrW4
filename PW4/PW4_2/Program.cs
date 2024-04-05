using System;

class Program
{
    static void Main(string[] args)
    {
        // Задані значення n та m для кожного варіанту
        int[] n_values = { 100, 50, 100, 50 };
        int[] m_values = { 4, 3, 2, 8 };

        // Для кожного варіанту (а, б, в, г)
        for (int i = 0; i < n_values.Length; i++)
        {
            int n = n_values[i];
            int m = m_values[i];

            Console.WriteLine($"Для варiанту {(char)('а' + i)}:");

            // Для кожного значення ймовірності помилкового прийому
            for (double p_error = 0; p_error <= 1; p_error += 0.05)
            {
                // Обчислення канальної ємності
                double channel_capacity = CalculateChannelCapacity(n, m, p_error);
                Console.WriteLine($"Ймовiрнiсть помилкового прийому: {p_error:F2}, Канальна ємнiсть: {channel_capacity:F4}");
            }

            Console.WriteLine();
        }
    }

    // Функція для обчислення канальної ємності
    static double CalculateChannelCapacity(int n, int m, double p_error)
    {
        // Обчислення умовної ентропії
        double conditional_entropy = -(p_error * Math.Log(1.0 / m, 2) + (1 - p_error) * Math.Log((1 - p_error) / (m - 1), 2));

        // Обчислення взаємної інформації та канальної ємності
        double mutual_information = Math.Log(m, 2) - conditional_entropy;
        return mutual_information;
    }
}
