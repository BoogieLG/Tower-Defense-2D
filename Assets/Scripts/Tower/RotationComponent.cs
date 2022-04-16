using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationComponent : MonoBehaviour
{
    public void lookAtEnemy(Transform enemyTransfrom)
    {

        transform.LookAt(enemyTransfrom);
    }
}
