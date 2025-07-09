using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller;

/// <summary>
/// This class represents a die that can have any number 
/// of sides between 1 and 255 inclusive.
/// 
/// It provides a method to roll the die, which returns a random number
/// between 1 and the number of sides on the die.
/// </summary>
public class Die
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Die"/> class with the specified number of sides.
    /// </summary>
    /// <param name="_NumberOfSides">The number of sides for the die. Must be between 1 and 255, inclusive.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="_NumberOfSides"/> is less than 1 or greater than 255.</exception>
    public Die(Byte _NumberOfSides)
    {
        if (_NumberOfSides < 1 || _NumberOfSides > 255)
        {
            throw new ArgumentOutOfRangeException(nameof(_NumberOfSides)
                , $"{nameof(_NumberOfSides)} must be between 1 and 255.");
        }
        NumberOfSides = _NumberOfSides;

        FaceUpValue = Roll();
    }

    /// <summary>
    /// A random number generator used to simulate rolling the die.
    /// The random number generator is static so that it is shared between
    /// all instances of the Die class.
    /// </summary>
    private static readonly Random rand = new Random();

    /// <summary>
    /// The number of sides on the die.
    /// can be set to any value between 1 and 255 inclusive.
    /// default is 6.
    /// </summary>
    public byte NumberOfSides { get; private set; } = 6;

    /// <summary>
    /// The current face-up value of the die.
    /// </summary>
    public byte FaceUpValue { get; private set; }

    /// <summary>
    /// This method simulates rolling the die.
    /// The result is stored in the FaceUpValue property
    /// The Result is also returned as an integer.
    /// </summary>
    /// <returns>A byte representing the face-up value of the die</returns>
    public byte Roll()
    {
        FaceUpValue = (byte) rand.Next(1, NumberOfSides + 1);
        return FaceUpValue;
    }
}
