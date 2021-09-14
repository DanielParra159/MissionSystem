using System.Collections.Generic;
using Missions;
using UnityEngine;

namespace Configuration
{
    [CreateAssetMenu(menuName = "Create ContenedorDeSteps", fileName = "ContenedorDeSteps", order = 0)]
    public class ContenedorDeSteps : StepConfiguration
    {
        [SerializeField] private StepConfiguration[] _stepsEnParalelo;
        [SerializeField] private StepConfiguration[] _stepsExcluyentes;
        public IReadOnlyCollection<StepConfiguration> StepsEnParalelo => _stepsEnParalelo;

        public IReadOnlyCollection<StepConfiguration> StepsExcluyentes => _stepsExcluyentes;
    }
}