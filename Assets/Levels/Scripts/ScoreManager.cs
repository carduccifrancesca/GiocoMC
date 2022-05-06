using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text bigliettiText;
    public int bigliettiAmount;
    public float scoreAmount;
    public float pointIncreasedPerSecond;

    // Start is called before the first frame update
    void Start()
    {
        bigliettiAmount = 0;
        scoreAmount = 0f;
        pointIncreasedPerSecond = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        bigliettiText.text = bigliettiAmount.ToString();
        scoreText.text = (int)scoreAmount + " Score";
        scoreAmount += pointIncreasedPerSecond * Time.deltaTime;
    }

   public void aggiornaBiglietti()
    {
        this.bigliettiAmount++;
    }
}