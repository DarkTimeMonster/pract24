using ConsoleApp6;
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        while (true)
        {
            try
            {
                Console.WriteLine($"\n====================\n");
                Console.WriteLine("Введите номер задания - ");
                Console.WriteLine("1 Наследование");
                Console.WriteLine("2 Полиморфизм");
                Console.WriteLine(" ");
                int x = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (x)
                {
                    case 1:
                        Console.WriteLine("Введите номер задания - ");
                        Console.WriteLine("1) Синхронный автомат ; Нахождение расстояния");
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
                                Console.WriteLine("Введено неверное значение");
                                break;
                        }
                        break;

                    case 2:
                        Console.WriteLine("Введите номер задания - ");
                        Console.WriteLine("1) Мобильный телефон и его сим карты");
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
        // Пример заглушки
        Console.WriteLine("Задание 1.1 не реализовано в этом фрагменте.");
    }

    static void InputInfoZ2()
    {
        // Пример заглушки
        Console.WriteLine("Задание 1.2 не реализовано в этом фрагменте.");
    }

    static void InputInfoZ3()
    {
        // Пример заглушки
        Console.WriteLine("Задание 2.1 не реализовано в этом фрагменте.");
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

                // Ввод с проверкой
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

            Console.WriteLine("\n====================\n");

            Console.WriteLine("Информация о студентах до перевода:");
            foreach (var student in students)
            {
                Console.WriteLine(student.GetInfo());
                if (student is ContractStudent contractStudent)
                {
                    Console.WriteLine(contractStudent.ItsContract());
                }
                Console.WriteLine();
            }

            foreach (var student in students)
            {
                student.PromoteToNextYear();
            }

            Console.WriteLine("\n====================\n");

            Console.WriteLine("Информация о студентах после перевода:");
            foreach (var student in students)
            {
                Console.WriteLine(student.GetInfo());
                if (student is ContractStudent contractStudent)
                {
                    Console.WriteLine(contractStudent.ItsContract());
                }
                Console.WriteLine();
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
