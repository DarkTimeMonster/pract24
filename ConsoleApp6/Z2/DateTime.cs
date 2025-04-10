namespace ConsoleApp6;

public class DateTime : Date
{
    // Поля класса-потомка
    private int hours;
    private int minutes;
    private int seconds;

    // Конструктор
    public DateTime(int d, int m, int y, int h, int min, int sec) : base(d, m, y)
    {
        hours = h;
        minutes = min;
        seconds = sec;
    }

    // Функция обработки: увеличение времени на 100 минут
    public void Add100Minutes()
    {
        minutes += 100;

        // Обработка перехода через часы
        hours += minutes / 60;
        minutes = minutes % 60;

        // Обработка перехода через сутки
        if (hours >= 24)
        {
            int extraDays = hours / 24;
            hours = hours % 24;
            day += extraDays;

            // Простая обработка перехода через месяц
            while (day > 30)
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
    }

    // Переопределение метода получения информации
    public override string GetInfo()
    {
        return base.GetInfo() + $"\nВремя: {hours:D2}:{minutes:D2}:{seconds:D2}";
    }
}
