using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NovelGame : MonoBehaviour
{
    public Text textDisplay; // セリフを表示させるText
    public Button choiceButton1; // 選択肢1のボタン
    public Button choiceButton2; // 選択肢2のボタン
    public Image backgroundImage; // 背景画像を表示するImage
    public Image lenaImage; // キャラクター画像を表示するImage
    public Image karenImage; // キャラクター画像を表示するImage

    public Sprite background1; // 背景1のスプライト
    public Sprite background2; // 背景2のスプライト
    public Sprite background3; // 背景3のスプライト

    public Sprite lennaNormal; // レナの通常の表情
    public Sprite lennaHappy; // レナの幸せな表情
    public Sprite lennaSad; // レナの悲しい表情

    public Sprite karenNormal; // カレンの通常の表情
    public Sprite karenHappy; // カレンの幸せな表情
    public Sprite karenAngry; // カレンの怒った表情

    private string[] storyTexts = new string[]
    {
        "レナ: カレン、見て見て！この魔法の本、すごく面白いよ！",
        "カレン: レナ、ちゃんと本の内容を理解してからじゃないと危ないよ。",
        "レナ: うん、そうだね。でも、カレンが一緒にいてくれるから大丈夫！",
        "カレン: （少し照れた表情で）べ、別に私は何でもできるわけじゃないし…。",
        
        "シオン: 何してるの、二人とも？",
        "レナ: あ、シオン！ちょうどいいところに。新しい魔法の研究をしてるんだ。",
        "シオン: 面白そうね。私も手伝っていい？",

        "カレン: もちろんよ。シオンがいればもっと安全だわ。",
        "レナ: ありがとう、シオン！じゃあ、この呪文を一緒に読んでみようか？",
        "シオン: いいわよ。でも、まずは落ち着いて。",
        "レナ: えっと、まずは…このページからだね。",
        "（レナが本を開き、呪文を読む準備をする。しかし、手元が滑って本が床に落ちる。）",
        "レナ: あっ、ごめん、カレン！またやっちゃった…。",
        "カレン: （ため息をつきつつも優しい目で）本当にドジね、レナ。でも大丈夫、私が手伝うから。一緒に拾おう。",

        "レナ: うん、ありがとう！カレンは本当に優しいなぁ。",
        "カレン: （少し顔を赤らめて）べ、別に優しくなんてないわよ。ただ、君が困ってると放っておけないだけ。",
        "シオン: さて、もう一度試してみましょうか。",
        "レナ: さぁ、今度こそ挑戦しよう！",
        "カレン: そうね、今度こそ成功させましょう。一緒に頑張ろう、レナ。",
        "レナ: ねえカレン、今度はうまくいくと思う？",
        "カレン: もちろんよ。君がちゃんと集中すれば、きっと結果が出るわ。",
        "シオン: もし呪文がうまくいかなかったらどうする？",
        "カレン: そんなこと考えないで。今は良い結果を信じるのよ。",
        "レナ: わかった、集中するね。…呪文を唱えるよ。"
    };

    private string[] branchPositive = new string[]
    {
        "（レナが呪文を成功させる。）",
        "レナ: 光が…見える！カレン、うまくいったかも！",
        "カレン: ほんと？すごいわ、レナ！",
        "レナ: やったー！カレンのおかげだよ！",
        "カレン: べ、別に私は何も…。でも、よくやったわね。",
        "シオン: 本当に見事だったわ、レナ。次はもっと難しい魔法に挑戦しよう。",
        "レナ: ありがとう、カレン、シオン。これからも一緒に頑張ろうね。",
        "（エンディングシーン）",
        "レナ: 今日は本当に楽しかったね。",
        "カレン: ええ、また一緒に研究しようね。",
        "FIn" // ストーリー終了メッセージ
    };

    private string[] branchRetry = new string[]
    {
        "（レナが呪文を失敗させる。）",
        "レナ: あれ…何も起こらない？",
        "カレン: もう一度挑戦してみる？",
        "シオン: 落ち着いて。失敗から学ぶことも大事よ。",
        "レナ: うん、そうだね。もう一度挑戦してみるよ。",
        "カレン: 今度はきっと良い結果が出るわ。",
        "シオン: 私たちがついてるわ、一緒に頑張ろう。",
        "（エンディングシーン）",
        "レナ: うーん、もう一度頑張ってみるよ。",
        "カレン: そうね、失敗を恐れずにまた挑戦することが大切よ。",
        "FIn" // ストーリー終了メッセージ
    };

    private int currentIndex = 0;
    private bool isBranching = false;

    void Start()
    {
        // 変数の割り当て確認
        if (textDisplay == null) Debug.LogError("textDisplay が設定されていません。");
        if (choiceButton1 == null) Debug.LogError("choiceButton1 が設定されていません。");
        if (choiceButton2 == null) Debug.LogError("choiceButton2 が設定されていません。");
        if (backgroundImage == null) Debug.LogError("backgroundImage が設定されていません。");
        if (lenaImage == null) Debug.LogError("lenaImage が設定されていません。");
        if (karenImage == null) Debug.LogError("karenImage が設定されていません。");

        if (textDisplay != null && storyTexts.Length > 0)
        {
            textDisplay.text = storyTexts[currentIndex];
        }
        else
        {
            Debug.LogError("textDisplay が設定されていないか、storyTexts が空です。");
        }

        choiceButton1.gameObject.SetActive(false);
        choiceButton2.gameObject.SetActive(false);
        choiceButton1.onClick.AddListener(() => ChooseBranch(true));
        choiceButton2.onClick.AddListener(() => ChooseBranch(false));

        // 初期設定
        backgroundImage.sprite = background1;
        lenaImage.sprite = lennaNormal; // 初期キャラクター画像
        karenImage.sprite = karenNormal; // 初期キャラクター画像
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isBranching) // マウスクリックを検知
        {
            AdvanceText();
        }
    }

    void AdvanceText()
    {
        currentIndex++;
        if (currentIndex < storyTexts.Length)
        {
            textDisplay.text = storyTexts[currentIndex];

            // キャラクターの感情を変更するタイミング
            if (currentIndex == 3)
            {
                lenaImage.sprite = lennaHappy;
                StartShakingImage(lenaImage);
            }
            else if (currentIndex == 7)
            {
                lenaImage.sprite = lennaSad;
                StartShakingImage(lenaImage);
            }
            else if (currentIndex == 10)
            {
                karenImage.sprite = karenAngry;
                StartShakingImage(karenImage);
            }

            // 背景変更のタイミング
            if (currentIndex == 5) // 特定のインデックスで背景を変更
            {
                backgroundImage.sprite = background2;
            }
            else if (currentIndex == 15) // 別のタイミングで背景を変更
            {
                backgroundImage.sprite = background3;
            }

            if (currentIndex == storyTexts.Length - 1 && storyTexts[currentIndex] != "FIn") // 分岐点前の最後のセリフに到達
            {
                ShowChoices();
            }
        }
        else if (storyTexts[currentIndex] == "FIn") // 分岐後のストーリーが終了した時
        {
            Debug.Log("ストーリーが終了しました。");
            textDisplay.text = "FIn";
            choiceButton1.gameObject.SetActive(false);
            choiceButton2.gameObject.SetActive(false);
            Application.Quit(); // アプリケーションを終了
        }
    }

    void ShowChoices()
    {
        isBranching = true;
        choiceButton1.gameObject.SetActive(true);
        choiceButton2.gameObject.SetActive(true);
        choiceButton1.GetComponentInChildren<Text>().text = "挑戦してみる";
        choiceButton2.GetComponentInChildren<Text>().text = "もう一度試す";
    }

    void ChooseBranch(bool isPositiveOutcome)
    {
        choiceButton1.gameObject.SetActive(false);
        choiceButton2.gameObject.SetActive(false);

        if (isPositiveOutcome)
        {
            currentIndex = -1; // 再挑戦ブランチの最初に戻るために設定
            storyTexts = branchPositive;
            backgroundImage.sprite = background3; // ポジティブな結果の背景
            lenaImage.sprite = lennaHappy; // ポジティブな結果でレナの幸せな表情
        }
        else
        {
            currentIndex = -1; // ポジティブブランチの最初に戻るために設定
            storyTexts = branchRetry;
            backgroundImage.sprite = background2; // 再挑戦の背景
            karenImage.sprite = karenNormal; // 再挑戦でカレンの通常の表情
        }

        isBranching = false;
        AdvanceText();
    }

    void StartShakingImage(Image image)
    {
        StartCoroutine(ShakeImage(image));
    }

    IEnumerator ShakeImage(Image image)
    {
        Vector3 originalPosition = image.transform.localPosition;
        float elapsedTime = 0f;
        float shakeDuration = 0.5f;
        float shakeMagnitude = 10f;

        while (elapsedTime < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;
            image.transform.localPosition = originalPosition + new Vector3(x, y, 0);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        image.transform.localPosition = originalPosition; // 元の位置に戻す
    }
}
