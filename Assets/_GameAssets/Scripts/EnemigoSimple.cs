using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoSimple : MonoBehaviour
{

    [SerializeField] private float velocidad = 1.5f;
    [SerializeField] float tiempocambiodireccion = 2;


    private Vector3 direccion;
    private float timer;
    // Use this for initialization
    void Start()
    {
        direccion = new Vector3(Random.Range(-1, 2), 0, Random.Range(-1, 2));
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > tiempocambiodireccion)
        {
            direccion = new Vector3(Random.Range(-1, 2), 0, Random.Range(-1, 2));
            timer = 0;
        }
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == Configuracion.capaMunicion))
        {
            Destroy(this.gameObject);
        }
    }
}
