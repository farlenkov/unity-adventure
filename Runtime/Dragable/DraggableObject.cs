using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAdventure
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Rigidbody))]
    public class DraggableObject : MonoBehaviour
    {
        [field: SerializeField]
        public Rigidbody Rigidbody { get; private set; }

        [field: SerializeField]
        public DraggableType Type { get; private set; }

        //[SerializeField]
        //Transform targetPoint;

        //[SerializeField]
        //float followSpeed;

        //void FixedUpdate()
        //{
        //    //rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, Vector3.zero, 0.5f);
        //    //rigidbody.angularVelocity = Vector3.Lerp(rigidbody.angularVelocity, Vector3.zero, 0.5f);

        //    var parentPos = targetPoint.position;
        //    var parentRot = targetPoint.rotation;

        //    //rigidbody.Move(parentPos, parentRot);

        //    rigidbody.Move(
        //        Vector3.Lerp(rigidbody.position, parentPos, Time.fixedDeltaTime * followSpeed),
        //        Quaternion.Lerp(rigidbody.rotation, parentRot, Time.fixedDeltaTime * followSpeed));
        //}

        //void Update()
        //{
        //rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, Vector3.zero, 0.5f);
        //rigidbody.angularVelocity = Vector3.Lerp(rigidbody.angularVelocity, Vector3.zero, 0.5f);

        //var parentPos = targetPoint.position;
        //var parentRot = targetPoint.rotation;

        //rigidbody.Move(parentPos, parentRot);

        //    rigidbody.Move(
        //        Vector3.Lerp(rigidbody.position, parentPos, Time.deltaTime * followSpeed),
        //        Quaternion.Lerp(rigidbody.rotation, parentRot, Time.deltaTime * followSpeed));
        //}
    }
}
