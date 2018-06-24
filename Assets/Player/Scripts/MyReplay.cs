using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyReplay : MonoBehaviour {
    private const int bufferFrames = 100;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
    private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Record();
    }

    private void Record()
    {
        rigidbody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;

        keyFrames[frame] = new MyKeyFrame(Time.time, transform.position, transform.rotation);
    }

    private void PlayBack()
    {
        rigidbody.isKinematic = true;
        int frame = Time.frameCount % bufferFrames;

        transform.position = keyFrames[frame].pos;
        transform.rotation = keyFrames[frame].rot;
    }
}

public class MyKeyFrame
{
    public float time;
    public Vector3 pos;
    public Quaternion rot;

    public MyKeyFrame(float time, Vector3 pos, Quaternion rot)
    {
        this.time = time;
        this.pos = pos;
        this.rot = rot;
    }
}
