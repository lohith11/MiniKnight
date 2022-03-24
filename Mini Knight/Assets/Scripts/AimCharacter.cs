using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCharacter : MonoBehaviour
{
    private Transform AimTransform;
    Vector2 direction;

    public Transform barrel;
    public GameObject bullet;
    public float bulletSpeed = 50;
    public string Bullets;
    public int GunDurability = 3;
    public GameObject Aimm;

    private ObjectPooler objectpool;

    private void Start()
    {
        objectpool = FindObjectOfType<ObjectPooler>();
    }
    private void Awake()
    {
        AimTransform = transform.Find("Aim");
    }
    void Update()
    {
        //Aiming at Mouse Pointer

        Vector3 mousePoistion = Input.mousePosition;
        mousePoistion = Camera.main.ScreenToWorldPoint(mousePoistion);

        direction = new Vector2(mousePoistion.x - transform.position.x, mousePoistion.y - transform.position.y);

        AimTransform.up = direction;

        //Shooting
        //for(int i = 0; i <= GunDurability; i++) 
        if(GunDurability >= 1)
        if(Input.GetMouseButtonDown(0))
        {
            GameObject bulletc = objectpool.SpawnFromPool(Bullets, barrel.position,Quaternion.Euler(0,0,1));
            //bulletc.transform.position = barrel.position;
            //bulletc.transform.rotation = Quaternion.Euler(0,0,direction);
            bulletc.GetComponent<Rigidbody2D>().velocity = barrel.right * bulletSpeed;
            GunDurability--;
        }
        if(GunDurability == 0)
        {
            Aimm.SetActive(false);
        }

        
    }
}
