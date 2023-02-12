using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followingtarget : MonoBehaviour
{
    public Transform PlayerTransform;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - PlayerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = PlayerTransform.position + offset;
    }
}
