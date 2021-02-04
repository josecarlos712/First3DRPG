using UnityEngine;

public class cubeBehaviour : MonoBehaviour
{
	public Rigidbody rg;
	// Start is called before the first frame update
	void Start()
	{
		//GetComponent
		rg = GetComponent<Rigidbody>();

		//Initialization
		//rg.AddForce(new Vector3(100, 0, 0), ForceMode.Force);
		rg.AddRelativeTorque(new Vector3(20, 0, 20), ForceMode.Force);
	}

	// Update is called once per frame
	void Update()
	{

	}
}
