using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [Header("GameObject")]
    // Start is called before the first frame update

    public Transform TargetObject;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        transform.position = new Vector3(TargetObject.position.x, TargetObject.position.y, -10);

    // TargetObject.position.z
    // catch (Exception error) {
    //     Debug.LogError(error);
    // }
        
    }
}
