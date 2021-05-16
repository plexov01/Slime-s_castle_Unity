using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    public Transform slime;
    private Vector3 StartPos;

    void Start()
    {
        StartPos=slime.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D myTrigger)
    {
        if (myTrigger.CompareTag("Player"))
        {
            dead();
        }
    }
    void dead(){
        slime.transform.position=StartPos;
    }
}
