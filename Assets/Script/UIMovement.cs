using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject hero;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().position = hero.transform.position + new Vector3(-5, 5, 0);
    }
}
