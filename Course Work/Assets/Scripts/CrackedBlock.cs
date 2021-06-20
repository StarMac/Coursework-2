using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackedBlock : AbstractBlock
{
    protected override void UpdateVisualState()
    {
        text.SetText(hitsRemaining.ToString());
        spriteRenderer.color = Color.Lerp(Color.magenta + Color.black, Color.white, hitsRemaining / 10f);
        text.color = Color.Lerp(Color.magenta, Color.white, hitsRemaining / 10f);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        hitsRemaining = hitsRemaining - 2;
        if (hitsRemaining > 0)
            UpdateVisualState();
        else
            Destroy(gameObject);
    }
}
