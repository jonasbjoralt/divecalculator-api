using System;
using Xunit;

namespace DiveBlenderApi
{
    public class InlineSettingsTests
    {
        [Fact]
        public void AirToNitrox()
        {
            var blenderSettings = new InlineSettings(new GasMixture(120, 0.21, 0), new GasMixture(230, 0.32, 0));
            Assert.Equal(44, blenderSettings.Oxygen);
            Assert.Equal(blenderSettings.Helium, 0);
            
            
        }
    }
}