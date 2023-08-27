/*TODO
All arrows have 3 parts:
[NAME]                Arrowhead 
    [TYPE]      Steel, Wood, Obsidian
   [Price]        10g,   3g,       5g

[NAME]                Shaft
  [Length]          60 - 100cm
   [Price]           0.05g/cm

[NAME]              Fletchling
    [TYPE]     Plastic, Turkey Feather, Goose Feathers
   [PRICE]         10g,             5g,             3g

- Define a new Arrow class with fields for the arrowhead type, fletchling type, and length
- Allow a user to pick the arrowhead, fletchling type, and length and then create a new Arrow instance.
- Add a GetCost method that returns its cost as a float based on the numbers above, use this to display
  arrow cost.
*/

using System.Text.Json;
using Microsoft.VisualBasic;

string? userInput;
Arrows arrow = new();
Arrows elitearrow = Arrows.CreateEliteArrow();
Arrows beginnerarrow = Arrows.CreateBeginnerArrow();
Arrows marksmanarrow = Arrows.CreateMarksManArrow();

    Console.WriteLine("                               Arrowhead                            \n" +
                      "                  Steel,   |    Wood,   |    Obsidian               \n" +
                      "                     10g,  |      3g,   |          5g               \n" +
                      "--------------------------------------------------------------------\n" +
                      "                                Shaft                               \n" +
                      "                              60 - 100cm                            \n" +
                      "                                0.05g/cm                            \n" +
                      "--------------------------------------------------------------------\n" +
                      "                             Fletchling                             \n" +
                      "            Plastic,   |     Goose Feather,   |     Turkey Feather  \n" +
                      "                10g,   |                3g,   |                 5g  \n" +
                      "--------------------------------------------------------------------\n" +
                      "                                                                    \n\n");

    Console.WriteLine("Current Presets: \n" +
                     $"[1] Name: {elitearrow.Name}\n" +
                     $"Arrowhead: {elitearrow.ArrowheadType}\n" +
                     $"Length: {elitearrow.Length}\n" +
                     $"Fletchling: {elitearrow.FletchlingType}\n" +
                     $"Cost: {elitearrow.GetCost()}\n");

    Console.WriteLine($"[2] Name: {beginnerarrow.Name}\n" +
                     $"Arrowhead: {beginnerarrow.ArrowheadType}\n" +
                     $"Length: {beginnerarrow.Length}\n" +
                     $"Fletchling: {beginnerarrow.FletchlingType}\n" +
                     $"Cost: {beginnerarrow.GetCost()}\n");
              
    Console.WriteLine($"[3] Name: {marksmanarrow.Name}\n" +
                     $"Arrowhead: {marksmanarrow.ArrowheadType}\n" +
                     $"Length: {marksmanarrow.Length}\n" +
                     $"Fletchling: {marksmanarrow.FletchlingType}\n" +
                     $"Cost: {marksmanarrow.GetCost()}\n");

var userChoice = Console.ReadLine();
    if(int.Parse(userChoice) == 1)
    {
        arrow = elitearrow;
        Console.WriteLine($"You picked a arrow with a {arrow.ArrowheadType} arrowhead, \n" +
                  $"with a length of {arrow.Length}cm, with {arrow.FletchlingType} fletchling.\n" +
                  $"The total is: {arrow.GetCost()}g. \n");
    }
    else if(int.Parse(userChoice) == 2)
    {
        arrow = beginnerarrow;
        Console.WriteLine($"You picked a arrow with a {arrow.ArrowheadType} arrowhead, \n" +
                  $"with a length of {arrow.Length}cm, with {arrow.FletchlingType} fletchling.\n" +
                  $"The total is: {arrow.GetCost()}g. \n");
    }
    else if(int.Parse(userChoice) == 3)
    {
        arrow = marksmanarrow;
        Console.WriteLine($"You picked a arrow with a {arrow.ArrowheadType} arrowhead, \n" +
                  $"with a length of {arrow.Length}cm, with {arrow.FletchlingType} fletchling.\n" +
                  $"The total is: {arrow.GetCost()}g. \n");
    }
    else{
        while(arrow.ArrowheadIsUnknown())
        {   
            userInput = Console.ReadLine();
            if(UserTypedExit(userInput))
            {
                return;
            }
            Arrows.Arrowhead arrowhead;
            arrow.TrySetArrowheadType(userInput, out arrowhead);
            arrow.ArrowheadType = arrowhead;
        }

            Console.Write("Pick length of arrow shaft (60-100cm): ");

        while(!arrow.ArrowShaftIsCorrectLength())
        {
            userInput = Console.ReadLine();
            if(UserTypedExit(userInput))
            {
                return;
            }
            var length = arrow.Length;
            arrow.TrySetShaftLength(userInput, out length);
            arrow.Length = length;
        }

            Console.Write("Pick Fletchling Type: ");

        while(arrow.FletchlingIsUnknown())
        {
            userInput = Console.ReadLine();
                if(UserTypedExit(userInput))
            {
                return;
            }
            var fletchling = Arrows.Fletchling.Unknown;
            arrow.TrySetFletchlingType(userInput, out fletchling);
            arrow.FletchlingType = fletchling;
        }


        Console.WriteLine($"You picked a arrow with a {arrow.ArrowheadType} arrowhead, \n" +
                        $"with a length of {arrow.Length}cm, with {arrow.FletchlingType} fletchling.\n" +
                        $"The total is: {arrow.GetCost()}g. \n");
    }                


