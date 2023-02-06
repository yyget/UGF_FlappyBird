using GameFramework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace StarForce
{
    public class GameOverForm : UGuiForm
    {
        public TMP_Text Score;
        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            //��ȡ����
            int score = GameEntry.DataNode.GetNode("Score").GetData<VarInt32>();
            Score.text = "score:" + score;
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
            Score.text = string.Empty;
        }

        public void OnRestartButtonClick()
        {
            Close(true);
            //�ɷ����¿�ʼ��Ϸ�¼�
            GameEntry.Event.Fire(this, ReferencePool.Acquire<RestartEventArgs>());

            //��ʾС��
            GameEntry.Entity.ShowBird(new BirdData(GameEntry.Entity.GenerateSerialId(), 3, 5f));
        }

        public void OnReturnButtonClick()
        {
            Close(true);
            //�ɷ����ز˵������¼�
            GameEntry.Event.Fire(this, ReferencePool.Acquire<ReturnMenuEventArgs>());
        } 
    }
}

