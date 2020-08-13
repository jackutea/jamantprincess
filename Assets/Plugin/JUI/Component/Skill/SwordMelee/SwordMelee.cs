using System;
using System.Collections.Generic;
using UnityEngine;

namespace JackUtil {

    public class SwordMelee : JSkillBase {

        void Update() {

            transform.position = transform.parent.position;

        }

    }
}