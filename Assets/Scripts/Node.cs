using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public enum NodeStatus {Occupied, Breakable, Empty, Danger, Priority};
    public List<GameObject> adjacentNodes;
    public float counter;

    private NodeStatus status;

    private void Start()
    {
        adjacentNodes = new List<GameObject>();
    }

    public void setStatus(NodeStatus givenStatus)
    {
        status = givenStatus;
    }
    public NodeStatus getStatus()
    {
        return status;
    }

    public void addAdjacent(GameObject node)
    {
        adjacentNodes.Add(node);
    }

//    public override string ToString()
//    {
//        return (string)gameObject.transform.position.x + gameObject.transform.position.y + counter;
//    }
}
