using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    private PhotonView view;
    private Camera cam;
    GameObject SelectedObject;
    bool isDragging;
    UnityEngine.AI.NavMeshAgent myNavMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        cam = LevelController.Instance.mainCamera;
        myNavMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        isDragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

        if (view.IsMine)
        {
            if (Input.GetMouseButtonDown(0))
            {

                MoveToRayPoint(ray);
            }
            if (isDragging == true)
            {
                //SelectedObject.transform.position = ;
            }
        }
        
    }



    void MoveToRayPoint(Ray ray)
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Player")
            {
                Debug.Log("name:" + hit.transform.name);
                SelectedObject = hit.transform.gameObject;
                isDragging = true;
            }
            myNavMeshAgent.SetDestination(hit.point);
        }
        
    }

    void MoveByDrag()
    {
        
    }
}
