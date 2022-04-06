using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> TargetList;
    public GameManager gameManager;
    public int spawnTick;

    private void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        while (gameManager.IsGameActive)
        {
            yield return new WaitForSeconds(spawnTick);
            int index = Random.Range(0, TargetList.Count);
            Instantiate(TargetList[index]);
        } 
    }
}
