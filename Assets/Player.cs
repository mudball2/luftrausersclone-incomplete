using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    //Data members

    //Public
    public GameObject sphere;
    public Transform spawn;
    public float cameraOffset;
    public bool showDebug;

    //Private
    private BoxCollider2D collider;
    private Rigidbody2D rigidBody;
	private bool isKeysEnabled;
    private float rotateSpeed;
    private float speed;

	// Used for instantation and setup
	protected virtual void Start () 
	{
        collider = GetComponent<BoxCollider2D>();
		rigidBody = GetComponent<Rigidbody2D>();
		isKeysEnabled = true;
        speed = 0f;
        rotateSpeed = 60;
        cameraOffset = 0f;
    }
	
	// Calls handle functions every frame
	void Update () 
	{
        this.HandleInput();
        this.HandleCollision();
    }

    // On GUI for debug HUD
    void OnGUI()
    {
        if (showDebug)
        {
            GUI.Label(new Rect(490, 90, 150, 150), "Speed: " + speed);
            GUI.Label(new Rect(490, 100, 150, 150), "RotateSpeed: " + rotateSpeed);
        }
    }

    //Function Definitions
    void HandleInput()
    {
		if (Input.GetKey("up") && isKeysEnabled)
        {
			rigidBody.AddRelativeForce(new Vector2(0, speed));
            if (speed < 1)
            {
                speed += 0.1f;
            }
        }
        else
        {
			if (speed >= 0)
				speed -= 0.02f;
			else if (speed < 0)
				speed = 0;
			rigidBody.transform.Translate(new Vector2(0, speed) * (Time.deltaTime + 0.5f));
        }

		if (Input.GetKey("left") && isKeysEnabled)
        {
            transform.Rotate(new Vector3(0, 0, -rotateSpeed) * (Time.deltaTime + 0.04f));
        }

		if (Input.GetKey("right") && isKeysEnabled)
        {
            transform.Rotate(new Vector3(0, 0, rotateSpeed) * (Time.deltaTime + 0.04f));
        }

        if (Input.GetKey("x") && (Input.GetKey("right") || Input.GetKey("left")))
        {
            Fire();
            rotateSpeed = 30;
        }
        else if (Input.GetKey("x"))
        {
            Fire();
            rotateSpeed = 60;
        }
        else
        {
            rotateSpeed = 60;
        }
    }

    void HandleCollision()
    {
		if (transform.position.y > 60f && isKeysEnabled) {
			transform.Rotate (new Vector3 (0, 0, rotateSpeed) * (Time.deltaTime + 0.4f));
			rigidBody.gravityScale = 20;
			rigidBody.transform.Translate(new Vector2(0, 1 * (Time.deltaTime + 0.3f)));
		} else if (transform.position.y < 60f) {
			rigidBody.gravityScale = 1;
		}
    }

    void Fire()
    {
        var bullet = (GameObject)Instantiate(
            sphere,
            spawn.position,
            spawn.rotation);
        
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * (Time.deltaTime + 50.0f);
        
        Destroy(bullet, 8.0f);
    }
}
