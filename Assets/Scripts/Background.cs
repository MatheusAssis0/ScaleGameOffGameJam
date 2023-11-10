using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private GameObject bg;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            Vector3 offset = new Vector3(39.39f, 0, 0);
            Instantiate(bg, this.gameObject.transform.position + offset, Quaternion.identity);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            Destroy(this.gameObject);
        }
    }
}
