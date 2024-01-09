using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float jumpForce = 10f;
    public float coolDown;
    public float timeShoot = 1.0f;

    public GameObject prefab;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coolDown = timeShoot;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(0, jumpForce);
        }

        coolDown -= Time.deltaTime;
        if (coolDown <= 0)
        {
            PoolingManager.Instance.GetObject(NamePrefabPool.bullet, null, transform.position, new Vector3(2,4)).Disable(4);
            coolDown = timeShoot;
        }
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.CompareTag("Block"))
    //     {
    //         Debug.Log("Collided with square");
    //         // tạo obj prefab khi va chạm
    //         // prefab - obj được tạo
    //         // vector3(...) - tọa độ vật
    //         // Quaternion.identity - góc cam
    //         Instantiate(prefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
    //         // hủy vật va chạm (other = đệm)
    //         Destroy(other.gameObject);
    //     }
    // }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            Debug.Log("Triggered with square");
        }
    }
}