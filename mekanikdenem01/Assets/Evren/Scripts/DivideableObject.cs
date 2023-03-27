using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivideableObject : MonoBehaviour
{
    public Transform leftObject;
    public bool isLeftStatic;
    public Transform rightObject;
    public bool isRightStatic;

    public float expldPower;

    public float exposionRadius;

    private bool isSphere = false;

    public void objectAyir()
    {
        Collider col = GetComponent<Collider>();
        col.enabled = false;
        leftObject.gameObject.layer = LayerMask.NameToLayer("Slided");
        rightObject.gameObject.layer = LayerMask.NameToLayer("Slided");
        if (!isLeftStatic)
        {
            AddComponent(leftObject.gameObject,1);
        }
        if (!isRightStatic)
        {
            AddComponent(rightObject.gameObject,-1);
        }

        if (col is SphereCollider)
        {
            isSphere = true;
        }
    }

    void AddComponent(GameObject obj, int yon)
    {
        Collider col;
        if (isSphere)
        {
            col = obj.AddComponent<MeshCollider>();
        }
        else
        {
            col = obj.AddComponent<BoxCollider>();
        }

    
    
        var rigidbody = obj.AddComponent<Rigidbody>();
        rigidbody.useGravity = true;
        rigidbody.isKinematic = false;
        //rigidbody.AddExplosionForce(expldPower, obj.transform.position, exposionRadius);
        rigidbody.AddForce(expldPower * yon,0,0,ForceMode.VelocityChange);
        obj.transform.parent = obj.transform.parent.parent;
    }


    public void makeTriggeredAgain()
    {
        StartCoroutine(waitForIsTrigger());
    }

    IEnumerator waitForIsTrigger()
    {
        yield return new WaitForSecondsRealtime(0.1F);
        Collider col = GetComponent<Collider>();
        col.isTrigger = true;
    }
}
