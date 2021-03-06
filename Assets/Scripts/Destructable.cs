using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject destroyedVersion;
    private void OnTriggerEnter(Collider other)
    {
        if (other is CapsuleCollider)
        {
            BreakBox();
        }
    }
    public void BreakBox()
    {
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
