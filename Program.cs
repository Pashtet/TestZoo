using System;

class Animal
{
    internal byte number;

    ushort caloriesConsumption;

    internal Meal[] mealM;

    public Animal(ushort cc, params Meal[] mealParams)
    //входные параметры: cc - потребление еды в день данного животного, mParams - передача типов пищи как параметры
    {
        mealM = new Meal[mealParams.Length]; 
        foreach (Meal i in mealM)
        {
            mealM = mealParams; 
        }
        caloriesConsumption = cc;
    }

    public decimal MealConsumption(byte d) => Convert.ToDecimal(number * d * (caloriesConsumption) / (mealM[0].calories));
    //расчет необходимого количества пищи для указанного количества дней в месяце d
    public decimal MealConsumption(byte d, ushort n) => Convert.ToDecimal(number * d * (caloriesConsumption / mealM.Length) / (mealM[n - 1].calories));
    //расчет необходимого количества пищи для указанного количества дней в месяце d и в зависимости от количества типов пищи
}
class Meal
{
    internal string typeMeal;
    internal int calories;
    public Meal(string s, int c)
    {
        typeMeal = s;
        calories = c;
    }
}


class Zoo
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, it's zoo!");
        //количество дней в месяце
        byte days = 0;

        //создаем типы пищи с указанием калорийности
        Meal banana = new Meal("Банан", 890);
        Meal meat = new Meal("Мясо", 1430);

        //изначально мы знаем про животных, сколько потребление калорий в день и типы пищи 
        //создаем животных с указанием потребляемых калорий, и типов пищи с помощью передачи параметров
        Animal lion = new Animal(10000, meat);
        Animal monkey = new Animal(1000, banana);
        Animal bear = new Animal(15000, meat, banana);

        //Интерфейс типа выбор из предложенных вариантов
        byte i = 1, j = 1;
        string? s;
        //главное меню выбора подменю ввода типа животных либо расчета необходимого количества еды в месяц
        Console.WriteLine("Данная программа предназначена для расчета количества необходимой еды для животных в зоопарке.");
        Console.WriteLine("На данный момент в программе есть 3 типа животных: медведи, львы, обезьяны.");
        while (i != 0)
        {
            Console.WriteLine("\nДля ввода дней в нужном вам месяце введите - '1'.");
            Console.WriteLine("Для ввода количества животных введите - '2'");
            Console.WriteLine("Чтобы вывести результат введите '5'");
            Console.WriteLine("Для выхода из программы введите - '0'");
            //контроль введенных символов
            s = Console.ReadLine();
            if (byte.TryParse(s, out i))
            {
                switch (i)
                {
                    //подменю ввода количества дней в месяце
                    case 1:
                        Console.WriteLine("\nВведите количество дней в выбранном месяце для расчета:");
                        days = Convert.ToByte(Console.ReadLine());
                        Console.WriteLine("\nВведенное количество дней: " + days);
                        break;

                    //подменю ввода количества животных
                    case 2:
                        {
                            while (j != 0)
                            {
                                Console.WriteLine("\nДля ввода количества львов введите - '1', обезьян  - '2', медведей - '3'.");
                                Console.WriteLine("Для выхода из меню введите - '0'");
                                j = Convert.ToByte(Console.ReadLine());
                                switch (j)
                                {
                                    case 1:
                                        Console.WriteLine("\nВведите количество львов:");
                                        lion.number = Convert.ToByte(Console.ReadLine());
                                        break;

                                    case 2:
                                        Console.WriteLine("\nВведите количество обезьян:");
                                        monkey.number = Convert.ToByte(Console.ReadLine());
                                        break;

                                    case 3:
                                        Console.WriteLine("\nВведите количество медведей:");
                                        bear.number = Convert.ToByte(Console.ReadLine());
                                        break;

                                    default:
                                        Console.WriteLine("\nВведенноe количество по типам животных:\n львы - {0},\n обезьяны - {1},\n медведи - {2}", lion.number, monkey.number, bear.number);
                                        break;
                                }
                            }
                            break;
                        }

                    //рассчет количества еды по типам животных
                    case 5:
                        if (days != 0)
                        {
                            Console.WriteLine("\nРезультат для месяца с количеством дней - '{0}':\n ", days);
                            if (lion.number != 0)
                            {
                                Console.WriteLine("для львов необходимо '{0}' штук еды типа '{1}'", lion.MealConsumption(days), lion.mealM[0].typeMeal);
                            }
                            else
                                Console.WriteLine("не введено количество львов");
                            if (bear.number != 0)
                            {
                                Console.WriteLine("для медведей необходимо '{0}' штук еды типа '{1}' и '{2}' штук еды типа '{3}' при делении видов еды по калорийности поровну за месяц", bear.MealConsumption(days, 1), bear.mealM[0].typeMeal, bear.MealConsumption(days, 2), bear.mealM[1].typeMeal);
                            }
                            else
                                Console.WriteLine("не введено количество медведей");
                            if (monkey.number != 0)
                            {
                                Console.WriteLine("для обезьян необходимо '{0}' штук еды типа '{1}'", monkey.MealConsumption(days), monkey.mealM[0].typeMeal);
                            }
                            else
                                Console.WriteLine("не введено количество обезьян");
                        }
                        else
                        {
                            Console.WriteLine("\nНе введено количество дней!");
                        }

                        break;

                    default:
                        if (i != 0)
                            Console.WriteLine("\nТакого пункта меню нет, повторите ввод.\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nВведен неверный символ, попробуйте еще раз.");
                i = 1;
            }
        }
        Console.WriteLine("\nВыход...");
    }
}