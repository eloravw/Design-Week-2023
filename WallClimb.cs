using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimb : MonoBehaviour
{

    public GameObject player;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            player.SendMessage("ClimbingWall");
           
        }

    }

   
}
