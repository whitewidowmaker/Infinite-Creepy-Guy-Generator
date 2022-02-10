using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject sphere;
    private GameObject spher;
    public Transform sphereParent;
    public bool sphereIsSpawned = false;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnSphere();
    }

    private void SpawnSphere()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && !sphereIsSpawned)
        {
            spher = Instantiate(sphere);
            spher.transform.SetParent(sphereParent.transform);
            spher.transform.localPosition = new Vector3(0, 0, 0);
            sphereIsSpawned = true;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && sphereIsSpawned)
        {
            spher.GetComponent<Rigidbody>().isKinematic = false;
            spher.transform.parent = null;
            spher.GetComponent<Rigidbody>().AddForce(player.transform.forward * 10000);
            sphereIsSpawned = false;
        }
    }
}
