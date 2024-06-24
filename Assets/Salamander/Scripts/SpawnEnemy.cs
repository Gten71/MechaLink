using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    [Tooltip("������ ������ ��� �������� ���������")]
    private GameObject playerObject;
    [SerializeField]
    [Tooltip("������ �����")]
    private GameObject enemyPrefab;
    [SerializeField]
    [Tooltip("������ ����� ����")]
    private Vector3 spawnZoneSize;
    [SerializeField]
    [Tooltip("���-�� ������ � ����")]
    private int MaxSpawnCount = 2;
    [SerializeField]
    [Tooltip("��������� ��� ��������� ������")]
    private int MinDistanceForSpawn = 60;
    public List<GameObject> allEnemies;

    private int spawnCount = 0;

    private void Update()
    {
        EnemySpawn(enemyPrefab);
    }

    //Is used to show Spawn Zone borders
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(gameObject.transform.position, spawnZoneSize);
    }

    //Is used for spawning enemies using spawn zones (gizmos). Use only if the script is attached to a gameobject
    private void EnemySpawn(GameObject enemy)
    {
        if (Vector3.Distance(playerObject.transform.position, gameObject.transform.position) > MinDistanceForSpawn && (spawnCount < MaxSpawnCount))  
        {
            Vector3 randomPosition = gameObject.transform.position + new Vector3(Random.Range(-spawnZoneSize.x / 2, spawnZoneSize.x / 2),
                                                                                 spawnZoneSize.y,
                                                                                 Random.Range(-spawnZoneSize.z / 2, spawnZoneSize.z / 2));
            GameObject clonedEnemy = Instantiate(enemy, randomPosition, Quaternion.identity);
            spawnCount++;
            allEnemies.Add(clonedEnemy);
        }
    }

    //Is used for spawning enemies individually using custom cordinates. Currently useless
    public void EnemySpawn(GameObject enemy, Transform position)
    {
        Instantiate(enemy, position);   
    }
}
