using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public float m_DampTime = 0.2f;                 
    public float m_ScreenEdgeBuffer = 10f;           
    public float m_MinSize = 100f;                  
    public Transform m_Target; 


    private Camera m_Camera;                        
    private Vector3 m_MoveVelocity;                 
    private Vector3 m_DesiredPosition;              


    private void Awake()
    {
        m_Camera = GetComponentInChildren<Camera>();
    }


    private void FixedUpdate()
    {
        // We just want the camera to move but not zoom
        Move();
    }


    private void Move()
    {
        FindAveragePosition();

        transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
    }


    private void FindAveragePosition()
    {
        Vector3 targetPosition = new Vector3();

        targetPosition.x = m_Target.position.x + 6f;
        targetPosition.y = 4f;
        // targetPosition.y = m_Target.position.y;
        targetPosition.z = -16f;
        // targetPosition.y = m_Target.position.z;

        m_DesiredPosition = targetPosition;
    }
}
