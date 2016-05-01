using UnityEngine;
using System.Collections;

public class BulletShooting : MonoBehaviour
{
    [SerializeField] private GameObject m_bulletPrefab;
    [SerializeField] private float m_minIntevalFireRate;
    [SerializeField] private float m_maxIntevalFireRate;
    [SerializeField] private float m_bulletSpeed;

    private GameObject[] m_bullets;
    private const int MAXBULLETS = 100;

    private Camera camera;

    private Vector2 m_screenBoudsMax;
    private Bounds m_bulletPrefabBounds;
    private float m_bulletDestroyYCoord;

    void Awake()
    {
        InitBullets();
    }

    void InitBullets()
    {
        m_bullets = new GameObject[MAXBULLETS];

        for (int i = 0; i < MAXBULLETS; i++)
        {
            m_bullets[i] = Instantiate(m_bulletPrefab);
            m_bullets[i].GetComponent<BulletHandler>().SetParent(gameObject);
            m_bullets[i].transform.SetParent(transform);
            m_bullets[i].transform.localPosition = Vector2.zero;
            m_bullets[i].SetActive(false);
        }
    }

	// Use this for initialization
	void Start ()
    {
        camera = Camera.main;

        StartCoroutine(BulletFireActions());
        //m_topOfScreenY = new Vector2(0, 1);
        m_screenBoudsMax = camera.BoundsMax();
        m_bulletPrefabBounds = m_bulletPrefab.GetComponent<SpriteRenderer>().bounds;


        m_bulletDestroyYCoord = m_screenBoudsMax.y + m_bulletPrefabBounds.min.y / 2; // this is fucking up
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    IEnumerator BulletFireActions()
    {
        yield return new WaitForSeconds(Random.Range(m_minIntevalFireRate, m_maxIntevalFireRate));
        for (int i = 0; i < MAXBULLETS; i++)
        {
            if (!m_bullets[i].activeInHierarchy)
            {
                m_bullets[i].SetActive(true);
                m_bullets[i].transform.parent = null;
                m_bullets[i].GetComponent<BulletHandler>().StartBulletMovement(m_bullets[i], transform.position, new Vector2(transform.position.x, m_bulletDestroyYCoord), m_bulletSpeed, m_bulletDestroyYCoord);
                //StartCoroutine(BulletMovementActions(m_bullets[i],transform.position, new Vector2(transform.position.x, m_bulletDestroyYCoord), m_bulletSpeed));
                break;
            }
        }
        StartCoroutine(BulletFireActions());
    }

    

    
}
