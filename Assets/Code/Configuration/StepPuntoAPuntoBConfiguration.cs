using UnityEngine;

namespace Configuration
{
    [CreateAssetMenu(menuName = "Create StepPuntoAPuntoBConfiguration", fileName = "StepPuntoAPuntoBConfiguration", order = 0)]
    public class StepPuntoAPuntoBConfiguration : StepConfiguration
    {
        [SerializeField]
        private string _destinoId;

        public string DestinoId => _destinoId;
    }
}