using System;
using Configuration;

namespace Missions
{
    public class StepFactory
    {
        public Step Create(StepConfiguration stepConfiguration)
        {
            if (stepConfiguration is StepPuntoAPuntoBConfiguration configuration)
            {
                return new StepPuntoAPuntoB(configuration);
            }

            throw new InvalidOperationException();
        }
    }
}