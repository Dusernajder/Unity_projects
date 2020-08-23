using UnityEngine;

public class Block : MonoBehaviour
{
    // configuration parameters
    [SerializeField] private AudioClip breakSound;
    [SerializeField] private GameObject particleVFX;
    [SerializeField] private Sprite[] hitSprites;

    // cached reference
    private Level _level;

    // state variables
    private int _timesHit;


    void Start()
    {
        CountBreakableBlocks();
    }


    private void CountBreakableBlocks()
    {
        _level = FindObjectOfType<Level>();
        if (CompareTag("Breakable"))
        {
            _level.CountBlocks();
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (CompareTag("Breakable"))
        {
            HandleHit();
        }
    }


    private void HandleHit()
    {
        _timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (_timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }


    private void ShowNextHitSprite()
    {
        int spriteIndex = _timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError(name + "'s sprite is missing from array!");
        }

    }


    private void DestroyBlock()
    {
        TriggerDestroySFX();
        TriggerParticleVFX();

        Destroy(gameObject);

        _level.DecrementBreakableBlocks();
        FindObjectOfType<GameSession>().AddToScore();
    }


    private void TriggerDestroySFX()
    {
        if (Camera.main != null)
        {
            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        }
    }


    private void TriggerParticleVFX()
    {
        GameObject particle = Instantiate(particleVFX, transform.position, transform.rotation);
        Destroy(particle, 1f);
    }
}