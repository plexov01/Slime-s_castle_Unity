using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeData : MonoBehaviour
{
    public static string currentLevel;
    public static ArrayList FinishedLevelTime = new ArrayList();
    public static int NumberOfLevel=1;
    public static List<Vector3> PointOfResurrect=new List<Vector3>();

// List<Vector3> tpPos = new List<Vector3>();

    // Start is called before the first frame update
    // void Start()
    // {
    //     print(FinishedLevelTime.Count +"+");
        
    //     // if(FinishedLevelTime.)
        
    // }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }

    // Функционал для поиска неактивных объектов иерархии
    public static class GameObjectExtension {
        public static Object Find(string name, System.Type type) {
            Object[] objects = Resources.FindObjectsOfTypeAll(type);
            foreach(var obj in objects) {
                if(obj.name == name) {
                    return obj;
                }
            }
            return null;
        }

        public static GameObject Find(string name) {
            return Find(name, typeof(GameObject)) as GameObject;
        }
    }
}
