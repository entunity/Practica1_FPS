using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : Flecha {
    [SerializeField] float danio;
    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == Configuracion.tagEntorno))
        {
            Destroy(this.gameObject);
        }else if ((collision.gameObject.tag == Configuracion.tagPlayer && chocado == false))
        {
            Configuracion.vida -= danio;
            chocado = true;
            Debug.Log("Vida: " + Configuracion.vida);
            Destroy(this.gameObject);

        }



    }
}
