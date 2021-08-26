
namespace Wiederholung
{
    class Generics<DataType, SecondDataType> // erstellt eine Klasse welche für jeden Datentypen (nur die benutzten) eine Kopie für diesen datentypen erstellt
    {
        DataType data; // Der Platzhalter "DataType" wird beim kompilieren ersetzt durch den gewünschten datentypen
        SecondDataType otherData;
    }

    class ClassWithGenericMethod
    {
        DataType GenericMethod<DataType>(DataType parameter) // auch einzelne Methoden können ein Generic sein. Für jeden benötigte Variante wird dann vom Compiler eine Überladung erzeugt
        {
            return parameter;
        }
    }


}
