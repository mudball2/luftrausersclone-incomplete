using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    // Data Members

    // Public
    public Transform target;

    // Private
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target);
        transform.Translate(Vector3.forward * (Time.deltaTime + 0.02f));
	
	}
}
