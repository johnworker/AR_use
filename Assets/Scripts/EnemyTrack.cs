using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrack : MonoBehaviour
{
    public float speed;
    public float radius;

    public GameObject target;

    public void Start()
    {
    }

    void Update()
    {
        // ��V�ؼ�
        float dx = target.transform.position.x - this.transform.position.x;
        float dy = target.transform.position.y - this.transform.position.y;
        float rotationZ = Mathf.Atan2(dy, dx) * 180 / Mathf.PI;
    }
}
