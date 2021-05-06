using AutoMapper;
using System;

namespace Surzor.Application.Profiles.CustomConverters
{
    public class EmptyStringToGuid : ITypeConverter<string, Guid?>
    {
        public Guid? Convert(string source, Guid? destination, ResolutionContext context) =>
            string.IsNullOrEmpty(source) ? null : Guid.Parse(source);
    }
}
