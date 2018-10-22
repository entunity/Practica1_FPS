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
    [SerializeField] List<Transform> EnemigosSpawn;
    [SerializeField] public float TiempoSpawn;
    private Transform EnemigoSpawn;
    private GameObject spawn;
    public float MaxTiempoSpawn;
    [Header("Escenario")]
    [SerializeField] GameObject Municion;
    [SerializeField] GameObject Vida;
    [Header("Boss")]
    [SerializeField] GameObject PuntoSpawnBoss;
    private GameObject boss;
    private bool bossFight = false;
    [Header("UILvl")]
    [SerializeField] Text InfoLvl;
<<<<<<< HEAD:Assets/_GameAssets/Scripts/EscenarioJugable/Spawn.cs
    [SerializeField] public Sprite[] spriteBoss;
    [SerializeField] Text InfoTiempo;
    private float timer=0;
    [SerializeField] int[] lvl;
    public GameObject player;
    private bool spokenLvl2;
    private bool spokenLvl3;
    private int timepoActual;
=======
    [SerializeField] Sprite[] spriteBoss;
    [SerializeField] Text InfoTiempo;
    private float timer;
    private int[] lvl;
    private GameObject player;
    private bool spokenLvl2;
    private bool spokenLvl3;
>>>>>>> f9348683a4de031621bdfc09079c3aa23d6bf04b:Assets/_GameAssets/Scripts/Escenario/Spawn.cs
    // Use this for initialization
    void Start () {
        lvl = Configuracion.lvl1;
        player=GameObject.Find(Configuracion.tagPlayer);
<<<<<<< HEAD:Assets/_GameAssets/Scripts/EscenarioJugable/Spawn.cs
        MaxTiempoSpawn = TiempoSpawn;
=======
>>>>>>> f9348683a4de031621bdfc09079c3aa23d6bf04b:Assets/_GameAssets/Scripts/Escenario/Spawn.cs
    }
	
	// Update is called once per frame
	void Update () {
        timepoActual = (int)Time.timeSinceLevelLoad;
        if (InfoTiempo != null) {
            InfoTiempo.text = (timepoActual).ToString();
        }
        //generador enemigo
        timer += Time.deltaTime;
        if (timer >= TiempoSpawn) {
            this.transform.Rotate(0,Random.Range(0,181),0);
            generarEnemigo();
            timer = 0;
        }
        if (timepoActual <= (Configuracion.TiemposLvl[0] * Configuracion.MultiplicadorLvl))
        {
            CambiarLvl(Configuracion.lvl1, "Lvl: 1");
        }
        else if (timepoActual <= (Configuracion.TiemposLvl[1] * Configuracion.MultiplicadorLvl))
        {
            
            
            if (spokenLvl2 == false) {
                CambiarLvl(Configuracion.lvl2, "Lvl: 2");
                activarRecoleccionable(Municion);
<<<<<<< HEAD:Assets/_GameAssets/Scripts/EscenarioJugable/Spawn.cs
                dialogo(Frases.lineas4, spriteBoss, Configuracion.tiempoDialogos);
=======
                player.GetComponentInChildren<Jugador>().MostrarTexto(Frases.lineas4, spriteBoss, 1);
>>>>>>> f9348683a4de031621bdfc09079c3aa23d6bf04b:Assets/_GameAssets/Scripts/Escenario/Spawn.cs
                spokenLvl2 = true;
            }
        }
        else if (timepoActual <= (Configuracion.TiemposLvl[2] * Configuracion.MultiplicadorLvl))
        {
            if (spokenLvl3 == false) {
                activarRecoleccionable(Vida);
                CambiarLvl(Configuracion.lvl3, "Lvl: 3");
<<<<<<< HEAD:Assets/_GameAssets/Scripts/EscenarioJugable/Spawn.cs
                dialogo(Frases.lineas5, spriteBoss, Configuracion.tiempoDialogos);
=======
                player.GetComponentInChildren<Jugador>().MostrarTexto(Frases.lineas5, spriteBoss, 1);
>>>>>>> f9348683a4de031621bdfc09079c3aa23d6bf04b:Assets/_GameAssets/Scripts/Escenario/Spawn.cs
                spokenLvl3 = true;
            }
        }
        else if(bossFight==false)
        {
            activarRecoleccionable(Municion);
            SpawnBoss();
<<<<<<< HEAD:Assets/_GameAssets/Scripts/EscenarioJugable/Spawn.cs
=======
            CambiarLvl(Configuracion.lvl1, "Boss");
            player.GetComponentInChildren<Jugador>().MostrarTexto(Frases.lineas6, spriteBoss, 1);
>>>>>>> f9348683a4de031621bdfc09079c3aa23d6bf04b:Assets/_GameAssets/Scripts/Escenario/Spawn.cs
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
    private void SpawnBoss() {
            bossFight = true;
            boss = Instantiate(EnemigosSpawn[3].gameObject, PuntoSpawnBoss.transform.position, PuntoSpawnBoss.transform.rotation);
            boss.GetComponent<Rigidbody>().AddRelativeForce(0, 350f, 350f);
            PuntoSpawnBoss.SetActive(false);
            dialogo(Frases.lineas6, spriteBoss, Configuracion.tiempoDialogos);
            CambiarLvl(Configuracion.lvl1, "Boss");
            Invoke("ActivarBoss", 1.5f);
        
    }
    private void ActivarBoss() {
        if (boss.activeSelf==true) {
        Instantiate(Enemigos[3].gameObject, boss.transform.position, boss.transform.rotation);
        Destroy(boss);
        }
    }
    public void CambiarLvl(int[] LvlNuevo,string TextoLvl) {
        this.lvl = LvlNuevo;
        //InfoLvl.text = TextoLvl;
    }
    private void activarRecoleccionable(GameObject objeto) {
        if(objeto!=null)
        objeto.SetActive(true);
    }
    private void dialogo(string[]frases,Sprite[] imagenes,float tiempo) {
        if (player != null)
            player.GetComponentInChildren<Jugador>().MostrarTexto(frases, imagenes, tiempo);
    }
}
