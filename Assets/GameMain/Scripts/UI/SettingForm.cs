//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework.Localization;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace StarForce
{
    public class SettingForm : UGuiForm
    {
        public void OnCloseButtonClick()
        {
            Close();
        }

        public void OnMusicSettingValueChange(float value)
        {
            GameEntry.Sound.SetVolume("Music", value);
        }

        public void OnSoundSettingValueChange(float value)
        {
            GameEntry.Sound.SetVolume("Sound", value);
            GameEntry.Sound.SetVolume("UISound", value);
        }

    }
}
