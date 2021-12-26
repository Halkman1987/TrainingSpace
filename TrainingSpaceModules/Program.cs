using System;
class Program
{
    //------------------------------------------ ИТОГОВОЕ ЗАДАНИЕ 5.6 ----------------------------------------------------

    public static void Main(string[] args)
    {
        Console.WriteLine("\t\tПредлагаю вам заполнить сводную анкету о вас и ваших предпочтениях !");
        Console.WriteLine();
        (string Name, string Oldname, int Age, string[] Pet, string[] favcolors) UserAnketa;
        UserAnketa = Anketa();
        Console.WriteLine();
        Console.WriteLine("-----------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine();
        PrintUser(UserAnketa.Name, UserAnketa.Oldname, UserAnketa.Age, UserAnketa.Pet, UserAnketa.favcolors);

    }


    static (string Name, string Oldname, int Age, string[] pitom, string[] col) Anketa()
    {

        Console.WriteLine("Введите ваше Имя :");
        var Name = Console.ReadLine();

        Console.WriteLine("Введите вашу Фамилию :");
        var Oldname = Console.ReadLine();


        /// Ввод возраста с проверкой на корректное число 
        int Age;
        string age;
        int intage;
        do
        {
            Console.WriteLine("Введите свой возраст цифрами :");
            age = Console.ReadLine();
        } while (!CheckNum(age, out intage));
        Age = intage;


        /// Ввод количества питомцев если есть 
       // string[] Pet;
        Console.WriteLine("Имеется ли у вас питомец Да/Нет :");
        var result = Console.ReadLine();
        string[] pitom = new string[0];
        if (result == "Да" | result == "да")
        {
            Console.WriteLine("Укажите сколько у вас питомцев (цифрами) : ");
            int pets = Convert.ToInt32(Console.ReadLine());
            pitom = ShowPet(pets);

        }
        else
        {
            Console.WriteLine("У вас нет питомцев");
        }


        Console.WriteLine();

        Console.WriteLine("Напишите сколько у вас любимых цветов цифрами:");
        string[] col = new string[0];
        int favcolors;
        favcolors = Convert.ToInt32(Console.ReadLine());
        col = ShowColor(favcolors);

        Console.WriteLine();



        return (Name, Oldname, Age, pitom, col);
    }


    // Проверка введенных данных 
    static bool CheckNum(string number, out int corrnumber)
    {
        corrnumber = 0;

        if (int.TryParse(number, out int intnum))
        {

            if (intnum > 0 && intnum < 100)
            {
                corrnumber = intnum;
                return true;
            }
            return false;
        }
        else
        {
            corrnumber = 0;
            return false;
        }

    }


    //  Создаем массив кличек питомце по введенному колличеству  
    static string[] ShowPet(int num)
    {
        var Pets = new string[num];
        if (num == 1)
        {
            Console.WriteLine("Напишите кличку вашего питомца :");
            Pets[0] = Console.ReadLine();
        }
        else if (num > 1)
        {
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine($"Напишите кличку {i + 1} питомца :");
                Pets[i] = Console.ReadLine();
            }
        }
        return Pets;
    }

    //  Ввод размера массива цветов, ввод их с консоли и передача обратно 
    public static string[] ShowColor(int fav)
    {
        string[] colors = new string[fav];
        for (int i = 0; i < colors.Length; i++)
        {
            Console.WriteLine($"Напишите ваш любимый цвет номер {i + 1} ");
            colors[i] = Console.ReadLine();
        }
        return colors;
    }


    ///Печать анкеты 
    static void PrintUser(string Name, string Oldname, int Age, string[] Pet, string[] favcolors)
    {
        Console.WriteLine();
        Console.WriteLine("Выводим сводные данные про Пользователя :");
        Console.WriteLine();
        Console.WriteLine($"Ваше имя и фамилия: {Name}  {Oldname}");
        Console.WriteLine($"Вам {Age} лет");
        Console.WriteLine("У вас имеются данные питомцы :");
        foreach (var item in Pet)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("Ваши любимые цвета :");
        foreach (var item in favcolors) { Console.WriteLine(item); }
    }

}
