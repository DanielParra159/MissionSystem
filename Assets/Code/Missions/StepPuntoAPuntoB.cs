using Configuration;
using UnityEngine;

namespace Missions
{
    public class StepPuntoAPuntoB : Step
    {
        private readonly StepPuntoAPuntoBConfiguration _stepConfiguration;

        public StepPuntoAPuntoB(StepPuntoAPuntoBConfiguration stepConfiguration) : base(stepConfiguration)
        {
            _stepConfiguration = stepConfiguration;
        }

        public override void Init()
        {
            Debug.Log("Step punto a punto empezado");
            EventDispatcherService.Instance.Subscribe<HeroeEntradoEnZona>(HeroeEnLaZona);
        }

        private void HeroeEnLaZona(Signal signal)
        {
            var data = (HeroeEntradoEnZona)signal;
            if (data.IdZona.Equals(_stepConfiguration.DestinoId))
            {
                OnStepCompleted?.Invoke(this);
            }
        }

        public override void Release()
        {
            Debug.Log("Step punto a punto terminado");
            EventDispatcherService.Instance.Unsubscribe<HeroeEntradoEnZona>(HeroeEnLaZona);
        }
    }
}