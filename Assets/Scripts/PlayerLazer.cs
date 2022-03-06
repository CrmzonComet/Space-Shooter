using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLazer : MonoBehaviour
{
    public float shootSpeed = 100f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void doShoot(Vector3 direction)
    {
        Rigidbody2D r2d = this.GetComponent<Rigidbody2D>();

        r2d.AddForce(shootSpeed * direction);

        Destroy(this.gameObject, 2f);
    }
}
