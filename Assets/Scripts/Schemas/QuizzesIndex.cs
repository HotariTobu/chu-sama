using System;

[Serializable]
record QuizzesIndex
{
    public CategoryIndex[] Categories = default!;
}
