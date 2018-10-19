using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoBase : MonoBehaviour {
    [SerializeField] private float vidaEnemigo;
    [Header("Movimiento")]
    [SerializeField] private float velocidad;
    [SerializeField] private float TiempoCambioDireccion;
    [SerializeField] public float AlturaMovimiento;
    private Vector3 direccion;
    private float TimerCambioDireccion;
    private Ray Rayo;
    private RaycastHit RayImpacto;
    private float maxVida;
    private Vector3 escalaActual;
    [Header("Impacto")]
    [SerializeField] private float danyo;
    [SerializeField] private float distanciaExplosion;
    [SerializeField] Transform Explosion;

    [Header("Herencia")]
    protected GameObject player;
    protected bool estaPersiguiendo;




    private void Awake() {
        player = GameObject.FindGameObjectWithTag(Configuracion.tagPlayer);
    }
    // Use this for initialization
    void Start() {
        cambiarDireccion();
        Rayo = new Ray(transform.position, Vector3.down);
        maxVida = vidaEnemigo;
        escalaActual = this.transform.localScale;
    }

    // Update is called once per frame
    public virtual void Update() {
        if (velocidad != 0)
        {
            this.transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
            //BaseMovimiento.transform.position = new Vector3(this.transform.position.x, BaseMovimiento.transform.position.y, this.transform.position.z);
            //this.transform.position = new Vector3(this.transform.position.x, BaseMovimiento.transform.position.y + AlturaMovimiento, this.transform.position.z);
            if (Physics.Raycast(Rayo, out RayImpacto, Mathf.Infinity) && RayImpacto.collider.tag == Configuracion.tagEntorno)
            {
                this.transform.position = new Vector3(this.transform.position.x, RayImpacto.point.y + AlturaMovimiento, this.transform.position.z);

            }
            if (estaPersiguiendo == false)
            {
                TimerCambioDireccion += Time.deltaTime;
                if (TimerCambioDireccion > TiempoCambioDireccion)
                {
                    cambiarDireccion();
                    TimerCambioDireccion = 0;
                }
            }
            //comprueba si toca al personaje para hacerle daño
            if (detectarDistanciaPersonaje() < distanciaExplosion)
            {
                Jugador.vidaPlayer -= danyo;
                if (Jugador.vidaPlayer < 0) {
                    Jugador.vidaPlayer = 0;
                        }
                morir();
                Debug.Log("Vida: " + Jugador.vidaPlayer);

            }
            float cambio= this.vidaEnemigo/maxVida;
            this.transform.localScale = escalaActual * cambio;
        }
    }
    //mira la distancia al player
    public float detectarDistanciaPersonaje() {
        return Vector3.Distance(this.transform.position, player.transform.position);
    }
    //cambia la direccion en la q mira
    public void cambiarDireccion() {
        direccion = new Vector3(0, Random.Range(-180, 181), 0);
        transform.Rotate(direccion);
    }
    //destrulle el objeto o si no el padre
    public void morir() {

        Instantiate(Explosion.gameObject, this.transform.position,this.transform.rotation);
        //Explosion.GetComponent<ParticleSystem>().Play();
        //Explosion.GetComponent<AudioSource>().Play();
        if (this.transform.parent == null) {
            Destroy(this.gameObject);
        } else {
            Destroy(this.transform.parent.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision) {
        if ((collision.gameObject.tag == Configuracion.tagEntorno)){
            cambiarDireccion();
        }
        if ((collision.gameObject.tag == Configuracion.tagMunicion)) {
            this.vidaEnemigo -= Jugador.danioPlayer;
            if (vidaEnemigo <= 0) {
                morir();
            }
        }
    }
    private void OnTriggerStay(Collider other) {
            if ((other.gameObject.tag == Configuracion.tagMunicion)) {
                this.vidaEnemigo -= Jugador.danioPlayer;
                if (vidaEnemigo <= 0) {
                    morir();
                }
            }
    }
}
    

