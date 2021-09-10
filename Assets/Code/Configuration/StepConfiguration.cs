using UnityEngine;

namespace Configuration
{
    public abstract class StepConfiguration : ScriptableObject
    {
        [SerializeField] private StepConfiguration[] _stepsEnParalelo;
        [SerializeField] private StepConfiguration[] _stepsExcluyentes;
        [SerializeField] private bool _esObligatorio;
    }
}