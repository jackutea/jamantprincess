using System;
using System.Collections.Generic;
using UnityEngine;

namespace JackUtil {

    public abstract class BTContext : MonoBehaviour {

        public abstract T GetData<T>(string _dataName) where T : MonoBehaviour;

    }

}