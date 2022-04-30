using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    Rigidbody obstacleBody;

    // Start is called before the first frame update
    void Start()
    {
        //Freeze object rotation.
        obstacleBody = GetComponent<Rigidbody>();
        obstacleBody.constraints = RigidbodyConstraints.FreezeRotation;
        transform.localPosition = new Vector3(0, 0.5f, 30);
        this.transform.localScale = new Vector3(10f, Random.Range(1, 3) , 1f );
        speed = Random.Range(0.05f, 0.2f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.back * speed);
        if (transform.localPosition.z < -10)
        {
            Start();
        }
    }
}
