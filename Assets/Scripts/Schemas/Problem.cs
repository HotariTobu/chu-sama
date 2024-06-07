using System;

[Serializable]
record Problem
{
    public int DifficultyLevel = default!;
    public string Body = default!;
    public Option[] Options = default!;
}
