namespace ConsoleApp6
{
    public class MowAutomat : Automat
    {
        public double SpeedMetersPerSecond { get; private set; }

        public MowAutomat(double speed)
        {
            SpeedMetersPerSecond = speed > 0 ? speed : 1.0;
        }

        // Метод вычисления расстояния по времени
        public double CalculateDistance(double timeSeconds)
        {
            if (timeSeconds < 0)
                throw new ArgumentException("Время не может быть отрицательным");
            
            return SpeedMetersPerSecond * timeSeconds;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Скорость объекта: {SpeedMetersPerSecond} м/с");
        }
    }
}