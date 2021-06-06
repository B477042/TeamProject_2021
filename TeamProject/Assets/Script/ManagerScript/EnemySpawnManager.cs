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
        int n_pattern = (int)data[PATTERN];

         //Distance from standard point
        float dis_from_cam = 16;
        //Distance between enemies
        float dis_enemies = 5;

        float new_x=0;
        float new_y = 2;

        switch(n_pattern)
        {
            //No.0 spawn pattern
            // in a row spawn
            case 0:
            print("case 0");
                for(int i=0;i<n_num;++i)
                {
                    dis_enemies = 5;
                    new_x = dis_from_cam+(i*dis_enemies);
                    new_y = 6;

                    var createObject = Instantiate<GameObject>(EnemyPrefabs[0]);
                    createObject.transform.position = standardPos +new Vector3(new_x,new_y,0);
                }
               
            
            
            
            break;
            
            //No.1 spawn pattern
            // Divide half. half of them will spawn at left. others on right.
            case 1:
            print("case 1");
               
                
                for(int i=0;i<n_num;++i)
                {
                    if(i<n_num/2)
                    {
                        new_x = dis_from_cam+(i*dis_enemies);
                        new_y = 2;

                        Vector3 addPos = new Vector3(new_x,new_y,0);
                        var createdObject = Instantiate<GameObject>(EnemyPrefabs[0]);
                        createdObject.transform.position = standardPos + addPos; 
                    }
                    else
                    {
                        new_x = (dis_from_cam+(i*dis_enemies))*-1;

                        Vector3 addPos = new Vector3(new_x,new_y,0);
                        var createdObject = Instantiate<GameObject>(EnemyPrefabs[0]);
                        createdObject.transform.position = standardPos + addPos; 
                    }
                }


            break;


            default:
            print("fail");
            break;
        }
        
    }

    
}
