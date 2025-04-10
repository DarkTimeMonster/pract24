namespace ConsoleApp6;

public class MobilePhone
{
    public string Brand { get; set; }
    public decimal Price { get; set; }
    public int Memory { get; set; }
 
    public MobilePhone(string brand, decimal price, int memory)
    {
        Brand = brand;
        Price = price;
        Memory = memory;
    }
 
    public virtual decimal CalculateQuality()
    {
        return Memory / Price;
    }
 
    public void DisplayInfo()
    {
        Console.WriteLine($"Бренд: {Brand}");
        Console.WriteLine($"Цена: {Price} USD");
        Console.WriteLine($"Память: {Memory} MB");
        Console.WriteLine($"Качество (Q): {CalculateQuality():F2}");
    }
}