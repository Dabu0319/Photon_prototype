using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject readyButton;

    public void ReadyToPlay()
    {
        readyButton.SetActive(false);
        SpawnPlayer();
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlayer()
    {
        PhotonNetwork.Instantiate("Player", new Vector3(0, 0,0), quaternion.identity, 0);
    }
}
