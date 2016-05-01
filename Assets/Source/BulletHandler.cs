using UnityEngine;
using System.Collections;

public class BulletHandler : MonoBehaviour
{
    GameObject m_parentShip;
    public void SetParent(GameObject parent)
    {
        m_parentShip = parent;
    }

    public void ResetBullet()
    {
        if (m_parentShip != null)
        {
            transform.SetParent(m_parentShip.transform);
        }
        transform.localPosition = Vector2.zero;
        gameObject.SetActive(false);
    }
}
