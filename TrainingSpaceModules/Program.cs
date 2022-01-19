using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        //Заводим номенклатуру товаров 
        Product[] tov = new Product[11];
        tov[0] = new Product (1 , "Гриф Олимпийский с замками 20кг",  20000 );
        tov[1] = new Product(2 ,"Диск 20кг",  3000);
        tov[2] = new Product(3 ,"Диск 10кг",  2000);
        tov[3] = new Product(4 ,"Диск 5кг",  1000);
        tov[4] = new Product(5 ,"Гиря 32кг",  2500);
        tov[5] = new Product(6 ,"Гиря 24кг",  2000);
        tov[6] = new Product(7 ,"Гиря 16кг",  1500);
        tov[7] = new Product(8 ,"Гантель 5кг", 600);
        tov[8] = new Product(9 ,"Гантель 8кг", 700);
        tov[9] = new Product(10 ,"Гантель 12кг", 800);
        tov[10] = new Product(11 ,"Гантель 16кг", 900);
        
        //Добавление в Список товаров из класса Продукт
        List<Product> ListTov = new List<Product>();
        foreach(var ls in tov)
        {
            ListTov.Add(ls);// заносим список товаров в Лист
        }
        //----------------------------- Начало Программы ---------------------------------------------- 
        Console.WriteLine("\tДобро пожаловать в магазин спорт-инвентаря :");
        Console.WriteLine("  Введите своё Имя :");
        string nm = Console.ReadLine();
        Console.WriteLine("  Введите свою Фамилию :");
        string fn = Console.ReadLine();
        Console.WriteLine("  Введите свой номер телефона :");
        string tn = Console.ReadLine();
        
        // Объявляем экземпляры класса для занесения в них значений
        Order<Delivery> MyOrder = new Order<Delivery>();
        MyOrder.user = new User(nm, fn, tn);
        Console.WriteLine("  ------ Данные приняты ------");
        Console.WriteLine("\tИмеются данные товары :");
        foreach(var p in tov)//Вывод списка товаров
        {
            Console.WriteLine( $" {p.pd} - {p.name} = {p.cash} рублей");
        }
        Console.WriteLine("-------------------------------------------------------------------------");
        int numtov;
        int muchtov;
        string choice; 
        //выбор товара и количество (покупателем)
        do
        {
            Console.WriteLine("   Выберите товар, введите номер товара :");
            numtov = Convert.ToInt32(Console.ReadLine());
            //MyOrder.TovaryVkorzineList.Add(ListTov[numtov-1]);
            Console.WriteLine(" Укажите количество :");
            muchtov = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < muchtov; i++)
            {
                MyOrder.TovaryVkorzineList.Add(ListTov[numtov-1]);
            }
            Console.WriteLine("   Желаете ли вы добавить еще товары в корзину ? :\n Да/Нет");
            choice = Console.ReadLine();
        }
        while (choice == "да" | choice == "Да" | choice == "ДА");
        Console.WriteLine("-------------------------------------------------------------------------");
        Console.WriteLine("-------------------------------------------------------------------------");
        Console.WriteLine("  Вы выбрали следующие товары :");
        foreach (var t in MyOrder.TovaryVkorzineList)
        {
            Console.WriteLine($"{t.name} , {t.cash} ");
        }
        double sum =0;
        int kolvo = 0;
        //Посчет суммы товаров в корзине и количество 
        foreach (var t in MyOrder.TovaryVkorzineList)
        {
            sum += t.cash;// поле цены товара
            kolvo ++;// счетчик колличества
        }
        MyOrder.SumTov = sum;

        Console.WriteLine($"\tОбщая сумма покупки составляет : {MyOrder.SumTov}");
        Console.WriteLine("-------------------------------------------------------------------------");
       

        Console.WriteLine("   Выберите способ доставки:\n 1 - Если нужна доставка на дом \n 2 - Если требуется доставка до Постамата \n 3 - Если вы хотите забрать товар из магазина");
        Adress adress = new Adress();
        int change = Convert.ToInt32(Console.ReadLine());
        switch (change)
        {
            case 1:
                Console.WriteLine("------------------------------------------------------------");
                MyOrder.Delivery = new HomeDelivery();
                var homedeliv = (HomeDelivery)MyOrder.Delivery;
                homedeliv.GetPrice(kolvo);
                Console.WriteLine("  Вы выбрали доставку на дом, введите свой адрес для доставки :");
                Console.WriteLine("  Введите индекс вашего населеннго пункта :");
                adress.indexcity = Console.ReadLine();
                Console.WriteLine("  Введите ваш город :");
                adress.city = Console.ReadLine();
                Console.WriteLine("  Введите вашу улицу :");
                adress.street = Console.ReadLine();
                Console.WriteLine("  Введите номер дома :");
                adress.house = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("  Введите номер квартиры:");
                adress.appartment = Convert.ToInt32(Console.ReadLine());
                homedeliv.SetHomeAdrNew(adress);
                break;
            
            case 2:
                Console.WriteLine("------------------------------------------------------------");
                MyOrder.Delivery = new PickPointDelivery(645982);// Цифры в скобках это boxnumber для присваивания номера отправления посылки,
                                                                 // по идее должен в ордер вкладываться при необходимости
                var pickpoit = (PickPointDelivery)MyOrder.Delivery;
                pickpoit.SetPick();//выбор постамата
                pickpoit.GetPrice(kolvo);// Подсчет стоимости доставки от количества товаров
                break;
            
            case 3:
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("Вы выбрали доставку в магазин");
                MyOrder.Delivery = new ShopDelivery();
                var shopdev = (ShopDelivery)MyOrder.Delivery;
                shopdev.GetPrice(kolvo);
                break;
        }

        MyOrder.Number = 100395;//присваиваем номер заказа, хотелось бы сделать это через рандомное значение 5-6 значное, но я этого не умею (
        Console.WriteLine($"  {MyOrder.user.Name} {MyOrder.user.Family} благодарим вас за выбор нашего магазина");
        Console.WriteLine($" ---- сводная информация по вашему заказу номер {MyOrder.Number} ---- ");
        Console.WriteLine(" Выбранные товары в корзине :");
        foreach(var tt in MyOrder.TovaryVkorzineList)
        {
            Console.WriteLine($"  {tt.name}");
        }
        Console.WriteLine($" Итоговая сумма к оплате = { MyOrder.SumTov} рублей ");
        Console.Write($" Выбранный вариант доставки :  ");
        MyOrder.Delivery.Getadress();
        Console.WriteLine($" Стоимость доставки = { MyOrder.Delivery.PriceDelivery} рублей ");
        Console.Write($" При необходимости в вами свяжется наш менеджер по телефону : {MyOrder.user.Telephone} ");

    }
    abstract class Delivery  
    {
        abstract public Adress Adress { get; set; } 
        abstract public int PriceDelivery { get; set; }
        abstract public void Getadress();
    }
    class HomeDelivery : Delivery
    {
        public override Adress Adress { get; set;}
        public void SetHomeAdrNew(Adress adress)
        {
            Adress = adress;
        }
       /* public void SetHomeAdr()// Ввод адреса для доставки НО НЕ СРАБОТАЛО !!!
        {
            Console.WriteLine("Вы выбрали доставку на дом, введите свой адрес для доставки :");
            Console.WriteLine("Введите индекс вашего населеннго пункта :");
            Adress.indexcity = Console.ReadLine();
            Console.WriteLine("Введите ваш город :");
            Adress.city = Console.ReadLine();
            Console.WriteLine("Введите вашу улицу :");
            Adress.street = Console.ReadLine();
            Console.WriteLine("Введите номер дома :");
            Adress.house = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите номер квартиры:");
            Adress.appartment = Convert.ToInt32(Console.ReadLine());
        }*/
        public override int PriceDelivery { get; set;} 
        public void GetPrice(int num)// num количество товаров
        {
            PriceDelivery = num * 100;
        }
        public override void Getadress() // Метод вывода адреса 
        {
            Console.WriteLine(" \tВы выбрали доставку на дом!");
            Console.WriteLine($"\tАдресс по которому будет произведена доставка:\n Город {Adress.city}, улица {Adress.street}, дом {Adress.house}, квартира номер {Adress.appartment}");
        }
    }
    class PickPointDelivery : Delivery
    {
        public PickPointDelivery(int boxnumber)
        {
            this.boxnumber = boxnumber;
        }
        public int boxnumber;//значение попадает из конструктора
        public override Adress Adress { get; set; }
        public override int PriceDelivery { get; set; }
        public string SetPick1;
        public void GetPrice(int num)// num количество товаров 
        {
            PriceDelivery = num * 50;
        }
        public string[] PickAdr = { " 1) Постамат-Приозерный, г.Уфа, ул.Шафиева, дом 12 ", " 2) Постамат-УфаАрена, г.Уфа, ул.Зорге, дом 46" };
        public void SetPick()// принимает значение для постамата
        {
            Console.Write(" В вашем городе имеются следующие постаматы : \n ");
            foreach(var pt in PickAdr)
            {
                Console.WriteLine(pt);
            }
            Console.WriteLine($"Выбирите нужный по номеру от 1 до {PickAdr.Length} ");
            int i = 0;
            i = Convert.ToInt32( Console.ReadLine());
            Console.Write(" Вы выбрали данный постамат : ");
            Console.WriteLine($" {PickAdr[i-1]} ");
            SetPick1 = PickAdr[i - 1];
            Console.WriteLine("------------------------------------------------------------");
        }
        public override void Getadress()
        {
            Console.WriteLine("   Вы выбрали доставку в постамат");
            Console.WriteLine($"  По этому номеру можно будет забрать заказ из постамата : {boxnumber}");
            Console.WriteLine($"  Вам необходимо забрать посылку по адресу{SetPick1}");
        }
    }
    class ShopDelivery : Delivery
    {
        public override Adress Adress { get; set; }
        public override int PriceDelivery { get; set; }
        public string ShopAdr = " г.Уфа, ул.Черниковская 87 ";
        public void GetPrice(int num)// num количество товаров к примеру
        {
            PriceDelivery = num * 10;
           // Console.WriteLine($" Сумма доставки составляет : {PriceDelivery} рублей");
        }
       
        public override void Getadress()
        {
            Console.WriteLine($" Адресс магазина из которого можно будет забрать посылку :\n {ShopAdr}");
        }
    }

    // Заказ 
    class Order<TDelivery> where TDelivery : Delivery
    {
        public Order()// пустой конструктор
        {

        }
        public User user;
        public TDelivery Delivery;
        public int Number;
        public List<Product> TovaryVkorzineList = new List<Product> { };
        public double TovaryVkorzine;// список выбранных товаров или List 
        public double SumTov;// сумма товаров выбранных
       
    }
    public class Product 
    {
        public int pd;
        public string name;
        public double cash;
        public Product(int id,string Name, double cash)
        {
            pd = id;
            name = Name;
            this.cash = cash;
        }
    }
    public class Adress
    {
        private string IndexCity;
        private string City;
        private string Street;
        private int House;
        private int Appartment;
        public string? indexcity { get { return IndexCity; } set { IndexCity = value; } }
        public string city { get { return City; } set { City = value; } }
        public string street { get { return Street; } set { Street = value; } }
        public int house { get { return House; } set { House = value; } }
        public int appartment { get { return Appartment; } set { Appartment = value; } }
        public Adress()
        {

        }
        public Adress(string index, string city, string street, int house, int appart)
        {
            indexcity = index;
            this.city = city;
            this.street = street;
            this.house = house;
            appartment = appart;
        }
    }
    public class User
    {
        public string Name;
        public string Family;
        public string Telephone;
        public User( string name, string family, string telephone)
        {
            Name = name;
            Family = family;
            Telephone = telephone;
        }
    }
}


