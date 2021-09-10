using System;
using UnityEngine.PlayerLoop;

namespace Missions
{
    public abstract class Step
    {
        public Action<Step> OnStepCompleted;
        
        public abstract void Init();
        public abstract void Release();
    }
}