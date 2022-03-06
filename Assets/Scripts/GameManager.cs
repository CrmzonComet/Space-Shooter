using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject gameUI;

    // Update is called once per frame
    void Update()
    {
        //if the player is not active...
        if(player.activeSelf != true)
        {
            //and the space bar has been pressed...
            if(Input.GetButton("Jump") )
            {
                //re-enable the player
                player.gameObject.SetActive(true);
                player.SendMessage("Respawn", SendMessageOptions.DontRequireReceiver);

                //inform UI player is active
                GameObject gameUI= GameObject.Find("GameUI");
        gameUI.SendMessage("hideRespawn", SendMessageOptions.DontRequireReceiver);

            }
        }
    }
}
