using ConsoleApp6;
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n====================\n");
            Console.WriteLine("Введите номер задания:");
            Console.WriteLine("1) Наследование");
            Console.WriteLine("2) Полиморфизм");
            Console.WriteLine();

            try
            {
                int x = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (x)
                {
                    case 1:
                        Console.WriteLine("1) Синхронный автомат; Нахождение расстояния");
                        Console.WriteLine("2) Площадь треугольника в пикселях");
                        int y = int.Parse(Console.ReadLine());
                        switch (y)
                        {
                            case 1:
                                InputInfoZ1();
                                break;
                            case 2:
                                InputInfoZ2();
                                break;
                            default:
                                Console.WriteLine("Неверный выбор.");
                                break;
                        }
                        break;

                    case 2:
                        Console.WriteLine("1) Мобильный телефон и его сим-карты");
                        Console.WriteLine("2) Задача со студентами");
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

                    default:
                        Console.WriteLine("Неверный номер задания.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Введены данные неверного формата.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }

    static void InputInfoZ1()
    {
        Console.WriteLine("=== Демонстрация автомата движения объекта ===");
        Console.Write("Введите скорость объекта (м/с): ");
        double speed = double.TryParse(Console.ReadLine(), out var val) ? val : 1.0;

        var automaton = new MowAutomat(speed);
        automaton.DisplayInfo();

        Console.WriteLine("\nВведите входы (например, 110, 012, 111). Введите 'stop' для завершения:");
        string input;
        while ((input = Console.ReadLine()) != "stop")
        {
            automaton.ProcessInput(input);
        }

        Console.Write("\nВведите время движения (сек): ");
        double time = double.TryParse(Console.ReadLine(), out var tVal) ? tVal : 0;
        double distance = automaton.CalculateDistance(time);
        Console.WriteLine($"Объект прошёл расстояние: {distance} м");
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

        Console.WriteLine("\nВведите количество SIM карт (P): ");
        decimal p = Convert.ToDecimal(Console.ReadLine());
        MobilePhoneWithP phone2 = new MobilePhoneWithP(brand, price, memory, p);

        Console.WriteLine("\nИнформация о телефоне с SIM картами:");
        phone2.DisplayInfo();
    }

    static void InputInfoZ4()
    {
        try
        {
            Console.WriteLine("Введите количество студентов: ");
            int studentCount = Convert.ToInt32(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 1; i <= studentCount; i++)
            {
                Console.WriteLine($"\nВведите данные для студента {i}:");

                Console.Write("ФИО студента: ");
                string fullName = Console.ReadLine();

                Console.Write("Факультет: ");
                string faculty = Console.ReadLine();

                Console.Write("Курс: ");
                int year = Convert.ToInt32(Console.ReadLine());

                decimal minGrade = GetValidMinGrade();

                Console.Write("Является ли студент контрактником (true/false): ");
                bool isContract = Convert.ToBoolean(Console.ReadLine());

                if (isContract)
                {
                    Console.Write("Оплачено ли обучение (true/false): ");
                    bool isContractPaid = Convert.ToBoolean(Console.ReadLine());
                    students.Add(new ContractStudent(fullName, faculty, year, minGrade, isContractPaid));
                }
                else
                {
                    students.Add(new Student(fullName, faculty, year, minGrade));
                }
            }

            Console.WriteLine("\nИнформация о студентах до перевода:");
            foreach (var student in students)
            {
                Console.WriteLine(student.GetInfo());
            }

            foreach (var student in students)
            {
                student.PromoteToNextYear();
            }

            Console.WriteLine("\nИнформация о студентах после перевода:");
            foreach (var student in students)
            {
                Console.WriteLine(student.GetInfo());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    static decimal GetValidMinGrade()
    {
        decimal minGrade;
        while (true)
        {
            Console.Write("Минимальная оценка (от 2 до 5): ");
            if (decimal.TryParse(Console.ReadLine(), out minGrade) && minGrade >= 2 && minGrade <= 5)
            {
                return minGrade;
            }
            Console.WriteLine("Ошибка ввода. Введите число от 2 до 5.");
        }
    }
}
