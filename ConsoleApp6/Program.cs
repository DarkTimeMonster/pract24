using ConsoleApp6;

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
        Console.WriteLine("=== Демонстрация автомата движения объекта ===");

        Console.Write("Введите скорость объекта (м/с): ");
        double speed = double.TryParse(Console.ReadLine(), out var val) ? val : 1.0;

        var automaton = new MowAutomat(speed);
        automaton.DisplayInfo();

        // Ввод переходов
        Console.WriteLine("\nВведите входы (например, 110, 012, 111). Введите 'stop' для завершения:");
        string input;
        while ((input = Console.ReadLine()) != "stop")
        {
            automaton.ProcessInput(input);
        }

        // Расчёт расстояния
        Console.Write("\nВведите время движения (сек): ");
        double time = double.TryParse(Console.ReadLine(), out var tVal) ? tVal : 0;

        double distance = automaton.CalculateDistance(time);
        Console.WriteLine($"Объект прошёл расстояние: {distance} м");

        Console.WriteLine("Работа завершена.");
        Console.ReadKey();
    }
    static void InputInfoZ2()
    {
        Console.WriteLine("Введите координаты точки A (x1 y1):");
        int x1 = int.Parse(Console.ReadLine());
        int y1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите координаты точки B (x2 y2):");
        int x2 = int.Parse(Console.ReadLine());
        int y2 = int.Parse(Console.ReadLine());

        Console.Write("Введите цвет треугольника: ");
        string color = Console.ReadLine();

        Console.Write("Введите текущие часы: ");
        int hour = int.Parse(Console.ReadLine());

        Console.Write("Введите текущие минуты: ");
        int minute = int.Parse(Console.ReadLine());

        ColoredTrio trio = new ColoredTrio(x1, y1, x2, y2, color, hour, minute);

        Console.WriteLine("\nИнформация об объекте:");
        Console.WriteLine(trio.GetInfo());

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