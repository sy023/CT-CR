using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
public class vector3 : MonoBehaviour
{
    public Transform targetA;
    public Transform pointB;
    public Transform bulletSpawnPoint;

    public float rangeValue;
    public float rotSpeed;
    public float bulletSpawnTime;
    public float rotationSpeed;
    public float bulletSpeed;

    public Quaternion currentRotation;

    float timeCount = 0.0f;

    public GameObject bulletPreFab;
    public GameObject gameOver;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBullet());
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        var targets = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var target in targets)
        {
            float dist = Vector3.Distance(transform.position, target.transform.position);
            if (dist <= rangeValue)
            {
                transform.LookAt(target.transform.position);
            } 
        }

    }
    IEnumerator SpawnBullet()
    {
        while (true)
        {
            GameObject Bullet = Instantiate(bulletPreFab, bulletSpawnPoint.position, Quaternion.identity);
            Rigidbody rb = Bullet.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * bulletSpeed;
            yield return new WaitForSeconds(bulletSpawnTime);
        }
    }
    void LookRotation()
    {
        Vector3 relativePos = targetA.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameOver.SetActive(true);
            Destroy(gameObject);

        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeValue);
    }

}