using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngageWithObject : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private bool _isGrabbed;
    private Renderer _myRenderer;
    private Vector3 _lastPosition;
    private float velocityThrowFactor = 100.0f;
    private float grabReturnFactor = 5.0f;

    public GameObject GazeDot;

    /// <summary>
    /// The material to use when this object is inactive (not being gazed at).
    /// </summary>
    public Material InactiveMaterial;

    /// <summary>
    /// The material to use when this object is active (gazed at).
    /// </summary>
    public Material GazedAtMaterial;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _myRenderer = GetComponent<Renderer>();
        SetMaterial(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_isGrabbed)
        {
            _lastPosition = transform.position;
            _rigidBody.velocity = (GazeDot.transform.position - transform.position) * grabReturnFactor;
        }
            
    }

    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    public void OnPointerEnter()
    {
        SetMaterial(true);
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {
        SetMaterial(false);
    }

    /// <summary>
    /// This method is called by the Main Camera when it is gazing at this GameObject and the screen
    /// is touched.
    /// </summary>
    public void OnPointerClick()
    {
        if (!_isGrabbed)
            Grab();
        else
            Drop();
    }

    private void Grab()
    {
        GameObject camera = GameObject.Find("Main Camera");
        _rigidBody.useGravity = false;
        _rigidBody.freezeRotation = true;
        _rigidBody.velocity = new Vector3(0, 0, 0);

        StartCoroutine(FadeGazeDot(true));

        transform.SetParent(camera.transform);
        _isGrabbed = true;
    }

    private void Drop()
    {
        GameObject treasure = GameObject.Find("Treasure");
        _rigidBody.useGravity = true;
        _rigidBody.freezeRotation = false;

        StartCoroutine(FadeGazeDot(false));

        transform.SetParent(treasure.transform);
        _isGrabbed = false;

        _rigidBody.AddForce((transform.position - _lastPosition) * velocityThrowFactor, ForceMode.VelocityChange);
    }

    /// <summary>
    /// Sets this instance's material according to gazedAt status.
    /// </summary>
    ///
    /// <param name="gazedAt">
    /// Value `true` if this object is being gazed at, `false` otherwise.
    /// </param>
    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }

    private IEnumerator FadeGazeDot(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 0.2 seconds backwards
            for (float i = 0.2f; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                GazeDot.GetComponent<TextMesh>().color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 0.2 seconds
            for (float i = 0.2f; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                GazeDot.GetComponent<TextMesh>().color = new Color(255, 255, 255, i);
                yield return null;
            }
        }
    }
}
