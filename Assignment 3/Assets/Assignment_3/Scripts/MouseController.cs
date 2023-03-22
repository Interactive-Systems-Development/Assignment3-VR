using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private EngageWithObject engage;
    // Start is called before the first frame update
    void Start()
    {
        engage = GetComponent<EngageWithObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            engage.OnPointerClick();
        }
    }
}
