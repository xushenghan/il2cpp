﻿using System.Linq;

namespace il2cpp
{
	internal static class RuntimeInternals
	{
		public static bool GenInternalMethod(MethodX metX, CodePrinter prt, GeneratorContext genContext)
		{
			string typeName = metX.DeclType.GetNameKey();
			string metName = metX.Def.Name;

			if (typeName == "String")
			{
				if (metName == "get_Length")
				{
					FieldX fldLen = metX.DeclType.Fields.FirstOrDefault(
						fld => fld.FieldType.ElementType == dnlib.DotNet.ElementType.I4);
					prt.AppendFormatLine(@"return arg_0->{0};",
						genContext.GetFieldName(fldLen));

					return true;
				}
				else if (metName == "get_Chars")
				{
					FieldX fldLen = metX.DeclType.Fields.FirstOrDefault(
						fld => fld.FieldType.ElementType == dnlib.DotNet.ElementType.I4);
					FieldX fldFirstChar = metX.DeclType.Fields.FirstOrDefault(
						fld => fld.FieldType.ElementType == dnlib.DotNet.ElementType.Char);
					prt.AppendFormatLine("IL2CPP_CHECK_RANGE(0, arg_0->{0}, arg_1);",
						genContext.GetFieldName(fldLen));
					prt.AppendFormatLine("return ((uint16_t*)&arg_0->{0})[arg_1];",
						genContext.GetFieldName(fldFirstChar));

					return true;
				}
			}
			/*
			else if (typeName == "System.ValueType")
			{
				if (metName == "GetHashCode")
				{
					prt.AppendLine("return (int32_t)0x14AE055C;");
					return true;
				}
			}*/
			return false;
		}
	}
}
