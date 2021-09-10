using System;
using Configuration;
using Missions;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private MissionConfig _missionConfig;

    private void Start()
    {
        var mission = new Mission(_missionConfig.StepsConfiguration);
        mission.Init();
    }
}