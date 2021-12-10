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
    public List<Transform> SecondLvlEnemy1Waypoints;
    public List<Transform> SecondLvlEnemy2Waypoints;  

    [Header("Third Level")]
    public Vector3 ThirdLvlEnemy1Pos;   
    public Vector3 ThirdLvlEnemy2Pos;
    public Vector3 ThirdLvlEnemy3Pos;
    public Vector3 ThirdLvlEnemy4Pos;
    public Vector3 ThirdLvlEnemy5Pos;
    public List<Transform> ThirdLvlEnemy1Waypoints;
    public List<Transform> ThirdLvlEnemy2Waypoints;
    public List<Transform> ThirdLvlEnemy4Waypoints;
    public List<Transform> ThirdLvlEnemy5Waypoints;

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
        Instantiate(batPref, parent.transform).SetPos(SecondLvlEnemy1Pos).SetWaypoints(SecondLvlEnemy1Waypoints);

        Instantiate(mushroomPref, parent.transform).SetPos(SecondLvlEnemy2Pos).SetWaypoints(SecondLvlEnemy2Waypoints);
    }

    private void InstantiateThirdLevel()
    {
        Instantiate(mushroomPref, parent.transform).SetPos(ThirdLvlEnemy1Pos).SetWaypoints(ThirdLvlEnemy1Waypoints);

        Instantiate(batPref, parent.transform).SetPos(ThirdLvlEnemy2Pos).SetWaypoints(ThirdLvlEnemy2Waypoints);

        Instantiate(goblinPref, parent.transform).SetPos(ThirdLvlEnemy3Pos);

        Instantiate(mushroomPref, parent.transform).SetPos(ThirdLvlEnemy4Pos).SetWaypoints(ThirdLvlEnemy4Waypoints);

        Instantiate(goblinPref, parent.transform).SetPos(ThirdLvlEnemy5Pos).SetSize(new Vector3 (-1,1,1));
    }
}
