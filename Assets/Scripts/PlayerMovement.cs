using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviourPun
{
    public float moveSpeed = 5.0f;

    private Rigidbody2D _rb;

    public Text nameText;

    private void Awake()
    {
        if (photonView.IsMine)
            nameText.text = PhotonNetwork.NickName;
        else
        {
            nameText.text = photonView.Owner.NickName;
        }
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        //DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //避免误操作其他玩家
        if (!photonView.IsMine && PhotonNetwork.IsConnected)
            return;

        
        float xMove = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(xMove*moveSpeed , _rb.velocity.y);
        
        
        

    }
}
