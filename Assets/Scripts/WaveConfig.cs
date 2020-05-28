using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{

    [SerializeField] GameObject enemyPrefab = null;
    [SerializeField] GameObject pathPrefab = null;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberofEnemies = 6;
    [SerializeField] float moveSpeed = 2f;

    public GameObject   GetEnemyPrefab()        { return enemyPrefab; }
    public float        GetTimeBetweenSpawns()  { return timeBetweenSpawns; }
    public float        GetSpawnRandomFactor()  { return spawnRandomFactor; }
    public int          GetNumberOfEnemies()    { return numberofEnemies; }
    public float        GetMoveSpeed()          { return moveSpeed; }

    public List<Transform> GetWaypoints()
    {
        var waypoints = new List<Transform>();

        foreach (Transform child in pathPrefab.transform)
        {
            waypoints.Add(child);
        }

        return waypoints;
    }
}
