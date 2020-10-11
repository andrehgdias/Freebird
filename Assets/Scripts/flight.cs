using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
//using System.Diagnostics;
//using System.Diagnostics;
//using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class flight : MonoBehaviour
{

    public float speed;
    public float rotationSpeed;
    public float speedUp;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float translation = 0.5F * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        float sobe = Input.GetAxis("Vertical") * speedUp;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        sobe *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(sobe, rotation, 0);

        if (rotation > 0)
        {
            transform.Rotate(0, 0, -0.5f);
        }
        else if (rotation < 0)
        {
            transform.Rotate(0, 0, 0.5f);
        }
    }
}