using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    //List of Enemy Objects to Spawn
    public List<GameObject> EnemyPrefabs;

    private  const string SPAWNTABLE_1="spawnTable1";
    private const string PATTERN="pattern";
    private const string NUM="num";
    private List<Dictionary<string,object>> spawnTable1;
    private static EnemySpawnManager instance = null;
    public static EnemySpawnManager Instance
    {
        get
        {
            return instance;
        }
    }



    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        // Debug.LogWarning("Game manger instance Called");

        DontDestroyOnLoad(this);
    }

    private void Start() 
    {
        spawnTable1=CSVReader.Read(SPAWNTABLE_1);
    }

    //* Spawn enemies to world 
    //* otherTransform : Coordinates to which the spawn point is referenced
    //* objNum : csv file search factor
    public void SpawnEnemy( Transform OtherTransform,  uint Row)
    {
        //Load SpawnTable.csv file 
        var data = spawnTable1[(int)Row];
        
        switch(data[PATTERN])
        {
            //No.0 spawn pattern
            case 0:
            print("case 0");
            break;
            
            //No.1 spawn pattern
            case 1:
            print("case 1");
            break;


            default:
            print("fail");
            break;
        }
        
    }

    
}
