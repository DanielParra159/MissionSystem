using System.Collections.Generic;
using Missions;
using UnityEngine;

namespace Configuration
{
    public abstract class StepConfiguration : ScriptableObject
    {
     
        [SerializeField] private bool _esObligatorio;

      
        public bool EsObligatorio => _esObligatorio;
    }
}