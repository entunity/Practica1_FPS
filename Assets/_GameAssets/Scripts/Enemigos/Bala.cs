using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : ProyectilBase {
    [SerializeField] float danio;
    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == Configuracion.tagEntorno))
        {
            Destroy(this.gameObject);
        }else if ((collision.gameObject.tag == Configuracion.tagPlayer && chocado == false))
        {
            Jugador.vidaPlayer -= danio;
            chocado = true;
            Debug.Log("Vida: " + Jugador.vidaPlayer);
            Destroy(this.gameObject);

        }



    }
}
