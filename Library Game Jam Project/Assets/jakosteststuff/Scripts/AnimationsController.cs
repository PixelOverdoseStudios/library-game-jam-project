using System.Collections.Generic;
using UnityEngine;

public class AnimationsController : MonoBehaviour
{
    public List<Sprite> upSprites;
    public List<Sprite> downSprites;
    public List<Sprite> leftSprites;
    public List<Sprite> rightSprites;
    public Sprite idleSprite; // Add a sprite for the idle state

    public Sprite signupSprite; // Assign the signup sprite in the Inspector
    public Sprite cardSprite; // Assign the card sprite in the Inspector

    private SpriteRenderer spriteRenderer;
    private int currentFrame;
    private float animationTimer;
    public float animationInterval = 0.2f; // Time between frames

    private Vector3 lastPosition; // Store the last position of the object
    private string currentDirection;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastPosition = transform.position; // Initialize lastPosition with the object's starting position
        UpdateSprite();
    }

    void Update()
    {
        currentDirection = GetMovementDirection(); // Get movement direction from the object's transform

        

        animationTimer += Time.deltaTime;
        if (animationTimer >= animationInterval)
        {
            animationTimer = 0f;
            currentFrame = (currentFrame + 1) % GetCurrentSpriteList().Count;
            UpdateSprite();
        }
    }

    void UpdateSprite()
    {
        spriteRenderer.sprite = GetCurrentSpriteList()[currentFrame];
        if (currentDirection == "signup" && signupSprite != null)
        {
            // Overlay signup sprite on top of current sprite
            spriteRenderer.sprite = OverlaySprite(spriteRenderer.sprite, signupSprite);
        }
    }

    Sprite OverlaySprite(Sprite baseSprite, Sprite overlaySprite)
    {
        // Create a new texture to combine the two sprites
        Texture2D combinedTexture = new Texture2D((int)baseSprite.rect.width, (int)baseSprite.rect.height);

        // Copy the base sprite's texture to the combined texture
        combinedTexture.SetPixels(baseSprite.texture.GetPixels());

        // Calculate the position to draw the overlay sprite (centered)
        int x = (int)((combinedTexture.width - overlaySprite.texture.width) / 2);
        int y = (int)((combinedTexture.height - overlaySprite.texture.height) / 2);

        // Copy the overlay sprite's texture to the combined texture at the calculated position
        combinedTexture.SetPixels(x, y, overlaySprite.texture.width, overlaySprite.texture.height, overlaySprite.texture.GetPixels());

        // Apply changes to the combined texture
        combinedTexture.Apply();

        // Create a new sprite using the combined texture
        Sprite combinedSprite = Sprite.Create(combinedTexture, new Rect(0, 0, combinedTexture.width, combinedTexture.height), new Vector2(0.5f, 0.5f));

        return combinedSprite;
    }

    List<Sprite> GetCurrentSpriteList()
    {
        switch (currentDirection)
        {
            case "up":
                return upSprites;
            case "down":
                return downSprites;
            case "left":
                return leftSprites;
            case "right":
                return rightSprites;
            default:
                return new List<Sprite> { idleSprite }; // Return idle sprite if current direction is not recognized
        }
    }

    string GetMovementDirection()
    {
        // Get the current position of the object
        Vector3 currentPosition = transform.position;

        // Calculate the movement direction based on the change in position
        Vector3 movementDirection = currentPosition - lastPosition;

        Debug.Log("Movement Magnitude: " + movementDirection.magnitude);

        // Update the last position for the next frame
        lastPosition = currentPosition;

        // Check if the magnitude of movement is significant
        if (movementDirection.magnitude < 0.001f)
        {
            return "idle";
        }
        else
        {
            // Calculate the angle of the movement direction vector
            float angle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg;

            // Determine the direction based on the angle
            if (angle > -45 && angle <= 45)
            {
                return "right";
            }
            else if (angle > 45 && angle <= 135)
            {
                return "up";
            }
            else if (angle > 135 || angle <= -135)
            {
                return "left";
            }
            else
            {
                return "down";
            }
        }
    }

    public void SpawnCardAboveSprite()
    {
        if (cardSprite != null && signupSprite != null)
        {
            // Overlay card sprite on top of current sprite
            spriteRenderer.sprite = OverlaySprite(spriteRenderer.sprite, cardSprite);
        }
        else
        {
            Debug.LogWarning("Card sprite or signup sprite is not assigned!");
        }
    }
}
