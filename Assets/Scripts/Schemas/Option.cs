using System;

[Serializable]
record Option
{
    public bool IsCorrect = default!;
    public string Body = default!;
}
