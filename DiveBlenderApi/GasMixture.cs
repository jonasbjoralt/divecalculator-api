namespace DiveBlenderApi
{
    public class GasMixture {
        public int Pressure {get; set;}
        public double Oxygen {get; set; }
        public double Helium {get; set;}

        public GasMixture(int pressure, double oxygen, double helium)
        {
            Pressure = pressure; 
            Oxygen = oxygen;
            Helium = helium;
        }
    }
}