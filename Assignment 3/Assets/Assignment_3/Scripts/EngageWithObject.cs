using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngageWithObject : MonoBehaviour
{
    private Rigidbody rigidBody;
    private bool grabbed;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    public void OnPointerEnter()
    {
        
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {
        
    }

    /// <summary>
    /// This method is called by the Main Camera when it is gazing at this GameObject and the screen
    /// is touched.
    /// </summary>
    public void OnPointerClick()
    {
        if (!grabbed)
            Grab();
        else
            Drop();
    }

    private void Grab()
    {
        GameObject camera = GameObject.Find("Main Camera");
        rigidBody.isKinematic = true;
        transform.parent = camera.transform;
        grabbed = true;
    }

    private void Drop()
    {
        GameObject treasure = GameObject.Find("Treasure");
        rigidBody.isKinematic = false;
        transform.parent = treasure.transform;
        grabbed = false;
    }
}
