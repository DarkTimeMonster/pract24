namespace ConsoleApp6;

public class movAutomat : Automat
{
    public double Speed { get; set; } 

    public movAutomat(double speed) : base()
    {
        Speed = speed;
    }

    //путь = скорость * время
    public double CalculateDistance(double timeSeconds)
    {
        return Speed * timeSeconds;
    }
}