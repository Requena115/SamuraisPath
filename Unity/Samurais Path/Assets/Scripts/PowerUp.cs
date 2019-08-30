using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public bool IsActive { set; get; }

    private float verticalVelocity;
    private float speed;
    private bool isSlice = false;
    private const float GRAVITY = 2.0f;

    public Sprite[] sprites;
    private int spriteIndex;
    public SpriteRenderer sRenderer;
    private float lastUpdateSprite;
    private float lastDeltaUpdate = 0.125f;

    private void Awake()
    {
        sRenderer = GetComponent<SpriteRenderer>();
    }


    public void LaunchPowerUp(float verticalVelocity, float xSpeed, float xStart)
    {
        IsActive = true;
        speed = xSpeed;
        this.verticalVelocity = verticalVelocity;
        transform.position = new Vector3(xStart, 0, 0);
        isSlice = false;
        spriteIndex = 0;
        sRenderer.sprite = sprites[spriteIndex];
    }

    private void Update()
    {
        if (!IsActive)
            return;
        verticalVelocity -= GRAVITY * Time.deltaTime;
        transform.position += new Vector3(speed, verticalVelocity, 0) * Time.deltaTime;

        if (isSlice)
        {
            if (spriteIndex != sprites.Length - 1 && Time.time - lastUpdateSprite > lastDeltaUpdate)
            {
                lastUpdateSprite = Time.time;
                spriteIndex++;
                sRenderer.sprite = sprites[spriteIndex];
            }
        }
        if (transform.position.y < -1)
        {
            IsActive = false;
        }
    }

    public void Slice()
    {
        if (isSlice)
        {
            return;
        }
        if (verticalVelocity < 0.5f)
            verticalVelocity = 0.5f;

        speed = speed * 0.5f;
        isSlice = true;

        //Here is the powerUp
        GameManager.Instance.gainPowerUp();
    }
}
