using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    private GameObject parent;
    public Enemy mushroomPref;
    public Enemy batPref;
    public Enemy goblinPref;
    private string currentLevel;

    [Header("First Level")]
    public Vector3 FirstLvlEnemy1Pos;
    public Vector3 FirstLvlEnemy2Pos;
    public Vector3 FirstLvlEnemy3Pos;
    public List<Transform> FirstLvlEnemy1Waypoints;
    public List<Transform> FirstLvlEnemy2Waypoints;
    public List<Transform> FirstLvlEnemy3Waypoints;

    [Header("Second Level")]
    public Vector3 SecondLvlEnemy1Pos;
    public Vector3 SecondLvlEnemy2Pos;
    public Vector3 SecondLvlEnemy3Pos;
    public List<Transform> SecondLvlEnemy1Waypoints;
    public List<Transform> SecondLvlEnemy2Waypoints;
    public List<Transform> SecondLvlEnemy3Waypoints;    

    [Header("Third Level")]
    public Vector3 ThirdLvlEnemy1Pos;   
    public Vector3 ThirdLvlEnemy2Pos;
    public Vector3 ThirdLvlEnemy3Pos;
    public List<Transform> ThirdLvlEnemy1Waypoints;
    public List<Transform> ThirdLvlEnemy2Waypoints;
    public List<Transform> ThirdLvlEnemy3Waypoints;

    void Awake()
    {
        currentLevel = SceneManager.GetActiveScene().name;
    }
    void Start()
    {        
        parent = GameObject.Find("MainGame");

        switch(currentLevel)
        {
            case "FirstLevel":
                InstantiateFirstLevel();
                break;
            case "SecondLevel":
                InstantiateSecondLevel();
                break;
            case "ThirdLevel":
                InstantiateThirdLevel();
                break;
        }
    }

    private void InstantiateFirstLevel()
    {
        Instantiate(mushroomPref, parent.transform).SetPos(FirstLvlEnemy1Pos).SetWaypoints(FirstLvlEnemy1Waypoints);

        Instantiate(mushroomPref, parent.transform).SetPos(FirstLvlEnemy2Pos).SetWaypoints(FirstLvlEnemy2Waypoints);

        Instantiate(mushroomPref, parent.transform).SetPos(FirstLvlEnemy3Pos).SetWaypoints(FirstLvlEnemy3Waypoints);
    }

    private void InstantiateSecondLevel()
    {
        //Instantiate(mushroomPref, parent.transform).SetPos(enemy1Pos).SetWaypoints(enemy1Waypoints);

        //Instantiate(mushroomPref, parent.transform).SetPos(enemy2Pos).SetWaypoints(enemy2Waypoints);

        //Instantiate(mushroomPref, parent.transform).SetPos(enemy3Pos).SetWaypoints(enemy3Waypoints);
    }

    private void InstantiateThirdLevel()
    {
        //Instantiate(mushroomPref, parent.transform).SetPos(enemy1Pos).SetWaypoints(enemy1Waypoints);

        //Instantiate(mushroomPref, parent.transform).SetPos(enemy2Pos).SetWaypoints(enemy2Waypoints);

        //Instantiate(mushroomPref, parent.transform).SetPos(enemy3Pos).SetWaypoints(enemy3Waypoints);
    }
}
