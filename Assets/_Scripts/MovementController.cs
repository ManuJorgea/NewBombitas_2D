using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private Vector2 direction = Vector2.down;
    public float speed = 5f;
    private int vidas = 3;

    //public bool player01;
    //public bool player02;
    //public bool player03;
    //public bool player04;

    [Header("Input")]
    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;

    [Header("Sprites")]
    public AnimatedSpriteRenderer spriteRendererUp;
    public AnimatedSpriteRenderer spriteRendererDown;
    public AnimatedSpriteRenderer spriteRendererLeft;
    public AnimatedSpriteRenderer spriteRendererRight;
    public AnimatedSpriteRenderer spriteRendererDeath;
    private AnimatedSpriteRenderer activeSpriteRenderer;

    public AnimatedSpriteRenderer spriteRendererLife3;
    public AnimatedSpriteRenderer spriteRendererLife2;
    public AnimatedSpriteRenderer spriteRendererLife1;
    public AnimatedSpriteRenderer spriteRendererLife0;
    private AnimatedSpriteRenderer activeSpriteRendererLifeCounter;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        activeSpriteRenderer = spriteRendererDown;
        activeSpriteRendererLifeCounter = spriteRendererLife3;
    }

    private void Update()
    {
        if (Input.GetKey(inputUp))
        {
            SetDirection(Vector2.up, spriteRendererUp);
        }
        else if (Input.GetKey(inputDown))
        {
            SetDirection(Vector2.down, spriteRendererDown);
        }
        else if (Input.GetKey(inputLeft))
        {
            SetDirection(Vector2.left, spriteRendererLeft);
        }
        else if (Input.GetKey(inputRight))
        {
            SetDirection(Vector2.right, spriteRendererRight);
        }
        else
        {
            SetDirection(Vector2.zero, activeSpriteRenderer);
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;

        rigidbody.MovePosition(position + translation);
    }

    private void SetDirection(Vector2 newDirection, AnimatedSpriteRenderer spriteRenderer)
    {
        direction = newDirection;

        spriteRendererUp.enabled = spriteRenderer == spriteRendererUp;
        spriteRendererDown.enabled = spriteRenderer == spriteRendererDown;
        spriteRendererLeft.enabled = spriteRenderer == spriteRendererLeft;
        spriteRendererRight.enabled = spriteRenderer == spriteRendererRight;

        activeSpriteRenderer = spriteRenderer;
        activeSpriteRenderer.idle = direction == Vector2.zero;
    }
        
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            vidas -= 1;

            if (vidas>=1)
            {
                enabled = false;
                DeathSequenceStill();
                if (vidas == 3)
                {
                    spriteRendererLife3.enabled = true;
                    spriteRendererLife2.enabled = false;
                    spriteRendererLife1.enabled = false;
                    spriteRendererLife0.enabled = false;

                }
                else if (vidas == 2)
                {
                    spriteRendererLife3.enabled = false;
                    spriteRendererLife2.enabled = true;
                    spriteRendererLife1.enabled = false;
                    spriteRendererLife0.enabled = false;
                    Debug.Log("El personaje ha muerto 1 vez");
                }
                else if (vidas == 1)
                {
                    spriteRendererLife3.enabled = false;
                    spriteRendererLife2.enabled = false;
                    spriteRendererLife1.enabled = true;
                    spriteRendererLife0.enabled = false;
                    Debug.Log("El personaje ha muerto 2 veces");
                }
            }
            else if (vidas==0)
            {
                DeathSequence();
                spriteRendererLife3.enabled = false;
                spriteRendererLife2.enabled = false;
                spriteRendererLife1.enabled = false;
                spriteRendererLife0.enabled = true;
                Debug.Log("El personaje ha muerto 3 veces");
            }

        }
    }


    private void DeathSequenceStill()
    {
        enabled = false;
        GetComponent<BombController>().enabled = false;

        spriteRendererUp.enabled = false;
        spriteRendererDown.enabled = false;
        spriteRendererLeft.enabled = false;
        spriteRendererRight.enabled = false;
        spriteRendererDeath.enabled = true;

        Invoke(nameof(OnDeathSequenceEndedStill), 1.25f);
    }
        private void OnDeathSequenceEndedStill()
    {
        gameObject.SetActive(true);

        enabled = true;
        GetComponent<BombController>().enabled = true;

        spriteRendererUp.enabled = true;
        spriteRendererDown.enabled = true;
        spriteRendererLeft.enabled = true;
        spriteRendererRight.enabled = true;
        spriteRendererDeath.enabled = false;
    }

    private void DeathSequence()
    {
        enabled = false;
        GetComponent<BombController>().enabled = false;

        spriteRendererUp.enabled = false;
        spriteRendererDown.enabled = false;
        spriteRendererLeft.enabled = false;
        spriteRendererRight.enabled = false;
        spriteRendererDeath.enabled = true;

        Invoke(nameof(OnDeathSequenceEnded), 1.25f);
    }

    private void OnDeathSequenceEnded()
    {
        gameObject.SetActive(false);
        FindObjectOfType<GameManager>().CheckWinState();
    }

}
