using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationSetter : MonoBehaviour
{
    [SerializeField] private navController[] characters;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.Log(ray.direction);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                //Debug.Log(hit.collider.transform.position);
                foreach (var character in characters) 
                {
                    character.SetTarget(hit.point);
                }
            }
        }
    }
}
