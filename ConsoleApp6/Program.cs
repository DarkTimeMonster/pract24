using ConsoleApp6;
using DateTime = ConsoleApp6.DateTime;

public class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine($"\n====================\n");
            
            Console.WriteLine("Введите номер задания - ");
            Console.WriteLine("1 Наследование  ");
            Console.WriteLine("2 Полиморфизм  ");
            Console.WriteLine(" ");
            int x = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (x)
            {
                case 1:
                    Console.WriteLine("Введите номер задания - ");
                int y = int.Parse(Console.ReadLine()); 
                switch (y)
                {
                case 1: 
                    InputInfoZ1();
                    break;
                case 2:
                    InputInfoZ2();
                    break;
                }
                break;
                case 2: 
                    Console.WriteLine("Введите номер задания - ");
                int z = int.Parse(Console.ReadLine());
                switch (z)
                {
                    case 1:
                        InputInfoZ3();
                        break;
                    case 2:
                        InputInfoZ4();
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
                break;
            }
        }
        Console.ReadKey();
    }
    
    static void InputInfoZ1()
    {
        Console.Write("Введите скорость движения объекта (м/с): ");
        if (!double.TryParse(Console.ReadLine(), out double speed))
        {
            Console.WriteLine("Ошибка ввода. Пожалуйста, введите числовое значение.");
            return;
        }
        
       movAutomat movingAutomaton = new movAutomat(speed);
       
        Console.Write("Введите входную последовательность (например, 012): ");
        string inputSequence = Console.ReadLine();
        
        movingAutomaton.ProcessInput(inputSequence);
        
        Console.Write("Введите время движения (в секундах): ");
        if (!double.TryParse(Console.ReadLine(), out double time))
        {
            Console.WriteLine("Ошибка ввода. Пожалуйста, введите числовое значение.");
            return;
        }
        
        double distance = movingAutomaton.CalculateDistance(time);
        Console.WriteLine($"Скорость: {movingAutomaton.Speed} м/с, Время: {time} с, Пройденное расстояние: {distance} м");
    }
    static void InputInfoZ2()
    {
        // Ввод данных для класса-родителя
        Console.WriteLine("Введите дату для класса-родителя:");

        Console.Write("День: ");
        int d1 = int.Parse(Console.ReadLine());

        Console.Write("Месяц: ");
        int m1 = int.Parse(Console.ReadLine());

        Console.Write("Год: ");
        int y1 = int.Parse(Console.ReadLine());

        Date date = new Date(d1, m1, y1);
        Console.WriteLine("\nКласс-родитель:");
        Console.WriteLine(date.GetInfo());
        Console.WriteLine($"Високосный год: {date.IsLeapYear()}");
        date.AddFiveDays();
        Console.WriteLine("После добавления 5 дней:");
        Console.WriteLine(date.GetInfo());
        Console.WriteLine();
        
        Console.WriteLine("Введите дату и время для класса-потомка:");

        Console.Write("День: ");
        int d2 = int.Parse(Console.ReadLine());

        Console.Write("Месяц: ");
        int m2 = int.Parse(Console.ReadLine());

        Console.Write("Год: ");
        int y2 = int.Parse(Console.ReadLine());

        Console.Write("Часы: ");
        int h = int.Parse(Console.ReadLine());

        Console.Write("Минуты: ");
        int min = int.Parse(Console.ReadLine());

        Console.Write("Секунды: ");
        int sec = int.Parse(Console.ReadLine());

        DateTime dateTime = new DateTime(d2, m2, y2, h, min, sec);
        Console.WriteLine("\nКласс-потомок:");
        Console.WriteLine(dateTime.GetInfo());
        dateTime.Add100Minutes();
        Console.WriteLine("После добавления 100 минут:");
        Console.WriteLine(dateTime.GetInfo());

        Console.ReadLine();
    }
    static void InputInfoZ3()
    {
        Console.WriteLine("Введите бренд мобильного телефона: ");
        string brand = Console.ReadLine();
        Console.WriteLine("Введите цену мобильного телефона: ");
        decimal price = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("Введите память мобильного телефона (MB): ");
        int memory = Convert.ToInt32(Console.ReadLine());
 
        MobilePhone phone1 = new MobilePhone(brand, price, memory);
        phone1.DisplayInfo();
        
        Console.WriteLine($"\n====================\n");
        
        Console.WriteLine("Введите количество SIM карт (P): ");
        decimal p = Convert.ToDecimal(Console.ReadLine());
        MobilePhoneWithP phone2 = new MobilePhoneWithP(brand, price, memory, p);
        
        Console.WriteLine($"\n====================\n");
        
        phone2.DisplayInfo();
        
    }
    static void InputInfoZ4()
    {
                    Console.WriteLine("Введите количество студентов: ");
                    int studentCount = Convert.ToInt32(Console.ReadLine());
 
                    List<Student> students = new List<Student>();
 
                    for (int i = 1; i <= studentCount; i++)
                    {
                        Console.WriteLine($"\nВведите данные для студента {i}:");
                        Console.WriteLine("ФИО студента: ");
                        string fullName = Console.ReadLine();
                        Console.WriteLine("Факультет: ");
                        string faculty = Console.ReadLine();
                        Console.WriteLine("Курс: ");
                        int year = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Минимальная оценка: ");
                        decimal minGrade = Convert.ToDecimal(Console.ReadLine());
 
                        Console.WriteLine("Является ли студент контрактником (true/false): ");
                        bool isContract = Convert.ToBoolean(Console.ReadLine());
 
                        if (isContract)
                        {
                            Console.WriteLine("Оплачено ли обучение (true/false): ");
                            bool isContractPaid = Convert.ToBoolean(Console.ReadLine());
                            students.Add(new ContractStudent(fullName, faculty, year, minGrade, isContractPaid));
                        }
                        else
                        {
                            students.Add(new Student(fullName, faculty, year, minGrade));
                        }
                    }
                    
                    Console.WriteLine($"\n====================\n");
 
                    Console.WriteLine("\nИнформация о студентах до перевода:");
                    foreach (var student in students)
                    {
                        Console.WriteLine(student.GetInfo());
                    }
 
                    // Перевод на следующий курс
                    foreach (var student in students)
                    {
                        student.PromoteToNextYear();
                    }
                    
                    Console.WriteLine($"\n====================\n");
                    
                    Console.WriteLine("\nИнформация о студентах после перевода:");
                    foreach (var student in students)
                    {
                        Console.WriteLine(student.GetInfo());
                    }
    }
}