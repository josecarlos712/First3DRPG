using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraZonesBehaviour : MonoBehaviour
{
    // Este script va en cada una de las cameraZones. Controladas por el gameObject padre con el script cameraZonesBehaviour
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.parent.gameObject.GetComponent<cameraZonesManager>().setPlayerZone(transform);
    }
}
