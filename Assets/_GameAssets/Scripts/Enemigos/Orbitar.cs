using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbitar : MonoBehaviour
{

	public Transform target;
    public float velocidadGradosSeg = 360.0f;

    // Use this for initialization
    void Start()
    {
        
    }

    void LateUpdate()
    {

        Orbit();

    }

    void Orbit()
    {
        if (target != null)
        {
            transform.RotateAround(target.position, new Vector3(0, 1, 0), velocidadGradosSeg * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == Configuracion.tagMunicion))
        {
            this.GetComponent<Renderer>().enabled = false;
            this.GetComponent<Collider>().enabled = false;
        }
    }
}
