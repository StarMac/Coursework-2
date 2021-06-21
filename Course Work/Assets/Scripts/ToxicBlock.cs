using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ToxicBlock : Block
{
    private Coroutine toxicRoutine;
    protected override void UpdateVisualState()
    {
        base.UpdateVisualState();
        spriteRenderer.color = Color.Lerp(Color.green + Color.black, Color.white, hitsRemaining / 10f);
        text.color = Color.Lerp(Color.green, Color.white, hitsRemaining / 10f);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        hitsRemaining--;
        if (hitsRemaining > 0)
        {
            UpdateVisualState();
            if (toxicRoutine != null)
                StopCoroutine(toxicRoutine);
                toxicRoutine = null;
            if (toxicRoutine == null)
                toxicRoutine = StartCoroutine(Toxic());
        }
        else
            Destroy(gameObject);
    }

    protected IEnumerator Toxic()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.8f);
            hitsRemaining--;
            if (hitsRemaining > 0)
                UpdateVisualState();
            else
            {
                Destroy(gameObject);
                break;
            }
        }
    }
}
