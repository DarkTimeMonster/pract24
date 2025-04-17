namespace ConsoleApp6;

public class TrioData
{
    public int X1, Y1, X2, Y2;

    public TrioData(int x1, int y1, int x2, int y2)
    {
        X1 = x1;
        Y1 = y1;
        X2 = x2;
        Y2 = y2;
    }

    public virtual string GetInfo()
    {
        return $"Координаты: A({X1}, {Y1}), B({X2}, {Y2})";
    }
}
