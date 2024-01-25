﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum SpeedType
    {
        Slow,
        Normal,
        Fast,
        Variation,
    }

    public enum WorldObject
    {
        Unknown,
        Player,
        Monster,
    }

	public enum State
	{
		Die,
		Moving,
		Idle,
		Skill,
	}

    public enum Layer
    {
        Platform = 6,
        Monster = 8,
        Ground = 9,
        Block = 10,
    }

    public enum Scene
    {
        Unknown,
        Title,
        Game,
    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }

    public enum UIEvent
    {
        Click,
        Drag,
        PointerDown,
        PointerUp,
    }

    public enum MouseEvent
    {
        Press,
        PointerDown,
        PointerUp,
        Click,
    }

    public enum CameraMode
    {
        QuarterView,
    }
}
