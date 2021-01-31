/*using UnityEngine;
using System.Collections;

public class CameraSwap : MonoBehaviour
{



    public Camera camera1;
    public Camera cameraCombat;
    //public string whichCamera = "2";





    // Use this for initialization
    void Start()
    {
        camera1.GetComponent<Camera>().enabled = !camera1.GetComponent<Camera>().enabled;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            //print("i'm in 1");
            camera1.GetComponent<Camera>().enabled = true;
            cameraCombat.GetComponent<Camera>().enabled = false;
        }


        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            //print("i'm in 2");
            camera1.GetComponent<Camera>().enabled = false;
            cameraCombat.GetComponent<Camera>().enabled = true;
        }
    }
}*/