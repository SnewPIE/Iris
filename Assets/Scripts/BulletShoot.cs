using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    PlayerControl playerControl;


    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetButtonDown("Fire1"))
        {

            GameObject bullet = Instantiate(bulletPrefab,transform.position, transform.rotation);
            bullet.transform.localScale = this.transform.localScale;
        }
        
    }

}
