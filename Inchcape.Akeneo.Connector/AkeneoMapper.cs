using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Inchcape.Akeneo.Connector.Attributes;
using Inchcape.Akeneo.Connector.Interfaces;
using Inchcape.Akeneo.Connector.Models;

namespace Inchcape.Akeneo.Connector
{
    public static class AkeneoMapper
    {
        public static T GetValue<T>(this IPimValueDictionary dictionary, string property, string locale = "en_AU")
        {
            return GetValue<T>(dictionary, property, default, locale);
        }
        
        public static T GetValue<T>(this IPimValueDictionary dictionary, string property, T fallbackValue, string locale = "en_AU")
        {
            return (T)dictionary.Values.GetPropertyNameValue(property, typeof(T), fallbackValue, locale);
        }

        public static T Map<T>(this IPimValueDictionary dictionary) where T : class
        {
            var typeInstance = Activator.CreateInstance<T>();

            MapIdentifierProperties(dictionary, typeInstance);
            
            MapFieldProperties(dictionary, typeInstance);
            
            MapPriceProperties(dictionary, typeInstance);
            
            MapMediaFileDownloadUrlProperties(dictionary, typeInstance);
            
            MapAssociationProductsIds(dictionary, typeInstance);

            return typeInstance;
        }

        private static void MapPriceProperties<T>(IPimValueDictionary dictionary, T typeInstance) where T : class
        {
            foreach (var property in GetTypeProperties(typeInstance, typeof(PimPropertyPriceAttribute)))
            {
                var attr = property.GetCustomAttribute<PimPropertyPriceAttribute>();
                if (attr == null) continue;

                var priceCurrencyValue = dictionary.Values.GetPropertyNameValue(attr.Field, typeof(PriceCurrency[])) as PriceCurrency[];
                
                var priceValue = (priceCurrencyValue ?? Array.Empty<PriceCurrency>()).FirstOrDefault(
                    x=> x.Currency == attr.Currency
                );
                
                property.SetValue(typeInstance, priceValue?.Amount ?? 0);
            }
        }

        private static void MapFieldProperties<T>(IPimValueDictionary dictionary, T typeInstance) where T : class
        {
            foreach (var property in GetTypeProperties(typeInstance, typeof(PimPropertyFieldAttribute)))
            {
                var attr = property.GetCustomAttribute<PimPropertyFieldAttribute>();
                if (attr == null) continue;

                var propertyValue = dictionary.Values.GetPropertyNameValue(attr.Field, property.PropertyType);

                property.SetValue(typeInstance, propertyValue);
            }
        }

        private static void MapIdentifierProperties<T>(IPimValueDictionary dictionary, T typeInstance) where T : class
        {
            if (dictionary is not IPimCodeIdentifier resObject) return;
            
            foreach (var property in GetTypeProperties(typeInstance, typeof(PimIdentifierPropertyAttribute)))
            {
                var attr = property.GetCustomAttribute<PimIdentifierPropertyAttribute>();
                if (attr == null) continue;
                switch (attr.Field)
                {
                    case "code":
                        property.SetValue(typeInstance, resObject.Code);
                        break;
                    case "identifier":
                        property.SetValue(typeInstance, resObject.Identifier);
                        break;
                }
            }
        }

        private static void MapMediaFileDownloadUrlProperties<T>(IPimValueDictionary dictionary, T typeInstance) where T : class
        {
            foreach (var property in GetTypeProperties(typeInstance, typeof(PimMediaFiledDownloadUrlAttribute)))
            {
                var attr = property.GetCustomAttribute<PimMediaFiledDownloadUrlAttribute>();
                if (attr == null) continue;

                var propertyValue = dictionary.Values.GetDownloadLink(attr.Field);

                property.SetValue(typeInstance, propertyValue);
            }
        }
        
        private static void MapAssociationProductsIds<T>(IPimValueDictionary dictionary, T typeInstance) where T : class
        {
            if (dictionary is not IWithAssociations withAssocRes) return;
            
            foreach (var property in GetTypeProperties(typeInstance, typeof(PimAssociationProductAttribute)))
            {
                if (property.PropertyType.GetInterface("IEnumerable") == null) continue;
                
                var attr = property.GetCustomAttribute<PimAssociationProductAttribute>();
                if (attr == null) continue;

                var ids = withAssocRes.Associations.GetProductIds(attr.Name);

                if (property.PropertyType.IsArray)
                    property.SetValue(typeInstance, ids);
                
                if (property.PropertyType.GetInterface("IList") != null)
                    property.SetValue(typeInstance, ids.ToList());
            }
        }
        
        private static IEnumerable<PropertyInfo> GetTypeProperties<T>(T typeInstance, Type attributeType) where T : class
        {
            return typeInstance.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(prop => prop.IsDefined(attributeType, true))
                .ToList();
        }
        
        public static string GetDownloadLink(this IPimValueDictionary dictionary, string property, string locale = "en_AU")
            => dictionary.Values.GetDownloadLink(property, locale);
    }
}
