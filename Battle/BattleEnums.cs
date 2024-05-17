﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BooBoo.Battle
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum InputType
    {
        None,

        _1,
        _2,
        _3,
        _4,
        _5,
        _6,
        _7,
        _8,
        _9,
        Crouching_Any,
        Standing_Any,
        Aerial_Any,

        _236,
        _214,
        _41236,
        _63214,
        _623,
        _421,
        _66,
        _44,
    }

    [Flags]
    public enum ButtonType
    {
        A = 0b_0000_0000_0000_0001,
        B = 0b_0000_0000_0000_0010,
        C = 0b_0000_0000_0000_0100,
        D = 0b_0000_0000_0000_1000,
        E = 0b_0000_0000_0001_0000,
        F = 0b_0000_0000_0010_0000,
        G = 0b_0000_0000_0100_0000,
        H = 0b_0000_0000_1000_0000,

        Charge = 0b_0001_0000_0000_0000,
        Release = 0b_0010_0000_0000_0000,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum CounterType
    {
        None,
        Normal,
        High,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum CancelType
    {
        Whenever,
        OnlyNeutral,
        OnlyHitOrBlock,
        OnlyWhenSpecified,
    }

    public enum StatePosition
    {
        Standing,
        Crouching,
        Aerial
    }

    public enum StateType
    {
        Neutral,
        Normal,
        Special,
        Super,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FloorType
    {
        Concrete,
        Wood,
        Glass,
        Water,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ShadowType
    {
        None,
        Shadow,
        Reflection,
        WaterReflection,
        ShadowAndReflection,
        Custom,
    }

    [Flags]
    public enum CollisionFlags
    {
        None = 0,

        //Push box and position checks
        StageWall = 0b_0000_0000_0000_0001, //Collide with wall at edge of stage
        DistanceWall = 0b_0000_0000_0000_0010, //Collide with wall at max player distances
        Floor = 0b_0000_0000_0000_0100, //Collide with the floor
        ActorsOnDifferentTeams = 0b_0000_0000_0000_1000, //Collide with all actors that dont have the same player as this
        ActorsOnSameTeam = 0b_0000_0000_0001_0000, //Collide with actors that have the same player as this

        //Attack checks
        Invincible = 0b_0000_0000_0010_0000, //Hit boxes cant detect hurt boxes
        GrabInvincible = 0b_0000_0000_0100_0000, //Grab boxes cant detect push boxes
        HitboxesCanHit = 0b_0000_0000_1000_0000, //Hit boxes are allowed to detect other boxes
        AttackMembersOfSameTeam = 0b_0000_0001_0000_0000, //This actor can attack actors that have the same player as this

        //Misc box checks
        MiscCountsAsHurt = 0b_0000_0010_0000_0000,
        MiscCountAsHit = 0b_0000_0100_0000_0000,
        MiscCountsAsObjLink = 0b_0000_1000_0000_0000,
        MiscCallsFuncOnOverlap = 0b_0001_0000_0000_0000,

        

        //Macros
        DefaultSettings = StageWall | Floor | ActorsOnDifferentTeams | HitboxesCanHit,
        DefaultPlayerSettings = StageWall | Floor | DistanceWall | ActorsOnDifferentTeams | HitboxesCanHit,
        CheckerObject = Invincible | GrabInvincible | MiscCallsFuncOnOverlap,
    }
}
