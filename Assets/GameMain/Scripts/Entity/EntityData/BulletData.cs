//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System;
using UnityEngine;

namespace StarForce
{
    [Serializable]
    public class BulletData : EntityData
    {
        /// <summary>
        /// 发射位置
        /// </summary>
        public Vector2 ShootPostion { get; private set; }

        /// <summary>
        /// 飞行速度
        /// </summary>
        public float FlySpeed { get; private set; }

        public BulletData(int entityId, int typeId, Vector2 shootPositoin, float flySpeed) : base(entityId, typeId)
        {

            ShootPostion = shootPositoin;
            FlySpeed = flySpeed;

        }

 
    }
}
