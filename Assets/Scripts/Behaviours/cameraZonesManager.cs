using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraZonesManager : MonoBehaviour
{
    //Este script va en el objeto padre y maneja cada objeto cameraZone hijo
    public GameObject mainCamera;
    public Transform leader;
    //DEBUG
    Transform playerZone;
        List<Transform> cameraZones;
    // Start is called before the first frame update
    void Start()
    {
        cameraZones = new List<Transform>();
        mainCamera.GetComponent<cameraBehaviour>();
        foreach(Transform child in transform)
            cameraZones.Add(child);
        playerZone = cameraZones[0];
    }

    // Update is called once per frame
    void Update()
    {
        mainCamera.GetComponent<cameraBehaviour>().setPosition(playerZone.position);
    }

    public void setPlayerZone(Transform playerZone)	{
        this.playerZone = playerZone;
	}
}
