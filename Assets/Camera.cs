using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    //Data Members

    //Public
    public Transform target;
    public Player player;

    //Private
    private float distance;
    private Vector3 trans;

    //Used for instantiation and setup
    protected virtual void Start()
    {
        //Initialize distance
        distance = 10.45632f;

        player = new Player();
    }

	//Updates camera every frame
	void Update()
	{
		if (Input.GetKey("up"))
		{
			this.transform.Translate(new Vector3(0, 0.05f, target.position.z + distance) * (Time.deltaTime + 0.5f));
		}
	}
    
    //Updates camera position every frame after everything else
    void LateUpdate()
    {
        this.transform.position = new Vector3(target.position.x, target.position.y, target.position.z + distance);
    }
}
