using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(slime))]
public class UserController : MonoBehaviour
{
    private slime slime;


    // Start is called before the first frame update
    void Start()
    {
        slime = GetComponent<slime>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // slime.MovementSlime();
    }
}
