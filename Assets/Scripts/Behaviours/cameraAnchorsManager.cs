using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
	public Transform leader;
	public GameObject mainCamera;
	public List<float> cameradistances;
	public float next, betweenDistance = 10;
	public Transform nextPosition;

	cameraBehaviour cameraScript;
	SortedDictionary<float, Transform> cameraList;
	// Start is called before the first frame update
	void Start()
	{
		cameraScript = mainCamera.GetComponent<cameraBehaviour>();
	}

	// Update is called once per frame
	void Update()
	{
		cameraList = new SortedDictionary<float, Transform>();
		cameradistances = new List<float>();
		foreach (Transform child in transform)
		{
			cameraList.Add(Vector3.Distance(child.position, leader.position), child);
			cameradistances.Add(Vector3.Distance(child.position, leader.position));
		}

		next = (cameraList.First().Key < (cameraList.ElementAt(1).Key - betweenDistance)) ? cameraList.First().Key : cameraList.ElementAt(1).Key;
		if (cameraList.TryGetValue(next, out nextPosition))
			cameraScript.setPosition(nextPosition.position);
		else
			Debug.LogError("Key no encontrada");
	}
}