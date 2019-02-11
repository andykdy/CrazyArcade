using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerChar;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerChar, new Vector3(-3.4f, 2.5f, 0f), Quaternion.identity);
    }

}
