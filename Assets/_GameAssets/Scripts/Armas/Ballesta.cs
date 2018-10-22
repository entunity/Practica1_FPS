using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ballesta : MonoBehaviour {
    [Header("Disparo")]
    [SerializeField] Transform objetoACrear;
    [SerializeField] float tiempoentredisparos;
    [SerializeField] GameObject puntodisparo;
    [Header("UI")]
    [SerializeField] Image MunicionFlecha;
    private float tiempoactual;
    private bool existeflecha;
    public static bool PuedeDisparar;


    private RaycastHit RayImpacto;
    private GameObject ptoMira;
    private Camera camara;
    private Ray rayo;

    private void Start() {
        ptoMira = GameObject.Find(Configuracion.PlayerPtoMira);
        camara= GameObject.Find(Configuracion.playerCamara).GetComponent<Camera>();
    }
    private void Update() {
        ControlBallesta();
        rayo=new Ray( ptoMira.transform.position, ptoMira.transform.forward*100);
        /*if (Physics.Raycast(rayo, out RayImpacto, Mathf.Infinity)) {
            Debug.DrawLine(player.transform.position, RayImpacto.collider.transform.position, Color.red, 10);}
        */
        Debug.DrawRay(ptoMira.transform.position, ptoMira.transform.forward * 100, Color.red);
    }
    // Use this for initialization
    private void ControlBallesta() {
        //disparo ballesta
        if (Time.time >= tiempoactual && (Input.GetButtonDown(Configuracion.botonDisparo))&&PuedeDisparar==true) {
            if (Physics.Raycast(rayo, out RayImpacto, Mathf.Infinity)) {
                GameObject go=Instantiate(objetoACrear.gameObject, puntodisparo.transform.position, puntodisparo.transform.rotation);
                go.transform.LookAt(RayImpacto.point);

            } else {
                Instantiate(objetoACrear.gameObject, puntodisparo.transform.position, transform.rotation);
            }
            this.GetComponent<AudioSource>().Play();
            tiempoactual = Time.time + tiempoentredisparos;
            
        }
        //zoom ballesta
        if (Input.GetButton(Configuracion.botonSecundario)) {
            camara.fieldOfView = Configuracion.FovZoom;
            ptoMira.transform.localRotation = Quaternion.Euler(1, 0.8f, 0);
        } else {
            camara.fieldOfView = Configuracion.FovPlayer;
            ptoMira.transform.localRotation = Quaternion.Euler(3, 2, 0);
        }

        //UI ballesta
        if (Time.time >= tiempoactual) {
            PuedeDisparar = true;
        } else {
            PuedeDisparar = false;
        }
        if (PuedeDisparar == true) {
            MunicionFlecha.enabled = true;
            puntodisparo.SetActive(true);
        } else {
            MunicionFlecha.enabled = false;
            puntodisparo.SetActive(false);
        }
    }
}
