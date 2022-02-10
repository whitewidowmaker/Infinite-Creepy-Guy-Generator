using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemy;
    private GameObject nMe;
    public bool thereIsAnEnemy = false;

    private void Awake()
    {
        //nMe = Instantiate(enemy);
        nMe = Instantiate(enemy, new Vector3(Random.Range(2, 30), 1, Random.Range(2, 30)), Quaternion.identity);
        thereIsAnEnemy = true;
    }
    private void Update()
    {
        
        if (!thereIsAnEnemy && !GameObject.Find("Enemy(Clone)"))
        {
            nMe = Instantiate(enemy, new Vector3(Random.Range(2,60), 1, Random.Range(2, 60)), Quaternion.identity);

            nMe.GetComponentInChildren<AudioSource>().pitch = Random.Range(0.7f, 1f);
            nMe.GetComponent<EnemyChaser>().MoveSpeed = Random.Range(3, 6);
            thereIsAnEnemy = true;
        }
        
    }
}
