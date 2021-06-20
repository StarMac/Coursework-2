using System;
using TMPro;
using UnityEngine;

public abstract class AbstractBlock : MonoBehaviour
{
    protected int hitsRemaining = 5;

    protected SpriteRenderer spriteRenderer;
    protected TextMeshPro text;

    protected void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        text = GetComponentInChildren<TextMeshPro>();
        UpdateVisualState();
    }

    protected abstract void UpdateVisualState();

    protected abstract void OnCollisionEnter2D(Collision2D collision);

    internal void SetHits(int hits)
    {
        hitsRemaining = hits;
        UpdateVisualState();
    }
}
