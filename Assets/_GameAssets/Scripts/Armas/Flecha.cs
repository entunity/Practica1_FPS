using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour {

    [SerializeField] float velocidad = 100f;
    [SerializeField] float tiempoespera=2f;
    [SerializeField] float danio;
    private float timer;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
            timer += Time.deltaTime;
        if (tiempoespera <= timer) {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ( (collision.gameObject.tag == Configuracion.tagEntorno)) {
            this.velocidad = 0;
            this.GetComponent<Rigidbody>().constraints= RigidbodyConstraints.FreezeAll;
            //Destroy(this.gameObject);
        }
        else if ((collision.gameObject.tag == Configuracion.tagEnemigos))
        {
            //collision.gameObject.GetComponent<>.vida -= danio;
            Destroy(this.gameObject);
        }
        else if ((collision.gameObject.tag == Configuracion.tagPlayer)) {
            Configuracion.vida -= danio;
            Debug.Log("Vida: " + Configuracion.vida);
            Destroy(this.gameObject);

        }



    }
}