bool UserTypedExit(string userInput)
{
    return userInput.ToLower() == "exit";
}

public class Arrows
{

    public Arrows()
    {
        ArrowheadType = Arrowhead.Unknown;
        Length = 0f;
        FletchlingType = Fletchling.Unknown;
    }
    public Arrows(Arrowhead arrowhead, float length, Fletchling fletchling)
    {
        ArrowheadType = arrowhead;
        Length = length;
        FletchlingType = fletchling;
    }

        public Arrows(string name, Arrowhead arrowhead, float length, Fletchling fletchling)
    {
        Name = name;
        ArrowheadType = arrowhead;
        Length = length;
        FletchlingType = fletchling;
    }
    
    public static Arrows CreateEliteArrow() => new Arrows("Elite Arrow", Arrowhead.Steel, 95, Fletchling.Plastic);
    public static Arrows CreateBeginnerArrow() => new Arrows("Beginner Arrow", Arrowhead.Wood, 75f, Fletchling.GooseFeather);
    public static Arrows CreateMarksManArrow() => new Arrows("Marksman Arrow", Arrowhead.Steel, 65, Fletchling.GooseFeather);
    public Arrowhead ArrowheadType { get; set; }
    public float Length { get; set; }
    public Fletchling FletchlingType { get; set; }
    public string Name {get; init; }

    public bool ArrowheadIsUnknown()
    {
        return ArrowheadType == Arrowhead.Unknown;
    }

    public bool ArrowShaftIsCorrectLength()
    {
        return Length >= 60 && Length <= 100;
    }
    public bool FletchlingIsUnknown()
    {
        return FletchlingType == Fletchling.Unknown;
    }

    public bool TrySetArrowheadType(string userInput, out Arrowhead arrowheadType)
    {
        switch(userInput.ToLower())
        {
            case "steel":
                arrowheadType = Arrowhead.Steel;
                return true;
            case "obsidian":
                arrowheadType = Arrowhead.Obsidian;
                return true;
            case "wood":
                arrowheadType = Arrowhead.Wood;
                return true;
            default:
                Console.Write("Invalid type, please choose an arrowhead type: ");
                arrowheadType = Arrowhead.Unknown;
                return false;
        }
    }
    
    public bool TrySetShaftLength(string userInput, out float length)
    {
        if(Single.TryParse(userInput, out length))
        {
            if(length >= 60 && length <= 100)
            {
                return true;
            }
        }
        Console.Write("Incorrect Length, please choose length (60-100cm): ");
        return false;
    }
    public bool TrySetFletchlingType(string userInput, out Fletchling fletchlingType)
    {
        switch(userInput.ToLower())
        {
            case "plastic":
                fletchlingType = Fletchling.Plastic;
                return true;
            case "goose feather":
            case "goosefeather":
                fletchlingType = Fletchling.GooseFeather;
                return true;
            case "turkey feather":
            case "turkeyfeather":
                fletchlingType = Fletchling.TurkeyFeather;
                return true;
            default:
                fletchlingType = Fletchling.Unknown;
                Console.Write("Invalid type, please choose an feltchling type: ");
                return false;
        }
    }

    public float GetCost()
    {
        return (int)ArrowheadType + (int)FletchlingType + (Length * 0.05f);
    }

    
    public enum Arrowhead
    {
        Unknown = 0,
        Steel = 10,
        Wood = 3,
        Obsidian = 5
    }

    public enum Fletchling
    {
        Unknown = 0,
        Plastic = 10,
        TurkeyFeather = 5,
        GooseFeather = 3
    }

}
