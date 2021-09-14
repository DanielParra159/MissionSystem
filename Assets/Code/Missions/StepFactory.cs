using System;
using Configuration;

namespace Missions
{
    public class StepFactory
    {
        public Step Create(StepConfiguration stepConfiguration)
        {
            if (stepConfiguration is StepPuntoAPuntoBConfiguration stepPuntoAPuntoBConfiguration)
            {
                return new StepPuntoAPuntoB(stepPuntoAPuntoBConfiguration);
            }

            if (stepConfiguration is StepMatarEnemigosConfiguration stepMatarEnemigosConfiguration)
            {
                return new StepMatarEnemigos(stepMatarEnemigosConfiguration);
            }

            throw new InvalidOperationException();
        }
    }
}