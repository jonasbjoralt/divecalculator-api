using Microsoft.AspNetCore.Mvc;

namespace DiveBlenderApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InlineBlenderController : ControllerBase
    {
        [HttpGet]
        public InlineSettings Get(int desiredPressure, float desiredO2, float desiredHe, int currentPressure, float currentO2, float currentHe)
        {
            return new InlineSettings(new GasMixture(
                currentPressure, (currentO2/100), (currentHe/100)
            ), new GasMixture(
                desiredPressure, desiredO2/100, desiredHe/100
            )); 
        }
    }
}