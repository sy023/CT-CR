using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
public class vector3 : MonoBehaviour
{
    public float rangeValue;
    public Quaternion currentRotation;
    public float rotSpeed;
    public Transform targetA;
    float timeCount = 0.0f;
    public float bulletSpawnTime;
    //prefab projectile
    public GameObject bulletPreFab;



    public float rotationSpeed;


    public GameObject gameOver;

    //bullet Spawn here
    public Transform bulletSpawnPoint;

    //speed of bullet
    public float bulletSpeed;

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


    public void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, rangeValue);
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
        Destroy(gameObject);
    }


}