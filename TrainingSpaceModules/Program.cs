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

        static void Main()
        {

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
        }

    }


}

