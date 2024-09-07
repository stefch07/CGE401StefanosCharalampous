using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class LoseOnFall : MonoBehaviour
{
    
    //public Text textbox;
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -1)
        {
            //textbox.text = "You lose!";
            ScoreManager.gameOver = true;
        }
    }
}
