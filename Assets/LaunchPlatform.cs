using UnityEngine;
using System.Collections;

public class LaunchPlatform : MonoBehaviour
{

    //Data members

    // Private
    private bool showLabel;
    private float timeToWait;
    private Rect textRect;
    private const string launchDisplay = "Press UP to launch.";

    // Use this for initialization
    void Start()
    {
        showLabel = true;
        timeToWait = 3f;
        textRect.x = 50;
        textRect.y = 50;
        textRect.width = 150;
        textRect.height = 150; 
    }

    // Update is called once per frame
    void Update()
    {
        this.HandleInput();
    }

    // Function Definitions
    void HandleInput()
    {
        if (Input.GetKey("up"))
        {
            //Destroy(GetComponent<LaunchPlatform>());
            showLabel = false;
        }

    }

    void OnGUI()
    {
        if (showLabel)
        {
            GUI.Label(textRect, launchDisplay);
        }
    }
}