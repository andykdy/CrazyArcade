using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

enum BotState {Moving, Idle}
public class AIManager : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject nodePrefab;
    private GameObject[,] mapNodes;
    private BotState mystate;
    private GameObject currentNode;
    private GameObject AIPlayer;
    
    private void Start()
    {
        AIPlayer = GameObject.Find("Enemy");
        mystate = BotState.Idle;
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);
        mapNodes = new GameObject[bounds.size.x, bounds.size.y];
        
        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile == null)
                {
                    GameObject node = Instantiate(nodePrefab, new Vector3(x - 5.5f, 3.5f - y, 0), Quaternion.identity, gameObject.transform);
                    node.GetComponent<Node>().setStatus(Node.NodeStatus.Empty);
                    mapNodes[x, y] = node;
                }
                else if (tile.name == "Crate")
                {
                    GameObject node = Instantiate(nodePrefab, new Vector3(x - 5.5f, 3.5f - y, 0), Quaternion.identity, gameObject.transform);
                    node.GetComponent<Node>().setStatus(Node.NodeStatus.Breakable);
                    mapNodes[x, y] = node;
                }
            }
        }
        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                GameObject currNode =  mapNodes[x, y];
                if (currNode)
                {
                    if (x + 1 < bounds.size.x)
                    {
                        if (mapNodes[x + 1, y])
                        {
                            currNode.GetComponent<Node>().addAdjacent(mapNodes[x + 1,y]);
                        }
                    }
                    if (0 <= x - 1)
                    {
                        if (mapNodes[x - 1, y])
                        {
                            currNode.GetComponent<Node>().addAdjacent(mapNodes[x - 1, y]);
                        }
                    }
                    if (y + 1 < bounds.size.y)
                    {
                        if (mapNodes[x, y + 1])
                        {
                            currNode.GetComponent<Node>().addAdjacent(mapNodes[x, y + 1]);
                        }
                    }
                    if (0 <= y - 1)
                    {
                        if (mapNodes[x, y - 1])
                        {
                            currNode.GetComponent<Node>().addAdjacent(mapNodes[x, y - 1]);
                        }
                    }
                }
            }
        }
    }
    private void FixedUpdate()
    {
        if (mystate == BotState.Idle){
            currentNode = worldToNode(AIPlayer.transform.position);
            //AIPlayer.GetComponent<EnemyController>().setVelocity(new Vector2(AIPlayer.transform.position.x,AIPlayer.transform.position.y) - new Vector2(2.5f,-3.5f));
            List<GameObject> adjNode = currentNode.GetComponent<Node>().adjacentNodes;
            List<GameObject> availableNode = new List<GameObject>();
            foreach (var t in adjNode){
                if (t.GetComponent<Node>().getStatus() == Node.NodeStatus.Empty){
                    availableNode.Add(t);
                }
            }
            Debug.Log(availableNode.Count);
            AIPlayer.GetComponent<EnemyController>().setVelocity((Vector2) AIPlayer.transform.position - (Vector2)availableNode[Random.Range(0, availableNode.Count - 1)].transform.position);
        }
    }
    // Vector2(2.5,-3.5)

    private GameObject worldToNode(Vector2 worldCord)
    {
        return mapNodes[6 + (int)worldCord.x, 4 - (int)worldCord.y];
    }

}
