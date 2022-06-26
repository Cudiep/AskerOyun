using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karakter : MonoBehaviour
{
    private float X = 0f , Y = 0f ;
    public float ZiplamaKuvveti = 5f;
    private Rigidbody rb;
    public float hareketHizi = 0f , sensitivity = 2.0f , kosmaHizi; 
    public bool isGrounded = false; 


    void Start()
    {
    Cursor.lockState = CursorLockMode.Locked;     Cursor.visible = false;
    rb = gameObject.GetComponent<Rigidbody>();

    }


    void Update()
    {
        Bak();
    }

    
    private void FixedUpdate()
    {
        Hareket();    
    }

    private void OnCollisionStay(Collision Zemin) //Zıplama
    {
        if(Input.GetKeyDown(KeyCode.Space) && Zemin.gameObject.CompareTag("Zemin"))
        {
            rb.velocity = new Vector3(rb.velocity.x , 5f , rb.velocity.z);
            isGrounded = false;
        }  
        else
        {
            isGrounded = true;
        }
    }
    
    void Bak()
    {
        X -= Input.GetAxis("Mouse Y") * sensitivity;
        X = Mathf.Clamp(X,-90f,90f);
        Y += Input.GetAxis("Mouse X") * sensitivity;
        Camera.main.transform.localRotation =Quaternion.Euler(X,Y,0);
    }

    void Hareket()
    {
        Vector2 axis = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")).normalized * hareketHizi;        
        Vector3 forward = new Vector3(-Camera.main.transform.right.z,0f,Camera.main.transform.right.x);
        Vector3 wishDirection = (forward * axis.x + Camera.main.transform.right * axis.y + Vector3.up * rb.velocity.y);
        rb.velocity = wishDirection;
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
        hareketHizi = 15;
        }
        else
        {
            hareketHizi = 6;
        }
    }

   
}
