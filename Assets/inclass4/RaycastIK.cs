using DitzelGames.FastIK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastIK : MonoBehaviour
{
    private float maxDist = 1f;
    private FastIKFabric ik;
    private GameObject target;
   
    private void Start()
    {
        ik = GetComponent<FastIKFabric>();
        target = ik.Target.gameObject;
    }
    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -Vector3.up, out hit, maxDist))
        {
            Debug.Log(hit.collider.name);
            ik.enabled = true;
            Vector3 go = hit.point;
            if (go != null)
            {
                ik.Target.transform.position = go;

            }
        }


    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ledge")
        {
            Debug.Log("hit");
            Mesh mesh = collision.gameObject.GetComponent<Mesh>();
            Vector3[] vertices = mesh.vertices;
            target.transform.position = vertices[0];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ledge")
        {
            Debug.Log("hit");
            Mesh mesh = other.gameObject.GetComponent<Mesh>();
            Vector3[] vertices = mesh.vertices;
            target.transform.position = vertices[0];
        }
    }*/
}
