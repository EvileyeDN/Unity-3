using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBackground : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 startpos;
    private float repeatwidth;
    void Start()
    {
        startpos = transform.position;
        repeatwidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startpos.x - repeatwidth)
        {
            transform.position = startpos;
        }
    }
}
