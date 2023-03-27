using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MainController : MonoBehaviour
{
    private Quaternion startingRotation;

    private Rigidbody rb;


    public Vector3 forceDirection;

    public float forceAmount = 10;

    public ForceMode forceMode;


    private bool readyForKinematic = true;

    public float speedLimit = 10;

    public AnimationCurve speedCurve;

    public float tourqe;


    public Vector3 torkSlowAngleStartStopBreak;


    private bool tamTurDondu = false;

    private bool isTorkAzaltma = false;

    private bool asagiKes = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            applyForce();
        }
/*
        Quaternion currentRotation = transform.rotation;
        float aciFark = Quaternion.Angle(currentRotation, startingRotation);
        if ( aciFark > 0.1F && aciFark < 5 && !tamTurDondu)
        {
            tamTurDondu = true;
            Debug.Log("tamTurDondu");
        }

        if (tamTurDondu)
        {
            Quaternion quaternionSinir = Quaternion.Euler(new Vector3(torkSlowAngleStartStopBreak.x,0,0));
            
            if (Quaternion.Angle(transform.rotation,quaternionSinir) < 10)
            {
                Debug.Log("AÇI UYGUN");
                rb.angularVelocity = rb.angularVelocity / torkSlowAngleStartStopBreak.z;
                isTorkAzaltma = true;
                tamTurDondu = false;
            }            
        }
        if (isTorkAzaltma)
        {
            Quaternion quaternionSinir = Quaternion.Euler(new Vector3(torkSlowAngleStartStopBreak.y,0,0));
            
            if (Quaternion.Angle(transform.rotation,quaternionSinir) < 10)
            {
                Debug.Log("AÇI UYGUN HIZLANMAYA");
                rb.angularVelocity = new Vector3(tourqe, 0, 0);
                isTorkAzaltma = false;
            }            
        }
        /*   if (!rb.isKinematic && rb.angularVelocity.x > torkDestek && isTorkDestek)
           {
               rb.angularVelocity = new Vector3(tourqe, 0, 0);
               //Debug.Log("extra torq");
           }*/
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("SAĞ TUŞ");
            rb.angularVelocity = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
          if (rb.velocity.y > 1 && rb.velocity.z < forceDirection.z)
          {
              Vector3 buffer = rb.velocity;
              buffer.z = forceDirection.z;
              rb.velocity = buffer;
          }

          if (rb.velocity.y > forceDirection.y)
          {
              Vector3 buffer = rb.velocity;
              buffer.y = forceDirection.y;
              rb.velocity = buffer;
          }


        /*
                if (isTorkAzaltma)
                {
                    rb.angularVelocity = rb.angularVelocity / 2F;
                    isTorkAzaltma = false;
                }else{
                    torkCounter++;
                    if (torkCounter > torkAzaltmaBekleme)
                    {
                        isTorkAzaltma = true;
                        torkCounter = 0;
                        Debug.Log("tork azaltılacak");
                    }
                }*/

    }

    IEnumerator waitForIsKinematic()
    {
        yield return new WaitForSecondsRealtime(0.5F);
        readyForKinematic = true;
    }

    private void applyForce()
    {
        float divider = 1;

        asagiKes = false;
        readyForKinematic = false;
        rb.isKinematic = false;
        isTorkAzaltma = false;
        if (rb.velocity.y > speedLimit)
        {
            divider = speedCurve.Evaluate(divider);
        }
        /*  forSap.AddForce(forceSap * forSap.transform.forward);
          forSharpe.AddForce(forceSharpe * forSharpe.transform.up);*/
        rb.AddForce(forceDirection * forceAmount / divider, forceMode);
        rb.angularVelocity = new Vector3(tourqe, 0, 0);
        tamTurDondu = false;
        startingRotation = transform.rotation;
        StartCoroutine(waitForIsKinematic());
    }

    private void applyAsagiForce()
    {
        rb.AddForce(Vector3.down * forceAmount);
        rb.angularVelocity = Vector3.zero;
    }

    public void ucSaplandi()
    {

        if (readyForKinematic)
            rb.isKinematic = true;
    }

    public void sapDokundu()
    {

    }

    public void asagiyaKes()
    {
        asagiKes = true;

    }

}

