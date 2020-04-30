using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int columnPoolSize = 10;
    public GameObject columnPrefab;
    public float spawnRate = 3f;
    public float columnMin = -3f;
    public float columnMax = 8f;
    private int x_chose;

    
    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(50, 50);
    private float timeSinceLastSpawned;
    private float spawnYPosition = 2.5f;
    private int currentColumn = 0;
    private float p2;

    float x, y;
    // Start is called before the first frame update
    void Start()
    {
        columns =new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        timeSinceLastSpawned += Time.deltaTime * 2;
        if(GameContol.instance.gameOver==false && timeSinceLastSpawned >= spawnRate)
        {
           
            timeSinceLastSpawned = 0;
            p2 = Random.Range(-8,9);
            float spawnXPosition = Random.Range(p2, columnMax);
            x = Mathf.Clamp(spawnXPosition + p2, -12f, 11.85f);
            y = spawnYPosition + 9;
            if ((int)GameContol.instance.score % 6 == 0 )
            {
                x_chose = Random.Range(0, 3);
                GameContol.instance.enemies[x_chose].SetActive(true);
                GameContol.instance.enemies[x_chose].transform.position = new Vector2(x,y+1.16f);
            }
            columns[currentColumn].transform.position = new Vector2(x,y);
            currentColumn++;
            if(currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }

        }

    }
}
