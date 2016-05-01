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

    public void StartBulletMovement(GameObject bullet, Vector2 a, Vector2 b, float bulletDuration, float m_bulletDestroyYCoord)
    {
        StartCoroutine(BulletMovementActions(bullet, a, b, bulletDuration, m_bulletDestroyYCoord));
    }

    public IEnumerator BulletMovementActions(GameObject bullet, Vector2 a, Vector2 b, float bulletDuration, float m_bulletDestroyYCoord)
    {
        float step = (bulletDuration / (a - b).magnitude) * Time.fixedDeltaTime;
        float t = 0;
        while (t <= 1.0f)
        {
            t += step;
            bullet.transform.position = Vector2.Lerp(a, b, t);
            yield return new WaitForFixedUpdate();
        }
        bullet.transform.position = b;

        if (bullet.transform.position.y == m_bulletDestroyYCoord)
        {
            bullet.GetComponent<BulletHandler>().ResetBullet();
        }
    }
}
