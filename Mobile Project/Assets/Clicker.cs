using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    private SpriteRenderer sprite;
    private BoxCollider2D boxCollider;
    private float xSpawnPos = 7;
    private float ySpawnPos = 3;

    private void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        boxCollider = gameObject.GetComponent <BoxCollider2D>();

        transform.position = RandomPosition();
    }
    public void OnMouseDown()
    {
        boxCollider.enabled = false;
        StartCoroutine(FadeTo(0.0f, 0.2f));
        Debug.Log("Clicked");
    }

    //Fades out the gameObject
    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = sprite.material.color.a;
        float oldSize = 0.01f;
        float newSize = 0.05f;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            float sizeX = Mathf.Lerp(oldSize, newSize, t);
            float sizeY = Mathf.Lerp(oldSize, newSize, t);
            sprite.size += new Vector2(sizeX, sizeY);
            sprite.material.color = newColor;
            yield return null;
        }
        //Checks if Object is faded out before destroying
        if (aValue <= 0.0f)
        {
            Debug.Log("It is destroyed");
            Destroy(this.gameObject);
        }
    }
    Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-xSpawnPos, xSpawnPos), Random.Range(-ySpawnPos, ySpawnPos), 0);
    }
}
