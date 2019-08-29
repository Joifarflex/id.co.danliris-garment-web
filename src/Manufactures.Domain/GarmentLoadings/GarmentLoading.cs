﻿using Infrastructure.Domain;
using Manufactures.Domain.Events;
using Manufactures.Domain.GarmentLoadings.ReadModels;
using Manufactures.Domain.Shared.ValueObjects;
using Moonlay;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manufactures.Domain.GarmentLoadings
{
    public class GarmentLoading : AggregateRoot<GarmentLoading, GarmentLoadingReadModel>
    {
        public string LoadingNo { get; internal set; }
        public Guid SewingDOId { get; internal set; }
        public string SewingDONo { get; internal set; }
        public UnitDepartmentId UnitFromId { get; internal set; }
        public string UnitFromCode { get; internal set; }
        public string UnitFromName { get; internal set; }
        public UnitDepartmentId UnitId { get; internal set; }
        public string UnitCode { get; internal set; }
        public string UnitName { get; internal set; }
        public string RONo { get; internal set; }
        public string Article { get; internal set; }
        public string Comodity { get; internal set; }
        public DateTimeOffset LoadingDate { get; internal set; }

        public GarmentLoading(Guid identity, string loadingNo, Guid sewingDOId, string sewingDONo, UnitDepartmentId unitFromId, string unitFromCode, string unitFromName, string rONo, string article, UnitDepartmentId unitId, string unitCode, string unitName, string comodity, DateTimeOffset loadingDate) : base(identity)
        {
            Validator.ThrowIfNull(() => unitId);
            Validator.ThrowIfNull(() => sewingDOId);

            //MarkTransient();
            LoadingNo = loadingNo;
            Identity = identity;
            SewingDOId = sewingDOId;
            SewingDONo = sewingDONo;
            UnitFromCode = unitFromCode;
            UnitFromName = unitFromName;
            UnitFromId = unitFromId;
            RONo = rONo;
            Article = article;
            UnitId = unitId;
            UnitCode = unitCode;
            UnitName = unitName;
            Comodity = comodity;
            LoadingDate = loadingDate;

            ReadModel = new GarmentLoadingReadModel(Identity)
            {
                LoadingDate = LoadingDate,
                LoadingNo = LoadingNo,
                RONo = RONo,
                Article = Article,
                UnitId = UnitId.Value,
                UnitCode = UnitCode,
                UnitName = UnitName,
                SewingDOId = SewingDOId,
                SewingDONo = SewingDONo,
                UnitFromCode = UnitFromCode,
                UnitFromName = UnitFromName,
                UnitFromId = UnitFromId.Value,
                Comodity=Comodity
            };

            ReadModel.AddDomainEvent(new OnGarmentLoadingPlaced(Identity));
        }

        public GarmentLoading(GarmentLoadingReadModel readModel) : base(readModel)
        {
            LoadingNo = readModel.LoadingNo;
            RONo = readModel.RONo;
            Article = readModel.Article;
            UnitId = new UnitDepartmentId(readModel.UnitId);
            UnitCode = readModel.UnitCode;
            UnitName = readModel.UnitName;
            SewingDOId = readModel.SewingDOId;
            SewingDONo = readModel.SewingDONo;
            UnitFromCode = readModel.UnitFromCode;
            UnitFromName = readModel.UnitFromName;
            UnitFromId = new UnitDepartmentId(readModel.UnitFromId);
        }

        public void Modify()
        {
            MarkModified();
        }

        protected override GarmentLoading GetEntity()
        {
            return this;
        }
    }
}
