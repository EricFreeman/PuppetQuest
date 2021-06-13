using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class SubtitleTrackMixer : PlayableBehaviour
{
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        TextMeshProUGUI text = playerData as TextMeshProUGUI;
        var currentText = "";
        float currentAlpha = 0f;

        var defaultText = $"<mark=#00000055 padding=\"10, 10, 0, 0\"><b>NARRATOR</b>\n";

        if (!text) { return; }

        var inputCount = playable.GetInputCount();
        for (var i = 0; i < inputCount; i++)
        {
            var inputWeight = playable.GetInputWeight(i);
            if (inputWeight > 0)
            {
                ScriptPlayable<SubtitleBehavior> inputPlayable = (ScriptPlayable<SubtitleBehavior>)playable.GetInput(i);
                var input = inputPlayable.GetBehaviour();
                currentText = defaultText + input.SubtitleText;
                currentAlpha = inputWeight;
            }
        }

        text.text = currentText;
        text.color = new Color(1, 1, 1, currentAlpha);
    }
}
