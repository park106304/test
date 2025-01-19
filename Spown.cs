using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spown : MonoBehaviour
{

    public Transform[] spawnPoint;
    public SpawnData[] spawnData;


    int level;

    float timer;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }
    // Start is called before the first frame update

    
 

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        level = Mathf.Min(Mathf.FloorToInt( GameManager.instance.gameTime/ 10f), spawnData.Length -1);
        

        if (timer >spawnData[level].spawnTime) {
        
            timer = 0;
            Spawn();
        }

        
        
    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(1,spawnPoint.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
    }


}
[System.Serializable]
public class SpawnData
{
    public int spriteType;
    public float spawnTime;

    public int health;

    public float speed;
}
