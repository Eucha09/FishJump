using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// json 형식의 파일 내용을 저장할 데이터 class들 정의
namespace Data
{
    /*ex)
    #region Stat

    [Serializable]
    public class Stat
    {
       public int level;
       public int maxHp;
       public int attack;
       public int totalExp;
    }

    [Serializable]
    public class StatData : ILoader<int, Stat>
    {
       public List<Stat> stats = new List<Stat>();

       public Dictionary<int, Stat> MakeDict()
       {
           Dictionary<int, Stat> dict = new Dictionary<int, Stat>();
           foreach (Stat stat in stats)
               dict.Add(stat.level, stat);
           return dict;
       }
    }

    #endregion
	*/

    #region TimeToClose

    [Serializable]
    public class TimeToClose
    {
        public int level;
        public int slow;
        public int normal;
        public int fast;
        public int variation;
    }

    [Serializable]
    public class TimeToCloseData : ILoader<int, TimeToClose>
    {
        public List<TimeToClose> timeToClose = new List<TimeToClose>();

        public Dictionary<int, TimeToClose> MakeDict()
        {
            Dictionary<int, TimeToClose> dict = new Dictionary<int, TimeToClose>();
            foreach (TimeToClose ttc in timeToClose)
                dict.Add(ttc.level, ttc);
            return dict;
        }
    }

    #endregion

    #region TimeToBeCreated

    [Serializable]
    public class TimeToBeCreated
    {
        public int level;
        public int slow;
        public int normal;
        public int fast;
    }

    [Serializable]
    public class TimeToBeCreatedData : ILoader<int, TimeToBeCreated>
    {
        public List<TimeToBeCreated> timeToBeCreated = new List<TimeToBeCreated>();

        public Dictionary<int, TimeToBeCreated> MakeDict()
        {
            Dictionary<int, TimeToBeCreated> dict = new Dictionary<int, TimeToBeCreated>();
            foreach (TimeToBeCreated ttbc in timeToBeCreated)
                dict.Add(ttbc.level, ttbc);
            return dict;
        }
    }

    #endregion
}