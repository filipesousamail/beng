namespace beng.InventoryService.Domain;

public sealed record EStockUnit(Guid Id, string Name)
{
    public static EStockUnit Box => new EStockUnit(Guid.Parse("abe9267a-0ebb-49ec-8dcc-2acea39cd219"), "Box");
    public static EStockUnit Unit => 
        new EStockUnit(Guid.Parse("57d0a8a9-3447-445a-9a0c-ddd5034440fd"), "Unit");
}