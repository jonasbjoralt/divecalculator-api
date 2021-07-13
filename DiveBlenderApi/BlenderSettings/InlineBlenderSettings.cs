
using DiveBlenderApi;

namespace DiveBlenderApi
{
        public class InlineSettings {
        public int Oxygen {get; set;}
        public int Helium {get; set;}

        public InlineSettings(int oxygen, int helium)
        {
            Oxygen = oxygen;
            Helium = helium;
        }

        static int CalculateSetPoint(int currentPressure, int desiredPressure, double currentFraction, double desiredFraction){
            int pressureDiff = desiredPressure - currentPressure; 
            double deltaBars = (desiredFraction*desiredPressure) - (currentFraction*currentPressure); 
            double barsSetPoint = pressureDiff > 0 ? ((deltaBars/pressureDiff)*100) : 0;
            return (int) barsSetPoint; 
        }

        public InlineSettings (GasMixture currentMix, GasMixture desiredMix)
        {
            int pressureDiff = desiredMix.Pressure - currentMix.Pressure; 
            int oxygenSetPoint = CalculateSetPoint(currentMix.Pressure, desiredMix.Pressure, currentMix.Oxygen, desiredMix.Oxygen);
            int heliumSetPoint = CalculateSetPoint(currentMix.Pressure, desiredMix.Pressure, currentMix.Helium, desiredMix.Helium);

            Oxygen = oxygenSetPoint; 
            Helium = heliumSetPoint;
        }
    }
}


