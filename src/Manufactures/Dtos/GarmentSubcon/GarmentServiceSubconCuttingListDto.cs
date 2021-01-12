﻿using Manufactures.Domain.GarmentSubcon.ServiceSubconCuttings;
using Manufactures.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manufactures.Dtos.GarmentSubcon
{
    public class GarmentServiceSubconCuttingListDto : BaseDto
    {
        public GarmentServiceSubconCuttingListDto(GarmentServiceSubconCutting garmentServiceSubconCutting)
        {
            Id = garmentServiceSubconCutting.Identity;
            SubconNo = garmentServiceSubconCutting.SubconNo;
            SubconType = garmentServiceSubconCutting.SubconType;
            SubconDate = garmentServiceSubconCutting.SubconDate;
            RONo = garmentServiceSubconCutting.RONo;
            Article = garmentServiceSubconCutting.Article;
            Unit = new UnitDepartment(garmentServiceSubconCutting.UnitId.Value, garmentServiceSubconCutting.UnitCode, garmentServiceSubconCutting.UnitName);
            Comodity = new GarmentComodity(garmentServiceSubconCutting.ComodityId.Value, garmentServiceSubconCutting.ComodityCode, garmentServiceSubconCutting.ComodityName);
            CreatedBy = garmentServiceSubconCutting.AuditTrail.CreatedBy;
            IsUsed = garmentServiceSubconCutting.IsUsed;
            Items = new List<GarmentServiceSubconCuttingItemDto>();
        }

        public Guid Id { get; set; }
        public string SubconNo { get; set; }
        public string SubconType { get; set; }

        public DateTimeOffset SubconDate { get; set; }
        public string RONo { get; set; }
        public string Article { get; set; }
        public UnitDepartment Unit { get; set; }
        public GarmentComodity Comodity { get; set; }

        public double TotalQuantity { get; set; }
        public bool IsUsed { get; set; }
        public List<string> Products { get; set; }
        public List<GarmentServiceSubconCuttingItemDto> Items { get; set; }
    }
}