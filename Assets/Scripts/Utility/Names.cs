using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Names
{
    private static List<string> _names = new List<string>
    {
    "Bacon Button",
    "Waffle Whacker",
    "Pixel Pusher",
    "Cookie Cruncher",
    "Sloth Slapper",
    "Donut Dynamo",
    "Meme Machine",
    "Sprocket Squeezer",
    "Unicorn Uplifter",
    "Taco Tapper",
    "Rainbow Roller",
    "Biscuit Basher",
    "Cactus Clicker",
    "Bubble Blaster",
    "Pineapple Puncher",
    "Goblin Grabber",
    "Squirrel Spinner",
    "Banana Bouncer",
    "Cupcake Crusher",
    "Dragon Dribbler"
    };

    public static string GetRandomName()
    {
        return _names[Random.Range(0, _names.Count - 1)];
    }
}
