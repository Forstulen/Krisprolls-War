﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class WaveModel
    {

        //Attributes
        public int              Number;
        public float            WaitingTime;
        public FollowingPath    Path;
        public EnemyType[]     _enemyCollections;
        public int             _ExtraReward;

        public WaveModel(EnemyType[] ennemies, FollowingPath path, float waitingTime, int number, int extraReward) {
            _enemyCollections = ennemies;
            WaitingTime = waitingTime;
            Path = path;
            Number = number;
            _ExtraReward = extraReward;
        }


    }

}