using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Transform observer;
	public float movementVelocity = 5f, runningDelay = 1f, movementCooldown = .5f, movementForce = 100f, rotationVelocity = 100, jumpForce = 300.0f, explosionRadius = 20f;
	//Debug
	public float dotForward, dotRight;

	Rigidbody rb;
	Collider col;
	bool running = false; //Estado del personaje (corriendo o andando)
	float movementCooldownInit, distToGround;
	int movementCounter = 0; //Tiempo que lleva andando el personaje. Cuando llega a /runnignDelay/ cambia de estado de andando a corriendo
	Material colorInicial;
	Inventory inventory;
	//Vector3 newVel; //Variable auxiliar para el calculo de la nueva velocidad
	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		col = rb.GetComponent<Collider>();
		inventory = GetComponent<Inventory>() ; //Hay que añadirle el script de inventario al personaje

		distToGround = col.bounds.extents.y; //Obtiene la distancia desde el centro del personaje a la base
		movementCooldownInit = movementCooldown; //Inicializacion de la variable de cooldown
	}

	// Update is called once per frame
	void Update()
	{
		movementUpdate(); //Funcion de actualizacion del movimiento del personaje
		playerInventoryUpdate();
		changeColor();
	}

	private void OnCollisionEnter(Collision collision)
	{
		GameObject obj = collision.collider.gameObject;
		//Deteccion de objetos de inventario
		switch(obj.tag)
		{
			case "InventoryItem":
				//inventory.putItem(obj.GetComponent<ScriptableObject<InventoryManager>>());
				GameObject.Destroy(obj);
				break;
		}
	}

	private void playerInventoryUpdate()
	{
		
	}

	private void movementUpdate()
	{
		//TO-DO Reemplazar en un futuro (cuando exista un menu de opciones) las teclas predefinidas por las elegidas por el usuario
		//TO-DO Reemplazar el movimiento del personaje por aplicaciones de fuerza en lugar de cambios de velocidad (asi a lo mejor se soluciona lo de que el personaje se quede pegado en la pared)
		//El personaje solo debe moverse hacia adelante y girar
		running = (Time.deltaTime * movementCounter >= runningDelay && movementCooldown > 0);
		movementCounter = (movementCooldown > 0) ? movementCounter : 0;

		if (Input.GetKey(KeyCode.D) ^ Input.GetKey(KeyCode.A))
		{
			rb.transform.Rotate(0, rotationVelocity * Time.deltaTime * (Input.GetKey(KeyCode.D)?1:-1), 0, Space.Self);
		}

		if (Input.GetKey(KeyCode.W) ^ Input.GetKey(KeyCode.S))
			//Si se pulsa hacia adelante o atras
		{
			movementCounter++; 
			movementCooldown = movementCooldownInit; //Se resetea el cooldown de movimiento

			if (rb.velocity.magnitude < movementVelocity * (running ? 2f : 1f))
				rb.AddRelativeForce(new Vector3(movementForce * (Input.GetKey(KeyCode.D) ? 4 : 0) * (Input.GetKey(KeyCode.A) ? -4 : 0), 0,
					movementForce * (Input.GetKey(KeyCode.W) ? 1 : -1)));
		}
		else
		{
			rb.velocity = Vector3.Scale(rb.velocity, new Vector3(0, 1, 0));
		}
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (isTouching(Vector3.down)) //Si esta tocando el suelo
			{
				rb.AddExplosionForce(jumpForce, new Vector3(col.bounds.center.x, col.bounds.extents.y, col.bounds.center.z), explosionRadius); //Añade una fuerza explosiva en la base
			}
		}
		if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.Space))
		{
			rb.velocity = new Vector3(0, rb.velocity.y, 0); //Se reinicia la velocidad del personaje
			if (movementCooldown > 0) //Una vez se han dejado de pulsar teclas de movimiento comienza la reduccion del cooldown
			{
				movementCooldown -= Time.deltaTime;
			}
		}
	}
	private void movementUpdate2()
	{
		//TO-DO Reemplazar en un futuro (cuando exista un menu de opciones) las teclas predefinidas por las elegidas por el usuario
		//TO-DO Reemplazar el movimiento del personaje por aplicaciones de fuerza en lugar de cambios de velocidad (asi a lo mejor se soluciona lo de que el personaje se quede pegado en la pared)
		//El personaje solo debe moverse hacia adelante y girar
		running = (Time.deltaTime * movementCounter >= runningDelay && movementCooldown > 0);
		movementCounter = (movementCooldown > 0) ? movementCounter : 0;

		if (Input.GetKey(KeyCode.D) ^ Input.GetKey(KeyCode.A))
		{
			rb.transform.Rotate(0, rotationVelocity * Time.deltaTime * (Input.GetKey(KeyCode.D) ? 1 : -1), 0, Space.Self);
		}

		if (Input.GetKey(KeyCode.W) ^ Input.GetKey(KeyCode.S))
		//Si se pulsa hacia adelante o atras
		{
			movementCounter++;
			movementCooldown = movementCooldownInit; //Se resetea el cooldown de movimiento

			if (rb.velocity.magnitude < movementVelocity * (running ? 2f : 1f))
				rb.AddRelativeForce(new Vector3(movementForce * (Input.GetKey(KeyCode.D) ? 4 : 0) * (Input.GetKey(KeyCode.A) ? -4 : 0), 0,
					movementForce * (Input.GetKey(KeyCode.W) ? 1 : -1)));
		}
		else
		{
			rb.velocity = Vector3.Scale(rb.velocity, new Vector3(0, 1, 0));
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (isTouching(Vector3.down)) //Si esta tocando el suelo
			{
				rb.AddExplosionForce(jumpForce, new Vector3(col.bounds.center.x, col.bounds.extents.y, col.bounds.center.z), explosionRadius); //Añade una fuerza explosiva en la base
			}
		}
		if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.Space))
		{
			rb.velocity = new Vector3(0, rb.velocity.y, 0); //Se reinicia la velocidad del personaje
			if (movementCooldown > 0) //Una vez se han dejado de pulsar teclas de movimiento comienza la reduccion del cooldown
			{
				movementCooldown -= Time.deltaTime;
			}
		}
	}

	private void changeColor()
	{
		dotForward = Vector3.Dot(observer.transform.forward, transform.forward);
		dotRight = Vector3.Dot(observer.transform.right, transform.forward);
		if (dotForward > 0)
		{
			if(dotForward > 0.9)
				gameObject.GetComponent<Renderer>().material.color = Color.blue;
			else
				gameObject.GetComponent<Renderer>().material.color = Color.green;
		}
		else
		{
			if (dotForward > -0.9)
				gameObject.GetComponent<Renderer>().material.color = Color.yellow;
			else
				gameObject.GetComponent<Renderer>().material.color = Color.red;
		}
	}

	bool isTouching(Vector3 direction)
	{
		return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f);
	}
}
