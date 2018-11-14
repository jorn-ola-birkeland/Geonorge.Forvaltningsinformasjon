﻿using Geonorge.Forvaltningsinformasjon.Core.Abstractions.FkbData.Management.Area;
using Geonorge.Forvaltningsinformasjon.Core.Entities.FkbData.Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Geonorge.Forvaltningsinformasjon.Web.Models.FkbData.Management.Area
{
    public class MunicipalitiesViewModel
    {
        public List<IMunicipality> Municipalities { get; set; }
        public int DirectUpdateCount { get; set; }
        public string CountyName { get; set; }

        public string GetIntroductionStateText(IntroductionState introductionState)
        {
            switch (introductionState)
            {
                case IntroductionState.NotPlanned:
                    return "Ikke planlagt";
                case IntroductionState.Planned:
                    return "Direkteoppdatering planlagt innført {0}";
                case IntroductionState.Introduced:
                    return "Direkteoppdatering innført";
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
    }
}
