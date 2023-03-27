using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class Sliceobjects : MonoBehaviour
{

    public Material materialslicedside;
    public float ExplosionForce;
    public float exposionRadius;
    public bool gravity, kinematic;


    public void OnSliceEnter(Collider other)
    {

        if(other.gameObject.CompareTag("CanSlice"))
        {
   
            SlicedHull sliceobj = slice(other.gameObject, materialslicedside);
            GameObject SlicedObjTop = sliceobj.CreateUpperHull(other.gameObject, materialslicedside);
            GameObject SliceObjDown=sliceobj.CreateLowerHull(other.gameObject, materialslicedside);
            Destroy(other.gameObject);
            AddComponent(SlicedObjTop);
            AddComponent(SliceObjDown);
        }
        if (other.gameObject.CompareTag("CanDivide"))
        {
            DivideableObject dob = other.transform.GetComponent<DivideableObject>();
            if (dob!= null)
            {
                dob.objectAyir();
            }
        }
    }


    private SlicedHull slice(GameObject obj,Material mat)
    {
        return obj.Slice(transform.position, transform.right, mat);

    }

    void AddComponent(GameObject obj)
    {
        obj.AddComponent<BoxCollider>();
        var rigidbody = obj.AddComponent<Rigidbody>();
        rigidbody.useGravity = gravity;
        rigidbody.isKinematic = kinematic;
        rigidbody.AddExplosionForce(ExplosionForce, obj.transform.position,exposionRadius);
       // obj.tag = "CanSlice";

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }


}
