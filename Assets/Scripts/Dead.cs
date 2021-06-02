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
        _Dead.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        _Dead.SetActive(false);
        
       // Time.timeScale = 1;
    }

    void Start()
    {
        SlimeData.PointOfResurrect.Add(slime.transform.position);
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
        // _Dead.SetActive(true);
        
        StartCoroutine(ShowDeadTime(0.50f));
       // Time.timeScale = 0;
        slime.transform.position=SlimeData.PointOfResurrect[SlimeData.PointOfResurrect.Count-1];
    }
}
