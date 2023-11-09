using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    private bool canMove, canMoveAgain;
    private Rigidbody rb;
    public float strength;
    [SerializeField] private GameObject arrow, ball;

    private void Start()
    {
        canMoveAgain = true;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        UseCheck();
    }

    IEnumerator KickBall()
    {
        yield return new WaitForSeconds(5);

        Vector3 force = new Vector3(strength, 0, 0);
        rb.AddForce(transform.forward * strength, ForceMode.Impulse);
    }

    private void UseCheck()
    {
        if (!canMove && Input.GetKeyDown(KeyCode.Space))
        {
            canMove = true;
        }
        else if (canMove && canMoveAgain && Input.GetKeyDown(KeyCode.Space))
        {
            float angleX = arrow.transform.eulerAngles.z;
            ball.transform.rotation = Quaternion.Euler(angleX - 90, 90, 0);
            StartCoroutine(KickBall());
            canMove = false;
            canMoveAgain = false;
        }
    }
}
