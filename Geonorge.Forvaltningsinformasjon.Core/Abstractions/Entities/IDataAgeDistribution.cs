﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Geonorge.Forvaltningsinformasjon.Core.Abstractions.Entities
{
    public interface IDataAgeDistribution : IEntityBase
    {
        string DataSetName { get; }
        Dictionary<AgeCategory, long> TransactionCounts { get; }
    }
}
