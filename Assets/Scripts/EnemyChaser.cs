using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    private GameObject Player;
    public float MoveSpeed = 3;
    float MaxDist = 10;
    float MinDist = 2;


    private void Awake()
    {
        Player = GameObject.Find("Player");
    }
    void Update()
    {
        transform.LookAt(Player.transform.position);

        if (Vector3.Distance(transform.position, Player.transform.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;



            if (Vector3.Distance(transform.position, Player.transform.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
            }

        }
    }
}
