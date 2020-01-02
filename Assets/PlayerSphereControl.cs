using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerSphereControl : MonoBehaviour
{
    Rigidbody body;
    public float force = 10;

    public Transform initialPosition;
    public Transform finalPosition;
    public float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(AutoMovePlayer());

        body = GetComponent<Rigidbody>();

        transform.position = initialPosition.position;
    }

    IEnumerator AutoMovePlayer()
    {
        while (t <= 1)
        {
            t += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    // Update is called once per frame
    void Update()
    {

        //float newT = (finalPosition.position - transform.position).magnitude / 10;
        //transform.position = Vector3.Lerp(transform.position, finalPosition.position, Time.deltaTime / newT);
    }

    private void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var forward = Input.GetAxis("Forward");
        var tilt = Input.GetAxis("Tilt");

        transform.rotation *= Quaternion.Euler(0, tilt, 0);

        body.AddForce(new Vector3(0, vertical) * force , ForceMode.Impulse);

        body.AddForce(transform.right * horizontal * force);

        body.AddForce(transform.forward * forward * force);
    }
}
