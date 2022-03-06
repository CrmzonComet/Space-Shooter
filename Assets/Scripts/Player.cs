using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject lazerPrefab;
    public float speed = 1.5f;
    private float health;
    public float maxHealth;
    private Rigidbody2D r2d;
    private Animator animator;

    public AudioSource shootSound;
    public GameObject explosion;
    private GameObject gameUI;
    // start of shield power up
    public GameObject shield;
    public GameObject shotgun;
    public GameObject shotgun1;
    public GameObject shotgun2;
    
    

    // Start is called before the first frame update
    void Start()
    {
        r2d = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        gameUI= GameObject.Find("GameUI");
        this.health = this.maxHealth;

        // shield
        shield = this.transform.Find("Shield").gameObject;
        DeactivateShield();

        //shotgun
        shotgun = this.transform.Find("Shotgun").gameObject;
    DeactivateShotgun();
    }

    public void EnemyCollide()
    {
        //make the explosion
        GameObject explo = Instantiate(explosion, this.transform.position, Quaternion.identity);

        //get rid of explosion after one second
        Destroy(explo, 1f);


        // if player has shield
         if (HasShield())
         {
             DeactivateShield();
         }
         else
         {
             //reduce heatlh
        health = health - 1;
        gameUI.SendMessage("SetHealthPercent", health / this.maxHealth);
         }
         //if at no health, show respawn
        if(health <= 0)
        {
            //inform UI player is inactive
        
        gameUI.SendMessage("showRespawn", SendMessageOptions.DontRequireReceiver);

        //disable for now...
        this.gameObject.SetActive(false);
        }


        //if player has shotgun
         if (HasShotgun())
         {
             DeactivateShotgun();
         }
    }

    // power up
    public void PowerUp(string type)
    {
        if (type == "shield")
        {
            ActivateShield();
        }
        
        if (type == "shotgun")
        {
             ActivateShotgun();
        }
        
    }

    public void Respawn()
    {
        this.health = this.maxHealth;
        gameUI.SendMessage("SetHealthPercent", 1.0);
    }

// start of sheild void
    void ActivateShield()
    {
        shield.SetActive(true);
    }

    void DeactivateShield()
    {
        shield.SetActive(false);
    }
// end of shield void

// shield bool
    public bool HasShield()
    {
        return shield.activeSelf;
    }
// end of shield bool

// shotgun bool
    public bool HasShotgun()
    {
        return shotgun.activeSelf;
    }
// of shotgun bool

    // start of shotgun void
    void ActivateShotgun()
    {
        shotgun.SetActive(true);
    }

    void DeactivateShotgun()
    {
        shotgun.SetActive(false);
    }
// end of shotgun void

    // Update is called once per frame
    void Update()
    {
        
        // simple movement vector
        Vector2 moveVec = new Vector2();

        moveVec.y = Input.GetAxis("Vertical") * speed;
        moveVec.x = Input.GetAxis("Horizontal") * speed;

        r2d.AddForce(moveVec);

        animator.SetFloat("speed", Mathf.Abs (moveVec.y));

        //shoot response
        if( Input.GetButtonDown("Fire1") ) 
        {
            //make laser shot
            GameObject myShot = Instantiate(lazerPrefab, this.transform.position, Quaternion.identity);
            myShot.SendMessage("doShoot", new Vector3(1f,0,0f));
            //make sound
            shootSound.Play();

            //if player has shotgun
         if (HasShotgun())
         {
             GameObject bulletOne = Instantiate(lazerPrefab, shotgun1.transform.position, shotgun1.transform.rotation);
             bulletOne.SendMessage("doShoot", new Vector3(1f,1f,0f));
             GameObject bulletTwo = Instantiate(lazerPrefab, shotgun2.transform.position, shotgun2.transform.rotation);
             bulletTwo.SendMessage("doShoot", new Vector3(1f,-1f,0f));
         }
        }
    }
}
