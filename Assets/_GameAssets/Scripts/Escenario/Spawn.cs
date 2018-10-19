using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour {
    [Header("Enemigo")]
    [SerializeField] List<Transform> Enemigos;
    private Transform Enemigo;
    [Header("Spawn")]
    [SerializeField] List<Transform> PuntosSpawn;
    [SerializeField] float TiempoSpawn;
    [SerializeField] List<Transform> EnemigosSpawn;
    private Transform EnemigoSpawn;
    private GameObject spawn;
    [Header("Escenario")]
    [SerializeField] GameObject Municion;
    [SerializeField] GameObject Vida;
    [Header("Boss")]
    [SerializeField] GameObject PuntoSpawnBoss;
    private GameObject boss;
    private bool bossFight = false;
    [Header("UILvl")]
    [SerializeField] Text InfoLvl;
    [SerializeField] Sprite[] spriteBoss;
    [SerializeField] Text InfoTiempo;
    private float timer;
    private int[] lvl;
    private GameObject player;
    private bool spokenLvl2;
    private bool spokenLvl3;
    // Use this for initialization
    void Start () {
        lvl = Configuracion.lvl1;
        player=GameObject.Find(Configuracion.tagPlayer);
    }
	
	// Update is called once per frame
	void Update () {
        InfoTiempo.text = ((int)Time.time).ToString();
        //generador enemigo
        timer += Time.deltaTime;
        if (timer >= TiempoSpawn) {
            this.transform.Rotate(0,Random.Range(0,181),0);
            generarEnemigo();
            timer = 0;
        }
        if (Time.time <= (Configuracion.TiemposLvl[0] * Configuracion.MultiplicadorLvl))
        {
            CambiarLvl(Configuracion.lvl1, "Lvl: 1");
        }
        else if (Time.time <= (Configuracion.TiemposLvl[1] * Configuracion.MultiplicadorLvl))
        {
            
            
            if (spokenLvl2 == false) {
                CambiarLvl(Configuracion.lvl2, "Lvl: 2");
                activarRecoleccionable(Municion);
                player.GetComponentInChildren<Jugador>().MostrarTexto(Frases.lineas4, spriteBoss, 1);
                spokenLvl2 = true;
            }
        }
        else if (Time.time <= (Configuracion.TiemposLvl[2] * Configuracion.MultiplicadorLvl))
        {
            if (spokenLvl3 == false) {
                activarRecoleccionable(Vida);
                CambiarLvl(Configuracion.lvl3, "Lvl: 3");
                player.GetComponentInChildren<Jugador>().MostrarTexto(Frases.lineas5, spriteBoss, 1);
                spokenLvl3 = true;
            }
        }
        else if(bossFight==false)
        {
            activarRecoleccionable(Municion);
            SpawnBoss();
            CambiarLvl(Configuracion.lvl1, "Boss");
            player.GetComponentInChildren<Jugador>().MostrarTexto(Frases.lineas6, spriteBoss, 1);
        }
    }
    private void generarEnemigo() {
        spawn = PuntosSpawn[Random.Range(0, PuntosSpawn.Count())].gameObject;
        int n = Random.Range(1, 11);
        //basico
        if (n <= lvl[0])
        {
            Enemigo = Enemigos[0];
            EnemigoSpawn = EnemigosSpawn[0];
        }
        //avanzado
        else if (n <= lvl[1])
        {
            Enemigo = Enemigos[1];
            EnemigoSpawn = EnemigosSpawn[1];
        }
        //torre
        else if (n <= lvl[2])
        {
            Enemigo = Enemigos[2];
            EnemigoSpawn = EnemigosSpawn[2];
        }
        spawn = Instantiate(EnemigoSpawn.gameObject, spawn.transform.position, spawn.transform.rotation);
        spawn.GetComponent<Rigidbody>().AddRelativeForce(0, 300f, 300f);
        Invoke("ActivarEnemigo", 1.5f);
    }
    private void ActivarEnemigo() {
        Instantiate(Enemigo.gameObject, spawn.transform.position, spawn.transform.rotation);
        Destroy(spawn);
    }
    private void SpawnBoss()
    {
        bossFight = true;
        boss=Instantiate(EnemigosSpawn[3].gameObject, PuntoSpawnBoss.transform.position, PuntoSpawnBoss.transform.rotation);
        boss.GetComponent<Rigidbody>().AddRelativeForce(0, 350f, 350f);
        PuntoSpawnBoss.SetActive(false);
        Invoke("ActivarBoss", 1.5f);
    }
    private void ActivarBoss() {
        if (boss.activeSelf==true) {
        Instantiate(Enemigos[3].gameObject, boss.transform.position, boss.transform.rotation);
        Destroy(boss);
        }
    }
    private void CambiarLvl(int[] LvlNuevo,string TextoLvl) {
        this.lvl = LvlNuevo;
        //InfoLvl.text = TextoLvl;
    }
    private void activarRecoleccionable(GameObject objeto) {

        objeto.SetActive(true);
    }
}
