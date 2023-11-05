using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class projectileBehavior : MonoBehaviour
{
    [SerializeField][Tooltip("Adjusts the bobbing rate of the projectile.")] private float frequency = 5f;
    [SerializeField] private float amplitude = 3f;
    [SerializeField] private float endPoint = Mathf.PI;
    [SerializeField] private float selfCollisionBuffer = 0.5f;
    [SerializeField] private float explosionExpandTimer = 0.5f;
    [SerializeField] private float explosionDamage = 200;
    GameObject substitudebomb;
    public bool explode = false;


    arcBomb arc;
    private float startTime;
    public int signForWave = 1;
  
    // Start is called before the first frame update
    void Start()
    {
        startTime = 0f;
        arc = FindObjectOfType<arcBomb>().GetComponent<arcBomb>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (explode == false)
        {


            gameObject.transform.localPosition = new Vector3(signForWave * amplitude * (Mathf.Sin(stopWave(frequency * startTime, endPoint))), 0, 0);
            startTime += Time.fixedDeltaTime;
            //Debug.Log(startTime);
            List<GameObject> bombList = arc.returnBombList();
            Debug.Log(bombList.Count);

            if (bombList.Count % 2 == 0)
            {
                if (startTime > selfCollisionBuffer && transform.localPosition == Vector3.zero)
                {
                    bombExplode();
                }
            }
            if (startTime > selfCollisionBuffer && transform.localPosition == Vector3.zero)
            {
                transform.localScale -= new Vector3(Time.fixedDeltaTime, Time.fixedDeltaTime, 0);
            }
            
        }
        else
        {
            if (explode && explosionExpandTimer > 0)
            {

                explosionExpandTimer -= Time.fixedDeltaTime;
                transform.localScale += new Vector3(2 * Time.fixedDeltaTime, 2 * Time.fixedDeltaTime, 0);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void determineSign(int projIndex)
    {
        if(projIndex == 0 || projIndex%2==0)
        {
            signForWave = 1;
            //Debug.Log("Yes");
        }
        else
        {
            signForWave = -1;
            //Debug.Log("No");
        }
    }
    public float returnExplodeDamage()
    {
        return explosionDamage;
    }
   
    private float stopWave(float waveTime, float endTime)
    {
        if(waveTime <= endTime)
        {
            return waveTime;
        }
        else
        {
            return 0;
        }
    }
    private void bombExplode()
    {
        explode = true;
        substitudebomb = Instantiate(gameObject, gameObject.transform.position, Quaternion.identity);
        substitudebomb.GetComponent<projectileBehavior>().explode = true;
        //substitudebomb.AddComponent<arcBombProj>();
        Destroy(gameObject);
    }
}

    
