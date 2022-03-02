using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeFlight : MonoBehaviour
{
    //forward speed
    [Tooltip("Velocidad de avance inicial")]
    public float speed;
    //horizontal speed
    [Tooltip("Velocidad de giro horizontal")]
    public float rSpeed;
    [Tooltip("Rotacion vertical")]
    public float rotation;

    [Tooltip("Rotacion horizontal")]
    public float hRotation;
    [Tooltip("GUI Seleccionada")]
    public GameObject GUI;


    // Start is called before the first frame update
    void Start()
    {
        rSpeed=0;
        rotation=0;
        hRotation=0;
    }

    // Update is called once per frame
    void Update()
    {
        //forward position
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if(Input.GetKey("w") && speed<=80){
                speed+=Time.deltaTime*10;
        }

        if(Input.GetKey("s") && speed>=3){
                speed-=Time.deltaTime*10;
        }
        
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        //move horizontaly
        if(Input.GetKey("a") && rSpeed>-50){
            rSpeed-=Time.deltaTime*10;
        }

        if(Input.GetKey("d") && rSpeed<50){
            rSpeed+=Time.deltaTime*10;
        }
        
        transform.Translate(Vector3.right * Time.deltaTime * rSpeed);

        //mouse vertical move
        rotation=Input.GetAxis("Mouse Y");
        hRotation=Input.GetAxis("Mouse X");

        Vector3 a = new Vector3(rotation*5f,0,hRotation*5f);

        transform.Rotate(a, Space.Self);
    }


    
    void OnCollisionEnter(Collision col) {
        GUI.SetActive(true);
    }
}
