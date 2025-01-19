using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("# Game Object")]

    public PoolManager pool;

    public Player player;

   [Header("# Game Control")]
    public float gameTime;
    public float maxGameTime = 2 * 10f;
    [Header("# Player Info")]
    public int level;
    public int Kill;
    public int exp;
    public int[] nextExp = {3, 5, 30, 100, 150, 210, 280, 360, 450, 600};

    public void GetExp()
    {
        exp++;
        if (exp == nextExp[level]) {
            level++;
            exp = 0;
        }
    }
    

   

    void Awake()
    {
        instance = this; 
    }

    void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime) {
        
            gameTime = maxGameTime;
            
        }

        
        
        
        
    }



}
