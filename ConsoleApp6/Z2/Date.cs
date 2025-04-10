namespace ConsoleApp6;

public class Date
{
    // Поля класса
    protected int day;
    protected int month;
    protected int year;

    // Конструктор по умолчанию
    public Date()
    {
        day = 1;
        month = 1;
        year = 2000;
    }

    // Конструктор с параметрами
    public Date(int d, int m, int y)
    {
        day = d;
        month = m;
        year = y;
    }

    // Деструктор
    ~Date()
    {
        Console.WriteLine("Объект DateClass уничтожен");
    }

    // Функция 1: Проверка високосного года
    public bool IsLeapYear()
    {
        return (year % 4 == 0);
    }

    // Функция 2: Увеличение даты на 5 дней
    public void AddFiveDays()
    {
        day += 5;

        // Простая проверка для перехода через месяц
        if (day > 30) // Упрощение: считаем, что в месяце 30 дней
        {
            day -= 30;
            month++;
            if (month > 12)
            {
                month = 1;
                year++;
            }
        }
    }

    // Формирование строки информации
    public virtual string GetInfo()
    {
        return $"Дата: {day:D2}.{month:D2}.{year}";
    }
}