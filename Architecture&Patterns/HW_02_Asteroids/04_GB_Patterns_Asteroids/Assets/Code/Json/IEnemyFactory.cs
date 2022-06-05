namespace Code.Json
{
    internal interface IUnitFactory
    {
        Unit Create(string type, Health hp);
    }
}