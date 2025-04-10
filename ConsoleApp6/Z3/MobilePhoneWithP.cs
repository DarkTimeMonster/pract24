namespace ConsoleApp6;

    public class MobilePhoneWithP : MobilePhone
    {
        public decimal P { get; set; }
 
        public MobilePhoneWithP(string brand, decimal price, int memory, decimal p)
            : base(brand, price, memory)
        {
            P = p;
        }
 
        public override decimal CalculateQuality()
        {
            decimal baseQuality = base.CalculateQuality();
            return baseQuality * P;
        }
 
        public new void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Количество SIM карт (P): {P}");
            Console.WriteLine($"Качество с P (Qp): {CalculateQuality():F2}");
        }
    }
