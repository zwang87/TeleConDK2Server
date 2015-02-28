using UnityEngine;
using System.Collections;

public class ObjectSync : MonoBehaviour {
    public Vector3 objPos;
    public Vector3 objOrien;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(!NetworkConnection.connected)
        {
            return;
        }

       

        networkView.RPC("sendObjectTransform", RPCMode.All, transform.position, transform.eulerAngles);

        if (networkView.isMine)
        {
            transform.position = objPos;
            transform.eulerAngles = objOrien;
        }
        else {
            transform.position = objPos;
            transform.eulerAngles = objOrien;
        }
	}

    [RPC]
    public void sendObjectTransform(Vector3 position, Vector3 eulerAngles)
    {
        objPos = position;
        objOrien = eulerAngles;
    }
}
