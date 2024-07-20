using UnityEngine;
using UnityEngine.UI;

public class Janken : MonoBehaviour
{
    public Button rockButton;
    public Button scissorsButton;
    public Button paperButton;
    public Image opponentHand;
    public Text resultText;

    private Sprite rockSprite;
    private Sprite scissorsSprite;
    private Sprite paperSprite;

    private void Start()
    {
        // ボタンのクリックイベントを設定
        rockButton.onClick.AddListener(OnRockClick);
        scissorsButton.onClick.AddListener(OnScissorsClick);
        paperButton.onClick.AddListener(OnPaperClick);

        // Resourcesフォルダから画像をロード
        rockSprite = Resources.Load<Sprite>("rock");
        scissorsSprite = Resources.Load<Sprite>("scissors");
        paperSprite = Resources.Load<Sprite>("paper");
    }

    public void OnRockClick()
    {
        PlayGame(Hand.Rock);
    }

    public void OnScissorsClick()
    {
        PlayGame(Hand.Scissors);
    }

    public void OnPaperClick()
    {
        PlayGame(Hand.Paper);
    }

    private void PlayGame(Hand playerHand)
    {
        // プレイヤーの手を決定
        Hand computerHand = (Hand)Random.Range(0, 3);

        // コンピューターの手の画像を設定
        switch (computerHand)
        {
            case Hand.Rock:
                opponentHand.sprite = rockSprite;
                break;
            case Hand.Scissors:
                opponentHand.sprite = scissorsSprite;
                break;
            case Hand.Paper:
                opponentHand.sprite = paperSprite;
                break;
        }

        // 勝敗を判定
        string result = DetermineWinner(playerHand, computerHand);
        resultText.text = result;
    }

    private string DetermineWinner(Hand player, Hand computer)
    {
        if (player == computer)
        {
            return "引き分け";
        }
        else if ((player == Hand.Rock && computer == Hand.Scissors) ||
                 (player == Hand.Paper && computer == Hand.Rock) ||
                 (player == Hand.Scissors && computer == Hand.Paper))
        {
            return "あなたの勝ち";
        }
        else
        {
            return "あなたの負け";
        }
    }

    private enum Hand
    {
        Rock,
        Scissors,
        Paper
    }
}
