using Missions;
using UnityEngine;

public class Zona : MonoBehaviour
{
    [SerializeField] private string _id;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        EventDispatcherService.Instance.Dispatch(new HeroeEntradoEnZona(_id));
    }
}