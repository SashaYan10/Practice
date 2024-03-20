using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform currentCamera;
    [SerializeField] private Transform Player;
    void Awake()
    {
        currentCamera = Camera.main.transform;
    }

    void Update()
    {
        if (currentCamera == null)
            return;

        var cameraPosition = transform.position;
        cameraPosition.x = Mathf.Lerp(cameraPosition.x, Player.position.x, speed);

        currentCamera.position = cameraPosition;
    }
}
