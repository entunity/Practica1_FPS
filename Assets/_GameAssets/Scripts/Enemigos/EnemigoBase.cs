using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoBase : MonoBehaviour {
    [Header("Movimiento")]
    [SerializeField] private float velocidad;
    [SerializeField] private float TiempoCambioDireccion;
    [SerializeField] private GameObject BaseMovimiento;
    [SerializeField] private float AlturaMovimiento;
    [Header("Impacto")]
    [SerializeField] private float danyo;
    [SerializeField] private float distanciaExplosion;
    [SerializeField] private ParticleSystem particulaExplosion;


    [Header("Herencia")]
    protected GameObject player;
    [SerializeField] protected bool estaPersiguiendo;


    private Vector3 direccion;
    private float timer;

    // Use this for initialization
    void Start() {
        cambiarDireccion();
        player = GameObject.FindGameObjectWithTag(Configuracion.tagPlayer);
        particulaExplosion = GameObject.Find(Configuracion.nombreParticulas).GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update() {
        if (BaseMovimiento != null&&velocidad!=0)
        {
            this.transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
            BaseMovimiento.transform.position = new Vector3(this.transform.position.x, BaseMovimiento.transform.position.y, this.transform.position.z);
            this.transform.position = new Vector3(this.transform.position.x, BaseMovimiento.transform.position.y + 1.5f, this.transform.position.z);


            if (estaPersiguiendo == false)
            {
                timer += Time.deltaTime;
                if (timer > TiempoCambioDireccion)
                {
                    cambiarDireccion();
                    timer = 0;
                }
            }
            if (detectarDistanciaPersonaje() < distanciaExplosion)
            {
                Configuracion.vida -= danyo;
                morir();
                Debug.Log("Vida: " + Configuracion.vida);

            }
        }
    }
    //mira la distancia al player
    private float detectarDistanciaPersonaje() {
        return Vector3.Distance(this.transform.position, player.transform.position);
    }
    //cambia la direccion en la q mira
    public void cambiarDireccion() {
        direccion = new Vector3(0, Random.Range(-180, 181), 0);
        transform.Rotate(direccion);
    }
    //destrulle el objeto o si no el padre
    public void morir() {
        particulaExplosion.transform.position = this.transform.position;
        //Instantiate(particulaExplosion.gameObject, this.transform.position, this.transform.rotation);
        particulaExplosion.Play();
        if (this.transform.parent == null) {
            Destroy(this.gameObject);
        } else {
            Destroy(this.transform.parent.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision) {
        //Debug.Log(collision.gameObject.name);
        if ((collision.gameObject.tag == Configuracion.tagMunicion)) {
            morir();
        }
        if ((collision.gameObject.tag == Configuracion.tagEntorno)){
            cambiarDireccion();
        }
    }
    
}
