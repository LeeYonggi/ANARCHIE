using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    //추가
    public float maxVspeed;

    public float speed; // pixels per second
    public float jumpSpeed;

    private float m_ScaleX;
    private Animator m_Animator;
    private Rigidbody2D m_Rigidbody2D;
    bool isJump;


    void Start()
    {
        m_ScaleX = transform.localScale.x;
        m_Animator = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        isJump = false;
    }

    void Update()
    {
        MoveObject();

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        if (isJump == true && m_Rigidbody2D.velocity.y < 0)
        {
            ChangeAnime(3);
        }

        //추가
        m_Rigidbody2D.velocity =  Vector3.up * Mathf.Max(m_Rigidbody2D.velocity.y, maxVspeed);
    }

    void MoveObject()
    {
        float amtMove = speed * Time.smoothDeltaTime;
        float key = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * amtMove * key, Space.World);

        if (FlipObject(key) && isJump == false)
            ChangeAnime(1);
        else if(isJump == false)
            ChangeAnime(0);
    }

    bool FlipObject(float key)
    {
        if (key < 0.0f)
        {
            transform.localScale = new Vector3(-m_ScaleX, transform.localScale.y, transform.localScale.z);
            return true;
        }
        else if (key > 0.0f)
        {
            transform.localScale = new Vector3(m_ScaleX, transform.localScale.y, transform.localScale.z);
            return true;
        }
        return false;  
    }

    void ChangeAnime(int state)
    {
        m_Animator.SetInteger("Anime_State", state);
    }

    void Jump()
    {
        if (isJump == false)
        {
            m_Rigidbody2D.AddForce(new Vector2(0, jumpSpeed));
            isJump = true;
            ChangeAnime(0);
            ChangeAnime(2);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isJump = false;
            ChangeAnime(0);
        }
    }
}
