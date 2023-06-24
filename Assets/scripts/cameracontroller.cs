using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    [SerializeField]private Transform player;

   private  void Update()
        // here tranformation deosnt need any get method because the script is main camera object and that transform can be imported directly
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);


        
    }
}
