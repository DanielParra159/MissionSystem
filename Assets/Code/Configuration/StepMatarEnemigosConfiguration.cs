using System.Collections.Generic;
using Missions;
using UnityEngine;

namespace Configuration
{
    [CreateAssetMenu(menuName = "Create StepMatarEnemigosConfiguration", fileName = "StepMatarEnemigosConfiguration", order = 0)]
    public class StepMatarEnemigosConfiguration : StepConfiguration
    {
        [SerializeField] private DatosDeEnemigosAMatar[] _enemigosaMatar;

        public IReadOnlyCollection<DatosDeEnemigosAMatar> EnemigosaMatar => _enemigosaMatar;
    
    }
}