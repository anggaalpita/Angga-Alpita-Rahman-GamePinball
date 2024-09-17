using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public Collider bola;
    public KeyCode input;

    public float maxTimeHold;
    public float maxForce;

    public Color holdColor = Color.red;  
    public Color defaultColor = Color.white;  

    private Renderer renderer;  
    private bool isHold;

    private void Start()
    {
        isHold = false;

        
        renderer = GetComponent<Renderer>();

        if (renderer == null)
        {
            Debug.LogError("Renderer not found on this object!");
        }
        else
        {
            renderer.material.color = defaultColor;  
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider == bola)
        {
            ReadInput(bola);
        }
    }

    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(input) && !isHold)
        {
            StartCoroutine(StartHold(collider));
        }
    }

    private IEnumerator StartHold(Collider collider)
    {
        isHold = true;

        float force = 0.0f;
        float timeHold = 0.0f;

       
        if (renderer != null)
        {
            renderer.material.color = holdColor;
        }

        while (Input.GetKey(input))
        {
           
            force = Mathf.Lerp(0, maxForce, timeHold / maxTimeHold);

            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
        }

        
        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);

       
        if (renderer != null)
        {
            renderer.material.color = defaultColor;
        }

        isHold = false;
    }
}