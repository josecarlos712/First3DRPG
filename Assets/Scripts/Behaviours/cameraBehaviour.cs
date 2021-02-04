using UnityEngine;

public class cameraBehaviour : MonoBehaviour
{
	public Transform leader; //Objeto al que sigue la camara
	public float distance = 40f; //Humbral maximo de distancia al personaje / Distancia de la camara fija
	public float height = 40f; //Altura de la camara fija
	public bool fixedCamera = false; //Indica si la camara va a seguir al personaje (la camara fija no es compatible con cameraAnchors o cameraZones)

	Vector3 originalLocation; //Localizacion original usada para el calculo de la orientacion y posicion de la camara
	float actualDistance = 0f; //Variable de seguimento de la distancia real de la camara al personaje
	// Start is called before the first frame update
	void Start()
	{
		originalLocation = transform.position;
	}

	// Update is called once per frame
	void LateUpdate()
	{
		if (fixedCamera)
		{
			transform.position = leader.position;
			transform.LookAt(leader, Vector3.up); //Se dirige la camara hacia el leader

			transform.position += Vector3.Scale(new Vector3(-distance, 0, -distance), leader.forward); //La camara se situa a la distancia establecida detras del jugador
			transform.position += Vector3.Scale(new Vector3(0, height, 0), leader.up); //Se sube la camara a la altura establecida

			transform.LookAt(leader, Vector3.up); //Se dirige la camara hacia el leader
		} else {
			transform.position = originalLocation; //Se reestablece la posicion original de la camara
			transform.LookAt(leader, Vector3.up); //Se dirige la camara hacia el leader
			actualDistance = Vector3.Distance(transform.position, leader.position); //Se calcula la distancia al leader
			if (actualDistance > distance) // Si es mayor al humbral, la camara se acerca hasta reducir la distancia al valor humbral
				transform.position += transform.forward * (actualDistance - distance);
		}
	}

	public void setPosition(Vector3 newLocation)
	{
		originalLocation = newLocation;
	}
	public void setFixedCamera(bool fixedCamera)
	{
		this.fixedCamera = fixedCamera;
	}
}
