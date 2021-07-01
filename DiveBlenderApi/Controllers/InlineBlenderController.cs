

using DiverBlenderApi;
using Microsoft.AspNetCore.Mvc;

namespace DiverBlenderApi
{
        public class InlineSettings {
        public int Oxygen {get; set;}
        public int Helium {get; set;}

        public InlineSettings(int oxygen, int helium)
        {
            Oxygen = oxygen;
            Helium = helium;
        }
    }
}

namespace DiveBlenderApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InlineBlenderController : ControllerBase
    {
        int calculateSetPoint(int currentPressure, int desiredPressure, float currentFraction, float desiredFraction){
            int pressureDiff = desiredPressure - currentPressure; 
            float deltaBars = (desiredFraction*desiredPressure) - (currentFraction*currentPressure); 
            float barsSetPoint = ((deltaBars/pressureDiff)*100);
            return (int) barsSetPoint; 
        }
        InlineSettings calculateSetings(GasMixture currentMix, GasMixture desiredMix)
        {
            int pressureDiff = desiredMix.Pressure - currentMix.Pressure; 
            int oxygenSetPoint = calculateSetPoint(currentMix.Pressure, desiredMix.Pressure, currentMix.Oxygen, desiredMix.Oxygen);
            int heliumSetPoint = calculateSetPoint(currentMix.Pressure, desiredMix.Pressure, currentMix.Helium, desiredMix.Helium);

            return new InlineSettings(oxygenSetPoint, heliumSetPoint);
        }

        [HttpGet]
        public InlineSettings Get(int desiredPressure, float desiredO2, float desiredHe, int currentPressure, float currentO2, float currentHe)
        {
            return calculateSetings(new GasMixture(
                currentPressure, (currentO2/100), (currentHe/100)
            ), new GasMixture(
                desiredPressure, desiredO2/100, desiredHe/100
            )); 
        }
    }
}