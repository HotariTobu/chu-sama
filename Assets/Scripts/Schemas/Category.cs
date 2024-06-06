using System;

[Serializable]
record Category
{
    public Problem[] Problems = default!;
}
