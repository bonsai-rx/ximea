using xiApi.NET;
using System.ComponentModel;

class SerialNumberConverter : StringConverter
{
    public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
    {
        return true;
    }

    public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
    {
        var camEnum = new xiCamEnum();
        var camCount = camEnum.ReEnumerate();
        var camSerialNumber = new string[camCount];
        for (int i = 0; i < camCount; i++)
        {
            camSerialNumber[i] = camEnum.GetSerialNumById(i);
        }
        return new StandardValuesCollection(camSerialNumber);
    }
}