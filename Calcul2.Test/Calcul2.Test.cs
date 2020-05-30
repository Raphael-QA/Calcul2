using NUnit.Framework;
using System;


namespace Calcul2.Test
{
    [TestFixture]
    public class UnitTest1
    {
        Summator summ;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            summ = new Summator();
            
        }
        [TestCase('(',1)]
        [TestCase(')', 2)]
        [TestCase('+', 3)]
        [TestCase('-', 3)]
        [TestCase('*', 4)]
        [TestCase('/', 4)]
        [TestCase('w', 0)]
        public void TestPriority(char a, int exp)
        {
            summ.znak.Clear();
            summ.nums.Clear();
           int act =  summ.Priority(a);
            Assert.AreEqual(exp, act);
            
        }


        [TestCase("2+222*2", 2, 3)]
        [TestCase("2+222*7482", 1, 0)]
        [TestCase("2+222*7482", 5, 0)]
        [TestCase("2+222*7482", 6, 4)]
        [TestCase("2+222*7482-(2+2)", 11, 0)]
        public void TestSuperMetody(string a, int i, int exp)
        {
            summ.znak.Clear();
            summ.nums.Clear();
            int act = summ.SuperMetod(a,i);
            Assert.AreEqual(exp, act);
        }


        [TestCase(98,2,"+",100)]
        [TestCase(435, 40, "-", 395)]
        [TestCase(32, 71, "*", 2272)]
        [TestCase(6928, 4, "/", 1732)]

        public void TestCalculator(int a, int b, char c,int exp)
        {
            summ.znak.Clear();
            summ.nums.Clear();
            summ.nums.Push(a);
            summ.nums.Push(b);
            summ.znak.Push(c);
            summ.Calculator();
            int act = summ.nums.Pop();
            Assert.AreEqual(exp, act);
        }

        [TestCase('(', '+')]

        public void TestBracketOut(char b, char exp)
        {
            summ.znak.Clear();
            summ.nums.Clear();
            summ.znak.Push('+');
            summ.znak.Push(b);
            summ.BracketOut();
           
            char act = summ.znak.Pop();
            Assert.AreEqual(exp, act);
        }

        [TestCase(1,"(2+2)",0, '(')]
        [TestCase(1, "1+1+(2+2)", 4, '(')]

        public void TestBracket(int znakI, string stroka, int i, char exp)
        {
            summ.znak.Clear();
            summ.nums.Clear();
            summ.Bracket(znakI, stroka, i);

            char act = summ.znak.Pop();
            Assert.AreEqual(exp, act);
        }

       
        [TestCase("+", 0, '+')]
        [TestCase("*", 0, '*')]

        public void TestCharAct(string stroka,int i, char exp)
        {
            summ.znak.Clear();
            summ.nums.Clear();
            
            summ.CharAct(stroka, i);
            
           

            char act = summ.znak.Pop();
            Assert.AreEqual(exp, act);
        }



        [Test]
        public void TestCharAct2()
        {
            summ.znak.Clear();
            summ.nums.Clear();
            
            string stroka = "(2+2)*2";
            summ.znak.Push(stroka[0]);
            summ.CharAct(stroka, 2);
            char exp = stroka[2];
            char act = summ.znak.Pop();

  
            Assert.AreEqual(exp, act);
        }

        [Test]
        public void TestCharAct3()
        {
            summ.znak.Clear();
            summ.nums.Clear();

            string stroka = "1+2+3";

            summ.nums.Push(1);
            summ.znak.Push(stroka[1]);
            summ.nums.Push(2);
         
            summ.CharAct(stroka, 3);

            int exp = 3;
            int act = summ.nums.Pop();


            Assert.AreEqual(exp, act);
        }

        [Test]
        public void TestCharAct4()
        {
            summ.znak.Clear();
            summ.nums.Clear();

            string stroka = "1+2+3";

            summ.nums.Push(2);
            summ.znak.Push(stroka[1]);
            summ.nums.Push(2);

            summ.CharAct(stroka, 3);

            int exp = 3;
            int act = summ.nums.Pop();


            Assert.AreNotEqual(exp, act);
        }
    }
}
