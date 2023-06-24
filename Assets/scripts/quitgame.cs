using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitgame : MonoBehaviour
{
 public void Quit()
    {
        //this only works when we build the game.
        Application.Quit();
    }
}
