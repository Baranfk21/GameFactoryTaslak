using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Knifemechanics : MonoBehaviour
{


    public Rigidbody rb;

    bool hashit=false;
    public GameObject knife;
    public GameObject plane;


    public float yercekimi = 4f;
    public float zýplamakatsayisi = 2.3f;
    public float xhiz = 1.1f;
    public float yhiz = 0f;
    public float yhiz1 = 0f;
    public float egim;

    private bool landed=false;





    // Start is called before the first frame update
    void Start()
    {
       
    }



    // Update is called once per frame
    void Update()
    {
             
        egim = 50 * yhiz1;

        yhiz -= yercekimi * Time.deltaTime;
        yhiz1 -= yercekimi * Time.deltaTime;



        if (Input.GetMouseButtonDown(0))
        {
            landed = false;
            yhiz = zýplamakatsayisi;
            xhiz = zýplamakatsayisi;
           


        }

        if(landed==false)
        {
            transform.eulerAngles = new Vector3(egim, 0, 0);
            transform.Translate(new Vector3(0, 2.5f*yhiz, -xhiz) * Time.deltaTime, Space.World);
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
        

    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag=="plane")
        {
            landed = true;

            if (landed == true)
            {

                rb.velocity = Vector3.zero;
                gameObject.transform.position = GetComponent<Transform>().position;

                gameObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
       
           
       
        
        
    }

}

