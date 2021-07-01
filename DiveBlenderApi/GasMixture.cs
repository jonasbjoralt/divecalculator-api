namespace DiveBlenderApi
{
    public class GasMixture {
        public int Pressure {get; set;}
        public float Oxygen {get; set; }
        public float Helium {get; set;}

        public GasMixture(int pressure, float oxygen, float helium)
        {
            Pressure = pressure; 
            Oxygen = oxygen;
            Helium = helium;
        }
    }
}