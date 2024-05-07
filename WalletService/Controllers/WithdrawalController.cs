﻿using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WalletService.Logic;
using WalletService.Dtos;

namespace WalletService.Controllers;

//[Authorize]
[Route("api/[controller]")]
[ApiController]
public class WithdrawalController : ControllerBase
{
    private readonly IWithdrawalBusinessProcessor _logic;
    private readonly ILogger<WithdrawalController> _logger;

    public WithdrawalController(IWithdrawalBusinessProcessor logic, ILogger<WithdrawalController> logger)
    {
        _logic = logic;
        _logger = logger;
    }

    /// <summary>
    /// Gets the list of all Withdrawal.
    /// </summary>
    /// <returns>The list of Withdrawal.</returns>
    // GET: api/GetBankUPIDetails
    [HttpGet]
    public async Task<object> Get()
    {
        _logger.LogInformation("Fetching Withdrawal Data..");
        var experts = await _logic.Get();
        return Ok(experts);
    }

    /// <summary>
    /// Gets the list of all Banks & UPI.
    /// </summary>
    /// <returns>The list of UPI.</returns>
    // GET: api/GetBankUPIDetails
    [HttpGet("GetBankUPIDetails", Name = "GetBankUPIDetails")]
    public async Task<object> GetBankUPIDetails()
    {
        _logger.LogInformation("Fetching Bank/UPI Data..");
        var experts = await _logic.GetWithdrawalMode();
        return Ok(experts);
    }


    /// <summary>
    /// Get an Experts.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET : api/Experts/1
    /// </remarks>
    /// <param name="Id"></param>
    [HttpGet("{Id}")]
    public async Task<ActionResult<WithdrawalReadDto>> Get(Guid Id)
    {
        _logger.LogInformation("Fetching blogs details for Id : " + Id.ToString());
        var blogs = await _logic.Get(Id);
        return blogs != null ? (ActionResult<WithdrawalReadDto>)Ok(blogs) : NotFound();
    }

    /// <summary>
    /// Get Bank/UPI Details By ID.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET : api/GetBankUPIById/1
    /// </remarks>
    /// <param name="Id"></param>
    [HttpGet("GetBankUPIById/{Id}", Name = "GetBankUPIById")]
    public async Task<ActionResult<WithdrawalModeReadDto>> GetBankUPIById(Guid Id)
    {
        _logger.LogInformation("Fetching bank upi details for Id : " + Id.ToString());
        var blogs = await _logic.GetWithdrawalMode(Id);
        return blogs != null ? (ActionResult<WithdrawalModeReadDto>)Ok(blogs) : NotFound();
    }

    /// <summary>
    /// Create Withdrawal Request
    /// </summary>
    /// /// <remarks>
    /// Sample request:
    /// 
    /// POST : api/Post
    /// </remarks>
    /// <param name="bankUPIDto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<object> Post(WithdrawalCreateDto bankUPIDto)
    {
        var response = await _logic.Post(bankUPIDto);

        if (response.IsSuccess)
        {
            Guid guid = (Guid)response.Data.GetType().GetProperty("Id").GetValue(response.Data);

            return Ok(response);
        }
        return NotFound(response);
    }

    /// <summary>
    /// Create Data for Bank/UPI
    /// </summary>
    /// /// <remarks>
    /// Sample request:
    /// 
    /// POST : api/PostBankUPIDetails
    /// </remarks>
    /// <param name="bankUPIDto"></param>
    /// <returns></returns>
    [HttpPost("PostBankUPIDetails", Name = "PostBankUPIDetails")]
    public async Task<object> PostBankUPIDetails(WithdrawalModeCreateDto bankUPIDto)
    {
        var response = await _logic.PostWithdrawalMode(bankUPIDto);

        if (response.IsSuccess)
        {
            Guid guid = (Guid)response.Data.GetType().GetProperty("Id").GetValue(response.Data);

            return Ok(response);
        }
        return NotFound(response);
    }

    [HttpPut("{Id:guid}")]
    public async Task<object> Put(Guid Id, WithdrawalCreateDto withdrawalDto)
    {
        var response = await _logic.Put(Id, withdrawalDto);

        if (response.IsSuccess)
        {
            Guid guid = (Guid)response.Data.GetType().GetProperty("Id").GetValue(response.Data);

            return Ok(response);
        }
        return NotFound(response);
    }

    [HttpPut("PutBankUPIDetails/{Id}", Name = "PutBankUPIDetails")]
    public async Task<object> PutBankUPIDetails(Guid Id, WithdrawalModeCreateDto withdrawalModeCreateDto)
    {
        var response = await _logic.PutBankUPIDetails(Id, withdrawalModeCreateDto);

        if (response.IsSuccess)
        {
            Guid guid = (Guid)response.Data.GetType().GetProperty("Id").GetValue(response.Data);

            return Ok(response);
        }
        return NotFound(response);
    }
}
 