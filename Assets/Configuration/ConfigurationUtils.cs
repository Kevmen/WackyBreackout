using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
        static ConfigurationData Configuration;
    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return Configuration.PaddleMoveUnitsPerSecond; }
    }

    public static float BallImpulseForce
    {
        get { return Configuration.BallImpulseForce; }
    }

    public static float BallLifeTime
    {
        get { return Configuration.BallLifeTime; }
    }

    public static float MinSpawnTime
    {
        get { return Configuration.MinSpawnTimer; }
    }
    public static float MaxSpawnTime
    {
        get { return Configuration.MaxSpawnTimer; }
    }

    public static int StandardBlockPoints
    {
        get { return Configuration.StandardBlockPoints; }
    }

    public static int BonusBlockpoints
    {
        get { return Configuration.BonusBlockPoints; }
    }

    public static int PickUpBlockPoints
    {
        get { return Configuration.PickUpBlockPoints; }
    }

    public static float StandardProbability
    {
        get { return Configuration.StandardProbability; }
    }

    public static float BonusProbability
    {
        get { return Configuration.BonusProbability; }
    }

    public static float PickupProbability
    {
        get { return Configuration.PickupProbability; }
    }

    public static int BallsLeft
    {
        get { return Configuration.BallsLeft; }
    }

    public static float FreezerEffect
    {
        get { return Configuration.FreezerEffect; }
    }



    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    /// 

    public static void Initialize()
    {
        Configuration = new ConfigurationData();
        

    }
}
