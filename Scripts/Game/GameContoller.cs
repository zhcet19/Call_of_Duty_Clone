using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameContoller : MonoBehaviour
{
    [Header("Game")]
    public Player player;
    public GameObject enemyContainer;
    [Header("UI")]
    public Text ammoText;
    public Text healthText;
    public Text enemyText;
    public Text infoText;
    private float resetTimer=3f;
    private bool gameOver=false;


    private int initialEnemyCount=0;

    void Start()
    {
        
        infoText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update(){
    
        ammoText.text="Bullet Left:-"+player.Ammo;
        healthText.text="Health Left:-"+player.Health;
        int aliveEnemies=0;
        foreach (Enemy enemy in enemyContainer.GetComponentsInChildren<Enemy>())

        {
            if(enemy.Killed==false)
            {
                aliveEnemies++;
            }
            
        }
    
        enemyText.text="Enemies Left:-"+aliveEnemies;

        if(aliveEnemies==0 )
        {   gameOver=true;
            infoText.gameObject.SetActive(true);
            infoText.text="You Win!\nGood Job!";
        }
    if(player.Killed==true)
    {         gameOver=true;
            infoText.gameObject.SetActive(true);
            infoText.text="Beta haar gaye Koi nahi";
    }
    if(gameOver==true || aliveEnemies==0)
    {
        resetTimer-=Time.deltaTime;
        if(resetTimer<=0)
        {
            SceneManager.LoadScene("Menu");
        }
    }
    }
    
}
