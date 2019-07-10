using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float horizontal;
    private float vertical;

    private Rigidbody body;

    public float force = 1;

    // Start is called before the first frame update
    void Start()
    {

        body = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        body.AddForce(new Vector3(horizontal * force, 0, vertical * force));
    }
}
