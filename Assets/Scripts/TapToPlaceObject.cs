using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;


// �Ĥ@���M�Φ��}���ɲK�[���w������ ARRaycastManager
[RequireComponent(typeof(ARRaycastManager))]
public class TapToPlaceObject : MonoBehaviour
{
    [Header("�Q��m������")]
    public GameObject tapObject;

    /// <summary>
    /// AR �g�u�I���޲z��
    /// </summary>
    private ARRaycastManager arRaycast;

    /// <summary>
    /// AR �g�u�I���쪺���� (���X �M��)
    /// </summary>
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    /// <summary>
    /// �I���y��
    /// </summary>
    private Vector2 mousePos;


    private void Start()
    {
        // ���o AR �g�u�޲z����
        arRaycast = GetComponent<ARRaycastManager>();
    }

    private void Update()
    {
        TapObject();
    }

    /// <summary>
    /// �I����m����
    /// </summary>
    private void TapObject()
    {
        // �P�_�O�_�I��
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // �x�s�I���y��
            mousePos = Input.mousePosition;
            // AR �g�u�I��  (Raycast���T�Ӯy�и�T(�Q�n���w���y��, �I���᪺��T, �g�u�l�ܪ�����))
            if (arRaycast.Raycast(mousePos, hits, TrackableType.PlaneWithinPolygon))
            {
                // �ͦ�����b�I�����y��
                Pose pose = hits[0].pose;

                GameObject temp = Instantiate(tapObject, pose.position, pose.rotation);
                Vector3 look = transform.position;
                look.y = temp.transform.position.y;
                temp.transform.LookAt(look);
            }
        }
    }
}
