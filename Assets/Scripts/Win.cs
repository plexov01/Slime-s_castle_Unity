using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Win : MonoBehaviour
{
    // public Transform slime;
    public Animator Anim;
    // private Vector3 StartPos;


    void Start()
    {
        // StartPos=new Vector3;
        // StartPos.y+=10;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D myTrigger)
    {
        if (myTrigger.CompareTag("Player"))
        {
            Anim.SetBool("Play",true);
            // new WaitForSeconds(2.9f);
            // win();
        }
    }
    public void win(){
        // slime.transform.position=StartPos;
        SceneManager.LoadScene("menu");
    }
}
