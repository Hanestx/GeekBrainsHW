using UnityEngine;


namespace Code.Json
{
    internal sealed class CompositeJson
    { 
        public UnitJsonList ParseJSON(TextAsset json)
        {
            return JsonUtility.FromJson<UnitJsonList>(json.text);
        }

        public void UnitFromJson(UnitJsonList unitJsonList)
        {
            if (unitJsonList == null)
            {
                return;
            }
            
            foreach (var unit in unitJsonList.unit)
            {
                switch (unit.type)
                {
                    case "mag":
                        IUnitFactory factoryMag = new MagFactory();
                        var mag = factoryMag.Create(unit.type,new Health(unit.health));
                        Debug.Log(mag.ToString());
                        break;
                    case "infantry":
                        IUnitFactory factoryInfantry = new InfantryFactory();
                        var infantry = factoryInfantry.Create(unit.type,new Health(unit.health));
                        Debug.Log(infantry.ToString());
                        break;
                    default:
                        Debug.Log("Такого типа Юнитов не найдено");
                        break;
                        
                }
            }
        }
    }
}