using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace Nzh.Super.Common
{
    public class EnumExt
    {
        public static string GetEnumCustomDescription(object e)
        {
            //获取枚举的Type类型对象
            Type t = e.GetType();
            //获取枚举的所有字段
            FieldInfo[] ms = t.GetFields();
            //遍历所有枚举的所有字段
            foreach (FieldInfo f in ms)
            {
                if (f.Name != e.ToString())
                {
                    continue;
                }
                //第二个参数true表示查找EnumDisplayNameAttribute的继承链
                if (f.IsDefined(typeof(DisplayAttribute), true))
                {
                    return
                        (f.GetCustomAttributes(typeof(DisplayAttribute), true)[0] as DisplayAttribute)
                            .Name;
                }
            }
            //如果没有找到自定义属性，直接返回属性项的名称
            return e.ToString();
        }

        public static List<SelectListItem> GetSelectList(Type enumType)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            foreach (object e in Enum.GetValues(enumType))
            {
                selectList.Add(new SelectListItem() { Text = GetEnumCustomDescription(e), Value = ((int)e).ToString() });
            }
            return selectList;
        }
    }
}
