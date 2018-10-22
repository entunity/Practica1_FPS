using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemigoBoss : EnemigoAvanzado {
    [Header("Boss")]
    [SerializeField] List<GameObject> protectores;
    [SerializeField] float TiempoSpawnEscudo;
    [SerializeField] private float divisorFase2 = 2;
    [SerializeField] private float divisorFase3 = 4;
    private GameObject spawn;
    private float TimerRespawn;
    private bool spoken1=false;
    private bool spoken2 = false;
    private bool spoken3 = false;
    private GameObject jugador;
    //fases boss divisor
    private void Start()
    {
        spawn = GameObject.Find(Configuracion.nombreSpawn);
        jugador = GameObject.Find(Configuracion.tagPlayer);
    }
    public override void Update() {
        base.Update();


        //50% de vida
        if (vidaEnemigo <= maxVida / divisorFase2)
        {
            TimerRespawn += Time.deltaTime;
            if (TimerRespawn >= TiempoSpawnEscudo)
            {
                GameObject respawn = protectores[Random.Range(0, protectores.Count())];
                respawn.GetComponent<Renderer>().enabled = true;
                respawn.GetComponent<Collider>().enabled = true;
                TimerRespawn = 0;
            }
            spawn.GetComponent<Spawn>().CambiarLvl(Configuracion.lvl2, "2ºFase");
            spawn.GetComponent<Spawn>().TiempoSpawn = spawn.GetComponent<Spawn>().MaxTiempoSpawn / divisorFase2;
            if (spoken1 == false){
                jugador.GetComponentInChildren<Jugador>().MostrarTexto(Frases.lineas7, spawn.GetComponent<Spawn>().spriteBoss, Configuracion.tiempoDialogos);
                spoken1 = true;
            }
        }
        //25% de vida
        if (vidaEnemigo <= maxVida / divisorFase3)
        {
            //mas enemigos y mas fuertes
            spawn.GetComponent<Spawn>().CambiarLvl(Configuracion.lvl3, "3ºFase");
            spawn.GetComponent<Spawn>().TiempoSpawn = spawn.GetComponent<Spawn>().MaxTiempoSpawn / divisorFase3;
            //regenera el escudo mas rapido hasta q lo tiene siempre
            TiempoSpawnEscudo-= Time.deltaTime;
            //se regenera hasta el 25% muy lentamente
            vidaEnemigo += Time.deltaTime;
            if (spoken2 == false)
            {
                jugador.GetComponentInChildren<Jugador>().MostrarTexto(Frases.lineas8, spawn.GetComponent<Spawn>().spriteBoss, Configuracion.tiempoDialogos);
                spoken2 = true;
            }
        }
        //muerte
        if (vidaEnemigo <= 0)
        {
            if (spoken3 == false)
            {
                jugador.GetComponentInChildren<Jugador>().MostrarTexto(Frases.lineas8, spawn.GetComponent<Spawn>().spriteBoss, Configuracion.tiempoDialogos);
                spoken3 = true;
                CambiarScena.CambiarScene(Configuracion.Final, true);
            }
        }
    }
}
