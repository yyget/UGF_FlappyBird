//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

namespace StarForce
{
    /// <summary>
    /// 界面编号。
    /// </summary>
    public enum UIFormId : byte
    {
        Undefined = 0,

        /// <summary>
        /// 菜单界面
        /// </summary>
        MenuForm = 1,

        /// <summary>
        /// 设置界面
        /// </summary>
        SettingForm = 2,

        /// <summary>
        /// 积分界面
        /// </summary>
        ScoreForm = 3,

        /// <summary>
        /// 游戏结束界面
        /// </summary>
        GameOverForm = 4
    }
}
