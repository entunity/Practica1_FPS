using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFuego : MonoBehaviour {

    [SerializeField] float tiempoespera = 2f;
    [SerializeField] Transform explosion;
    [SerializeField] float danio;
    [SerializeField] float tamanioExplosion=20f;
    private float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (tiempoespera <= timer)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosion.gameObject, this.transform.position, this.transform.rotation);
        int n = LayerMask.NameToLayer(Configuracion.layerEnemigos);
        Debug.Log(n);
        Collider[] hitColliders=Physics.OverlapSphere(this.transform.position, tamanioExplosion);
        foreach (Collider enemigo in hitColliders)
        {
            if (enemigo.gameObject.tag == Configuracion.tagEnemigos)
            {
                if (enemigo.gameObject.GetComponent<EnemigoBase>())
                    enemigo.gameObject.GetComponent<EnemigoBase>().vidaEnemigo -= danio;
                else
                    if (enemigo.gameObject.GetComponent<Orbitar>())
                        enemigo.gameObject.GetComponent<Orbitar>().vidaEnemigo -= danio;
            }
        }
        Destroy(this.gameObject);
    }
}
