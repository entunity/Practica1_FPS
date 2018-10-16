using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariarIluminacion : MonoBehaviour {

    [SerializeField] float IluminacionMinima;
    [SerializeField]float IluminacionMaxima;
    [SerializeField] Light luz;
    [SerializeField] float TiempoCambio;
    // Use this for initialization
    void Start () {
        InvokeRepeating("CambiarLuz",0, TiempoCambio);
	}
	
	// Update is called once per frame
	void Update () {
        
        //luz.intensity=Mathf.Lerp(IluminacionMinima, IluminacionMaxima, (Mathf.Sin(VelocidadCambio * Time.time) + 1.0f) / 2.0f);
    }
    private void CambiarLuz() {
        luz.intensity = Random.Range(IluminacionMinima, IluminacionMaxima);
    }
}
