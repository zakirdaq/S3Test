namespace ChartApi.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChartValue")]
    public partial class ChartValue
    {
        public int Id { get; set; }

        public TimeSpan Time { get; set; }

        public double? Value { get; set; }
    }
}
