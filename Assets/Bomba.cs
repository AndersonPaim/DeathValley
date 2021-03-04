using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject shatteredBomba, impact;
    public float lifetime, damageRadius, spawnForce, destroyDelay, gravityForce, shatterAmount, shatterOffset, seekForce, damageInterval, vortexDuration;
    public bool isDead = false;
    [HideInInspector] //COLOCAR NOS OUTROS SCRIPTS, MUITO MAIS LIMPO
    public Rigidbody rb;
    public ParticleSystem bomba /*impact*/, vortex;
    public Transform target;
    public GameObject targetAquisition;
    public float damageIntervalTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * spawnForce, ForceMode.VelocityChange);
        //bomba = transform.Find("Bomba").GetComponent<ParticleSystem>();
        //impact = transform.Find("Impacto").GetComponent<ParticleSystem>();

        targetAquisition = transform.Find("AquisicaoDeAlvo").gameObject;

        if(vortexDuration > 0)
        {
           // vortex = transform.Find("Vortex").GetComponent<ParticleSystem>();
        }

        if(seekForce > 0)
        {
            targetAquisition.transform.SetParent(null);
        }
        else
        {
            targetAquisition.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (targetAquisition)
        {
            targetAquisition.transform.position = transform.position;
        }
        if (isDead)
        {
            if(vortexDuration > 0)
            {
                vortexDuration -= Time.deltaTime;
                damageIntervalTimer -= Time.deltaTime;

                if(damageIntervalTimer < 0)
                {
                    AOEDamage();
                }

            }
            else
            {
                if (vortex)
                {
                    vortex.transform.SetParent(null);
                    vortex.Stop();
                    Destroy(vortex.gameObject, destroyDelay);
                    Destroy(gameObject, destroyDelay);
                   
                }
            }
        }
        else
        {
            if (lifetime > 0)
            {
                lifetime -= Time.deltaTime;
            }
            else
            {
                Impact();
                AOEDamage();
            }
        }
    }

    void FixedUpdate()
    {
        if (!isDead)
        {
            if (target) //PROBLEMA NO TARGET
            {
                Debug.Log("TEM UM ALVO" + target.position);
                Vector3 dir = target.position - transform.position;
                rb.AddForce(dir.normalized * seekForce, ForceMode.VelocityChange);
            }
            else if(gravityForce > 0)
            {
                rb.AddForce(Vector3.down * gravityForce, ForceMode.VelocityChange);
            }
        }
    }

    void Impact()
    {
        if(shatterAmount > 0 && shatteredBomba)
        {
            for(int i = 0; i < shatterAmount; i++)
            {
                Quaternion randomRotation = Quaternion.Euler(Random.Range(-20, -90), Random.Range(0, 360), 0);
                Instantiate(shatteredBomba, transform.position + Vector3.up * shatterOffset, randomRotation);
                
            }
        }

        Debug.Log("CHEGOU AQUI");

        //impact.Play();
        //bomba.Stop();
        impact.SetActive(true);
        isDead = true;
        rb.velocity = Vector3.zero;
        Destroy(targetAquisition);
        
        if (vortexDuration > 0)
        {
            vortex.gameObject.SetActive(true);
        }
        else
        {
           // Destroy(gameObject, destroyDelay);
        }
        
    }

    void AOEDamage()
    {
        damageIntervalTimer = damageInterval;

        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, damageRadius);
        foreach(Collider enemy in enemiesInRange)
        {
            //DANO
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colidiu");
   
        if (!isDead && other.tag != "Player" && other.tag != "Bomba" && other.tag != "hit")
        {
            Debug.Log("BATEU NO CHAO");
            Impact();
            AOEDamage();
        }
    }
}
