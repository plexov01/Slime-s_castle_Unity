using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public Transform slime;
    private Vector3 StartPos;

    void Start()
    {
        StartPos=slime.transform.position;
        StartPos.y+=10;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D myTrigger)
    {
        if (myTrigger.CompareTag("Player"))
        {
            win();
        }
    }
    void win(){
        slime.transform.position=StartPos;
    }
}
