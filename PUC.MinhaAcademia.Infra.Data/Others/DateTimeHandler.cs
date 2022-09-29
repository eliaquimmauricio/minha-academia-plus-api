using Dapper;
using System;
using System.Data;
using System.Globalization;

namespace Tasken.SRC.Infra.Data.Others
{
    public class DateTimeHandler : SqlMapper.TypeHandler<DateTime>
    {
        public override void SetValue(IDbDataParameter parameter, DateTime value)
        {
            parameter.Value = value;
        }

        public override DateTime Parse(object value)
        {
            try
            {
                return DateTime.Parse(value?.ToString(), CultureInfo.GetCultureInfo("pt-BR"));
            }
            catch (Exception)
            {
                try
                {
                    return DateTime.Parse(value?.ToString(), CultureInfo.GetCultureInfo("en-US"));
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
