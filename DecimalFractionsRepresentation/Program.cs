using System;

namespace DecimalFractionsRepresentation {
        class Program {
            static void decimalView(int M, int N) {
                string result = "";

                if (M >= N) {
                    Console.Write(M / N);
                    M %= N;
                }
                else
                    Console.Write("0");

                if (M == 0)
                    return;

                Console.Write(".");

                int[] mods = new int[N]; // массив остатков от деления
                int index = 0; // текущий индекс массива остатков (и размер массива)

                for (int i = 0; i < 10 && M != 0; i++) {
                    M *= 10;
                    int div = M / N;
                    M %= N;

                    int modIndex = 0; // ищем такой остаток в массиве остатков
                    while (modIndex < index && mods[modIndex] != M)
                        modIndex++;

                    // если дошли до количества остатков, значит его ещё нет
                    if (modIndex == index) {
                        mods[index++] = M; // добавляем его в масив остатков
                        result += div; // добавляем значение деления к результату
                    }
                    else {
                        result = result.Substring(0, modIndex) + "(" + result.Substring(modIndex) + ")"; // иначе нашли период, добавляем скобки
                        break; // выходим из цикла
                    }
                }

                Console.WriteLine(result);
            }

            static void Main(string[] args) {
                Console.Write("Введите M: ");
                int M = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите N: ");
                int N = Convert.ToInt32(Console.ReadLine());

                decimalView(M, N);

                Console.ReadKey();
            }
        }
    }
