using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class energyShotgunProj : Projectile
{
    EdgeCollider2D edgeCol;
    [SerializeField] float pushMagnitude = 2f;
    [SerializeField] float increaseMagnitude = 2f;
    List<Vector2> points = new List<Vector2>();

    public float PushMagnitude { get => pushMagnitude; set => pushMagnitude = value; }
    public float IncreaseMagnitude { get => increaseMagnitude; set => increaseMagnitude = value; }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print(collision.transform.rotation.normalized);
        float xNormal = Mathf.Cos((transform.eulerAngles.z + 90) * Mathf.Deg2Rad);
        float yNormal = Mathf.Sin((transform.eulerAngles.z+90) * Mathf.Deg2Rad);
        Vector2 normalVect = new Vector2(xNormal, yNormal);
        collision.GetComponent<Rigidbody2D>().AddForce(normalVect * pushMagnitude);
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
        points[1] += new Vector2(0, Time.deltaTime*increaseMagnitude);
        points[2] = points[2] + new Vector2(0, Time.deltaTime*increaseMagnitude);
        edgeCol.SetPoints(points);
    }
}
