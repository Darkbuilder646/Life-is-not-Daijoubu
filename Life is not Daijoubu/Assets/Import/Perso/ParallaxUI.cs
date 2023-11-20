using UnityEngine;

public class ParallaxUI : MonoBehaviour
{
    private Vector2 startPos;
    [SerializeField] private int parallaxFactor = 20;


    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        float posX = Mathf.Lerp(transform.position.x, startPos.x + (mousePos.x * parallaxFactor), 2f * Time.deltaTime);
        float posY = Mathf.Lerp(transform.position.y, startPos.y + (mousePos.y * parallaxFactor), 2f * Time.deltaTime);

        transform.position = new Vector3(posX, posY, 0);
    }

}
