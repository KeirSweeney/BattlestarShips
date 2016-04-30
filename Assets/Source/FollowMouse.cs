using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour
{
    private Vector2 m_mousePosition;
    private Camera m_mainCamera;

    //use of floats rather than Vector2's as Vector.x function is another process.
    private float m_minMouseY;
    private float m_maxMouseY;
    private float m_minMouseX;
    private float m_maxMouseX;

    private const float SPEED = 1.0f;


    void Awake()
    {
        m_mousePosition = Vector2.zero;
        m_mainCamera = Camera.main;

        //setting minMouse positions
        Vector2 mousePos = m_mainCamera.ScreenToWorldPoint(new Vector2(0, 0));
        m_minMouseX = mousePos.x;
        m_minMouseY = mousePos.y;

        //setting maxMouse positions
        mousePos = m_mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height / 2));
        m_maxMouseX = mousePos.x;
        m_maxMouseY = mousePos.y;
    }

        // Use this for initialization
        void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        m_mousePosition = m_mainCamera.ScreenToWorldPoint(Input.mousePosition);
        m_mousePosition.y = Mathf.Clamp(m_mousePosition.y, m_minMouseY, m_maxMouseY);
        m_mousePosition.x = Mathf.Clamp(m_mousePosition.x, m_minMouseX, m_maxMouseX);

        transform.position = Vector2.Lerp(transform.position, m_mousePosition, Time.deltaTime * SPEED);
    }
}
