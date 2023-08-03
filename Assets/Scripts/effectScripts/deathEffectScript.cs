using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathEffectScript : MonoBehaviour
{
    [SerializeField]
    float animTime;

    private void Start()
    {
        Destroy(gameObject, animTime);
    }

}
