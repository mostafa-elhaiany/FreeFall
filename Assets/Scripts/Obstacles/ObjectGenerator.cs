using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] prefablist; //items to generate (randomized)
    [SerializeField] float generate_after = 5; // wait time before generating objects
    [SerializeField] Vector2 bounds; // x-axis range for item generation 
    [SerializeField] Vector2 time_range; // range of time for item generation 
    [SerializeField] Vector2 generation_range; //range of number of item generated


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(5f);
        StartCoroutine(generate());
    }

    IEnumerator generate()
    {
        float timer = Random.Range(time_range.x, time_range.y);
        yield return new WaitForSeconds(timer);
        if (prefablist.Length != 0)
        {
            int object_idx = 0;
            if (prefablist.Length > 1)
            {
                object_idx = Random.Range(0, prefablist.Length);
            }
            int num_generated = Random.Range((int)generation_range.x, (int)generation_range.y);
            float x_loc;
            for(int i=0; i < num_generated; i++)
            {
                x_loc = Random.Range(bounds.x, bounds.y);
                Instantiate(prefablist[object_idx], new Vector3(x_loc, transform.position.y, 0), Quaternion.identity);
            }

            StartCoroutine(generate());
        }
    }


}
