using System.Collections;
using UnityEngine;

public class Ally : MonoBehaviour
{
    public Transform target = null;
    public float speed;
    private Vector3 destination;
    [Range(0f, 1f)]
    public float smoothTime;
    public Rigidbody rb;

    public int qtdBirds = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

     private void FixedUpdate()
    {
        Debug.Log("Quantidade de passaros");
        Debug.Log(qtdBirds);

        // destination = new Vector3(target.position.x, target.position.y, target.position.z);
        rb.position = Vector3.Lerp(rb.position, target.position, Time.deltaTime * speed);
        transform.rotation = target.rotation;
    }
}