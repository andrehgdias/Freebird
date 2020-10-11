using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Ally : MonoBehaviour
{
    public Transform target = null;
    public bool followMove = true;
    public bool followRotate = true;
    public float offset = 0f;
    public float speed = 70f;
    private Vector3 destination; 


   

     private void Update()
    {


        destination = new Vector3(target.position.x + 10, target.position.y, target.position.z - 7);
        if (followMove)
        {
            GetComponent<Rigidbody>().MovePosition( Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime));
        }

        if(followRotate)
        {
            // Determine para qual direção girar
            Vector3 targetDirection = target.transform.forward;

            // O tamanho do passo é igual à velocidade vezes o tempo do quadro.
            float singleStep = speed * Time.deltaTime;

            // Rotaciona o vetor de avanço em direção ao alvo em um passo
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

            // Desenhe um raio apontando para nosso alvo em
            Debug.DrawRay(transform.position, newDirection, Color.red);

            // Calcula uma rotação um passo mais perto do alvo e aplica a rotação a este objeto
            transform.rotation = Quaternion.LookRotation(newDirection);
        }



    }


    


















   /* public Transform player;
    private Vector3 movement;
    public float moveSpeed = 5F;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = UnityEngine.Quaternion(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector3 direction)
    {
        rb.MovePosition((Vector3)transform.position + (direction * moveSpeed * Time.deltaTime));
    }*/
}