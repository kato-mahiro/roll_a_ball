using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed; //スピードをエディターから調節できるようにするための変数
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
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
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
            if(count >= 12)
            {
                winText.text = "You Win!";
            }
        }
    }


    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}