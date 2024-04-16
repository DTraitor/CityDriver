using System;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField]
    private GameObject ui;
    public const string LayerName = "PlayerVehicle";

    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody.gameObject.layer == LayerMask.NameToLayer(LayerName))
        {
            ui.SetActive(true);
        }
    }
}
