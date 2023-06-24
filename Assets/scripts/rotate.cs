using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [SerializeField] private float sppedrotate = 2f;

    private void Update()
    {

        transform.Rotate(0, 0, 360 * sppedrotate * Time.deltaTime);
        //rotating by 360 degree * spped *deltatime.
        
    }
}
