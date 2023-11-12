using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    private bool canMove, canMoveAgain;
    private Rigidbody rb;
    public float strength;
    [SerializeField] private float slowSpeed, timeToSlow;
    [SerializeField] private GameObject arrow, ball;
    private GameManager gameManager;

    private void Start()
    {
        canMoveAgain = true;
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
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
        StartCoroutine(SlowDownPlayer());
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

    IEnumerator SlowDownPlayer()
    {
        Vector3 slow = new Vector3(slowSpeed, 0, 0);
        if(rb.velocity.x > 0)
        {
            rb.velocity += slow;
        }
        else if(rb.velocity.x < 0)
        {
            rb.velocity = Vector3.zero;
        }

        yield return new WaitForSeconds(timeToSlow);

        if (rb.velocity.x == 0)
        {
            gameManager.gameOver = true;
        }

        StartCoroutine(SlowDownPlayer());
    }
}
