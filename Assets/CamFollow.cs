using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public GameObject target;
    float offset;
    public float damp = 4;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position.z - target.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        var targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z + offset);
        var thisPosition = transform.position;

        Debug.Log(offset);


        transform.position = Vector3.Lerp(thisPosition, targetPosition, Time.deltaTime * damp);

        //var x = Mathf.Abs(targetPosition.x - thisPosition.x) < damp ? thisPosition.x : Mathf.Lerp(thisPosition.x, targetPosition.x, Time.deltaTime) ;

        //transform.position = new Vector3(x, targetPosition.y, targetPosition.z + offset);
    }
}
