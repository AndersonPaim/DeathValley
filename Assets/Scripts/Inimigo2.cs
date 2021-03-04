using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inimigo2 : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player, floatingText;
    public float velocidade;
    public float distancia;
    public GameObject alvo;
    public GameObject NumInimigos, particulaDano;
    public float vida;
    public float danoSofrido, danoTiro;
    public float tempoMorte;
    public bool vivo = true;
    public Transform transfParticula;
    public AudioClip explosao, audio2;
    AudioSource audioSource;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player;
        player = GameObject.Find("Player");
        alvo = GameObject.Find("Torre");
        NumInimigos = GameObject.Find("Spawners");

        distancia = Vector3.Distance(player.transform.position, transform.position);


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
            GetComponent<Animator>().Play("Die");  
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
                GetComponent<Animator>().Play("Attack");
            }
        }
        if (collision.gameObject.tag == "Tiro")
        {
            GetComponent<Animator>().Play("Hit");
            Instantiate(particulaDano, transfParticula.position, transfParticula.rotation);

            floatingText.GetComponent<TextMesh>().text = danoTiro.ToString();
            Instantiate(floatingText, transform.position, Quaternion.identity, transform);

            if (vida >= 100)
            {
                GetComponent<Rigidbody>().AddRelativeForce(0, 50, -300);
            }
            vida -= danoSofrido * 2;
            Destroy(collision.gameObject);
            //audioSource.clip = explosao;
           // audioSource.Play();
        }
       
        if (collision.gameObject.tag == "Hit")
        {

            GetComponent<Animator>().Play("Hit");
            Instantiate(particulaDano, transfParticula.position, transfParticula.rotation);

            floatingText.GetComponent<TextMesh>().text = danoSofrido.ToString();
            Instantiate(floatingText, transform.position, Quaternion.identity, transform);
             

            if (vida >= 100)
            {
                GetComponent<Rigidbody>().AddRelativeForce(0, 50, -300);
            }
         
            vida -= danoSofrido;
        }
       
    }
    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "Torre")
        {
            GetComponent<Animator>().Play("Attack");
        }

    }
    public void OncollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<Animator>().Play("Move");
        }
        if (collision.gameObject.tag == "Torre")
        {
            GetComponent<Animator>().Play("Move");
        }
    }
}
