using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseDirection : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private float speed, bounds;
    public bool toLeft, toRight, canStop;

    private void Start()
    {
        toLeft = false;
        toRight = true;
        canStop = false;
    }

    private void Update()
    {
        RotateArrow();
        UseCheck();
    }

    private void RotateArrow()
    {
        Quaternion targetRight = Quaternion.Euler(0, 0, bounds);
        Quaternion targetLeft = Quaternion.Euler(0, 0, 0);

        if (toRight && !toLeft)
        {
            arrow.transform.localRotation = Quaternion.Slerp(arrow.transform.rotation, targetRight, speed * Time.deltaTime); 
            if (arrow.transform.rotation == targetRight)
            {
                toLeft = true;
                toRight = false;
            }
        }
        else if (toLeft && !toRight)
        {
            arrow.transform.localRotation = Quaternion.Slerp(arrow.transform.rotation, targetLeft, speed * Time.deltaTime);
            if (arrow.transform.rotation == targetLeft)
            {
                toLeft = false;
                toRight = true;
            }
        }
    }

    private void UseCheck()
    {
        if (!canStop && Input.GetKeyDown(KeyCode.Space))
        {
            canStop = true;
        }
        else if (canStop && Input.GetKeyDown(KeyCode.Space))
        {
            toLeft = false;
            toRight = false;
        }
    }
}
