using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SapController : MonoBehaviour
{
    public MainController mainObject;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    private void OnCollisionEnter(Collision col)
    {
        mainObject.sapDokundu();
    }
    private void OnTriggerEnter(Collider col)
    {
        
        col.isTrigger = false;
        DivideableObject dob = col.GetComponent<DivideableObject>();
        if (dob != null)
        {
            dob.makeTriggeredAgain();
        }
    }
}
