using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inimigo3 : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    public float velocidade;
    public float distancia;
    public GameObject alvo;
    public GameObject NumInimigos, particulaDano, tiro;
    public float vida;
    public float danoSofrido;
    public float tempoMorte;
    public bool vivo = true;
    public AudioClip explosao, audio2;
    AudioSource audioSource;
    public Transform transfParticula;
    public float delayTiro;
    public Transform tiroPos;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player;
        player = GameObject.Find("Player");
        alvo = GameObject.Find("Torre");
        NumInimigos = GameObject.Find("Spawners");

        delayTiro += Time.deltaTime;

        distancia = Vector3.Distance(player.transform.position, transform.position);

        if (vivo)
        {

            transform.LookAt(player.transform.position);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

            if (distancia > 40 && player.GetComponent<MoveCTRLDemo>().invisivel == false)
            {
               transform.Translate(0, 0, velocidade * Time.deltaTime);
            }
            if (distancia > 40 && distancia < 45 && player.GetComponent<MoveCTRLDemo>().invisivel == false)
            {
                Instantiate(tiro, tiroPos.position, tiroPos.rotation);
            }
            if (player.GetComponent<MoveCTRLDemo>().invisivel == true)
            {

            }
        }

        if (vida <= 0)
        {
            vivo = false;
            tempoMorte += Time.deltaTime;
            GetComponent<Animator>().Play("Death1");

            if (tempoMorte >= 2)
            {
                Destroy(gameObject);
                NumInimigos.GetComponent<Spawner>().Inimigos -= 1;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (vivo)
            {
                GetComponent<Animator>().Play("Attack1");
            }
        }
        if (collision.gameObject.tag == "Tiro")
        {
            Destroy(collision.gameObject);
            audioSource.clip = explosao;
            audioSource.Play();
        }

        if (collision.gameObject.tag == "Hit" || collision.gameObject.tag == "Tiro")
        {

            Instantiate(particulaDano, transfParticula.position, transfParticula.rotation);


            if (vida > 100)
            {
                GetComponent<Rigidbody>().AddRelativeForce(0, 50, -300);
            }

            vida -= danoSofrido;
        }

        /*
        if (collision.gameObject.tag == "Tiro")
        {
            GetComponent<Animator>().Play("Hit");
           
            if (vida > 100)
            {
                GetComponent<Rigidbody>().AddRelativeForce(0, 50, -300);
            }
            vida -= danoSofrido * 2;
        }*/
    }
    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "Torre")
        {
            GetComponent<Animator>().Play("Attack1");
        }

    }
    public void OncollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<Animator>().Play("Run");
        }
        if (collision.gameObject.tag == "Torre")
        {
            GetComponent<Animator>().Play("Run");
        }
    }
}
