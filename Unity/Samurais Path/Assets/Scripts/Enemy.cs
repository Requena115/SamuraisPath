using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool IsActive { set; get; }

    private float verticalVelocity;
    private float speed;
    private bool isSlice = false;
    private const float GRAVITY = 2.0f;


    public void LaunchEnemy(float verticalVelocity, float xSpeed, float xStart)
    {
        IsActive = true;
        speed = xSpeed;
        this.verticalVelocity = verticalVelocity;
        transform.position = new Vector3(xStart, 0, 0);
        isSlice = false;
    }

    private void Update()
    {
        if (!IsActive)
            return;
        verticalVelocity -= GRAVITY * Time.deltaTime;
        transform.position += new Vector3(speed, verticalVelocity, 0) * Time.deltaTime;

        if (transform.position.y < -1)
        {
            IsActive = false;
            if (!isSlice)
            {
                GameManager.Instance.LoseLP();
            }
        }
    }

    public void Slice()
    {
        if(isSlice)
        {
            return;
        }
        if (verticalVelocity < 0.5f)
            verticalVelocity = 0.5f;

        speed = speed * 0.5f;
        isSlice = true;

        GameManager.Instance.IncrementScore(1);
    }

}
