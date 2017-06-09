using Heren.Common.Libraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace EMRDBLib
{
    public class Reflect
    {
        /// <summary>
        /// C#反射对象属性
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="model">对象</param>
        public static PropertyInfo[] GetProperties<T>(T model)
        {
            Type t = model.GetType();
            PropertyInfo[] PropertyList = t.GetProperties();
            //foreach (PropertyInfo item in PropertyList)
            //{
            //    string name = item.Name;
            //    object value = item.GetValue(model, null);
            //}
            return PropertyList;
        }
        /// <summary>
        /// 获取指定类型名称对应的类型
        /// </summary>
        /// <param name="baseType">类型名称</param>
        /// <param name="typeName">类型名称</param>
        /// <returns>类型对象</returns>
        public static Type GetType(Type baseType, string typeName)
        {
            if (baseType == null || string.IsNullOrEmpty(typeName))
                return null;
            try
            {
                return baseType.Assembly.GetType(typeName);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("GlobalMethods.GetType", ex);
                return null;
            }
        }

        /// <summary>
        /// 创建指定类型元素对象的实例
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="args">构造参数</param>
        /// <returns>对象实例</returns>
        public static object CreateInstance(Type type, params object[] args)
        {
            if (type == null)
                return null;
            try
            {
                return Activator.CreateInstance(type, args);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("GlobalMethods.CreateInstance", ex);
                return null;
            }
        }

        /// <summary>
        /// 从指定类型中获取指定名称的属性信息
        /// </summary>
        /// <param name="type">指定类型</param>
        /// <param name="szPropertyName">指定的属性名称</param>
        /// <returns>PropertyInfo</returns>
        public static PropertyInfo GetPropertyInfo(Type type, string propertyName)
        {
            if (type == null || GlobalMethods.Misc.IsEmptyString(propertyName))
                return null;
            try
            {
                return type.GetProperty(propertyName);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("StructBinder.GetPropertyInfo", ex);
                return null;
            }
        }

        /// <summary>
        /// 获取指定对象的指定属性的属性值
        /// </summary>
        /// <param name="instance">指定对象</param>
        /// <param name="property">指定属性</param>
        /// <returns>属性值</returns>
        public static object GetPropertyValue(object instance, PropertyInfo property)
        {
            if (property == null || instance == null || !property.CanRead)
                return null;
            try
            {
                return property.GetValue(instance, null);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("GlobalMethods.GetPropertyValue", ex);
                return null;
            }
        }

        /// <summary>
        /// 从指定对象中获取的指定属性的值
        /// </summary>
        /// <param name="instance">属性名称列表</param>
        /// <param name="property">返回的属性值</param>
        /// <param name="value">返回的属性值</param>
        /// <returns>bool</returns>
        public static bool GetPropertyValue(object instance, string property, ref object value)
        {
            string[] propertyNameArray = property.Split('.');
            if (propertyNameArray == null)
                return false;
            object target = instance;
            PropertyInfo propertyInfo = null;
            for (int index = 0; index < propertyNameArray.Length; index++)
            {
                string propertyName = propertyNameArray[index];
                if (target == null || string.IsNullOrEmpty(propertyName))
                    continue;
                propertyInfo = GetPropertyInfo(target.GetType(), propertyName);
                if (propertyInfo != null)
                    target = GetPropertyValue(target, propertyInfo);
            }
            if (target != instance) value = target;
            return true;
        }

        /// <summary>
        /// 设置指定对象的指定属性的属性值
        /// </summary>
        /// <param name="instance">指定对象</param>
        /// <param name="property">指定属性</param>
        /// <param name="value">属性值</param>
        /// <returns>是否成功</returns>
        public static bool SetPropertyValue(object instance, PropertyInfo property, object value)
        {
            if (property == null || instance == null || !property.CanWrite)
                return false;

            try
            {
                if (value == null || value.GetType() == property.PropertyType)
                {
                    property.SetValue(instance, value, null);
                    return true;
                }

                TypeConverter converter = TypeDescriptor.GetConverter(property.PropertyType);
                if (converter.CanConvertFrom(value.GetType()))
                {
                    value = converter.ConvertFrom(null, CultureInfo.InvariantCulture, value);
                }
                property.SetValue(instance, value, null);
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// 拷贝同类型的两个对象的属性
        /// </summary>
        /// <param name="source">源对象</param>
        /// <param name="target">目标对象</param>
        /// <returns>是否成功</returns>
        public static bool CopyProperties(object source, object target)
        {
            if (source == null || target == null || source.GetType() != target.GetType())
                return false;
            PropertyInfo[] elementProperties = source.GetType().GetProperties();
            foreach (PropertyInfo property in elementProperties)
            {
                MethodInfo method = property.GetSetMethod();
                if (method == null || !method.IsPublic)
                    continue;
                if (!property.CanRead || !property.CanWrite)
                    continue;

                Type propertyType = property.PropertyType;
                object propertyValue = GetPropertyValue(source, property);
                ICloneable cloneValue = propertyValue as ICloneable;
                if (cloneValue != null)
                {
                    SetPropertyValue(target, property, cloneValue.Clone());
                    continue;
                }

                //支持IList或IDictionary接口来迭代集合
                IDictionary dictionary = propertyValue as IDictionary;
                if (dictionary != null)
                {
                    IDictionary instance = null;
                    if (!property.CanWrite)
                        instance = GetPropertyValue(target, property) as IDictionary;
                    else
                        instance = CreateInstance(propertyType, null) as IDictionary;
                    if (instance == null)
                        continue;
                    foreach (DictionaryEntry entry in dictionary)
                    {
                        ICloneable clone = entry.Key as ICloneable;
                        object key = (clone == null) ? entry.Key : clone.Clone();
                        if (key == null)
                            continue;
                        object value = null;
                        if (entry.Value != null)
                        {
                            clone = entry.Value as ICloneable;
                            value = (clone == null) ? entry.Value : clone.Clone();
                        }
                        instance.Add(key, value);
                    }
                    Reflect.SetPropertyValue(target, property, instance);
                    continue;
                }

                //支持IList或IDictionary接口来迭代集合
                IList list = propertyValue as IList;
                if (list != null)
                {
                    IList instance = null;
                    if (!property.CanWrite)
                        instance = GetPropertyValue(target, property) as IList;
                    else
                        instance = CreateInstance(propertyType, null) as IList;
                    if (instance == null)
                        continue;
                    foreach (object item in list)
                    {
                        ICloneable clone = item as ICloneable;
                        if (clone == null)
                            instance.Add(item);
                        else
                            instance.Add(clone.Clone());
                    }
                    Reflect.SetPropertyValue(target, property, instance);
                    continue;
                }
               Reflect.SetPropertyValue(target, property, propertyValue);
            }
            return true;
        }
    }
}
