namespace ConsoleApp6;

public class ColoredTrio : TrioData
{
    public string Color { get; set; }
    public int Hour { get; set; }
    public int Minute { get; set; }

    public ColoredTrio(int x1, int y1, int x2, int y2, string color, int hour, int minute)
        : base(x1, y1, x2, y2)
    {
        Color = color;
        Hour = hour;
        Minute = minute;
    }

    // Метод вычисления площади треугольника (прямоугольный по оси Y)
    public double CalculateArea()
    {
        // Площадь треугольника через координаты (только две точки = предполагаем 3-я в одной оси)
        return 0.5 * Math.Abs((X1 - X2) * (Y1 - Y2));
    }

    public override string GetInfo()
    {
        return $"{base.GetInfo()}, Цвет: {Color}, Время: {Hour:D2}:{Minute:D2}, Площадь: {CalculateArea()} пикселей";
    }
}
