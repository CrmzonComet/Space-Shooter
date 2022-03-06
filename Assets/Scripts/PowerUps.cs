using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{

public float speed;
public string type;

    // Start is called before the first frame update
    void Start()
    {
        
    }

 public void OnTriggerEnter2D( Collider2D other) {

       
       
       if(other.gameObject.CompareTag("Player"))
       {
           other.gameObject.SendMessage("PowerUp", type);
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
