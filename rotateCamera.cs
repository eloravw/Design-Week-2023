using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 speed = new Vector3(0, 100, 0);
    public float direction = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("q") && direction < 1)
        {
            direction += 0.01f;
        }
        else if (direction > 0)
        {
            direction -= 0.01f;
        }
        if (Input.GetKey("e") && direction > -1)
        {
            direction -= 0.01f;
        }
        else if (direction < 0)
        {
            direction += 0.01f;
        }
        //direction = Input.GetAxis("Horizontal");
        transform.position = player.position;
        transform.Rotate(speed * direction * Time.deltaTime);
    }
}
