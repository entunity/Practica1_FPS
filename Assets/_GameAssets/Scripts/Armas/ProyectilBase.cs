using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilBase : MonoBehaviour {

    [SerializeField] public float velocidad = 100f;
    [SerializeField] float tiempoespera=2f;


    private float timer;
    public bool chocado=false;
	// Use this for initialization
	void Start () {
        chocado = false;
            }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
            timer += Time.deltaTime;
        if (tiempoespera <= timer) {
            Destroy(this.gameObject);
        }
        if (this.transform.position.y < -0.4) {
            Paralizar();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if ( (collision.gameObject.tag == Configuracion.tagEntorno)) {
            Paralizar();
            //Destroy(this.gameObject);
        }
        else if ((collision.gameObject.tag == Configuracion.tagEnemigos))
        {
            //collision.gameObject.GetComponent<>.vida -= danio;
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerExit(Collider other) {
        if ((other.gameObject.tag == Configuracion.tagEntorno)&&this.transform.position.y<4f) {
            Paralizar();
            //Destroy(this.gameObject);
        }
    }
    private void Paralizar() {
        this.velocidad = 0;
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
}
