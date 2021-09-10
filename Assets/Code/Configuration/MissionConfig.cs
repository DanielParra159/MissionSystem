using UnityEngine;

namespace Configuration
{
    [CreateAssetMenu(menuName = "Create MissionConfig", fileName = "MissionConfig", order = 0)]
    public class MissionConfig : ScriptableObject
    {
        [SerializeField] private StepConfiguration[] _stepsConfiguration;

        public StepConfiguration[] StepsConfiguration => _stepsConfiguration;
    }
}