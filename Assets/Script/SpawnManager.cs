using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject hero;
    [SerializeField]
    private GameObject path;
    float currHeight = 2f;

    bool spawnStarted = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnStarted) return;
        if (currHeight-hero.gameObject.transform.position.y  < 1)
        {
            spawnStarted = true;
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject temp=Instantiate(path);
        temp.transform.position = new Vector3(hero.gameObject.transform.position.x, hero.gameObject.transform.position.y+5, 0);
        spawnStarted = false;
    }
}
