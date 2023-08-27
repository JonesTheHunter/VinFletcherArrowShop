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

string? userInput;
Arrows arrow = new();

//MAIN GAME LOOP START
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
                      "                                                                    \n");

    Console.Write("Pick arrowhead type: ");

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


Arrows arrow2 = new();

    Console.Write("Pick arrowhead type: ");

while(arrow2.ArrowheadIsUnknown())
{   
    userInput = Console.ReadLine();
    if(UserTypedExit(userInput))
    {
        return;
    }
    var arrowhead = Arrows.Arrowhead.Unknown;
    arrow2.TrySetArrowheadType(userInput, out arrowhead);
    arrow2.ArrowheadType = arrowhead;
}

    Console.Write("Pick length of arrow shaft (60-100cm): ");

while(!arrow2.ArrowShaftIsCorrectLength())
{
    userInput = Console.ReadLine();
    if(UserTypedExit(userInput))
    {
        return;
    }
    var length = arrow.Length;
    arrow2.TrySetShaftLength(userInput, out length);
    arrow2.Length = length;
}

    Console.Write("Pick Fletchling Type: ");

while(arrow2.FletchlingIsUnknown())
{
    userInput = Console.ReadLine();
        if(UserTypedExit(userInput))
    {
        return;
    }
    var fletchling = Arrows.Fletchling.Unknown;
    arrow2.TrySetFletchlingType(userInput, out fletchling);
    arrow2.FletchlingType = fletchling;
}

Console.WriteLine($"Arrow 1: You picked a arrow with a {arrow.ArrowheadType} arrowhead, \n" +
                  $"with a length of {arrow.Length}cm, with {arrow.FletchlingType} fletchling.\n" +
                  $"The total is: {arrow.GetCost()}g. \n");


Console.WriteLine($"Arrow 2: You picked a arrow with a {arrow2.ArrowheadType} arrowhead, \n" +
                  $"with a length of {arrow2.Length}cm, with {arrow2.FletchlingType} fletchling.\n" +
                  $"The total is: {arrow2.GetCost()}g. \n");
//MAIN GAME LOOP END

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
    
    public Arrowhead ArrowheadType { get; set; }
    public float Length { get; set; }
    public Fletchling FletchlingType { get; set; }

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
