using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcul2
{
    class Program
    {        
        static void Main(string[] args)
        {
            while (true)
            {
                Summator sum = new Summator();
                Console.Clear();
                Console.WriteLine("                              Злой Калькулятор");
                string stroka = Console.ReadLine();
                for (int i = 0; i < stroka.Length; i++)
                {
                    int act = sum.SuperMetod(stroka, i); //Определяет знак или число.
                    if (act == 0)//если 0, значит знак.
                    {
                        sum.CharAct(stroka, i);//Проводит всю основную работу со знаками и числами (Подроблнее в классе "Summator").
                    }
                    else
                    {
                        sum.nums.Push(Convert.ToInt32(stroka.Substring(i, act))); //Определяет сколько чисел и помещает их в стек.
                        i += act - 1;
                    }
                }
                while (sum.znak.Count != 0)  //Если знаки в стеке остались идет обработка оставшихся чисел и снаков.
                {
                    sum.Calculator();
                }
                Console.WriteLine($"\n{sum.nums.Peek()}  - Столько кругов ада ждут тебя!\n");
                Console.WriteLine("\nНажми на что то, чтобы продолжить...");
                Console.ReadKey();
            }
        }
        
    }
}
