using Configuration;
using UnityEngine;

namespace Missions
{
    public class Mission
    {
        private readonly StepConfiguration[] _stepsConfiguration;
        private StepFactory _stepFactory;
        private int _currentStep;

        public Mission(StepConfiguration[] missionConfigStepsConfiguration)
        {
            _stepsConfiguration = missionConfigStepsConfiguration;
            _stepFactory = new StepFactory();
        }

        public void Init()
        {
            Debug.Log("iniciamos misión");
            _currentStep = 0;
            InitCurrentStep();
        }

        private void InitCurrentStep()
        {
            Debug.Log($"iniciamos step {_currentStep}");
            var step = _stepFactory.Create(_stepsConfiguration[_currentStep]);
            step.OnStepCompleted += OnStepCompleted;
            step.Init();
        }

        private void OnStepCompleted(Step step)
        {
            Debug.Log($"step {_currentStep} completado");
            step.OnStepCompleted -= OnStepCompleted;
            step.Release();
            NextStep();
        }

        private void NextStep()
        {
            _currentStep += 1;
            if (_currentStep < _stepsConfiguration.Length)
            {
                InitCurrentStep();
                return;
            }
            
            // Termina la misión
            Debug.Log($"Misión terminada");
        }
    }
}