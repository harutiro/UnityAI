using UnityEngine;
using UnityEngine.UI;

public class NovelGame : MonoBehaviour
{
    public Text textDisplay; // セリフを表示させるText
    private string[] storyTexts = new string[] // 表示されるセリフの配列
    {
        "レナ: カレン、見て見て！この魔法の本、すごく面白いよ！",
        "カレン: レナ、ちゃんと本の内容を理解してからじゃないと危ないよ。",
        "レナ: うん、そうだね。でも、カレンが一緒にいてくれるから大丈夫！",
        "カレン: （少し照れた表情で）べ、別に私は何でもできるわけじゃないし…。",
        "レナ: ありがとう、カレン！じゃあ、この呪文を一緒に読んでみようか？",
        "カレン: わかったわ。でも、まずは落ち着いて。"
    };

    private int currentIndex = 0;

    void Start()
    {
        if (textDisplay != null && storyTexts.Length > 0)
        {
            textDisplay.text = storyTexts[currentIndex];
        }
        else
        {
            Debug.LogError("textDisplay が設定されていないか、storyTexts が空です。");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // マウスクリックを検知
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
        }
        else
        {
            Debug.Log("ストーリーが終了しました。");
        }
    }
}
