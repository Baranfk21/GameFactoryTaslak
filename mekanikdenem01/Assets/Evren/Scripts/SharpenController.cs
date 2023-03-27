using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpenController : MonoBehaviour
{
    public MainController mainObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame


    private void OnCollisionEnter(Collision col)
    {

        
        if (col.gameObject.CompareTag("plane"))
        {
            mainObject.ucSaplandi();
        }


    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("plane"))
        {
            return;
        }
        Sliceobjects so = mainObject.GetComponent<Sliceobjects>();
        if (so != null)
        {
            so.OnSliceEnter(col);
            mainObject.asagiyaKes();
        }
    }
}
