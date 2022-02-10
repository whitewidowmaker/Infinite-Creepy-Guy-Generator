using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Explosion : MonoBehaviour
{
    public GameObject explosion;
    public GameObject explosionSFX;
    private Vector3 colPos;
    private Quaternion colRot;
    public GameObject score = null;
    public GameObject shotsMissed = null;
    private GameObject enemyGen;
    private GameObject clingSFX;


    private void Start()
    {
        clingSFX = GameObject.Find("clingSFX");
        score = GameObject.Find("Score");
        shotsMissed = GameObject.Find("Score");
        enemyGen = GameObject.Find("EnemyGenerator");

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            clingSFX.GetComponent<AudioSource>().Play();
            score.GetComponent<ScoreHolder>().score++;
            GameObject.FindWithTag("Enemy").GetComponent<Enemy>().Die();
        }
        else if (collision.gameObject.tag == "Environment")
        {
            shotsMissed.GetComponent<ScoreHolder>().shotsMissed++;
        }
        ContactPoint contact = collision.contacts[0];
        colRot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        colPos = contact.point;
        explosion = Instantiate(explosion, colPos, colRot);
        Destroy(gameObject);
        enemyGen.GetComponent<EnemyGenerator>().thereIsAnEnemy = false;
        Destroy(explosion, 2f);
        PlaySfx();
    }

    private void PlaySfx()
    {

        explosionSFX = Instantiate(explosionSFX, colPos, colRot);
        explosionSFX.GetComponent<AudioSource>().Play();
        Destroy(explosionSFX, 2.0f);

    }
    
     

}
