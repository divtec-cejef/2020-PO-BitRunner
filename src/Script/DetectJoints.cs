using System.Collections;
using System.Collections.Specialized;
using UnityEngine;
using Windows.Kinect;

public class DetectJoints : MonoBehaviour
{

    public GameObject BodySrcManager;
    public JointType TrackedJoint;
    private BodySourceManager bodyManager;
    private Body[] bodies;

    // Start is called before the first frame update
    void Start()
    {
        if (BodySrcManager == null)
        {
            Debug.Log("Assignez un objet avec le gestionnaire de source du corps");
        }
        else
        {
            bodyManager = BodySrcManager.GetComponent<BodySourceManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bodyManager == null)
        {
            return;
        }
        bodies = bodyManager.GetData();

        if (bodies == null)
        {
            return;
        }
        foreach (var body in bodies)
        {
            if (body == null)
            {
                continue;
            }
            if (body.IsTracked)
            {
                var position = body.Joints[TrackedJoint].Position;

                gameObject.transform.position = new Vector3(position.X * 10, position.Y * 10);
            }
        }

    }
}