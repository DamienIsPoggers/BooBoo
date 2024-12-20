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
        _236236,
        _214214
    }

    [JsonConverter(typeof(StringEnumConverter))]
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

        AB = A | B,
        ABC = AB | C,
        ABCD = ABC | D,
        BC = B | C,
        BCD = BC | D,
        AC = A | C,
        ACD = AC | D,
        CD = C | D,
        BD = B | D,
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

    public enum AttackHitAttribute
    {
        Body,
        Low,
        High,
        Projectile
    }

    [JsonConverter(typeof(StringEnumConverter))]
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

        //Attack Hit Attribute specific invuls
        //if you want body invul just add normal invul :skull:
        InvulLow = 0b_0010_0000_0000_0000,
        InvulHigh = 0b_0100_0000_0000_0000,
        InvulProjectile = 0b_1000_0000_0000_0000,

        

        //Macros
        DefaultSettings = StageWall | Floor | ActorsOnDifferentTeams | HitboxesCanHit,
        DefaultPlayerSettings = StageWall | Floor | DistanceWall | ActorsOnDifferentTeams | HitboxesCanHit,
        CheckerObject = Invincible | GrabInvincible | MiscCallsFuncOnOverlap,
    }

    public enum HitstunStates
    {
        None,

        //These are hitstun states on the ground. They are X frames of hitstun plus Y frames in state
        CmnHurtStandWeak, //X frames + 6
        CmnHurtStandMedium, //X frames + 9
        CmnHurtStandHeavy, //X frames + 15

        CmnHurtGutWeak, //X frames + 6
        CmnHurtGutMedium, //X frames + 9
        CmnHurtGutHeavy, //X frames + 15

        CmnHurtCrouchWeak, //X frames + 6
        CmnHurtCrouchMedium, //X frames + 9
        CmnHurtCrouchHeavy, //X frames + 15

        CmnHurtStagger, //This guy is special where it loops until you either go into CmnHurtCrumple or wake up
        CmnHurtCrumple, //Little inbetween anim. Lingers on final frame until wake up. Entire anim should be 30 frames

        //These are the air states. No special properties
        CmnHurtLaunch, //When going up
        CmnHurtLaunchToFall, //An inbetween state for anim reasons. Acts the sam as fall
        CmnHurtFall, //Going back down
        CmnHurtTrip, //Used for falling forward reasons such as trip moves

        CmnHurtBlowback, //Used when its a really strong hit in one direction, usually leading in a wall stick/bounce
        CmnHurtWallStick, //Used for when on the wall

        //CmnHurtSpinySpinSpin, //Hard to explain. Just spin around then goes into CmnHurtGroundSlide. Also points to whoever gets the reference
        CmnHurtDiagonalSpin, //Funny little diagonal spin. Basically acts as another anim for launch for variety

        //These are OTG states. All of them linger on the final frame until hitstun is done
        CmnHurtLandFall, //Landing from CmnHurtFall. Should be 25 frames
        CmnHurtLandTrip, //Landing from CmnHurtTrip. Should be 20 frames

        //CmnHurtGroundSlide, //When landing from spiny spin spin. Will go into CmnHurtGroundSlideEnd once momentum ends
        //CmnHurtGroundSlideEnd,
        
        //Wake up states
        CmnHurtWakeUpAir, //When waking up in the air.
        CmnHurtWakeUpGround, //When waking up on the ground.
        CmnHurtWakeUpLand, //When landing from wake up states.

        CmnHurtWakeUpLazy, //When you wait to do a slow wake up. Should be 24 frames.
    }
}
