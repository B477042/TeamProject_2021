using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
  

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
    public void SpawnEnemy( Transform OtherTransform,  uint Row, List<GameObject> EnemyPrefabs)
    {

        //Load SpawnTable.csv file 
        var data = spawnTable1[(int)Row];
        //position which is represent standard position
        var standardPos = OtherTransform.position;
        //

        int n_num = (int)data[NUM];
        switch((int)data[PATTERN])
        {
            //No.0 spawn pattern
            case 0:
            print("case 0");
            // for(int i=0;i<n_num;++i)
            // {
            //     var createObject = Instantiate<GameObject>(EnemyPrefabs[0]);
            //     createObject.transform.position = standardPos +new Vector3(16+i,6,0);
            // }
            
            
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
