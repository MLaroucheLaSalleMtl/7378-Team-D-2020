//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class pushpull : MonoBehaviour
//{
//    public float pushforce;
//    public Rigidbody rb;
//    public float 
//  //  CharacterController charactercollider;
//    // Start is called before the first frame update
//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//        rb.mass = 
//       // charactercollider = gameObject.GetComponent<CharacterController>();
//    }

//    // Update is called once per frame
//    void Update()
//    {

//        if (Input.GetButton("Push"))
//        {
//            pushforce = 10f;
//        }
//        else
//        {
//            pushforce = 0f;
//        }

//    }
//     void OnControllerColliderHit(ControllerColliderHit hit)
//    {
//        if (pushforce == 10f)
//        {
//            Rigidbody rigid = hit.collider.attachedRigidbody;
//            if (rigid != null && rigid.isKinematic == false)
//            {

//                Vector3 pushdirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
//                rigid.velocity = pushdirection * pushforce;


//            }
//        }

//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushpull : MonoBehaviour
{

    Rigidbody m_Rigidbody;
    Vector3 m_XAxis;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        //This locks the RigidBody so that it does not move or rotate in the x axis (can be seen in Inspector).
        m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
        //Set up vector for moving the Rigidbody in the x axis
        m_XAxis = new Vector3(5, 0, 0);
    }

    void Update()
    {
        //Press space to remove the constraints on the RigidBody
        if (Input.GetButton("Push")) 
        {
            //Remove all constraints
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }
        if(Input.GetButtonUp("Push"))
        {
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }

        //Press the right arrow key to move positively in the x axis if the constraints are removed
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //If the constraints are removed, the Rigidbody moves along the x axis
            //If the constraints are there, no movement occurs
            m_Rigidbody.velocity = m_XAxis;
        }

        //Press the left arrow key to move negatively in the x axis if the constraints are removed
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            m_Rigidbody.velocity = -m_XAxis;
        }
    }
}

