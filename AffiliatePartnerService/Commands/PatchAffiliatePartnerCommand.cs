﻿using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using ExpertService.Dtos;
using MigrationDB.Models;
using AffiliatePartnerService.Dtos;
using MigrationDB.Model;


namespace AffiliatePartnerService.Commands;

public record PatchAffiliatePartnerCommand(Guid Id, JsonPatchDocument<AffiliatePartnerCreateDTO> JsonPatchDocument, AffiliatePartner AffiliatePartner) : IRequest<AffiliatePartner>;
