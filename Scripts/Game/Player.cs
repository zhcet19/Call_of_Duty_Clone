using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update 
    [Header("Visuals")]
    public Camera playerCamera;
    [Header("GamePlay")]
    public int initialammo=12;
    public int initialhealth=100;
    public float knockbackForce=10;
    public float hurtDuration=0.5f;

    private int ammo;
    public int Ammo{get{return ammo;}}
    private int health;
    public int Health{get{return health;}}
    private bool isHurt;
    private bool killed;
    public bool Killed{get{return killed;}}

    void Start()
    {
        ammo=initialammo;
        health=initialhealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
          if(ammo>0 && Killed==false)
          {ammo--;
           GameObject bulletObject=ObjectPoolingManager.Instance.GetBullet(true);
          bulletObject.transform.position=playerCamera.transform.position+playerCamera.transform.forward;
          bulletObject.transform.forward=playerCamera.transform.forward;

          }
         
        }
    }

void OnTriggerEnter (Collider otherCollider){
        //Colliding with  AmmoCrate to collect ammo
        if(otherCollider.GetComponent<AmmoCrate>()!=null)
        {
            AmmoCrate ammocrate = otherCollider.GetComponent<AmmoCrate>();
            ammo+=ammocrate.ammo;
            Destroy(ammocrate.gameObject);
        } else if(otherCollider.GetComponent<HealthCrate>()!=null)
        {
            HealthCrate healthcrate = otherCollider.GetComponent<HealthCrate>();
            health+=healthcrate.health;
            Destroy(healthcrate.gameObject);
        } 
        if(isHurt==false)
          { 
             GameObject hazard=null;



         if(otherCollider.GetComponent<Enemy>()!=null)
        {  
              //Colliding with enemy to lose health
            Enemy enemy =otherCollider.GetComponent<Enemy>();
            if(enemy.Killed==false)
            {
                     hazard=enemy.gameObject;
            health -= enemy.damage;
            }
        
        
          }
          else if(otherCollider.GetComponent<Bullet>()!=null)
          {
                    Bullet bullet=otherCollider.GetComponent<Bullet>();
                    if(bullet.ShotByPlayer==false)
                    {   hazard=bullet.gameObject;
                       health-=bullet.damage;
                       bullet.gameObject.SetActive(false);

                       
                    }
          }

          if(hazard!=null)
          {
              isHurt=true;
              // Perform the knockback effect.
				Vector3 hurtDirection = (transform.position - hazard.transform.position).normalized;
				Vector3 knockbackDirection = (hurtDirection + Vector3.up).normalized;
				GetComponent<ForceReceiver> ().AddForce (knockbackDirection, knockbackForce);

				StartCoroutine (HurtRoutine ());
          }
          if(health<=0)
          {
              if(killed==false)
              {
                  killed=true;
                  OnKill();
              }
          }
            

        }
    }
    IEnumerator HurtRoutine()
    {
        yield return new WaitForSeconds(hurtDuration);
        isHurt=false;
    }
    private void OnKill()
    {
       GetComponent<CharacterController>().enabled=false;
       GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled=false;
    }

}
