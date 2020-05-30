using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcul2
{
    public class Summator
    {
       
       public Stack<int> nums;
       public Stack<char> znak;
       public Summator()
        {
            nums = new Stack<int>() ;
            znak = new Stack<char>();
        }
        public void Calculator()
        {
            switch (znak.Pop())
            {
                case '*': nums.Push(nums.Pop() * nums.Pop()); break;
                case '/':
                    int a = nums.Pop();
                    int b = nums.Pop();
                    nums.Push(b / a);
                    break;
                case '+': nums.Push(nums.Pop() + nums.Pop()); break;
                case '-':
                    int c = nums.Pop();
                    int d = nums.Pop();
                    nums.Push(d - c); break;
            }
        }
        public int Priority(char a)
        {
            switch (a)
            {
                case '(':
                    return 1;
                case ')':
                    return 2;
                case '+':
                case '-':
                    return 3;

                case '*':
                case '/':
                    return 4;

                default: return 0;
            }
        }
        public int SuperMetod(string stroka, int idx)
        {
            int count = 0;
            if (idx <= stroka.Length - 1)
            {
                if (int.TryParse(stroka[idx].ToString(), out int i))
                {
                    count++;
                    count += SuperMetod(stroka, idx + 1);
                }
            }
            return count;
        }
        public void BracketOut()
        {
            if (znak.Peek() == '(')
            {
                znak.Pop();
            }
            else                                        //+4+(7-89+7)-1
            {
                while (znak.Peek() != '(')
                {
                    Calculator();
                }
                znak.Pop();
            }
        }
        
        
        public void Bracket(int znakI,string stroka, int i)
        {
            if (znakI == 2)
            {
                BracketOut();
            }
            else
            {
                if (znakI == 1)
                {
                    znak.Push(stroka[i]);
                }
                else
                {
                    while (znak.Count != 0 && znak.Peek() != '(')
                    {
                        Calculator();
                    }
                    znak.Push(stroka[i]);
                }
            }
        }
        public void CharAct(string stroka, int i)
        {
            int znakI = Priority(stroka[i]);

            if (znak.Count == 0)
            {
                znak.Push(stroka[i]);
            }
            else
            {
                if (znakI != Priority(znak.Peek()))
                {
                    if (znakI > Priority(znak.Peek()))
                    {
                        znak.Push(stroka[i]);
                    }
                    else
                    {
                        Bracket(znakI, stroka, i);
                    }
                }
                else
                {
                    while (znak.Count != 0 && znakI == Priority(znak.Peek()))
                    {
                        Calculator();

                    }
                    znak.Push(stroka[i]);
                }

            }
        }
        //public void Test()  //метод только для теста
        //{
        //    //1+2*(3+4/2-(1+2))*2+1
        //    foreach (int a in nums)
        //    {
        //        Console.WriteLine(a);
        //    }
        //    foreach (char q in znak)
        //    {
        //        Console.WriteLine(q);
        //    }
        //}
    }
}
