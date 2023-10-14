using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class projectileBehavior : MonoBehaviour
{
    [SerializeField][Tooltip("Adjusts the bobbing rate of the projectile.")] private float frequency = 5f;
    [SerializeField] private float amplitude = 3f;
    private float startTime;
  
    // Start is called before the first frame update
    void Start()
    {
        startTime = 0f;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        gameObject.transform.localPosition = new Vector3(amplitude * Mathf.Sin(frequency * startTime), 0, 0);
        startTime += Time.fixedDeltaTime;
    }
   

}

    
