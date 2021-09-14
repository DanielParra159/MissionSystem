using System;
using Configuration;
using UnityEngine.PlayerLoop;

namespace Missions
{
    public abstract class Step
    {
        public Action<Step> OnStepCompleted;

        public StepConfiguration StepConfiguration { get; }

        protected Step(StepConfiguration stepConfiguration)
        {
            StepConfiguration = stepConfiguration;

        }

        public abstract void Init();

        public abstract void Release();
    }
}