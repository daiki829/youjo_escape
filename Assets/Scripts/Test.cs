using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
   public GameObject Player;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = Player.transform.position;

        playerPos.x = Player.transform.position.x;
        playerPos.y = Player.transform.position.y ;
        playerPos.z = Player.transform.position.z ;

        transform.position = new Vector3(playerPos.x, playerPos.y, -10);

    }
}
