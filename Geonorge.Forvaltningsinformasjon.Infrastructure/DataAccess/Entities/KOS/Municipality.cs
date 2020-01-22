﻿using Geonorge.Forvaltningsinformasjon.Core.Abstractions.Entities;
using Geonorge.Forvaltningsinformasjon.Core.Abstractions.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Geonorge.Forvaltningsinformasjon.Infrastructure.DataAccess.Entities.Kos
{
    internal class Municipality : IMunicipality
    {
        private int _id = 0;

        #region IMunicipality
        public int Id
        {
            get
            {
                return _id == 0 ? _id = int.Parse(Number) : _id;
            }
        }
        public string Number { get; set; }
        public string Name { get; set; }
        public DateTime? PlannedIntroductionDate
        {
            get
            {
                if (CentralFkb.First().PlannedIntroduction == null)
                {
                    return null;
                }
                return DateTime.ParseExact(
                    CentralFkb.First().PlannedIntroduction,
                    "yyyyMMdd",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None);          
            }
        }
        public DateTime? IntroductionDate
        {
            get
            {
                if (CentralFkb.First().DirectUpdateInroduced == null)
                {
                    return null;
                }
                return DateTime.ParseExact(
                    CentralFkb.First().DirectUpdateInroduced,
                    "yyyyMMdd",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None);
            }
        }

        public IntroductionState IntroductionState
        {
            get
            {
                if (IntroductionDate.HasValue)
                {
                    return IntroductionState.Introduced;
                }
                else if (PlannedIntroductionDate.HasValue)
                {
                    return IntroductionState.Planned;
                }
                return IntroductionState.NotIntroduced;
            }
        }
        #endregion

        public string CountyId { get; set; }
        public County County { get; set; }
        public short? CoordSys { get; set; }
        public string VerticalDatum { get; set; }
        public int? BBoxSouthVestN { get; set; }
        public int? BBoxSouthVestNE { get; set; }
        public int? BBoxNorthEastN { get; set; }
        public int? BBoxNorthEastE { get; set; }
        public int? Active { get; set; }
        public ICollection<Project> Project { get; set; }
        public ICollection<CentralFkb> CentralFkb { get; set; }

        public Municipality()
        {
            Project = new HashSet<Project>();
            CentralFkb = new HashSet<CentralFkb>();
        }
    }
}