using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    public Text ScoreTxt;
    public GameObject FinishLabel;
    public float Speed = 5f;

    int score;
    bool isCarMoving = true;

    void Update()
    {
        if (isCarMoving)
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
        {
            score++;
            ScoreTxt.text = score.ToString();

            coin.gameObject.SetActive(false); // деактивируем монету. (тут идёт обращение именно к монете)

            if (score >= 5)
            {
                isCarMoving = false;
                FinishLabel.SetActive(true);
            }

            //     other.gameObject.SetActive(false); // идентичная запись. Но в данном случае мы обращаемся к other (то, с чем мы стокнулись)
            // Destroy(other.gameObject); // Либо Destroy(coin.gameObject); В данном случае идёт удаление объекта со сцены
        }
    }

}
