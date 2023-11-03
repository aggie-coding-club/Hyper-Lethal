using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class energyShotgunProj : Projectile
{
    EdgeCollider2D edgeCol;
    [SerializeField] float pushMagnitude = 2f;
    [SerializeField] float increaaseMagnitude = 2f;
    List<Vector2> points = new List<Vector2>();
    private void Start()
    {
        edgeCol = GetComponent<EdgeCollider2D>();
        setCollider();
    }
    public override void FixedUpdate()
    {
        updateProjectile();
        expandCollider();
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //print(collision.transform.rotation.normalized);
        float xNormal = Mathf.Cos((transform.eulerAngles.z + 90) * Mathf.Deg2Rad);
        float yNormal = Mathf.Sin((transform.eulerAngles.z+90) * Mathf.Deg2Rad);
        Vector2 normalVect = new Vector2(xNormal, yNormal);
        //print(normalVect);
        collision.GetComponent<Rigidbody2D>().AddForce(Time.deltaTime * normalVect * pushMagnitude);
    }

    private void setCollider()
    {
        points.Add(new Vector2(0, 0));
        points.Add(new Vector2(-0.3f, 0.5f));
        points.Add(new Vector2(0.3f, 0.5f));
        points.Add(new Vector2(0, 0));
    }
    private void expandCollider()
    {
       // print(points[1]);
        points[1] += new Vector2(0, Time.deltaTime*increaaseMagnitude);
        points[2] = points[2] + new Vector2(0, Time.deltaTime*increaaseMagnitude);
        edgeCol.SetPoints(points);
    }
}
