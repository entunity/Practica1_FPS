using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour {


    [SerializeField] Transform objetoACrear;
    [SerializeField] float tiempoentredisparos;
    [SerializeField] GameObject puntodisparo;
    [SerializeField] ParticleSystem Fuego;

    private float tiempoactual;
    private GameObject flecha;
    private bool existeflecha;
    public bool disparandofuego=false;
    void Start()
    {
        tiempoentredisparos = 0.4f;
        disparandofuego = false;
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update () {
        
        if (Time.time >= tiempoactual && (Input.GetButtonDown("Fire1")))
        {
            flecha=Instantiate(objetoACrear.gameObject, puntodisparo.transform.position, transform.rotation);
            flecha.AddComponent<MoverFlecha>();
            tiempoactual = Time.time + tiempoentredisparos;
        }

        if ( (Input.GetButtonDown("Fire2")&&disparandofuego==false))
        {
            Fuego.Play();
            disparandofuego = true;
            tiempoactual = Time.time + tiempoentredisparos;
        }

        if ((Input.GetButtonDown("Fire2") && disparandofuego == true)&&Time.time >= tiempoactual)
        {
            Fuego.Stop();
            disparandofuego = false;
        }

    }
}
