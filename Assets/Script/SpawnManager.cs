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
    float currHeight = 1.7f;
    public float currX = 7;

    bool spawnStarted = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (spawnStarted) return;
        if (currHeight - hero.gameObject.transform.position.y < 1)
        {
            spawnStarted = true;
            Spawn();
        }
    }

    void Spawn()
    {
        currX += giveRandomX();
        GameObject temp = Instantiate(path);

        temp.transform.position = new Vector3(currX, currHeight + 4.8f, 0);
        currHeight += 4.8f;
        spawnStarted = false;
    }

    float giveRandomX()
    {
        if (hero.gameObject.transform.position.x < 0) return 4;
        return -4;
    }
}
