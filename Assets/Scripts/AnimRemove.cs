using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimRemove : MonoBehaviour
{
    private void Update()
    {
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
}
