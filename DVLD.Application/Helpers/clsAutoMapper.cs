//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace DVLD_Application
//{
//    internal static class clsAutoMapper
//    {
//        public static TDestination Map<TSource, TDestination>(TSource source)
//            where TDestination : class,new()
//        {
//            if (source == null)
//                return null;

//            TDestination destination = new TDestination();

//            // Get all public readable properties from the source
//            PropertyInfo[] sourceProperties = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);

//            // Get all public writable properties from the destination
//            PropertyInfo[] destProperties = typeof(TDestination).GetProperties(BindingFlags.Public | BindingFlags.Instance);

//            foreach (var sourceProp in sourceProperties)
//            {
//                var destProp = Array.Find(destProperties, p =>
//                    p.Name == sourceProp.Name &&
//                    p.PropertyType == sourceProp.PropertyType &&
//                    p.CanWrite);

//                if (destProp != null)
//                {
//                    var value = sourceProp.GetValue(source);
//                    destProp.SetValue(destination, value);
//                }
//            }

//            return destination;
//        }
//    }

//}

using System;
using System.Linq;
using System.Reflection;

internal static class clsAutoMapper
{
    public static TDestination Map<TSource, TDestination>(TSource source)
        where TDestination : class, new()
    {
        if (source == null)
            return null;

        TDestination destination = new TDestination();

        PropertyInfo[] sourceProperties = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        PropertyInfo[] destProperties = typeof(TDestination).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var sourceProp in sourceProperties)
        {
            var destProp = Array.Find(destProperties, p => p.Name == sourceProp.Name && p.CanWrite);
            if (destProp == null) continue;

            var sourceVal = sourceProp.GetValue(source);
            if (sourceVal == null)
            {
                destProp.SetValue(destination, null);
                continue;
            }

            Type srcType = Nullable.GetUnderlyingType(sourceProp.PropertyType) ?? sourceProp.PropertyType;
            Type dstType = Nullable.GetUnderlyingType(destProp.PropertyType) ?? destProp.PropertyType;

            // same type -> direct copy
            if (dstType == srcType)
            {
                destProp.SetValue(destination, sourceVal);
                continue;
            }

            try
            {
                // enum -> enum (convert by underlying numeric value)
                if (srcType.IsEnum && dstType.IsEnum)
                {
                    var underlying = Convert.ChangeType(sourceVal, Enum.GetUnderlyingType(srcType));
                    var enumObj = Enum.ToObject(dstType, underlying);
                    destProp.SetValue(destination, enumObj);
                    continue;
                }

                // enum -> numeric (e.g., enum -> byte/int)
                if (srcType.IsEnum && IsIntegralType(dstType))
                {
                    var underlying = Convert.ChangeType(sourceVal, Enum.GetUnderlyingType(srcType));
                    var converted = Convert.ChangeType(underlying, dstType);
                    destProp.SetValue(destination, converted);
                    continue;
                }

                // numeric -> enum (e.g., byte/int -> enum)
                if (IsIntegralType(srcType) && dstType.IsEnum)
                {
                    var numeric = Convert.ChangeType(sourceVal, Enum.GetUnderlyingType(dstType));
                    var enumObj = Enum.ToObject(dstType, numeric);
                    destProp.SetValue(destination, enumObj);
                    continue;
                }

                // fallback: try ChangeType (handles common convertible types)
                var fallback = Convert.ChangeType(sourceVal, dstType);
                destProp.SetValue(destination, fallback);
            }
            catch
            {
                // ignore conversion errors - or log if you want
            }
        }

        return destination;
    }

    static bool IsIntegralType(Type t)
    {
        return t == typeof(byte) || t == typeof(sbyte) ||
               t == typeof(short) || t == typeof(ushort) ||
               t == typeof(int) || t == typeof(uint) ||
               t == typeof(long) || t == typeof(ulong);
    }
}
