using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    public enum DestructMethod { Instant, Delayed, Fadeout}
    [SerializeField] bool destroyOnStart = false;
    [SerializeField] float destructionDelay = 1f;
    [SerializeField] float fadeoutTime;
    private float currentFadeoutTime = 0;
    private bool shouldFade = false;
    private SpriteRenderer spriteRenderer;
    public DestructMethod destructMethod;

    private void Start()
    {
        if (destroyOnStart)
            DestroyMethod();
    }

    public void DestroyMethod()
    {
        Debug.Log("destroymethod :)");
        switch (destructMethod)
        {
            case DestructMethod.Instant:
                Destroy(gameObject);
                break;
            case DestructMethod.Delayed:
                StartCoroutine(DelayedDestruction());
                break;
            case DestructMethod.Fadeout:
                Fadeout();
                break;
            default:
                Destroy(gameObject);
                Debug.Log("DestructMethod Defaulted on: " + gameObject.name);
                break;
        }
        Debug.Log(destructMethod);
    }

    private IEnumerator DelayedDestruction()
    {
        yield return new WaitForSeconds(destructionDelay);
        Destroy(gameObject);
    }

    private void Fadeout()
    {
        Debug.Log("FadingOut");
        shouldFade = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (shouldFade && currentFadeoutTime < fadeoutTime)
        {
            Debug.Log("WE ARE FADING");
            currentFadeoutTime += Time.deltaTime;
            Color temp = spriteRenderer.color;
            temp.a = fadeoutTime/fadeoutTime - currentFadeoutTime/fadeoutTime;
            spriteRenderer.color = temp;
        }
        else if(shouldFade && currentFadeoutTime > fadeoutTime)
            Destroy(gameObject);
            
    }
}
