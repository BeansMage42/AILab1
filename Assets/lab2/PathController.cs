using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class PathController : MonoBehaviour
{

    [SerializeField]
    public PathManager pathManager;

    private Animator anim;
    bool isWalking;

    List<Waypoint> thePath;
    Waypoint target;

    public float MoveSpeed;
    public float RotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        thePath = pathManager.GetPath();
        if(thePath != null && thePath.Count > 0)
        {
            target = thePath[0];
            Debug.Log("added target");
        }
        anim = GetComponent<Animator>();
        isWalking = false;
        anim.SetBool("isWalking", isWalking);
    }
    
    

    void rotateTowardsTarget()
    {
        float stepSize = RotateSpeed * Time.deltaTime;

        Vector3 targetDir = target.GetPos() - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, stepSize, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    void moveForward()
    {
        float stepSize = Time.deltaTime * MoveSpeed;
        float distanceToTarget = Vector3.Distance(transform.position, target.pos);
        if(distanceToTarget < stepSize)
        {
            return;
        }
        Vector3 moveDir = Vector3.forward;
        transform.Translate(moveDir * stepSize);

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            isWalking = !isWalking;
            anim.SetBool("isWalking", isWalking);
        }
        if (isWalking)
        {
            rotateTowardsTarget();
            moveForward();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        target = pathManager.GetNextTarget();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if(collision.gameObject.tag == "wall")
        {
            isWalking = !isWalking;
            anim.SetBool("isWalking", isWalking);
        }
    }
}
