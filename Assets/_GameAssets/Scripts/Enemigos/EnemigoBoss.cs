using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoBoss : EnemigoBase
{
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
        
       /* if ((collision.gameObject.tag == Configuracion.tagEntorno))
        {
            cambiarDireccion();
        }*/
    }
}
