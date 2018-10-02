using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour {

    [SerializeField] float velocidad = 100f;
    [SerializeField] float tiempoespera=2f;

    private bool enganchado = false;
    private float timer;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);


        if (enganchado == true) {
            timer += Time.deltaTime;
        }
        if (tiempoespera <= timer&& enganchado == true) {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ( (collision.gameObject.tag == Configuracion.capaEntorno)) {
            this.velocidad = 0;
            this.GetComponent<Rigidbody>().constraints= RigidbodyConstraints.FreezeAll;
            //Destroy(this.gameObject);
            enganchado = true;
        }
        else if ((collision.gameObject.tag == Configuracion.capaEnemigos))
        {
            Destroy(this.gameObject);
        }



    }
}
