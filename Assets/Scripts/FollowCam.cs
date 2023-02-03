using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] private Player player;
    private Vector2 newCamPos;

    void Update()
    {
        newCamPos = new Vector2(player.transform.position.x, 0);
        transform.position = new Vector3(newCamPos.x, newCamPos.y, transform.position.z);
    }
}
