using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRaycast : MonoBehaviour
{
    public float hoverForce = 65f;
    public float hoverHeight = 3.5f;
    private float powerInput;
    private float turnInput;
    //private Rigidbody carRigidbody;
    // Use this for initialization
    void Start()
    {
        //carRigidbody = GetComponent<Rigidbody>();
    }

    private Ray pulsacion;
    private RaycastHit colision;

    void Update()
    {
        /*if (Input.GetMouseButton(0))
        {
            pulsacion = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(transform.position,Vector3.down,2,0, out colision))
            {
                Debug.Log(colision.collider.name);
            }
        }*/
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, hoverHeight))
        {
            /*float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
            Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
            carRigidbody.AddForce(appliedHoverForce, ForceMode.Acceleration);*/
            this.transform.position=new Vector3(this.transform.position.x, hit.point.y + hoverHeight, this.transform.position.z);

        }
    }
}
/*
void Update()
{
    if (Input.GetMouseButton(0))
    {
        pulsacion = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(pulsacion, out colision))
        {
            Debug.Log(colision.collider.name);
        }
    }
}
}*/
