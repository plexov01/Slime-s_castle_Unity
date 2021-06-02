using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResurrectStone : MonoBehaviour
{
    private GameObject slime;
    [SerializeField]private Animator Anim;
    [SerializeField]private AudioSource Active;
    // Start is called before the first frame update
    void Start()
    {
        slime=GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D myTrigger)
    {
        if (myTrigger.CompareTag("Player"))
        {
            SlimeData.PointOfResurrect.Add(transform.position);
            Anim.SetBool("Shine",true);
        }
    }

    private void PlayActive(){
        Active.Play();
    }
}
