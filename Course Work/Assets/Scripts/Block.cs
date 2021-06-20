using System;
using TMPro;
using UnityEngine;

public class Block : AbstractBlock
{
    protected override void UpdateVisualState()
    {
        text.SetText(hitsRemaining.ToString());
        spriteRenderer.color = Color.Lerp(Color.blue, Color.white, hitsRemaining / 10f);
        text.color = Color.Lerp(Color.blue, Color.white, hitsRemaining / 10f);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        hitsRemaining--;
        if (hitsRemaining > 0)
            UpdateVisualState();
        else
            Destroy(gameObject);
    }
}
