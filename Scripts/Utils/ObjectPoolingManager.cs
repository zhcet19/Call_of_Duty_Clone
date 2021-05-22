using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static ObjectPoolingManager instance;
    public static ObjectPoolingManager Instance{get{return instance;}}
    public GameObject bulletPrefab;
    public int bulletAmount=20;
    private List<GameObject> bullets;
    void  Awake()
    {
        instance=this;
        bullets= new List<GameObject>(bulletAmount);
        for(int i=0;i<bulletAmount;i++)
        {
            GameObject prefabInstance=Instantiate (bulletPrefab) ;
            prefabInstance.transform.SetParent(transform);
            prefabInstance.SetActive(false);
            bullets.Add(prefabInstance);
        
    }
    }

   public GameObject GetBullet(bool shotByPlayer)
   {
      foreach(GameObject bullet in bullets)
      {
          if(!bullet.activeInHierarchy)
          {
              bullet.SetActive(true);
              bullet.GetComponent<Bullet>().ShotByPlayer = shotByPlayer;
              return bullet;
          }
      }
      GameObject prefabInstance=Instantiate (bulletPrefab) ;
      prefabInstance.transform.SetParent(transform);
      prefabInstance.GetComponent<Bullet>().ShotByPlayer = shotByPlayer;
            bullets.Add(prefabInstance);

            return prefabInstance;
   }
    
}
