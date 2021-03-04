using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

    public GameObject inimigo;
    public GameObject inimigo2;
    public GameObject tiro;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    public int Inimigos;
    public float tempo;
    public int Wave = 1;
    public Text texto;
    public int n = 1;
    public GameObject spawner1, spawner2, spawner3, spawner4, particulasFim;
    public Text highscore, highscore2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
        spawner1 = GameObject.Find("spawner (1)");
        spawner2 = GameObject.Find("spawner (2)");
        spawner3 = GameObject.Find("spawner (3)");
        spawner4 = GameObject.Find("spawner (4)");
        inimigo = GameObject.Find("ZolrikMain");
        inimigo2 = GameObject.Find("Troll");

        highscore.text = PlayerPrefs.GetInt("HighScore", 1).ToString();

    }

    void Update()
    {
       
        tempo += Time.deltaTime;

        
        if (tempo > 8)
        {
            texto.text = "WAVE:" + n;
            particulasFim.SetActive(false);
        }

        if (tempo > 60 && Inimigos == 0)
        {
            Debug.Log("WAVE COMPLETA");
            spawnDelay--;
            tempo = 0;
            stopSpawning = false;
            Wave++;

            texto.text = "WAVE: " + n++;

            if (n > PlayerPrefs.GetInt("HighScore", 1))
            {
                PlayerPrefs.SetInt("HighScore", n);
            }
            
           
            particulasFim.SetActive(true);
                            
        }

    }

    // Update is called once per frame
    public void SpawnObject()
    {
        if (stopSpawning == false)
        {
            if (tempo < 60)
            {
                Instantiate(inimigo, spawner1.transform.position, spawner1.transform.rotation);
                Instantiate(inimigo, spawner2.transform.position, spawner2.transform.rotation);
                Instantiate(inimigo, spawner3.transform.position, spawner3.transform.rotation);
                Instantiate(inimigo2, spawner4.transform.position, spawner4.transform.rotation);
                Inimigos += 4;
            }
            else
            {
                stopSpawning = true;
            }
        }
      /*  if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }*/
    }
}
