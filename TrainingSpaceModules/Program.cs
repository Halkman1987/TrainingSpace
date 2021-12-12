using System;

class Mainclass
{
    public static void Main(string[] args)
    {
        // -----------------------------------Домашнее задание АНКЕТА для трех человек (Практикум 4.5)----------------------------------


        (string name, string family, string login, int loginlength, bool pet, double age, string[] color) User;

        for (int j = 0; j < 3; j++)
        {
            Console.WriteLine("Введите имя пользователя : ");
            User.name = Console.ReadLine();

            Console.WriteLine("Введите фамилию пользователя : ");
            User.family = Console.ReadLine();

            Console.WriteLine("Введите логин пользователя : ");
            User.login = Console.ReadLine();
            User.loginlength = User.login.Length;
            Console.WriteLine("Длинна логин пользователя : {0}", User.loginlength);
            Console.WriteLine("Имеется ли у вас питомец Да/Нет : ");
            var result = Console.ReadLine();
            if (result == "да")
            {
                User.pet = true;
            }
            else
            {
                User.pet = false;
            }
            Console.WriteLine("Введите ваш возраст : ");
            User.age = double.Parse(Console.ReadLine());
            User.color = new string[3];
            Console.WriteLine("Введите три любимых цвета :");
            for (int i = 0; i < User.color.Length; i++)
            {
                User.color[i] = Console.ReadLine();
            }
            Console.WriteLine();
        }
        Console.ReadKey();

    }
}