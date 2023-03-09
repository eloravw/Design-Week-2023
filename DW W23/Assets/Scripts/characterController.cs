using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public Rigidbody rigidbody;
    
    public GameObject rArm;
    public GameObject lArm;
    public GameObject rLeg;
    public GameObject lLeg;
    public GameObject torso;

    public GameObject rHand;
    public GameObject lHand;
    public GameObject rFoot;
    public GameObject lFoot;

    bool rHandGrounded = false;
    bool lHandGrounded = false;
    bool rFootGrounded = false;
    bool lFootGrounded = false;

    Vector3 spawnPoint = new Vector3(-4f, 3.5f, 1.7f);

    Vector3 rotationRate = new Vector3(500, 0, 0);
    Vector3 spinRate = new Vector3(0, 200, 0);
    float speed = 750;

    public Vector3 direction = Vector3.zero;

    float frontRayLength, backRayLength;

    // Start is called before the first frame update
    void Start()
    {
        frontRayLength = rFoot.GetComponent<Collider>().bounds.extents.y;
        backRayLength = rHand.GetComponent<Collider>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            if (Input.GetMouseButton(0))
            {
                lLeg.transform.Rotate(rotationRate * Time.deltaTime);
                if (lFootGrounded)
                {
                    direction += speed * lLeg.transform.forward;
                }
            }
            if (Input.GetMouseButton(1))
            {
                lLeg.transform.Rotate(rotationRate * -1 * Time.deltaTime);
                if (lFootGrounded)
                {
                    direction -= speed * lLeg.transform.forward;
                }
            }
            if (Input.GetKey("w"))
            {
                lLeg.transform.Rotate(spinRate * Time.deltaTime);
            }
        }
        if (Input.GetKey("s"))
        {
            if (Input.GetMouseButton(0))
            {
                rLeg.transform.Rotate(rotationRate * Time.deltaTime);
                if (rFootGrounded)
                {
                    direction += speed * rLeg.transform.forward;
                }
            }
            if (Input.GetMouseButton(1))
            {
                rLeg.transform.Rotate(rotationRate * -1 * Time.deltaTime);
                if (rFootGrounded)
                {
                    direction -= speed * rLeg.transform.forward;
                }
            }
            if (Input.GetKey("w"))
            {
                rLeg.transform.Rotate(spinRate * Time.deltaTime);
            }
        }
        if (Input.GetKey("d"))
        {
            if (Input.GetMouseButton(0))
            {
                lArm.transform.Rotate(rotationRate * Time.deltaTime);
                if (lHandGrounded)
                {
                    direction += speed * lArm.transform.forward;
                }
            }
            if (Input.GetMouseButton(1))
            {
                lArm.transform.Rotate(rotationRate * -1 * Time.deltaTime);
                if (lHandGrounded)
                {
                    direction -= speed * lArm.transform.forward;
                }
            }
            if (Input.GetKey("w"))
            {
                lArm.transform.Rotate(spinRate * Time.deltaTime);
            }
        }
        if (Input.GetKey("f"))
        {
            if (Input.GetMouseButton(0))
            {
                rArm.transform.Rotate(rotationRate * Time.deltaTime);
                if (rHandGrounded)
                {
                    direction += speed * rArm.transform.forward;
                }
            }
            if (Input.GetMouseButton(1))
            {
                rArm.transform.Rotate(rotationRate * -1 * Time.deltaTime);
                if (rHandGrounded)
                {
                    direction -= speed * rArm.transform.forward;
                }
            }
            if (Input.GetKey("w"))
            {
                rArm.transform.Rotate(spinRate * Time.deltaTime);
            }
        }
        if (direction != Vector3.zero)
        {
            GetComponent<Rigidbody>().velocity = direction * Time.deltaTime;
            direction = Vector3.zero;
        }
        rHandGrounded = false;
        lHandGrounded = false;
        rFootGrounded = false;
        lFootGrounded = false;
        if (Input.GetKey("p"))
        {
            spawnPoint = transform.position;
        }
        if (Input.GetKey("r"))
        {
            transform.position = spawnPoint;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            direction = Vector3.zero;
            transform.eulerAngles = Vector3.zero;
            lArm.transform.Rotate(-1 * lArm.transform.eulerAngles);
            rArm.transform.Rotate(-1 * rArm.transform.eulerAngles);
            lLeg.transform.Rotate(-1 * lLeg.transform.eulerAngles);
            rLeg.transform.Rotate(-1 * rLeg.transform.eulerAngles);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        for (int i = 0; i<collision.contactCount; i++)
        {
            Collider current = collision.GetContact(i).thisCollider;
            switch (current.name)
            {
                case "rightFoot":
                    rFootGrounded = true;
                    break;
                case "leftFoot":
                    lFootGrounded = true;
                    break;
                case "rightHand":
                    rHandGrounded = true;
                    break;
                case "leftHand":
                    lHandGrounded = true;
                    break;
                default:
                    break;
            }
        }
    }

    public bool Grounded(GameObject limb, bool front)
    {
        if (front == true)
        {
            return Physics.Raycast(limb.transform.position, -Vector3.up, frontRayLength + 0.2f);

        }
        else
        {
            return Physics.Raycast(limb.transform.position, -Vector3.up, backRayLength + 0.1f);
        }
    }


    private void ClimbingWall ()
    {

       // rigidbody.useGravity = false;


    }

}