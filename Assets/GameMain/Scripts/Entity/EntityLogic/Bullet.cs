//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework.Event;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace StarForce
{
    /// <summary>
    /// 子弹类。
    /// </summary>
    public class Bullet : Entity
    {
        [SerializeField]
        private BulletData m_BulletData = null;

        //public ImpactData GetImpactData()
        //{
        //    return new ImpactData(m_BulletData.OwnerCamp, 0, m_BulletData.Attack, 0);
        //}

#if UNITY_2017_3_OR_NEWER
        protected override void OnInit(object userData)
#else
        protected internal override void OnInit(object userData)
#endif
        {
            base.OnInit(userData);
        }

#if UNITY_2017_3_OR_NEWER
        protected override void OnShow(object userData)
#else
        protected internal override void OnShow(object userData)
#endif
        {
            base.OnShow(userData);

            m_BulletData = userData as BulletData;
            if (m_BulletData == null)
            {
                Log.Error("Bullet data is invalid.");
                return;
            }
            CachedTransform.SetLocalScaleX(1.8f);
            CachedTransform.position = m_BulletData.ShootPostion;
            //监听小鸟死亡事件
            GameEntry.Event.Subscribe(BirdDeadEventArgs.EventId, OnBirdDead);
        }

#if UNITY_2017_3_OR_NEWER
        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
#else
        protected internal override void OnUpdate(float elapseSeconds, float realElapseSeconds)
#endif
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            CachedTransform.Translate(Vector2.right * m_BulletData.FlySpeed * elapseSeconds, Space.World);


            //已达到最大飞行距离
            if (CachedTransform.position.x >= 9.1f)
            {
                GameEntry.Entity.HideEntity(this);
            } 
        }
        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown,userData);
            //取消监听小鸟死亡事件
            GameEntry.Event.Unsubscribe(BirdDeadEventArgs.EventId, OnBirdDead);
        }
        private void OnBirdDead(object sender, GameEventArgs e)
        {
            //小鸟死亡后立即隐藏自身
            GameEntry.Entity.HideEntity(this);
        } 
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //隐藏管道与自身
            GameEntry.Sound.PlaySound(1);
            collision.gameObject.SetActive(false);
            GameEntry.Entity.HideEntity(this);
        }
         
    }
}
