using Configuration;

namespace Missions
{
    public class StepPuntoAPuntoB : Step
    {
        private readonly StepPuntoAPuntoBConfiguration _stepConfiguration;

        public StepPuntoAPuntoB(StepPuntoAPuntoBConfiguration stepConfiguration)
        {
            _stepConfiguration = stepConfiguration;
        }

        public override void Init()
        {
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
        }
    }
}