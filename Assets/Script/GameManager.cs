using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private Transform land;

    GameObject enemy;
    float timer = 0;
    public List<GameObject> enemyObject = new List<GameObject>();

    private void Update() {
        timer += Time.deltaTime;

        if(timer >= 7 && enemyObject.Count < 5)
        {
            enemy = Instantiate(enemyPrefab, land.position, Quaternion.identity);
            enemyObject.Add(enemy);
            timer = 0;
        }

    }

    public void DeleteList(GameObject enemy)
    {
        enemyObject.Remove(enemy);
    }

}
