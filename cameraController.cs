using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;

    public float zOffset = 5;
    public Vector3 camOffset = new Vector3(0, -1, 5);
    public Vector3 currentAngleVector;
    public float currentAngle;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = player.position - camOffset;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = player.position - camOffset;
    }
}
