using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    Rigidbody rigi;

    // Use this for initialization
    void Start()
    {
        rigi = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        

        rigi.AddRelativeForce(Camera.main.transform.localPosition * 20, ForceMode.Impulse);
        Destroy(gameObject, 3f);
    }
}
