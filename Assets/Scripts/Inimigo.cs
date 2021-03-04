using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inimigo : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player, floatingText;
    public float velocidade;
    public float distancia;
    public GameObject alvo;
    public GameObject NumInimigos, particulaDano;
    public float vida, vida2;
    public float danoSofrido;
    public float tempoMorte;
    public bool vivo = true;
    public AudioClip Somexplosao, Somdano;
    AudioSource audioSource;
    public Transform transfParticula;

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
        distancia = Vector3.Distance(player.transform.position, transform.position);

        vida2 = vida / 100;

        if (vivo)
        {

            if (distancia >= 30 || player.GetComponent<MoveCTRLDemo>().invisivel == true)
            {
                transform.LookAt(alvo.transform.position);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                transform.Translate(0, 0, velocidade * Time.deltaTime);
            }
            else if (distancia < 30 && player.GetComponent<MoveCTRLDemo>().invisivel == false)
            {
                
                transform.LookAt(player.transform.position);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                transform.Translate(0, 0, velocidade * Time.deltaTime);
            }
        }

        if (vida <= 0)
        {
            vivo = false;
            tempoMorte += Time.deltaTime;
            GetComponent<Animator>().Play("Death1");
            GetComponent<Rigidbody>().detectCollisions = false;
            
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
            audioSource.clip = Somexplosao;
            audioSource.Play();
        }

        if (collision.gameObject.tag == "Hit")
        {
           

            audioSource.clip = Somdano;
            audioSource.Play();
        }


        if (collision.gameObject.tag == "Hit" || collision.gameObject.tag == "Tiro")
        {
            floatingText.GetComponent<TextMesh>().text = danoSofrido.ToString();
            Instantiate(floatingText, transform.position, Quaternion.identity, transform);

            Instantiate(particulaDano, transfParticula.position, transfParticula.rotation);
            vida -= danoSofrido;
        }
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
    public void Damage()
    {
        vida -= 100;
    }
}
