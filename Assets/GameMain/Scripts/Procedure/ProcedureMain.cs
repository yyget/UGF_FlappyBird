//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace StarForce
{
    public class ProcedureMain : ProcedureBase
    {
        private const float GameOverDelayedSeconds = 2f;

        private readonly Dictionary<GameMode, GameBase> m_Games = new Dictionary<GameMode, GameBase>();
        private GameBase m_CurrentGame = null;
        private bool m_GotoMenu = false;
        private float m_GotoMenuDelaySeconds = 0f;

        /// <summary>
        /// 管道产生时间
        /// </summary>
        private float m_PipeSpawnTime = 0f;

        /// <summary>
        /// 管道产生计时器
        /// </summary>
        private float m_PipeSpawnTimer = 0f;

        public override bool UseNativeDialog
        {
            get
            {
                return false;
            }
        }

        public void GotoMenu()
        {
            m_GotoMenu = true;
        }

        protected override void OnInit(ProcedureOwner procedureOwner)
        {
            base.OnInit(procedureOwner);

            m_Games.Add(GameMode.Survival, new SurvivalGame());
        }

        protected override void OnDestroy(ProcedureOwner procedureOwner)
        {
            base.OnDestroy(procedureOwner);

            m_Games.Clear();
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            //m_GotoMenu = false;
            //GameMode gameMode = (GameMode)procedureOwner.GetData<VarByte>("GameMode").Value;
            //m_CurrentGame = m_Games[gameMode];
            //m_CurrentGame.Initialize();

            GameEntry.Entity.ShowBg(new BgData(GameEntry.Entity.GenerateSerialId(), 1, 1f, 0));
            GameEntry.Entity.ShowBird(new BirdData(GameEntry.Entity.GenerateSerialId(), 3, 5f));
            //设置初始管道产生时间
            m_PipeSpawnTime = Random.Range(3f, 5f);

        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            if (m_CurrentGame != null)
            {
                m_CurrentGame.Shutdown();
                m_CurrentGame = null;
            }

            base.OnLeave(procedureOwner, isShutdown);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            m_PipeSpawnTimer += elapseSeconds;
            if (m_PipeSpawnTimer >= m_PipeSpawnTime)
            {
                m_PipeSpawnTimer = 0;
                //随机设置管道产生时间
                m_PipeSpawnTime = Random.Range(3f, 5f);

                //产生管道
                GameEntry.Entity.ShowPipe(new PipeData(GameEntry.Entity.GenerateSerialId(), 2, 1f));

            }
            //if (m_CurrentGame != null && !m_CurrentGame.GameOver)
            //{
            //    m_CurrentGame.Update(elapseSeconds, realElapseSeconds);
            //    return;
            //}

            //if (!m_GotoMenu)
            //{
            //    m_GotoMenu = true;
            //    m_GotoMenuDelaySeconds = 0;
            //}

            //m_GotoMenuDelaySeconds += elapseSeconds;
            //if (m_GotoMenuDelaySeconds >= GameOverDelayedSeconds)
            //{
            //    procedureOwner.SetData<VarInt32>("NextSceneId", GameEntry.Config.GetInt("Scene.Menu"));
            //    ChangeState<ProcedureChangeScene>(procedureOwner);
            //}
        }
    }
}
