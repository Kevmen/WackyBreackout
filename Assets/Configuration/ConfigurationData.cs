using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 10;
    static float ballImpulseForce = 10;
    static float ballLifeTime = 10;
    static float minSpawnTime = 5;
    static float maxSpawnTime = 10;
    static int standarBlockPoints = 20;
    static int bonusBlockPoints = 40;
    static int pickUpBlockPoints = 10;
    static float standardprobability = 0.5f;
    static float bonusProbability = 0.3f;
    static float pickupProbability = 0.2f;
    static int ballsLeft = 10;
    static float freezerEffect = 2.0f;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    public float BallLifeTime
    {
        get { return ballLifeTime; }
    }

    public float MinSpawnTimer
    {
        get { return minSpawnTime; }
    }
    public float MaxSpawnTimer
    {
        get { return maxSpawnTime; }
    }

    public int StandardBlockPoints
    {
        get { return standarBlockPoints; }
    }
    public int BonusBlockPoints
    {
        get { return bonusBlockPoints; }
    }

    public int PickUpBlockPoints
    {
        get { return pickUpBlockPoints; }
    }

    public float StandardProbability
    {
        get { return standardprobability; }
    }

    public float BonusProbability
    {
        get { return bonusProbability; }
    }


    public float PickupProbability
    {
        get { return pickupProbability; }
    }

    public int BallsLeft
    {
        get { return ballsLeft; }
    }

    public float FreezerEffect
    {
        get { return freezerEffect; }
    }




    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        // read and save configuration data from file
        StreamReader input = null;
        try
        {
            // create stream reader object
            input = File.OpenText(Path.Combine(
                Application.streamingAssetsPath, ConfigurationDataFileName));

            // read in names and values
            string names = input.ReadLine();
            string values = input.ReadLine();

            // set configuration data fields
            SetConfigurationDataFields(values);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
        finally
        {
            // always close input file
            if (input != null)
            {
                input.Close();
            }
        }
    }

    /// <summary>
    /// Sets the configuration data fields from the provided
    /// csv string
    /// </summary>
    /// <param name="csvValues">csv string of values</param>
    static void SetConfigurationDataFields(string csvValues)
    {
        // the code below assumes we know the order in which the
        // values appear in the string. We could do something more
        // complicated with the names and values, but that's not
        // necessary here
        string[] values = csvValues.Split(',');
        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = float.Parse(values[1]);
        ballLifeTime = float.Parse(values[2]);
        minSpawnTime = float.Parse(values[3]);
        maxSpawnTime = float.Parse(values[4]);
        standarBlockPoints = int.Parse(values[5]);
        bonusBlockPoints = int.Parse(values[6]);
        pickUpBlockPoints = int.Parse(values[7]);
        standardprobability = float.Parse(values[8]);
        bonusProbability = float.Parse(values[9]);
        pickupProbability = float.Parse(values[10]);
        ballsLeft = int.Parse(values[11]);
        freezerEffect = float.Parse(values[12]);
    }

    #endregion
}
