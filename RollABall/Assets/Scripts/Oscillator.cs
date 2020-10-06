using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
  float timeCounter = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;

        float x = 0;
        float y = Mathf.Cos (timeCounter);
        float z = Mathf.Sin (timeCounter);

        transform.position = new Vector3(x,y,z);
    }
}
