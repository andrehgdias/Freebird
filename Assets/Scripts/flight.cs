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
    public float speedBoost;

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
        float boost = Input.GetAxis("Boost") * speedBoost;

        translation *= Time.deltaTime;
        boost *= Time.deltaTime;
        rotation *= Time.deltaTime;
        sobe *= Time.deltaTime;

        if(boost > 0)
        {
            transform.Translate(0, 0, translation + boost);
        }
        else
        {
            transform.Translate(0, 0, translation);
        }

        
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