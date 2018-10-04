using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAvanzado : MonoBehaviour {

    [SerializeField] private float velocidad;
    [SerializeField] float tiempocambiodireccion;
    [SerializeField] float distanciaDeteccion;

    private GameObject player;
    public Vector3 direccion;
    private float timer;
    // Use this for initialization
    void Start()
    {
        direccion = new Vector3(Random.Range(-1, 2), 0, Random.Range(-1, 2));
        player = GameObject.FindGameObjectWithTag(Configuracion.tagPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) < distanciaDeteccion)
        {
            transform.Translate((player.transform.position-this.transform.position) * velocidad/2 * Time.deltaTime) ;

        }
        else
        {

            timer += Time.deltaTime;
            if (timer > tiempocambiodireccion)
            {
                direccion = new Vector3(Random.Range(-1, 2), 0, Random.Range(-1, 2));
                timer = 0;
            }
            transform.Translate(direccion * velocidad * Time.deltaTime);
        }
    }


}
