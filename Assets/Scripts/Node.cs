using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public enum NodeStatus {Occupied, Breakable, Empty, Danger, Priority}

    private NodeStatus status;


    // Update is called once per frame
    void Update()
    {
        
    }

    public void setStatus(NodeStatus givenStatus)
    {
        status = givenStatus;
    }
    
}
