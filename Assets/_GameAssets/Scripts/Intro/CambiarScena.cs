using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CambiarScena : MonoBehaviour {
    [SerializeField] Transform particula;
    [SerializeField] int numeroParticulas;
    private GameObject objeto;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other) {
        
        if (other.tag == Configuracion.tagPlayer) {

            other.GetComponent<CharacterController>().enabled = false;
            
            CrearParticulas(other.gameObject, new Vector3(-2f, 0, 0));
            CrearParticulas(other.gameObject, new Vector3(-2f, 0, 0));
            CrearParticulas(other.gameObject, new Vector3(0, 2f, 0));
            CrearParticulas(other.gameObject, new Vector3(0, -2f, 0));
            Invoke("Cambio", 5);
        }
    }
    private void CrearParticulas(GameObject player,Vector3 distancia) {
        objeto = Instantiate(particula.gameObject, player.transform.position + distancia, particula.transform.rotation);
        objeto.GetComponent<Orbitar>().target = player.transform;
    }
    private void Cambio() {
        SceneManager.LoadScene(Configuracion.LvlJugable);
    }
}
