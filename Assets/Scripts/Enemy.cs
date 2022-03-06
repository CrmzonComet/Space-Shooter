using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    public int health;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 4f);
    }

    public void OnTriggerEnter2D( Collider2D other) {

        //Inform the game UI this object has been destroyed
        GameObject gameUI= GameObject.Find("GameUI");
        gameUI.SendMessage("addPoint", SendMessageOptions.DontRequireReceiver);

        //check what kind of object was hit
        if(other.gameObject.CompareTag("Lazer"))
        {
            //remove other laser
            Destroy(other.gameObject);

            //reduce health
            health = health - 1;

            //if health is zero or less
            if(health <= 0)
            {
                Destroy(this.gameObject);
                
            }

        }
       
       if(other.gameObject.CompareTag("Player"))
       {
           other.gameObject.SendMessage("EnemyCollide");
           Destroy(this.gameObject);
       }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = this.transform.position + new Vector3(-speed, 0f, 0f);
        this.transform.position = newPosition;
    }
}
