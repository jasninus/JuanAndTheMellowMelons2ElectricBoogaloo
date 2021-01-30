using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    GameObject instancedAimer;
    [SerializeField] private GameObject aimer;
    public string aimerName;

    static public Vector3 AimerPos()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {

            //Debug.Log(hit.point);
            return hit.point;
        }
        else
        {
            return Camera.main.ScreenToWorldPoint(mousePos);
        }
    }

    private bool AimerFound()
    {
        if (GameObject.Find(aimerName))
        {
            return true;
        }
        return false;
    }

    private void SpawnAimer(Vector3 aimingPos)
    {
        if (!AimerFound() && Input.GetMouseButtonDown(1))
        {
            instancedAimer = (GameObject)Instantiate(aimer, aimingPos, Quaternion.identity);
            //Debug.Log("Aimer spawned");
        }
    }

    private void DestoryAimer(GameObject instancedAimer)
    {
        if (Input.GetMouseButtonDown(2))
        {
                Destroy(instancedAimer);
                //Debug.Log("Destroyed");
        }
    }

    private void MoveAimer(Vector3 aimingPos, GameObject instancedAimer) => instancedAimer.transform.localPosition = aimingPos;

    //Call this function to run the aimer
    public void PlayerAim()
    {
        Vector3 aimingPos = AimerPos();
        SpawnAimer(aimingPos);
        if (AimerFound()) MoveAimer(aimingPos, instancedAimer);
        if (AimerFound()) DestoryAimer(instancedAimer);
    }

    private void Update()
    {
        PlayerAim();
    }

}
