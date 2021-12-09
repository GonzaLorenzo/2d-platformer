using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy mushroomPref;
    public Enemy goblinPref;
    public Enemy batPref;
    public Vector3 enemy1Pos;
    public Vector3 enemy2Pos;
    public Vector3 enemy3Pos;
    public List<Transform> enemy1Waypoints;
    public List<Transform> enemy2Waypoints;
    public List<Transform> enemy3Waypoints;
    private GameObject parent;

    void Start()
    {
        
        parent = GameObject.Find("MainGame");

        Instantiate(mushroomPref, parent.transform).SetPos(enemy1Pos).SetWaypoints(enemy1Waypoints);

        Instantiate(mushroomPref, parent.transform).SetPos(enemy2Pos).SetWaypoints(enemy2Waypoints);

        Instantiate(mushroomPref, parent.transform).SetPos(enemy3Pos).SetWaypoints(enemy3Waypoints);
    }
}
