using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class JamBTContext : BTContext {

        public override T GetData<T>(string _dataName) {

            DebugUtil.LogError("无该数据: " + _dataName);
            return null;

        }

    }

}