using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BugTracker.Cross_Cutting.Utilities
{
    public struct SQLCommandParameter
    {
        public string Name { get; private set; }
        public object Value { get; private set; }
        public SqlDbType Type { get; private set; }

        public SQLCommandParameter(string name, object value, SqlDbType type)
        {
            Name = name;
            Value = value;
            Type = type;
        }
    }

    public static class SQLCommandExtensions
    {
        public static void AddParameter(this SqlCommand command, SQLCommandParameter parameter)
        {
            command.Parameters.Add($"@{parameter.Name}", parameter.Type).Value = parameter.Value;
        }
    }
}