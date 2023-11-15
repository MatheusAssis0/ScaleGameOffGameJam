using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthBar : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private Rigidbody ballRb;
    private MoveBall script;
    public enum StrengthZone { Red, Yellow, Green };
    public StrengthZone strengthZone;

    private void Start()
    {
        script = FindObjectOfType<MoveBall>();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch(strengthZone)
        {
            case StrengthZone.Green:
                ball.transform.localScale *= 0.75f;
                ballRb.mass = 1;
                script.aditionalForce = 1.75f;
                break;
            case StrengthZone.Yellow:
                script.aditionalForce = 1.25f;
                break;
            case StrengthZone.Red:
                ball.transform.localScale *= 1.5f;
                ballRb.mass = 5;
                script.aditionalForce = 0.75f;
                break;
        }
    }
}
