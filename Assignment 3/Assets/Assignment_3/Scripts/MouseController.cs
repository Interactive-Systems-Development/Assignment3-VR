using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private bool _isPressing = false;
    private Coroutine _pressingCoroutine;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MouseWheel();

        if (Google.XR.Cardboard.Api.IsTriggerHeldPressed || Input.GetMouseButton(1))
        {
            _isPressing = true;
            if (_pressingCoroutine == null)  
                _pressingCoroutine = StartCoroutine(CardBoardLongPress());
        } else if (_isPressing)
        {
            _isPressing = false;
            StopCoroutine(_pressingCoroutine);
            _pressingCoroutine = null;
        }
    }

    private void MoveDotDepth(float z, bool absolute = false)
    {
        Vector3 gazeDotPosition = transform.localPosition;
        if (absolute)
            gazeDotPosition.z = z;
        else
            gazeDotPosition.z = gazeDotPosition.z + z;
        transform.localPosition = gazeDotPosition;
    }

    private void MouseWheel()
    {
        float mouseDelta = Input.GetAxis("Mouse ScrollWheel");
        MoveDotDepth(mouseDelta);
    }

    private IEnumerator CardBoardLongPress()
    {
        const float movementFactor = 5.0f;
        const float maxDistance = 5.0f / movementFactor;
        const float minDistance = 1.5f / movementFactor;
        while (true)
        {
            for (float i = maxDistance; i >= minDistance; i -= Time.deltaTime)
            {
                MoveDotDepth(i*movementFactor, true);
                //Debug.Log(i);
                yield return null;
            }

            for (float i = minDistance; i <= maxDistance; i += Time.deltaTime)
            {
                MoveDotDepth(i*movementFactor, true);
                //Debug.Log(i);
                yield return null;
            }
        }
    }
}
