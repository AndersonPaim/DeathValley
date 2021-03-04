using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Criar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //PRESSIONAR botao do mouse
        if (Input.GetMouseButtonDown(0))
        //if (Input.GetMouseButton(0))
        {
            //CRIAR obj em tempo real - guarda referencia
            GameObject novo = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //mudar propriedades do obj
            novo.name = "NovoCubo";
            //posicao - copiar pos do player
            novo.transform.position = transform.position;
            //um pouco acima
            novo.transform.position += new Vector3(0, 1.5f, 0);
            //copia rotacao do player
            novo.transform.rotation = transform.rotation;

            //mudar a cor
            novo.GetComponent<MeshRenderer>().material.color = Color.blue;

            //escala 
            novo.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            //adicionar components, scripts
            //novo.AddComponent<Girar>();
            //adicionar fisica
            novo.AddComponent<Rigidbody>();
            //adicionar forca fisica no obj
            //novo.GetComponent<Rigidbody>().AddForce(0, 500, 300);
            //forca relativa = para direcao do obj
            //novo.GetComponent<Rigidbody>().AddRelativeForce(0, 500, 300);
            novo.GetComponent<Rigidbody>().AddRelativeForce(0, 0, 4000);

            //adiciona script
            //novo.AddComponent<Bala>();
        }

    }
}
