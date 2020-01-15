﻿using Geonorge.Forvaltningsinformasjon.Core.Abstractions.Entities;
using Geonorge.Forvaltningsinformasjon.Web.Models.Common;
using Geonorge.Forvaltningsinformasjon.Web.Models.Common.Helpers;
using System.Collections.Generic;

namespace Geonorge.Forvaltningsinformasjon.Web.Models.FkbData.DataContent
{
    public class DataQualityClassificationViewModel
    {
        public List<IDataQualityClassification> Classifications { get; set; }
        public string AdministrativeUnitName { get; set; }
        public AdministrativeUnitType Type { get; set; }

        public MapViewModel MapViewModel { get; set; } = new MapViewModel();
    }
}
