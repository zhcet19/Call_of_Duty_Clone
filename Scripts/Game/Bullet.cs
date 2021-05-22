using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 8f;
    public float lifeDuration=2f;
    public int damage=5;
    private float lifeTimer;
    private bool shotByPlayer;
    public bool ShotByPlayer{ get {return shotByPlayer;} set{shotByPlayer= value;}}

    void OnEnable()
    {
        lifeTimer=lifeDuration;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position +=transform.forward * speed* Time.deltaTime;

        lifeTimer-=Time.deltaTime;
        if(lifeTimer <= 0f)
        {
          gameObject.SetActive(false);
        }

    }
}
