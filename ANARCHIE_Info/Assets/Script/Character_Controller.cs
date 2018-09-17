using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{

    public float speed = 5.0f;
    private float m_ScaleX;
    private Animator m_Animator;


    // Use this for initialization
    void Start()
    {
        m_ScaleX = transform.localScale.x;
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();
    }

    void MoveObject()
    {
        float amtMove = speed * Time.smoothDeltaTime;
        float key = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * amtMove * key, Space.World);
        if (FlipObject(key))
            ChangeAnime(1);
        else
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
}
