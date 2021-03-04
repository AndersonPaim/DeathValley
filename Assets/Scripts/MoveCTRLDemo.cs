using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;
using UnityEngine.SceneManagement;
public class MoveCTRLDemo : MonoBehaviour
{

    private bool stop = false;
    public float delay = 0, tempo, tempoInicio, tempoInvisivel;
    public Image barraVida, barraEnergia;
    public float dano, dano2, danoTiro = 0.25f, regeneracao;
    public float custo, custo2, delayEnergia; //custo de energia
    public Rigidbody barreira;
    public SkinnedMeshRenderer rend, rend2;
    public Shader shader1, shader2;
    GameObject corpo;
    public float delayHab, delayHab2, delayTiro;
    public bool invisivel = false, vivo = true;
    public GameObject Inimigo, Inimigo2, colisor, cura, bomba;
    public Transform pontoSaida, pontoSaidaBomba;
    Animator animator;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rend.material.shader = shader1;
        rend2.material.shader = shader1;
        Inimigo = GameObject.Find("ZolrikMain");
        Inimigo2 = GameObject.Find("Troll");
        animator = GetComponent<Animator>();
    }

    void Move()
    {
        float speed = 0.0f;
        float add = 0.0f;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w"))
        {
            if (Input.GetKey(KeyCode.LeftShift)) { 
                add = 10; //velocidade de corrida
            }
            else {   
                add = 5; //velocidade de caminhada
            }
            speed = Time.deltaTime * add;
            transform.Translate(0, 0, speed);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
        {
            add = 5; //para de correr volta velocidade de caminhada
            speed = Time.deltaTime * add;
            transform.Translate(0, 0, -speed);
        }
    }
 
    void Update()
    {
        //timers
        delayEnergia += Time.deltaTime;
        tempo += Time.deltaTime;
        tempoInicio += Time.deltaTime;
        delayHab += Time.deltaTime;
        delayHab2 += Time.deltaTime;
        delayTiro += Time.deltaTime;

        if (tempoInicio > 8)
        {
            //falta estado do ataque com o Q, danos sofridos
            //ESTADO ANDAR
            if (Input.GetKeyDown(KeyCode.W))
            {
                animator.SetBool("isWalking", true);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                animator.SetBool("isWalking", false);
            }
            //ESTADO CORRER
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (animator.GetBool("isWalking") == true)
                {
                    animator.SetBool("isRunning", true);
                }
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                animator.SetBool("isRunning", false);
            }
            //ESTADO TIRO
            if (Input.GetKeyDown(KeyCode.Mouse0) && delayTiro > 3)
            {
                delayTiro = 0;
                animator.SetBool("isAttacking", true);
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                animator.SetBool("isAttacking", false);
            }
            //ESTADO MELEE
            if (Input.GetKeyDown(KeyCode.Q))
            {
                animator.SetBool("isAttacking2", true);
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                animator.SetBool("isAttacking2", false);
            }
            //REGENERAR ENERGIA
            if (delayEnergia > 3)
            {
                barraEnergia.fillAmount += regeneracao * Time.deltaTime;
            }
            //
            if (barraVida.GetComponent<Image>().fillAmount == 0)
            {
                //MORREU
                vivo = false;
                Destroy(gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Cursor.lockState = CursorLockMode.None;
            }

            Habilidades();

            // // // // // // // // // // // // // // // //

            transform.Rotate(0, Input.GetAxis("Mouse X") * 90 * Time.deltaTime, 0);

            Move();

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
            {
                transform.Rotate(0, Time.deltaTime * -100, 0);
            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
            {
                transform.Rotate(0, Time.deltaTime * 100, 0);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (Inimigo.GetComponent<Inimigo>().vivo == true)
            {
                GetComponent<Rigidbody>().AddRelativeForce(0, 50, -500);
                barraVida.fillAmount -= dano;
                //FALTA ESTADO DA ANIMACAO DE DANO 
            }
        }
        if (collision.gameObject.tag == "Enemy2")
        {
            if (Inimigo2.GetComponent<Inimigo2>().vivo == true)
            {
                GetComponent<Rigidbody>().AddRelativeForce(0, 50, -500);
                barraVida.fillAmount -= dano2;
                //FALTA ESTADO DA ANIMACAO DE DANO
            }
        }
        if (collision.gameObject.tag == "Tiro")
        {
            barraVida.GetComponent<Image>().fillAmount -= danoTiro;
        }
       
    }

    public void Habilidades()
    {
        //HABILIDADES

        //BOMBA
        if (delayHab2 > 2)
        {
            if (Input.GetKey(KeyCode.Alpha2))
            {
                Instantiate(bomba, pontoSaidaBomba.transform.position, pontoSaidaBomba.transform.rotation);
                delayHab2 = 0;
            }


        }

        //INVISIVEL

        if (delayHab > 3)
        {
            if (barraEnergia.GetComponent<Image>().fillAmount == 1)
            {
                if (Input.GetKey(KeyCode.Alpha3))
                {
                    if (rend.material.shader == shader1)
                    {
                        rend.material.shader = shader2;
                        rend.material.mainTextureScale = new Vector2(50, 50);
                        rend2.material.shader = shader2;
                        delayHab = 0;
                        barraEnergia.fillAmount -= custo;
                        invisivel = true;
                    }
                    else if (rend.material.shader == shader2)
                    {
                        rend.material.shader = shader1;
                        rend.material.mainTextureScale = new Vector2(1, 1);
                        rend2.material.shader = shader1;
                        delayHab = 0;
                        invisivel = false;
                    }
                }
            }
        }

        //CURA
        if (barraEnergia.GetComponent<Image>().fillAmount == 1)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                barraEnergia.fillAmount -= custo;
                barraVida.GetComponent<Image>().fillAmount = 1;
                if (!cura.active)
                {
                    cura.SetActive(true);
                }
                else
                {
                    cura.SetActive(false);
                    cura.SetActive(true);
                }
            }
        }

    }

    public void ColisaoLigar() //ligar colisor do ataque durante evento da animação
    {
        colisor.GetComponent<SphereCollider>().enabled = true;
    }

    public void ColisaoDesligar()  //desligar colisor do ataque durante evento da animação
    {
        colisor.GetComponent<SphereCollider>().enabled = false;
        animator.SetBool("isAttacking", false);
        animator.SetBool("isAttacking2", false);
    }
}