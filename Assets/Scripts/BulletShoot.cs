using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    float fireCooldown;
    float fireTime;
    public GameObject bulletPrefab;
    public Transform FirePlace;
    PlayerControl playerControl;


    // Start is called before the first frame update
    void Start()
    {
        fireCooldown = 0.5f;
        fireTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if (fireTime <=0)
            {

                GameObject bullet = Instantiate(bulletPrefab, FirePlace.position, FirePlace.rotation);
                bullet.transform.localScale = this.transform.localScale;
                fireTime = fireCooldown;
            }
        }
        fireTime = fireTime - Time.deltaTime;

    }

}
