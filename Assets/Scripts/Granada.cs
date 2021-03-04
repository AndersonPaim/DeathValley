using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada : MonoBehaviour
{

    public GameObject particula;
    public float raioExp = 15;
    public float forcaExp = 700;
   // public float forcaLancar = 700;
    public float dano = 100;
    public GameObject inimigo1, inimigo2;
    Rigidbody rgbody;

    

    // Start is called before the first frame update
    void Start()
    {
        rgbody = GetComponent<Rigidbody>();
        Explodir();
        // rgbody.AddRelativeForce(Vector3.forward * forcaLancar);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Explodir();
            Destroy(gameObject);

        }
    }
    
    void Explodir()
    {
        Instantiate(particula, transform.position, transform.rotation);
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, raioExp);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
           
            if (rb != null)
            {
                rb.AddExplosionForce(forcaExp, explosionPos, raioExp, 3.0F);   
            }
        }
    }
}
