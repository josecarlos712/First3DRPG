using UnityEngine;

public class spotlightBehaviour : MonoBehaviour
{
	public Transform leader;
	public float distance = 20f;
	float actualDistance = 0f;

	Vector3 originalLocation;
	// Start is called before the first frame update
	void Start()
	{
		originalLocation = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		transform.position = originalLocation;
		transform.LookAt(leader, Vector3.up);
		actualDistance = Vector3.Distance(transform.position, leader.position);
		if (actualDistance > distance)
		{
			transform.position += transform.forward * (actualDistance - distance);
		}
	}
}
