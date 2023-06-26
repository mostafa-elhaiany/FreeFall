using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBag : MonoBehaviour
{
    [SerializeField] float degrees;

    // Start is called before the first frame update
    void Start()
    {
        degrees = Random.Range(10, 30);
        if(Random.Range(0.0001f, 0.999f)>0.5f)
        {
            degrees *= -1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += Vector3.forward * degrees * Time.deltaTime;
    }
}
