using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace FinalTask
{
    class Program
    {
        public class MyExciption : Exception
        {
            public MyExciption() : base("Зачем вы ввели не заданные числа???")
            {

            }
        }
        public class SortList
        {
            public delegate void SortFamDel(int a);
            public event SortFamDel SortFamEvent;
            public void Read()
            {
                Console.WriteLine("Введите число 1 или 2");
                int num = Convert.ToInt32(Console.ReadLine());
                if (num != 1 && num != 2) throw new MyExciption();
                NumberEnter(num);

            }
            public void NumberEnter(int a)
            {
                SortFamEvent?.Invoke(a);
            }
        }
        static void Main()
        {
            // ----------------------------------------------- ПЕРВОЕ ЗАДАНИЕ С ВЫВОДОМ МАССИВА ИСКЛЮЧЕНИЙ ------------------------------------------------
            Exception[] exc = { new FormatException("Это сработало Формат Эксэпшн"), new ArgumentNullException(), new MyExciption(), new RankException("Опять этот РанкЭксэпшн"), new TimeoutException() };
            foreach (Exception ex in exc)
            {
                try
                {
                    throw ex;
                }
                catch (MyExciption ex0)
                {
                    Console.WriteLine(ex0.Message);
                }
                catch (FormatException ex1)
                {
                    Console.WriteLine(ex1.Message);
                }
                catch (ArgumentNullException ex2)
                {
                    Console.WriteLine(ex2.Message);
                }
                catch (TimeoutException ex3)
                {
                    Console.WriteLine(ex3.Data.Values);
                }
                catch (RankException ex4)
                {
                    Console.WriteLine(ex4.GetType());
                    Console.WriteLine(ex4.Message);
                }
            }
            // -------------------------------------------------- КОНЕЦ ПЕРВОГО ЗАДАНИЯ -------------------------------------------------------------------


            // ------------------------------------------------- ВТОРОЕ ЗАДАНИЕ С СОРТИРОВКОЙ ФАМИЛИЙ -----------------------------------------------------
            List<string> Family = new List<string>();
            Family.Add("Гринн");
            Family.Add("Огородников");
            Family.Add("Арбузов");
            Family.Add("Шварцнеггер");
            Family.Add("Коломбо");
            Family.Add("Прист");
            Family.Add("Катллер");
            SortList sortList = new SortList();
            sortList.SortFamEvent += Sorted;
            try
            {
                sortList.Read();
            }
            catch (MyExciption ex) { Console.WriteLine(ex.Message); }
            void Sorted(int choice)
            {
                switch (choice)
                {
                    case 1:
                        Family.Sort();
                        foreach (string family in Family)
                        {
                            Console.WriteLine(family);
                        }
                        break;
                    case 2:
                        Family.Sort();
                        Family.Reverse();
                        foreach (string i in Family)
                        {
                            Console.WriteLine(i);
                        }
                        break;
                }
            }
        }

    }


}

