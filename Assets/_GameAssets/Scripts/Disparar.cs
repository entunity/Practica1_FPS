using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour {


    [SerializeField] Transform objetoACrear;
    [SerializeField] float tiempoentredisparos = 1f;
    [SerializeField] GameObject ballesta;

    private float tiempoactual;
    private GameObject flecha;
    private bool existeflecha;
    MoverFlecha m;
    void Start()
    {
        tiempoentredisparos = 1f;
        //m=flecha.GetComponent<MoverFlecha>();
    }

    // Update is called once per frame
    void Update () {
        
        if (Time.time >= tiempoactual && (Input.GetButtonDown("Fire1")))
        {
            flecha=Instantiate(objetoACrear.gameObject, ballesta.transform.position, transform.rotation);
            
        }
        /*
        if (Input.GetButtonDown("Fire1")&&flecha.activeSelf==true) {
           
            
            m.enabled = true;
            tiempoactual = Time.time + tiempoentredisparos;
        }
        if (Time.time >= tiempoactual&& existeflecha==true) {
            flecha = Instantiate(flecha, ballesta.transform.position, Quaternion.identity);
            existeflecha = true;
        }*/

    }
}
