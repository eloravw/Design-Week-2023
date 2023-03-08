using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 camOffset = new Vector3(5, -1, 0);

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = player.transform.position - camOffset;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = player.transform.position - camOffset;
    }
}
