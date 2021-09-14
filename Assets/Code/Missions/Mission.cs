using System.Collections.Generic;
using System.Linq;
using Configuration;
using UnityEngine;

namespace Missions
{
    public class Mission
    {
        private readonly StepConfiguration[] _stepsConfiguration;
        private readonly StepFactory _stepFactory;
        private int _currentStep;
        private bool _ejecutandoStepsEnParalelo;
        private readonly HashSet<Step> _stepsEnEjecucion;

        public Mission(StepConfiguration[] missionConfigStepsConfiguration)
        {
            _stepsConfiguration = missionConfigStepsConfiguration;
            _stepFactory = new StepFactory();
            _stepsEnEjecucion = new HashSet<Step>();
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
            _ejecutandoStepsEnParalelo = false;
            var stepConfiguration = _stepsConfiguration[_currentStep];

            if (stepConfiguration is ContenedorDeSteps contenedorDeSteps)
            {
                GestionarStepParalelo(contenedorDeSteps);
                return;
            }
            
            GestionarStep(stepConfiguration);
        }

        private void GestionarStep(StepConfiguration stepConfiguration)
        {
            InitStep(stepConfiguration);
        }

        private void GestionarStepParalelo(ContenedorDeSteps stepConfiguration)
        {
            var sonStepsEnParalelo = stepConfiguration.StepsEnParalelo.Count > 0;
            if (sonStepsEnParalelo)
            {
                IniciarStepsEnParalelo(stepConfiguration);
                return;
            }
        }


        private void IniciarStepsEnParalelo(ContenedorDeSteps stepConfiguration)
        {
            _ejecutandoStepsEnParalelo = true;
            // Ejecutar los steps en paralelo
            foreach (var configuration in stepConfiguration.StepsEnParalelo)
            {
                InitStep(configuration);
            }
        }

        private void InitStep(StepConfiguration configuration)
        {
            var step = _stepFactory.Create(configuration);
            step.OnStepCompleted += OnStepCompleted;
            step.Init();
            _stepsEnEjecucion.Add(step);
        }

        private void OnStepCompleted(Step step)
        {
            step.OnStepCompleted -= OnStepCompleted;
            step.Release();
            _stepsEnEjecucion.Remove(step);

            var quedanStepsObligatorios = _stepsEnEjecucion
                .Count(step => step.StepConfiguration.EsObligatorio) > 0;

            if (quedanStepsObligatorios)
            {
                return;
            }

            Debug.Log($"step {_currentStep} completado");
            NextStep();
        }

        private void LimpiarStepsEnEjecucion()
        {
            foreach (var stepEnEjecucion in _stepsEnEjecucion)
            {
                stepEnEjecucion.OnStepCompleted -= OnStepCompleted;
                stepEnEjecucion.Release();
            }
        }

        private void NextStep()
        {
            LimpiarStepsEnEjecucion();

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