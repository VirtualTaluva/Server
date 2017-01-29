﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using VirtualTaluva.Protocol.DataTypes.Enums;
using VirtualTaluva.Server.DataTypes.Attributes;
using VirtualTaluva.Server.Logic.GameVariants;

namespace VirtualTaluva.Server.Logic
{
    public static class RuleFactory
    {
        private static Dictionary<GameSubTypeEnum, AbstractGameVariant> m_Variants;

        public static Dictionary<GameSubTypeEnum, AbstractGameVariant> Variants
        {
            get
            {
                if (m_Variants == null)
                {
                    m_Variants = new Dictionary<GameSubTypeEnum, AbstractGameVariant>();
                    foreach (Type t in typeof(AbstractGameVariant).Assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(AbstractGameVariant)) && !x.IsAbstract))
                    {
                        var att = t.GetCustomAttribute<GameVariantAttribute>();
                        if (att != null && !m_Variants.ContainsKey(att.Variant))
                            m_Variants.Add(att.Variant, (AbstractGameVariant)Activator.CreateInstance(t));
                    }
                }
                return m_Variants;
            }
        }
    }
}
