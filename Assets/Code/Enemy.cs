using System;
using Missions;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string _enemyId;

    private void OnDestroy()
    {
        Debug.Log($"Enemigo muerto {_enemyId}");
        EventDispatcherService.Instance.Dispatch(new EnemigoMuerto(_enemyId));
    }
}