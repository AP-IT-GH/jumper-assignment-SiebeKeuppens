using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleVertical : MonoBehaviour
{
    public float speed;
    Rigidbody obstacleBody;

    // Start is called before the first frame update
    void Start()
    {
        //Freeze object rotation.
        obstacleBody = GetComponent<Rigidbody>();
        obstacleBody.constraints = RigidbodyConstraints.FreezeRotation;
        transform.localPosition = new Vector3(30f,0.5f,0f);
        this.transform.localScale = new Vector3(1f, Random.Range(1, 3) , 10f );
        speed = Random.Range(0.05f, 0.2f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.left * speed);
        if (transform.localPosition.x < -10)
        {
            Start();
        }
    }
}
