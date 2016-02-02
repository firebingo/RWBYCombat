using UnityEngine;
using System.Collections;

public class uiBar : MonoBehaviour
{
    [SerializeField]
    bool isHealth;
    [SerializeField]
    float currentValue;
    [SerializeField]
    float maxValue;
    [SerializeField]
    float changeToValue;
    Character charScript;
    SpriteRenderer uiImage;


    // Use this for initialization
    void Start()
    {
        charScript = transform.parent.transform.parent.GetComponent<Character>();
        uiImage = GetComponent<SpriteRenderer>();
        if (charScript)
        {
            maxValue = charScript.getFullEndurance();
            currentValue = maxValue;
            changeToValue = maxValue;
        }
        else
        {
            maxValue = 0;
            currentValue = 0;
            changeToValue = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (charScript)
        {
            changeToValue = charScript.getCurrentEndurance();

            if (changeToValue != currentValue)
                currentValue = Mathf.Lerp(currentValue, changeToValue, 0.5f * Time.deltaTime);

            transform.localScale = new Vector3(currentValue / maxValue, 1.0f, 1.0f);

            if (isHealth)
            {
                if (transform.localScale.x > 0.5f)
                    uiImage.color = new Color(2.0f - (transform.localScale.x / 0.5f), 1.0f, 0.0f);
                else if (transform.localScale.x < 0.5f)
                    uiImage.color = new Color(1.0f, transform.localScale.x / 0.5f, 0.0f);
            }
            else
            {
                uiImage.color = new Color(Mathf.Min(1.0f - transform.localScale.x, 0.9f), 1.0f, 1.0f);
            }
        }
    }
}
