using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hit : MonoBehaviour
{
    public GameObject NumInimigos;
    public GameObject inimigo;
    public GameObject inimigo2;
    public float dano;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inimigo = GameObject.Find("ZolrikMain");
        inimigo2 = GameObject.Find("Troll");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (collision.gameObject.tag == "Enemy")
            {
               // collision.gameObject.tag = "Untagged";
               // Destroy(collision.gameObject);
              //  NumInimigos.GetComponent<Spawner>().Inimigos -= 1;
           
                Debug.Log("INIMIGO -1");
            }

            
        }
    }

}
