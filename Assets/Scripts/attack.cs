 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public GameObject explosion;
    public Transform player;
    public float BaxDist;
    public IEnumerator _Wait () {
                for (int i = 0; i >= 0; i++) {
                        yield return new WaitForSeconds (1);
                        //print ("Bax!!");
                        float distToPlayer = Vector2.Distance(transform.position, player.position);

                        if (distToPlayer < BaxDist)
                        {
                            Instantiate(explosion, new Vector3(Random.Range(player.position.x - 1/2, player.position.x + 1/2), Random.Range(player.position.y- 1/2, player.position.y + 1/2), transform.position.z), Quaternion.identity);
                        }
                        
                }
        }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_Wait());
    }

    // Update is called once per frame
    void Update()
    {
    }
}
