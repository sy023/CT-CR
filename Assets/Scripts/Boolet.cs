using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public Rigidbody rigidBody;
    MeshRenderer mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>();
        var player = GameObject.FindGameObjectWithTag("Player");

        var currentColor = player.GetComponent<FunctionTest>().currentColor;
        mat.material.color = currentColor;
    }

    void Update()
    {
        if (FunctionTest.Instance.i == 0)
        {
        }
        if (FunctionTest.Instance.i == 1)
        {

        }
        if (FunctionTest.Instance.i == 2)
        {

        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Enemy") && collision.GetComponent<Enemy>().mat.material.color.Equals(mat.material.color))
        {
            Destroy(collision.gameObject);

        }
        Destroy(gameObject);

    }

}
