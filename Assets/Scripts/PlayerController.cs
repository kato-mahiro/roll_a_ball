using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed; //スピードをエディターから調節できるようにするための変数
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() // 物理演算のたびに呼ばれる
    {
        // プレイヤーのキーボード入力を取得する
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); 

        rb.AddForce(movement * speed);
    }

    
    void OnTriggerEnter(Collider other)
    //OnTriggerENter関数はPlayerゲームオブジェクトがTrigger担っているColliderに接触した瞬間に呼ばれる
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("衝突した");
        }
    }
    
}