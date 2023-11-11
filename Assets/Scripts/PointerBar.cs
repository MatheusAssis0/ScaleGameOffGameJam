using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerBar : MonoBehaviour
{
    [SerializeField] private GameObject pointer;
    [SerializeField] private float speed, boundsLeft, boundsRight;
    [SerializeField] private GameObject colliders;
    public bool toLeft, toRight;
    

    private void Start()
    {
        toLeft = false;
        toRight = true;
    }

    private void Update()
    {
        MoveThePointer();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            toLeft = false;
            toRight = false;
            colliders.SetActive(true);
        }
    }

    private void MoveThePointer()
    {
        Vector3 targetRight = new Vector3(boundsRight, pointer.transform.position.y, pointer.transform.position.z);
        Vector3 targetLeft = new Vector3(boundsLeft, pointer.transform.position.y, pointer.transform.position.z);

        if (toRight && !toLeft)
        {
            pointer.transform.position = Vector3.LerpUnclamped(pointer.transform.position, targetRight, speed * Time.deltaTime);
            if (Vector3.Distance(pointer.transform.position, targetRight) <= 0.001f)
            {
                toLeft = true;
                toRight = false;
            }
        }
        else if(toLeft && !toRight)
        {
            pointer.transform.position = Vector3.LerpUnclamped(pointer.transform.position, targetLeft, speed * Time.deltaTime);
            if (Vector3.Distance(pointer.transform.position, targetLeft) <= 0.001f)
            {
                toLeft = false;
                toRight = true;
            }
        }
    }
}
