using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    public Transform slime;
    [SerializeField] private GameObject _Dead;
    private Vector3 StartPos;
    IEnumerator ShowDeadTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _Dead.SetActive(false);
    }

    void Start()
    {
        StartPos=slime.transform.position;
        
    }
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
        _Dead.SetActive(true);
        StartCoroutine(ShowDeadTime(0.50f));
        slime.transform.position=StartPos;
    }
}
