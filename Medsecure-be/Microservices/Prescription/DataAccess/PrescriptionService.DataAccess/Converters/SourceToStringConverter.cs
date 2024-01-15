
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using PrescriptionService.DataAccess.PrescriptionService.DataAccess.Enums;

namespace PrescriptionService.DataAccess.PrescriptionService.DataAccess.Converters;

public class SourceToStringConverter : ValueConverter<SourceEnum, string>
{
    public SourceToStringConverter()
        : base(v => ToString(v), v => ToSource(v))
    {
    }

    private static string ToString(SourceEnum value)
        => value.ToString().ToUpper();

    private static SourceEnum ToSource(string value)
        => Enum.Parse<SourceEnum>(value, true);
}